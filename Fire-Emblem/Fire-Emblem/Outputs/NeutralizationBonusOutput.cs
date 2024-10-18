using System.Collections.Generic;
using System.Linq;

namespace Fire_Emblem.Outputs;

public class NeutralizationBonusOutput
{
    // Listas para almacenar los mensajes de neutralización por jugador
    private List<string> FirstPlayerMessages = new();
    private List<string> SecondPlayerMessages = new();

    // Nombres de los jugadores
    public string FirstPlayerName;
    public string SecondPlayerName;
    
    // Lista que define el orden deseado de las estadísticas
    private readonly List<StatType> StatOrder = new() { StatType.Atk, StatType.Spd, StatType.Def, StatType.Res };

    public NeutralizationBonusOutput()
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
            string message = $"Los bonus de {stat} de {playerName} fueron neutralizados";
            playerMessages.Add(message);
        }
    }
    public void AddEspecificStatMessage(string name, bool isStarter, StatType stat)
    {
        // Determinar si es el primer jugador o el segundo
        var playerMessages = isStarter ? FirstPlayerMessages : SecondPlayerMessages;
        var playerName = isStarter ? FirstPlayerName = name : SecondPlayerName = name;



        // Generar y agregar mensajes para todas las estadísticas

            string message = $"Los bonus de {stat} de {playerName} fueron neutralizados";
            // Reemplazar el mensaje existente para la estadística especificada si ya existe
            var existingMessageIndex = playerMessages.FindIndex(m => m.Contains($"Los bonus de {stat}"));
            if (existingMessageIndex >= 0)
            {
                playerMessages[existingMessageIndex] = message;
            }
            else
            {
                playerMessages.Add(message);
            }

            // Reordenar los mensajes según el orden de StatOrder
            ReorderMessages(playerMessages);
        
    }
    private void ReorderMessages(List<string> playerMessages)
    {
        // Reordenar los mensajes basados en el orden de StatOrder
        playerMessages.Sort((msg1, msg2) =>
        {
            var stat1 = StatOrder.FirstOrDefault(stat => msg1.Contains($"Los bonus de {stat}"));
            var stat2 = StatOrder.FirstOrDefault(stat => msg2.Contains($"Los bonus de {stat}"));
            return StatOrder.IndexOf(stat1).CompareTo(StatOrder.IndexOf(stat2));
        });
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
