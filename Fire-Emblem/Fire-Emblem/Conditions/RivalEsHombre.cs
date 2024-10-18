using Fire_Emblem_View;

namespace Fire_Emblem;

public class RivalEsHombre : Condition
{
    private Unit _unit;
    private Combat _combat;
    public RivalEsHombre(Unit unit, Combat combat )
    {
        _unit = unit;
        _combat = combat;
    }

    public override bool Cumple(Unit unit, View view)
    {

        // Verifica si la unidad es el atacante o el defensor
        if (unit.Opponent.Gender == "Male")
        {
            return true;
        }
        return false;
    }

        

    
}