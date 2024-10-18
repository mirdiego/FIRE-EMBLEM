using Fire_Emblem_View;

namespace Fire_Emblem.Effects.Neutralizer;

public abstract class GenericBonusNeutralizer : Neutralizer
{
    protected StatType _stat;
    public void ApplyBonusNeutralizer(Unit unit, BonusClassEffects bonus, StatType stat)
    {
        {
            {
                int valor = bonus.GetBonusValue();
                if (valor != 0)
                {
                    unit.Opponent.DecreaseStat(stat, valor);
                }
            }

        }
    }
}