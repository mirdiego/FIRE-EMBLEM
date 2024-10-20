using Fire_Emblem_View;
using Fire_Emblem.Effects;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class SoulBlade : Skill
{


    public SoulBlade()
        : base("Soulblade")

    {
        attackType = AttackType.All;
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(attackType);
        UnidadesAfectadas = AffectedUnit.Opponent;
    }
    
    public override void AgregarCondiciones(View view)
    {
        // Agregar la condición IniciaCombate
        AddCondition(new UsaArma(Owner, "Sword"));
    }
    
    public override void CumpleCondiciones(Unit owner, View view)
    {
        CalculateBonusOrPenalty(view);

        VerificarYActivar(view); // Verifica las condiciones y activa si es necesario
    }
    private void CalculateBonusOrPenalty(View view)
    {
        
        int promedioDefYRes = (int)Math.Truncate((double)(Owner.Opponent.BaseDefense + Owner.Opponent.BaseResistance) / 2);
        int DiferenciaPromedioConDef = promedioDefYRes - Owner.Opponent.BaseDefense;
        int DiferenciaPromedioConRes = promedioDefYRes - Owner.Opponent.BaseResistance;

        if (DiferenciaPromedioConDef >= 0 && DiferenciaPromedioConRes <= 0)
        {
            _effects = new MultiEffect(
                new BonusOnOpponentEffect(StatType.Def, DiferenciaPromedioConDef), 
                new PenaltyEffect(StatType.Res, (-1 * DiferenciaPromedioConRes))
                
            );
        }
        else if (DiferenciaPromedioConDef <= 0 && DiferenciaPromedioConRes >= 0)
        {
            _effects = new MultiEffect(
                new PenaltyEffect(StatType.Def, (-1 * DiferenciaPromedioConDef)),
                new BonusOnOpponentEffect(StatType.Res, DiferenciaPromedioConRes)
            );
        }

        
    }
}