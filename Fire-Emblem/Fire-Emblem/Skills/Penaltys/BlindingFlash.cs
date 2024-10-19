using Fire_Emblem_View;
using Fire_Emblem.Effects;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class BlindingFlash : Skill
{


    public BlindingFlash()
        : base("Blinding Flash")

    {
        attackType = AttackType.All;
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(attackType);
        UnidadesAfectadas = AffectedUnit.Opponent;
        _effects = new MultiEffect(
            new PenaltyEffect(StatType.Spd, 4)
        );
    }
    
    public override void AgregarCondiciones(View view)
    {
        AddCondition(new IniciaCombate(Owner, Owner.CurrentCombat));
    }




    public override void CumpleCondiciones(Unit owner, View view)
    {
        VerificarYActivar(view); // Verifica las condiciones y activa si es necesario
    }
}