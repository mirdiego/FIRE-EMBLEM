using Fire_Emblem_View;

namespace Fire_Emblem;

public class MenorIgual :Comparison
{
    public MenorIgual(int value, StatType _targetStat) : base(value, _targetStat)
    {
    }
    public override bool Cumple(Unit unit, View view)
    {
        // Obtener el valor de la stat correspondiente
        int statValue = ObtenerValorStat(unit);

        // Comparar si el valor de la stat es mayor o igual al valor especificado
        return statValue <= comparisonValue;
    }
}