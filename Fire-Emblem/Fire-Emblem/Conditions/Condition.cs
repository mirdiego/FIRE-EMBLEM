using System.ComponentModel.DataAnnotations;
using Fire_Emblem_View;

namespace Fire_Emblem;

public abstract class Condition
{

    // Método para comparar dos valores usando el operador especificado
    protected bool UsarOperadores(int valor1, int valor2, Operadores operador)
    {
        return operador switch
        {
            Operadores.GreaterThan => valor1 > valor2,
            Operadores.LessThan => valor1 < valor2,
            Operadores.GreaterOrEqual => valor1 >= valor2,
            Operadores.LessOrEqual => valor1 <= valor2,
            Operadores.Equal => valor1 == valor2,
            Operadores.NotEqual => valor1 != valor2,
            _ => throw new ApplicationException("Operador de comparación no válido.")
        };

    }
    public abstract bool Cumple(Unit unit, View view);
}