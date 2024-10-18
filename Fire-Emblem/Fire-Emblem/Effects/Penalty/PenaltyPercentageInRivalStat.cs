using Fire_Emblem_View;
using FireEmblem.Effects;

namespace Fire_Emblem.Effects;

public class PenaltyPercentageInRivalStat : PenaltyValueCalculate
{
    private readonly double _proporcion_extra;
    private readonly StatType _statArevisar;
    
    public PenaltyPercentageInRivalStat(StatType targetStat,  StatType statArevisar)
    {
        _targetStat = targetStat;
        _statArevisar = statArevisar;
        _penalty = 0;
    }
    public StatType GetStatType()
    {
        return _targetStat;
    }

    // Método para obtener el valor del bono
    public int GetPenaltyValue()
    {
        return _penalty;
    }
    

    public override void Apply(Unit unit, View view, Output output, Skill skill)
    {


        ApplyEffects(unit, _penalty, view);

    }

    public override void CalculatePenalty(Unit unit)
    {
        switch (_statArevisar)
        {
            case StatType.Atk:
                _penalty = (unit.Opponent.BaseAttack / 2);
                break;
            case StatType.Def:
                _penalty = (unit.Opponent.BaseDefense / 2);
                break;
            case StatType.Res:
                _penalty = (unit.Opponent.BaseResistance / 2);
                break;
            case StatType.Spd:
                _penalty = (unit.Opponent.BaseSpeed / 2);
                break;
            case StatType.MaxHP:
                _penalty = (unit.Opponent.BaseMaxHP / 2);
                break;
            default:
                throw new ApplicationException("Tipo de estadística no válido.");
        }
    }

}