using Fire_Emblem_View;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Neutralizer;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

public class LullAtkRes : Skill
{
    public LullAtkRes()
        : base("Lull Atk/Res")

    {
        attackType = AttackType.All;
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(attackType);
        UnidadesAfectadas = AffectedUnit.Opponent;
        _effects = new MultiEffect(
            new PenaltyEffect(StatType.Atk, 3),
            new PenaltyEffect(StatType.Res, 3),
            new BonusStatNeutralizer(StatType.Atk),
            new BonusStatNeutralizer(StatType.Res)
        );
        
    }
    
    public override void AgregarCondiciones(View view)
    {
        AddCondition(new SiempreCumple());



    }
    
    public override void CumpleCondiciones(Unit owner, View view)
    {

        VerificarYActivar(view);
    }
}