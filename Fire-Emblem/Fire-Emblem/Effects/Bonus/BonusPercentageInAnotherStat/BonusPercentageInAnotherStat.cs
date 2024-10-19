using Fire_Emblem_View;
using FireEmblem.Effects;

namespace Fire_Emblem.Effects;

public abstract class BonusPercentageInAnotherStat : BonusValueCalculate
{
    protected  double _proporcion_extra;
    protected  StatType _statArevisar;
    

    public StatType GetStatType()
    {
        return _targetStat;
    }

    // Método para obtener el valor del bono
    public int GetBonusValue()
    {
        return _bonus;
    }
    



    public override void CalculateBonus(Unit unit)
    {
        switch (_statArevisar)
        {
            case StatType.Atk:
                _bonus = (unit.BaseAttack - unit.Attack);
                break;
            case StatType.Def:
                _bonus = (unit.BaseDefense - unit.Defense);
                break;
            case StatType.Res:
                _bonus = (unit.BaseResistance - unit.Resistance);
                break;
            case StatType.Spd:
                _bonus = (unit.BaseSpeed - unit.Speed);
                break;
            case StatType.MaxHP:
                _bonus = (unit.BaseMaxHP - unit.CurrentHP);
                break;
            default:
                throw new ApplicationException("Tipo de estadística no válido.");
        }
    }

}