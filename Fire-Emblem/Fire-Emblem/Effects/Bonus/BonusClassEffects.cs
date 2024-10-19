using Fire_Emblem_View;

namespace Fire_Emblem.Effects;

public abstract class BonusClassEffects : Effect
{
    protected  StatType _targetStat;
    protected int _bonus;

    public override void NeutralizeOwnerBonus(Skill skill, Neutralizer.BonusStatNeutralizer neutralizer, Unit unit)
    {
        {
            if (skill.GetUnidadesAfectadas() == AffectedUnit.Owner || skill.GetUnidadesAfectadas() == AffectedUnit.Both)
            {
                if (neutralizer.GetStat() == GetStatType())
                {
                    neutralizer.ApplyBonusNeutralizer(unit, this, neutralizer.GetStat());
                }
            }
        }
    }
    public override void NeutralizeOpponentBonus(Skill skill, Neutralizer.BonusStatNeutralizer neutralizer, Unit unit)
    {
        {
            {
                if (skill.GetUnidadesAfectadas() == AffectedUnit.Opponent || skill.GetUnidadesAfectadas() == AffectedUnit.Both)
                {
                    if (neutralizer.GetStat() == GetStatType())
                    {
                        neutralizer.ApplyBonusNeutralizer(unit, this,  neutralizer.GetStat());
                    }
                }
            }
        }
    }
    public override void NeutralizeAllOwnerBonus(Skill skill, Neutralizer.BonusNeutralizer neutralizer, Unit unit)
    {
        {
            if (skill.GetUnidadesAfectadas() == AffectedUnit.Owner || skill.GetUnidadesAfectadas() == AffectedUnit.Both)
            {
                StatType stat = GetStatType();
                neutralizer.ApplyBonusNeutralizer(unit, this, stat);
                neutralizer.AddNeutralizedStat(stat);
            }
        }
    }
    public override void NeutralizeAllOpponentBonus(Skill skill, Neutralizer.BonusNeutralizer neutralizer, Unit unit)
    {
        {
            if (skill.GetUnidadesAfectadas() == AffectedUnit.Opponent || skill.GetUnidadesAfectadas() == AffectedUnit.Both)
            {
                StatType stat = GetStatType();
                neutralizer.ApplyBonusNeutralizer(unit, this, stat);
                neutralizer.AddNeutralizedStat(stat);
            }
        }
    }

    public StatType GetStatType()
    {
        return _targetStat;
    }

    public int GetBonusValue()
    {
        return _bonus;
    }

    public void ApplyEffects(Unit unit, int _bonus, View view)
    {
        if (_targetStat == StatType.Atk)
            unit.IncreaseAttack(_bonus);
        else if (_targetStat == StatType.Def)
            unit.IncreaseDefense(_bonus);
        else if (_targetStat == StatType.Res)
            unit.IncreaseResistance(_bonus);
        else if (_targetStat == StatType.Spd)
            unit.IncreaseSpeed(_bonus);
        else if (_targetStat == StatType.MaxHP)
            unit.IncreaseMaxHP(_bonus);
        else
            throw new ApplicationException();
        
    }
}
