using Fire_Emblem_View;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Neutralizer;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class DistantDef : Skill
{


    public DistantDef()
        : base("Distant Def")

    {
        attackType = AttackType.All;
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(attackType);
        UnidadesAfectadas = AffectedUnit.Owner;
        _effects = new MultiEffect(
            new BonusEffect(StatType.Def, 8),
            new BonusEffect(StatType.Res, 8),
            new BonusNeutralizer()
        );
        
    }
    
    public override void AgregarCondiciones(View view)
    {
        AddCondition(new RivalIniciaCombate(Owner, Owner.CurrentCombat));
        AddOptionalCondition(new RivalUsaArma(Owner, "Bow"));
        AddOptionalCondition(new RivalUsaArma(Owner, "Magic"));


    }
    
    public override void CumpleCondiciones(Unit owner, View view)
    {

        VerificarYActivar(view);
    }

}