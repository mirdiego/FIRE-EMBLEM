using Fire_Emblem_View;
using Fire_Emblem.Effects;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class LancePower : Skill
{


    public LancePower()
        : base("Lance Power")

    {
        attackType = AttackType.All;
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(attackType);
        UnidadesAfectadas = AffectedUnit.Owner;
        _effects = new MultiEffect(
            new BonusEffect(StatType.Atk, 10),
            new PenaltyOnOwnerEffect(StatType.Def, 10)
        );
        
    }
    
    public override void AgregarCondiciones(View view)
    {
        AddCondition(new UsaArma(Owner, "Lance"));
    }
    
    public override void CumpleCondiciones(Unit owner, View view)
    {

        VerificarYActivar(view);
    }

}