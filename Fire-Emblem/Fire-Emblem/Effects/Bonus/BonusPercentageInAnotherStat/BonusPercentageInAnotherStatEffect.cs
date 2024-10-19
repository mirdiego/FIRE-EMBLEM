using Fire_Emblem_View;
using FireEmblem.Effects;

namespace Fire_Emblem.Effects;

public class BonusPercentageInAnotherStatEffect : BonusPercentageInAnotherStat
{
    
    public BonusPercentageInAnotherStatEffect(StatType targetStat, double proporcion_extra, StatType statArevisar)
    {
        _targetStat = targetStat;
        _statArevisar = statArevisar;
        _proporcion_extra = proporcion_extra;
        _bonus = 0;
    }

    

    public override void Apply(Unit unit, View view, Output output, Skill skill)
    {

        if (_bonus > 30)
        {
            _bonus = 30;
        }
        ApplyEffects(unit, _bonus, view);

    }
    

}