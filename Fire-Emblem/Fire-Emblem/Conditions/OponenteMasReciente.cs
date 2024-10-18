using Fire_Emblem_View;

namespace Fire_Emblem;


public class OponenteMasReciente : Condition
{
    private Unit _unit;
    public OponenteMasReciente(Unit unit)
    {
        _unit = unit;
    }
    public override bool Cumple(Unit unit, View view)
    {
        if (_unit.LastOponentName == unit.Opponent.Name)
        {
            return true;
        }

        return false;
        

    }
}