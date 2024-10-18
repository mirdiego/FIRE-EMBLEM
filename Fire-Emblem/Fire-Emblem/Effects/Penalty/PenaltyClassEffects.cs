using Fire_Emblem_View;
using Fire_Emblem.Effects.Neutralizer;

namespace Fire_Emblem.Effects;

public abstract class PenaltyClassEffects : Effect
{
    protected  StatType _targetStat;
    protected int _penalty;
    
    public StatType GetStatType()
    {
        return _targetStat;
    }

    public int GetPenaltyValue()
    {
        return _penalty;
    }

    public void ApplyEffects(Unit unit, int _penalty, View view)
    {
        unit.DecreaseStat(_targetStat, _penalty);
    }
    public override void NeutralizeOwnerPenalty(Skill skill, PenaltyNeutralizer neutralizer, Unit unit)
    {
        if (skill.GetUnidadesBonificadas() == "oponente" || skill.GetUnidadesBonificadas() == "ambas")
        {
            neutralizer.ApplyPenaltyNeutralizer(unit, this);
          
        }
    }
    public override void NeutralizeOpponentPenalty(Skill skill, PenaltyNeutralizer neutralizer, Unit unit)
    {
        if (skill.GetUnidadesBonificadas() == "dueno" || skill.GetUnidadesBonificadas() == "ambas")
        {
            neutralizer.ApplyPenaltyNeutralizer(unit, this);
          
        }
    }
}