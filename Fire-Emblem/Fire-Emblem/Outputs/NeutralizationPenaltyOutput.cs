using System.Collections.Generic;
using System.Linq;

namespace Fire_Emblem.Outputs;

public class NeutralizationPenaltyOutput
{
    // Listas para almacenar los mensajes de neutralización por jugador
    private List<string> FirstPlayerMessages = new();
    private List<string> SecondPlayerMessages = new();

    // Nombres de los jugadores
    public string FirstPlayerName;
    public string SecondPlayerName;
    
    // Lista que define el orden deseado de las estadísticas
    private readonly List<StatType> StatOrder = new() { StatType.Atk, StatType.Spd, StatType.Def, StatType.Res };

    public NeutralizationPenaltyOutput()
    {
        // Inicializar las listas para los mensajes de cada jugador
        FirstPlayerMessages = new List<string>();
        SecondPlayerMessages = new List<string>();
    }

    public void AddMessage(string name, bool isStarter)
    {
        // Determinar si es el primer jugador o el segundo
        var playerMessages = isStarter ? FirstPlayerMessages : SecondPlayerMessages;
        var playerName = isStarter ? FirstPlayerName = name : SecondPlayerName = name;

        // Limpiar mensajes previos para asegurar que no se acumulen en múltiples llamadas
        playerMessages.Clear();

        // Generar y agregar mensajes para todas las estadísticas
        foreach (var stat in StatOrder)
        {
            string message = $"Los penalty de {stat} de {playerName} fueron neutralizados";
            playerMessages.Add(message);
        }
    }

    // Obtener todos los mensajes combinados de ambos jugadores
    public IEnumerable<string> GetCombinedMessages()
    {
        return FirstPlayerMessages.Concat(SecondPlayerMessages);
    }

    // Obtener solo los mensajes del FirstPlayer
    public IEnumerable<string> GetFirstPlayerMessages()
    {
        return FirstPlayerMessages;
    }

    // Obtener solo los mensajes del SecondPlayer
    public IEnumerable<string> GetSecondPlayerMessages()
    {
        return SecondPlayerMessages;
    }
}
