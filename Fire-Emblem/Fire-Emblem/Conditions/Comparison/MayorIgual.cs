using Fire_Emblem_View;

namespace Fire_Emblem;

public class MayorIgual : Comparison
{
    public MayorIgual(int value, StatType _targestat) : base(value, _targestat)
    {
    }
    public override bool Cumple(Unit unit, View view)
    {
        // Obtener el valor de la stat correspondiente
        int statValue = ObtenerValorStat(unit);

        // Comparar si el valor de la stat es mayor o igual al valor especificado
        return statValue >= comparisonValue;
    }
}