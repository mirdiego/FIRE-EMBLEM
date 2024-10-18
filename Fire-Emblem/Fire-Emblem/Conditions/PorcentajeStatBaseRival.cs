using Fire_Emblem_View;

namespace Fire_Emblem;

public class PorcentajeDeStatBaseRival : Condition

{
    private double _proporcion;
    private StatType _statType;
    private Operadores _operador;

    public PorcentajeDeStatBaseRival(double proporcion, StatType statType, Operadores operador)
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
                valorBase = unit.Opponent.BaseAttack;
                valorActual = unit.Opponent.Attack;
                break;
            case StatType.Def:
                valorBase = unit.Opponent.BaseDefense;
                valorActual = unit.Opponent.Defense;
                break;
            case StatType.Spd:
                valorBase = unit.Opponent.BaseSpeed;
                valorActual = unit.Opponent.Speed;
                break;
            case StatType.Res:
                valorBase = unit.Opponent.BaseResistance;
                valorActual = unit.Opponent.Resistance;
                break;
            case StatType.Hp:
                valorBase = unit.Opponent.BaseMaxHP;
                valorActual = unit.Opponent.CurrentHP;
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