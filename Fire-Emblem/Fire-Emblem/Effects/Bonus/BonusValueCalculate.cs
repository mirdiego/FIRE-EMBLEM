using Fire_Emblem;
using Fire_Emblem_View;
using Fire_Emblem.Effects;
using Fire_Emblem.Outputs;

namespace FireEmblem.Effects;

public abstract class BonusValueCalculate : BonusClassEffects
{
    private readonly double _proporcion_extra;


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
        ApplyEffects(unit, _bonus, view);
    }
    public abstract void CalculateBonus(Unit unit);
}