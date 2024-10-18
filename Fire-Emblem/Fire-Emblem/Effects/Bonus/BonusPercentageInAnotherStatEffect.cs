using Fire_Emblem_View;
using FireEmblem.Effects;

namespace Fire_Emblem.Effects;

public class BonusPercentageInAnotherStatEffect : BonusValueCalculate
{
    private readonly double _proporcion_extra;
    private readonly StatType _statArevisar;
    
    public BonusPercentageInAnotherStatEffect(StatType targetStat, double proporcion_extra, StatType statArevisar)
    {
        _targetStat = targetStat;
        _statArevisar = statArevisar;
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

        if (_bonus > 30)
        {
            _bonus = 30;

            
        }
        ApplyEffects(unit, _bonus, view);

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