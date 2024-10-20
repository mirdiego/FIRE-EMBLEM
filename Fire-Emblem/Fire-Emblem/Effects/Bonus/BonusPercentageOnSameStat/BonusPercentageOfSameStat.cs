using Fire_Emblem;
using Fire_Emblem_View;
using Fire_Emblem.Effects;
using Fire_Emblem.Outputs;

namespace FireEmblem.Effects;

public abstract class BonusPercentageOfSameStat : BonusValueCalculate
{
    protected  double _proporcion_extra;
    

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
        switch (_targetStat)
        {
            case StatType.Atk:
                _bonus = (int)Math.Truncate(unit.BaseAttack * _proporcion_extra);
                break;
            case StatType.Def:
                _bonus = (int)Math.Truncate(unit.BaseDefense * _proporcion_extra);
                break;
            case StatType.Res:
                _bonus = (int)Math.Truncate(unit.BaseResistance * _proporcion_extra);
                break;
            case StatType.Spd:
                _bonus = (int)Math.Truncate(unit.BaseSpeed * _proporcion_extra);
                break;
            case StatType.MaxHP:
                _bonus = (int)Math.Truncate(unit.BaseMaxHP * _proporcion_extra);
                break;
            default:
                throw new ApplicationException("Tipo de estadística no válido.");
        }
    }
    
}