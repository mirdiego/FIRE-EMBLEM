using Fire_Emblem_View;

namespace Fire_Emblem;


public class UsaMagia : Condition
{
    private Unit _unit;
    private Combat _combat;
    public UsaMagia(Unit unit)
    {
        _unit = unit;

    }
    public override bool Cumple(Unit unit, View view)
    {
        if (_unit.Weapon.Type == "Magic")
        {
            return true;
        }

        return false;
        

    }
}