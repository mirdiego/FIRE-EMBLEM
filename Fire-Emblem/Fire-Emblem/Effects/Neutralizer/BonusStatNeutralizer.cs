namespace Fire_Emblem.Effects.Neutralizer;
using Fire_Emblem_View;


public class BonusStatNeutralizer : GenericBonusNeutralizer
{
    private StatType _stat;
    public BonusStatNeutralizer(StatType stat)
    {
        _stat = stat;
    }
    public StatType GetStat()
    {
        return _stat;
    }
    
    public override void ApplyEffects(Unit unit, View view)
    {
        AddNeutralizedStat(_stat);
        foreach (Skill skill in unit.Opponent.Skills)
        {
            if (skill.activo & skill._ValidAttackType.Contains(unit.CurrentCombat.Attacktype[unit.CurrentCombat.Attackposition]))
            {
                foreach(Effect effect in skill._effects.GetEffects())
                {
                    effect.NeutralizeOwnerBonus(skill, this, unit);
                }
            }
        }
        foreach (Skill skill in unit.Skills)
        {
            if (skill.activo & skill._ValidAttackType.Contains(unit.CurrentCombat.Attacktype[unit.CurrentCombat.Attackposition]))
            {
                foreach(Effect effect in skill._effects.GetEffects())
                {
                    effect.NeutralizeOpponentBonus(skill, this, unit);
                }
            }
        }
    }
    public StatType GetNeutralizedStat()
    {
        return _stat;
    }
}