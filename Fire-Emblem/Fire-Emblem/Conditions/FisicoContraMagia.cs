using Fire_Emblem_View;

namespace Fire_Emblem;


public class FisicoContraMagia : Condition
{
    public FisicoContraMagia()
    {

    }
    public override bool Cumple(Unit unit, View view)
    {
        if ((unit.Weapon.Type == "Magic" && unit.Opponent.Weapon.Type != "Magic") || (unit.Opponent.Weapon.Type == "Magic" && unit.Weapon.Type != "Magic"))
        {
            return true;
        }

        return false;
        

    }
}