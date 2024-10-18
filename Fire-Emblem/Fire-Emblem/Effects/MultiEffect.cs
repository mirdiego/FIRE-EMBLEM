using Fire_Emblem_View;
using Fire_Emblem.Effects.Neutralizer;
using Fire_Emblem.Outputs;
using FireEmblem.Effects;

namespace Fire_Emblem.Effects;

public class MultiEffect : Effect
{
    private readonly Effect[] _effects;

    public MultiEffect(params Effect[] effects)
        => _effects = effects;

    public override void Apply(Unit unit, View view, Output output, Skill skill)
    {
        if (!skill._ValidAttackType.Contains(unit.CurrentCombat.Attacktype[unit.CurrentCombat.Attackposition]))
        {
            return;
        }
        ApplyBonusAndPenalty(unit, view, output, skill);



    }
    

    public void ApplyBonusAndPenalty(Unit unit, View view, Output output, Skill skill)
    {
        foreach (Effect effect in _effects)
        {
            if (effect is BonusClassEffects || effect is PenaltyClassEffects)
            {
                effect.Apply(unit, view, output, skill);
            }
        }
    }
    public void ApplyNeutralizator(Unit dueno, View view, Output output, Skill skill)
    {
        foreach (Effect effect in _effects)
        {
            if (effect is BonusNeutralizer)
            {
                effect.Apply(dueno, view, output, skill);
            }
            else if (effect is PenaltyNeutralizer)
            {
                effect.Apply(dueno, view, output, skill);
            }
            else if (effect is  BonusStatNeutralizer BonusStat)
            {
                BonusStat.Apply(dueno, view, output, skill);
            }

        }
        if (dueno.CurrentCombat.Attackposition == 0)
        {
            skill.GenerateNeutralizationMessages(output);
        }
    }
    public Effect[] GetEffects()
    {
        return _effects;
    }

    public void CalculateBonuses(Unit owner, View view)
    {
        // para cada efecto en los efectos 
        foreach (Effect effect in _effects)
        {
            if (effect is  BonusValueCalculate bonuspercentageeffect)
            {
                bonuspercentageeffect.CalculateBonus(owner);
            }
            else  if (effect is  PenaltyValueCalculate penaltypercentageeffect)
            {
                penaltypercentageeffect.CalculatePenalty(owner);
            }
        }
    }
}