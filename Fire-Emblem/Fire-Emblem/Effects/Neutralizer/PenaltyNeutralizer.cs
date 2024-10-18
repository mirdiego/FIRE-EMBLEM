namespace Fire_Emblem.Effects.Neutralizer;
using Fire_Emblem_View;


public class PenaltyNeutralizer : Neutralizer
{
    public override void ApplyEffects(Unit dueno, View view)
    {

        foreach (Skill skill in dueno.Opponent.Skills)
        {
            
            if (skill.activo & skill._ValidAttackType.Contains(dueno.CurrentCombat.Attacktype[dueno.CurrentCombat.Attackposition]))
            {
                foreach(Effect effect in skill._effects.GetEffects())
                {
                    effect.NeutralizeOwnerPenalty(skill, this, dueno);
                }
            }
        }
        foreach (Skill skill in dueno.Skills)
        {
            if (skill.activo & skill._ValidAttackType.Contains(dueno.CurrentCombat.Attacktype[dueno.CurrentCombat.Attackposition]))
            {
                foreach(Effect effect in skill._effects.GetEffects())
                {
                    effect.NeutralizeOpponentPenalty(skill, this, dueno);
                }
            }
        }
    }
    public void ApplyPenaltyNeutralizer(Unit unit, PenaltyClassEffects penalty)
    {
        int valor = penalty.GetPenaltyValue();
        if (valor != 0)
        {
            StatType stat = penalty.GetStatType();
            unit.IncreaseStat(stat, valor);
            AddNeutralizedStat(stat);
        }
    }
}