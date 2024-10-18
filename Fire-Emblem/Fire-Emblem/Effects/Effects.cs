using Fire_Emblem_View;
using Fire_Emblem.Effects.Neutralizer;
using Fire_Emblem.Outputs;

namespace Fire_Emblem.Effects;


using Fire_Emblem;

public abstract class Effect
{
    protected  Unit  _unit_afectada;
    public abstract void Apply(Unit unit, View view, Output output, Skill skill);

    public virtual void NeutralizeOwnerBonus(Skill skill, Neutralizer.BonusStatNeutralizer neutralizer, Unit unit)
    {
    }
    public virtual void NeutralizeOpponentBonus(Skill skill, Neutralizer.BonusStatNeutralizer neutralizer, Unit unit)
    {
    }

    public virtual void NeutralizeAllOwnerBonus(Skill skill, Neutralizer.BonusNeutralizer neutralizer, Unit unit)
    {
    }
    public virtual void NeutralizeAllOpponentBonus(Skill skill, Neutralizer.BonusNeutralizer neutralizer, Unit unit)
    {
    }
    public virtual void NeutralizeOwnerPenalty(Skill skill, PenaltyNeutralizer neutralizer, Unit unit)
    {
    }
    public virtual void NeutralizeOpponentPenalty(Skill skill, PenaltyNeutralizer neutralizer, Unit unit)
    {
    }
}