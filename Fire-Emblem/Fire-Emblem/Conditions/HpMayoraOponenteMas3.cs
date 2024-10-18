using Fire_Emblem_View;

namespace Fire_Emblem;


public class HpMayorAOponenteMas3 : Condition
{
    private Unit _unit;
    public HpMayorAOponenteMas3(Unit unit)
    {
        _unit = unit;
    }
    public override bool Cumple(Unit unit, View view)
    {
        if (unit.CurrentHP >= unit.Opponent.CurrentHP + 3)
        {
            return true;
        }

        return false;
        

    }
}