using Fire_Emblem_View;
using System.Collections.Generic;
using System.Linq;

namespace Fire_Emblem.Outputs;

public class SkillOutput
{
    public Dictionary<string, Dictionary<StatType, int>> PlayerBonusesFullCombat = new();
    public Dictionary<string, Dictionary<StatType, int>> PlayerBonusesFirstAttack = new();
    public Dictionary<string, Dictionary<StatType, int>> PlayerBonusesFollowUp = new();
    public Dictionary<string, Dictionary<StatType, int>> PlayerPenaltysFullCombat = new();
    public Dictionary<string, Dictionary<StatType, int>> PlayerPenaltysFirstAttack = new();
    public Dictionary<string, Dictionary<StatType, int>> PlayerPenaltysFollowUp = new();
    public List<string> FirstPlayerOrderedMessages = new();
    public List<string> SecondPlayerOrderedMessages = new();
    public string FirstPlayerName;
    public string SecondPlayerName;
    
    // Lista que define el orden deseado de las estadísticas
    private readonly List<StatType> StatOrder = new() { StatType.Atk, StatType.Spd, StatType.Def, StatType.Res };

    public SkillOutput()
    {
        // Inicializar diccionarios para cada tipo de ataque y cada jugador
        InitializeDictionaries(PlayerBonusesFullCombat);
        InitializeDictionaries(PlayerBonusesFirstAttack);
        InitializeDictionaries(PlayerBonusesFollowUp);
        InitializeDictionaries(PlayerPenaltysFullCombat);
        InitializeDictionaries(PlayerPenaltysFirstAttack);
        InitializeDictionaries(PlayerPenaltysFollowUp);
    }
    private void InitializeDictionaries(Dictionary<string, Dictionary<StatType, int>> dictionary)
    {
        dictionary["FirstPlayer"] = new Dictionary<StatType, int>();
        dictionary["SecondPlayer"] = new Dictionary<StatType, int>();
    }

    public void BonusFullCombat(StatType stat, int value, string name, bool isStarter)
    {
        string playerKey = isStarter ? "FirstPlayer" : "SecondPlayer";
        string playerName = isStarter ? FirstPlayerName = name : SecondPlayerName = name;
        AccumulateValue(PlayerBonusesFullCombat[playerKey], stat, value);
    }

    public void BonusFirstAttack(StatType stat, int value, string name, bool isStarter)
    {
        string playerKey = isStarter ? "FirstPlayer" : "SecondPlayer";
        string playerName = isStarter ? FirstPlayerName = name : SecondPlayerName = name;
        AccumulateValue(PlayerBonusesFirstAttack[playerKey], stat, value);
    }

    public void BonusFollowUp(StatType stat, int value, string name, bool isStarter)
    {
        string playerKey = isStarter ? "FirstPlayer" : "SecondPlayer";
        string playerName = isStarter ? FirstPlayerName = name : SecondPlayerName = name;
        AccumulateValue(PlayerBonusesFollowUp[playerKey], stat, value);
    }

    public void PenaltyFullCombat(StatType stat, int value, string name, bool isStarter)
    {
        string playerKey = isStarter ? "SecondPlayer" : "FirstPlayer";
        string playerName = isStarter ? SecondPlayerName = name : FirstPlayerName = name ;
        AccumulateValue(PlayerPenaltysFullCombat[playerKey], stat, -value);
    }

    public void PenaltyFirstAttack(StatType stat, int value, string name, bool isStarter)
    {
        string playerKey = isStarter ? "SecondPlayer" : "FirstPlayer";
        string playerName = isStarter ? SecondPlayerName = name : FirstPlayerName = name;
        AccumulateValue(PlayerPenaltysFirstAttack[playerKey], stat, -value);
    }

    public void PenaltyFollowUp(StatType stat, int value, string name, bool isStarter)
    {
        string playerKey = isStarter ? "SecondPlayer" : "FirstPlayer";
        string playerName = isStarter ? SecondPlayerName = name : FirstPlayerName = name ;
        AccumulateValue(PlayerPenaltysFollowUp[playerKey], stat, -value);
    }

