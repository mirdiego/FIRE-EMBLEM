using Fire_Emblem_View;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Neutralizer;
using Fire_Emblem.Outputs;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem
{
    public abstract class Skill
    {
        protected AffectedUnit UnidadesAfectadas;
        public string Name { get; private set; }
        protected Unit Owner { get; private set; }
        public List<string> _ValidAttackType; 
        public MultiEffect _effects;          
        public bool activo;                  
        private List<Condition> _conditions;
        protected List<Condition> _optionalConditions;


        public Skill(string name)
        {
            Name = name;
            _effects = new MultiEffect();
            _ValidAttackType = new List<string>();
            _conditions = new List<Condition>();
            _optionalConditions = new List<Condition>(); 
            
        }

        public void SetOwner(Unit owner, View view)
        {
            Owner = owner;
            AgregarCondiciones(view);
            
        }
        protected AttackType attackType;

        public abstract void AgregarCondiciones(View view);

        public void CalculateBonus(View view)
        {
            _effects.CalculateBonuses(Owner, view);
            
        }
        
        public void Activate()
        {
            activo = true;
        }
        public void Deactivate()
        {
            activo = false;
        }
        public void AddCondition(Condition condition)
        {
            _conditions.Add(condition);
        }
        public void AddOptionalCondition(Condition condition)
        {
            _optionalConditions.Add(condition);
        }
        public bool VerificarCondiciones(View view)
        { 
            foreach (var condition in _conditions)
            {
                if (!condition.Cumple(Owner, view))
                {
                    return false; 
                }
            }
            if (_optionalConditions.Count > 0)
            {
                bool algunaCondicionOpcionalCumplida = false;
                foreach (var condition in _optionalConditions)
                {
                    if (condition.Cumple(Owner, view))
                    {
                        algunaCondicionOpcionalCumplida = true;
                        break; 
                    }
                }
                if (!algunaCondicionOpcionalCumplida)
                {
                    return false; 
                }
            }
            return true;
        }

        public void VerificarYActivar(View view)
        {
            
            if (VerificarCondiciones(view))
            {
                Activate();
            }
            else
            {
                Deactivate();
            }
        }
        public void Apply(View view, string currentAttackType, Output output)
        {

            ApplyBonusYPenaltysSegunDestino(view, currentAttackType, output);
            if (Owner.CurrentCombat.Attackposition == 0)
            {
                GenerateSkillMessages(output, view);
                output.Skills.SaveMessages(view);
            }
            ApplyNeutralizerSegunDestino(view, currentAttackType, output);
            
        }

        public void ApplyBonusYPenaltysSegunDestino(View view, string currentAttackType, Output output)
        {
            if (!_ValidAttackType.Contains(currentAttackType))
            {
                return;
            }

            if (activo)
            {

                    _effects.Apply(Owner, view, output, this);
                
           
            }
            
        }
        public void ApplyNeutralizerSegunDestino(View view, string currentAttackType, Output output)
        {
            if (!_ValidAttackType.Contains(currentAttackType))
            {
                return;
            }
            if (activo)
            {
                _effects.ApplyNeutralizator(Owner, view, output, this);
            }
        }

        public bool MensajeGenerado = false;
        public abstract void CumpleCondiciones(Unit owner, View view);


        public void GenerateSkillMessages(Output output, View view)
        {
                if (!activo) return;
                foreach (var effect in _effects.GetEffects()) // Obtener todos los efectos
                {

                    if (effect is BonusClassEffects bonusEffect)
                    {
                        StatType stat = bonusEffect.GetStatType();
                        int value = bonusEffect.GetBonusValue();
                        var units = GetUnitsToApplyEffect(UnidadesAfectadas, "bonus");

                        foreach (var unit in units)
                        {
                            if (attackType == AttackType.First)
                            {
                                output.Skills.BonusFirstAttack(stat, value, unit.Name, unit.IsStarter);
                            }
                            else if (attackType == AttackType.FollowUp)
                            {
                                output.Skills.BonusFollowUp(stat, value, unit.Name, unit.IsStarter);
                            }
                            else if (attackType == AttackType.All || attackType == AttackType.Start)
                            {
                                output.Skills.BonusFullCombat(stat, value, unit.Name, unit.IsStarter);
                            }

                        }
                    }
                    else if (effect is PenaltyClassEffects penaltyEffect)
                    {
                        StatType stat = penaltyEffect.GetStatType();
                        int value = penaltyEffect.GetPenaltyValue();
                        var units = GetUnitsToApplyEffect(UnidadesAfectadas, "penalty");

                        foreach (var unit in units)
                        {
                            if (attackType == AttackType.First)
                            {
                                output.Skills.PenaltyFirstAttack(stat, value, unit.Opponent.Name, unit.IsStarter);
                            }
                            else if (attackType == AttackType.FollowUp)
                            {
                                output.Skills.PenaltyFollowUp(stat, value, unit.Opponent.Name, unit.IsStarter);
                            }
                            else if (attackType == AttackType.All || attackType == AttackType.Start)
                            {
                                output.Skills.PenaltyFullCombat(stat, value, unit.Opponent.Name, unit.IsStarter);
                            }

                        }
                    }
                }

        }
        public void GenerateNeutralizationMessages(Output output)
        {
            if (!activo)
            {
                return;
            }
            foreach (var effect in _effects.GetEffects())
            {
                if (effect is BonusNeutralizer bonus_neutralizer )
                {
                    var stats = bonus_neutralizer.GetNeutralizedStats();
                    
                    output.AddNeutralizationBonus(Owner.Opponent.Name, Owner.IsStarter);
                }
                else if (effect is PenaltyNeutralizer penalty_neutralizer)
                {
                    var stats = penalty_neutralizer.GetNeutralizedStats();
                    output.AddNeutralizationPenalty(Owner.Name, Owner.Opponent.IsStarter);
                }
                if (effect is BonusStatNeutralizer bonus_stat_neutralizer)
                {
                    StatType stat = bonus_stat_neutralizer.GetNeutralizedStat();

                    output.AddEspecificNeutralizationBonus(Owner.Opponent.Name, Owner.IsStarter, stat);
                }
            }
        }
        private List<Unit> GetUnitsToApplyEffect(AffectedUnit unidades, string effect)
        {
            var units = new List<Unit>();

            switch (unidades)
            {
                case AffectedUnit.Both:
                    units.Add(Owner);
                    units.Add(Owner.Opponent);
                    break;
                case AffectedUnit.Owner:
                    if (effect == "penalty")
                    {
                        units.Add(Owner.Opponent);
                    }
                    else
                    {
                        units.Add(Owner);

                    }
                    break;
                case AffectedUnit.Opponent:
                    if (effect == "penalty")
                    {
                        units.Add(Owner);
                    }
                    else
                    {
                        units.Add(Owner.Opponent);

                    }
                    break;
            }

            return units;
        }

        public AffectedUnit GetUnidadesAfectadas()
        {
            return UnidadesAfectadas;
        }
    }
}