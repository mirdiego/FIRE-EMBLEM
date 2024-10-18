using Fire_Emblem_View;

namespace Fire_Emblem;

public class PorcentajeDeStatBase : Condition

{
    private double _proporcion;
    private StatType _statType;
    private Operadores _operador;

    public PorcentajeDeStatBase(double proporcion, StatType statType, Operadores operador)
    {
        _proporcion = proporcion;
        _statType = statType;
        _operador = operador;
    }

    public override bool Cumple(Unit unit, View view)
    {
        // Obtener los valores actuales y base de la stat especificada
        int valorBase = 0;
        int valorActual = 0;

        // Según el tipo de stat, obtener los valores correspondientes
        switch (_statType)
        {
            case StatType.Atk:
                valorBase = unit.BaseAttack;
                valorActual = unit.Attack;
                break;
            case StatType.Def:
                valorBase = unit.BaseDefense;
                valorActual = unit.Defense;
                break;
            case StatType.Spd:
                valorBase = unit.BaseSpeed;
                valorActual = unit.Speed;
                break;
            case StatType.Res:
                valorBase = unit.BaseResistance;
                valorActual = unit.Resistance;
                break;
            case StatType.Hp:
                valorBase = unit.BaseMaxHP;
                valorActual = unit.CurrentHP;
                break;
            default:
                throw new ApplicationException("Tipo de stat no válido.");
        }

        // Evitar división por cero
        if (valorBase == 0)
        {
            throw new ApplicationException("El valor base de la stat no puede ser 0.");
        }

        double proporcionActual = (double)valorActual / valorBase;

        // Convertir la proporción actual y la proporción esperada a enteros para compararlos
        int proporcionActualInt = (int)(proporcionActual * 100);
        int proporcionEsperadaInt = (int)(_proporcion * 100);

        // Usar el método UsarOperadores para comparar los valores enteros
        return UsarOperadores(proporcionActualInt, proporcionEsperadaInt, _operador);
    }
}