    private void AccumulateValue(Dictionary<StatType, int> dictionary, StatType stat, int value)
    {
        if (!dictionary.ContainsKey(stat))
        {
            dictionary[stat] = value;
        }
        else
        {
            dictionary[stat] += value;
        }
    }

    public void SaveMessages(View view)
    {
        // Limpiar listas anteriores para evitar duplicados
        FirstPlayerOrderedMessages.Clear();
        SecondPlayerOrderedMessages.Clear();

        // Generar y agregar mensajes para los bonuses y penalties del FirstPlayer
        FirstPlayerOrderedMessages.AddRange(GenerateMessages("FirstPlayer", PlayerBonusesFullCombat, "obtiene"));
        FirstPlayerOrderedMessages.AddRange(GenerateMessages("FirstPlayer", PlayerBonusesFirstAttack, "obtiene", "en su primer ataque"));
        FirstPlayerOrderedMessages.AddRange(GenerateMessages("FirstPlayer", PlayerBonusesFollowUp, "obtiene", "en su Follow-Up"));
        FirstPlayerOrderedMessages.AddRange(GenerateMessages("FirstPlayer", PlayerPenaltysFullCombat, "obtiene"));
        FirstPlayerOrderedMessages.AddRange(GenerateMessages("FirstPlayer", PlayerPenaltysFirstAttack, "obtiene", "en su primer ataque"));
        FirstPlayerOrderedMessages.AddRange(GenerateMessages("FirstPlayer", PlayerPenaltysFollowUp, "obtiene", "en su Follow-Up"));

        // Generar y agregar mensajes para los bonuses y penalties del SecondPlayer
        SecondPlayerOrderedMessages.AddRange(GenerateMessages("SecondPlayer", PlayerBonusesFullCombat, "obtiene"));
        SecondPlayerOrderedMessages.AddRange(GenerateMessages("SecondPlayer", PlayerBonusesFirstAttack, "obtiene", "en su primer ataque"));
        SecondPlayerOrderedMessages.AddRange(GenerateMessages("SecondPlayer", PlayerBonusesFollowUp, "obtiene", "en su Follow-Up"));
        SecondPlayerOrderedMessages.AddRange(GenerateMessages("SecondPlayer", PlayerPenaltysFullCombat, "obtiene"));
        SecondPlayerOrderedMessages.AddRange(GenerateMessages("SecondPlayer", PlayerPenaltysFirstAttack, "obtiene", "en su primer ataque"));
        SecondPlayerOrderedMessages.AddRange(GenerateMessages("SecondPlayer", PlayerPenaltysFollowUp, "obtiene", "en su Follow-Up"));
    }
    private IEnumerable<string> GenerateMessages(string playerKey, Dictionary<string, Dictionary<StatType, int>> values, string action, string extraInfo = "")
    {
        var messages = new List<string>();

        if (values.ContainsKey(playerKey))
        {
            string playerName = playerKey == "FirstPlayer" ? FirstPlayerName : SecondPlayerName;

            foreach (var stat in StatOrder)
            {
                if (values[playerKey].ContainsKey(stat) && values[playerKey][stat] != 0)
                {
                    int value = values[playerKey][stat];
                    messages.Add($"{playerName} {action} {stat}{(value > 0 ? "+" : "")}{value} {extraInfo}".Trim());
                }
            }
        }

        return messages;
    }

    public string GetCombinedSkillMessages(View view)
    {
        return string.Join("\n", FirstPlayerOrderedMessages.Concat(SecondPlayerOrderedMessages));
    }

    // Función para obtener solo los mensajes del FirstPlayer
    public string GetFirstPlayerCombinedSkillMessages(View view)
    {
        return string.Join("\n", FirstPlayerOrderedMessages);
    }

    // Función para obtener solo los mensajes del SecondPlayer
    public string GetSecondPlayerCombinedSkillMessages(View view)
    {
        return string.Join("\n", SecondPlayerOrderedMessages);
    }
}
