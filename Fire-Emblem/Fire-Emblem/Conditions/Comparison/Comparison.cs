namespace Fire_Emblem;

public abstract class Comparison : Condition
{
    protected int  comparisonValue;
    protected StatType targetStat;

    public Comparison(int value, StatType _targetStat)
    {
        comparisonValue = value;
        targetStat = _targetStat;
        
    }
    protected int ObtenerValorStat(Unit unit)
    {
        // Seleccionar el valor de la stat de la unidad dependiendo del tipo de stat
        return targetStat switch
        {
            StatType.Atk => unit.Attack,
            StatType.Def => unit.Defense,
            StatType.Res => unit.Resistance,
            StatType.Spd => unit.Speed,
            _ => throw new ApplicationException("Tipo de stat no válido.")
        };
    }
}