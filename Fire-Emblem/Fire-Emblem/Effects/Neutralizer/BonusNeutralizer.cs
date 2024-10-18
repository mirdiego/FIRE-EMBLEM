namespace Fire_Emblem.Effects.Neutralizer;
using Fire_Emblem_View;


public class BonusNeutralizer : GenericBonusNeutralizer
{
    public override void ApplyEffects(Unit unit, View view)
    {
        foreach (Skill skill in unit.Opponent.Skills)
        {
            
            if (skill.activo & skill._ValidAttackType.Contains(unit.CurrentCombat.Attacktype[unit.CurrentCombat.Attackposition]))
            {
                foreach(Effect effect in skill._effects.GetEffects())
                {
                    effect.NeutralizeAllOwnerBonus(skill, this, unit);
                }
            }
        }
        foreach (Skill skill in unit.Skills)
        {
            if (skill.activo & skill._ValidAttackType.Contains(unit.CurrentCombat.Attacktype[unit.CurrentCombat.Attackposition]))
            {
                foreach(Effect effect in skill._effects.GetEffects())
                {
                    effect.NeutralizeAllOpponentBonus(skill, this, unit);

                }
            }
        }
    }
}