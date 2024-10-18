using Fire_Emblem_View;

namespace Fire_Emblem;

public class VidaNoMaxima : Condition

{


    public VidaNoMaxima()
    {
    }

    public override bool Cumple(Unit unit, View view)
    {
        if (unit.MaxHP < unit.BaseMaxHP)
        {
            return true;
        }

        return false;

    }
}