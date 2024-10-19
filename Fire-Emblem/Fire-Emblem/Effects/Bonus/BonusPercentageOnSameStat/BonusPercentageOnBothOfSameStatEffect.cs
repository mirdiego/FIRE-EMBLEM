using Fire_Emblem_View;
using FireEmblem.Effects;

namespace Fire_Emblem.Effects;

public class BonusPercentageOnOpponentOfSameStatEffect : BonusPercentageOfSameStat
{

    public BonusPercentageOnOpponentOfSameStatEffect(StatType targetStat, double proporcion_extra)
    {
        _targetStat = targetStat;
        _proporcion_extra = proporcion_extra;
        _bonus = 0;
    }

    public override void Apply(Unit unit, View view, Output output, Skill skill)
    {

        ApplyEffects(unit.Opponent, _bonus, view);

        
    }
    

}