using Fire_Emblem_View;

namespace Fire_Emblem.Weapon;

public class Weapon
{
    public string Type { get; private set; } // "Sword", "Axe", "Lance", "Magic", etc.

    public Weapon(string type)
    {
        Type = type;
    }

    public bool IsMagical()
    {
        var magicalWeapons = new List<string> { "Magic" };
        return magicalWeapons.Contains(Type);
    }
}