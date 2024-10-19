using Fire_Emblem_View;
using Fire_Emblem.Effects;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class DeadlyBlade : Skill
{


    public DeadlyBlade()
        : base("Deadly Blade")

    {
        attackType = AttackType.All;
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(attackType);
        UnidadesAfectadas = AffectedUnit.Owner;
        _effects = new MultiEffect(
            new BonusEffect(StatType.Atk, 8), new BonusEffect(StatType.Spd, 8)
            
            
        );
    }
    
    public override void AgregarCondiciones(View view)
    {
        AddCondition(new UsaArma(Owner, "Sword"));
        AddCondition(new IniciaCombate(Owner, Owner.CurrentCombat));
    }




    public override void CumpleCondiciones(Unit owner, View view)
    {
        VerificarYActivar(view); 
    }
}