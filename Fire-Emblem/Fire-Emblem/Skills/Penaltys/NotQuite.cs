using Fire_Emblem_View;
using Fire_Emblem.Effects;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class NotQuite : Skill
{


    public NotQuite()
        : base("Not *Quite*")

    {
        attackType = AttackType.All;
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(attackType);
        UnidadesAfectadas = AffectedUnit.Opponent;
        _effects = new MultiEffect(
            new PenaltyEffect(StatType.Atk, 4)
        );
    }
    
    public override void AgregarCondiciones(View view)
    {
        AddCondition(new RivalIniciaCombate(Owner, Owner.CurrentCombat));
    }




    public override void CumpleCondiciones(Unit owner, View view)
    {
        VerificarYActivar(view); // Verifica las condiciones y activa si es necesario
    }
}