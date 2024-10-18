using Fire_Emblem_View;

namespace Fire_Emblem;


public class RivalUsaArma : Condition
{
    private Unit _unit;
    private Combat _combat;
    private string _arma;
    public RivalUsaArma(Unit unit, string arma)
    {
        _unit = unit;
        _arma = arma;

    }
    public override bool Cumple(Unit unit, View view)
    {
        if (_unit.Opponent.Weapon.Type == _arma)
        {
            return true;
        }

        return false;
        

    }
}