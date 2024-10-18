using Fire_Emblem_View;

namespace Fire_Emblem;

public class Menor :Comparison
{
    public Menor(int value, StatType _targetstat) : base(value, _targetstat)
    {
    }
    public override bool Cumple(Unit unit, View view)
    {
        // Obtener el valor de la stat correspondiente
        int statValue = ObtenerValorStat(unit);

        // Comparar si el valor de la stat es mayor o igual al valor especificado
        return statValue < comparisonValue;
    }
}