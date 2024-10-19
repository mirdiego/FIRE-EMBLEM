using Fire_Emblem_View;
using FireEmblem.Effects;

namespace Fire_Emblem.Effects;

public class BonusPercentageOnBothOfSameStatEffect : BonusPercentageOfSameStat
{

    public BonusPercentageOnBothOfSameStatEffect(StatType targetStat, double proporcion_extra)
    {
        _targetStat = targetStat;
        _proporcion_extra = proporcion_extra;
        _bonus = 0;
    }

    public override void Apply(Unit unit, View view, Output output, Skill skill)
    {

        ApplyEffects(unit, _bonus, view);
        ApplyEffects(unit.Opponent, _bonus, view);


        
    }
    

}