namespace Fire_Emblem.Outputs;

public class TriangleBonus
{
    public string TriangleBonusMessage { get; set; }
    public void SaveTriangleBonus(double weaponTriangleBonus, Combat combat)
    {
        if (weaponTriangleBonus > 1.0)
        {
            TriangleBonusMessage = $"{combat.Attacker.Name} ({combat.Attacker.WeaponType}) tiene ventaja con respecto a {combat.Defender.Name} ({combat.Defender.WeaponType})";
        }
        else if (weaponTriangleBonus < 1.0)
        {
            TriangleBonusMessage = $"{combat.Defender.Name} ({combat.Defender.WeaponType}) tiene ventaja con respecto a {combat.Attacker.Name} ({combat.Attacker.WeaponType})";
        }
        else
        {
            TriangleBonusMessage ="Ninguna unidad tiene ventaja con respecto a la otra";
        }
    }
}