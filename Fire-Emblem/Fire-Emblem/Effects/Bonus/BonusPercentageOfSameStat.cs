using Fire_Emblem;
using Fire_Emblem_View;
using Fire_Emblem.Effects;
using Fire_Emblem.Outputs;

namespace FireEmblem.Effects;

public class BonusPercentageOfSameStatEffect : BonusValueCalculate
{
    private readonly double _proporcion_extra;
    
    public BonusPercentageOfSameStatEffect(StatType targetStat, double proporcion_extra)
    {
        _targetStat = targetStat;
        _proporcion_extra = proporcion_extra;
        _bonus = 0;
    }
    public StatType GetStatType()
    {
        return _targetStat;
    }

    // Método para obtener el valor del bono
    public int GetBonusValue()
    {
        return _bonus;
    }
    

    public override void Apply(Unit unit, View view, Output output, Skill skill)
    {

        ApplyEffects(unit, _bonus, view);

        
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