using Fire_Emblem_View;

namespace Fire_Emblem;


public class UnSoloUso : Condition
{
    private Unit _unit;
    private bool _usado;
    public UnSoloUso()
    {
        _usado = false;
    }
    public override bool Cumple(Unit unit, View view)
    {
        if (!_usado)
        {
            _usado = true;
            return true;
        }


        return false;
        

    }
}