using Fire_Emblem;
using Fire_Emblem_View;
using Fire_Emblem.Effects;
using Fire_Emblem.Outputs;

namespace FireEmblem.Effects;

public class BonusOnBothPlayerEffect : BonusClassEffects
{

    public BonusOnBothPlayerEffect( StatType targetStat, int bonus)

    {
        _targetStat = targetStat;
        _bonus = bonus;
        // _condicion = condicion;
    }
    public StatType GetStatType()
    {
        return _targetStat;
    }

    // Método para obtener el valor del bono
    public int GetBonusValue()
    {
        return _bonus;
    }

    public override void Apply(Unit unit, View view, Output output, Skill skill)
    {
        ApplyEffects(unit.Opponent, _bonus, view);
        ApplyEffects(unit, _bonus, view);
        
    }


}