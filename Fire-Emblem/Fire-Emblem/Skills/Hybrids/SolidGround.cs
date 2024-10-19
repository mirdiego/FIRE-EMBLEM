using Fire_Emblem_View;
using Fire_Emblem.Effects;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class SolidGround : Skill
{


    public SolidGround()
        : base("Solid Ground")

    {
        attackType = AttackType.All;
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(attackType);
        UnidadesAfectadas = AffectedUnit.Owner;
        _effects = new MultiEffect(
            new BonusEffect(StatType.Atk, 6),
            new BonusEffect(StatType.Def, 6),
            new PenaltyOnOwnerEffect(StatType.Res, 5)
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