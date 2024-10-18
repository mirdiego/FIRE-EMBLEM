namespace Fire_Emblem.Weapon;

public class WeaponController
{
    private Weapon _weapon;
    public static double GetWeaponTriangleBonusAgainst(Weapon attackerWeapon, Weapon defenderWeapon)
    {
        double bonus = 1.0;
    
        if (attackerWeapon.IsMagical() || defenderWeapon.IsMagical())
        {
            return bonus;
        }
    
        if (attackerWeapon.Type == "Sword" && defenderWeapon.Type == "Axe" ||
            attackerWeapon.Type == "Lance" && defenderWeapon.Type == "Sword" ||
            attackerWeapon.Type == "Axe" && defenderWeapon.Type == "Lance")
        {
            bonus = 1.2;
        }
        else if (attackerWeapon.Type == "Sword" && defenderWeapon.Type == "Lance" ||
                 attackerWeapon.Type == "Lance" && defenderWeapon.Type == "Axe" ||
                 attackerWeapon.Type == "Axe" && defenderWeapon.Type == "Sword")
        {
            bonus = 0.8;
        }
    
        return bonus;
    }
}