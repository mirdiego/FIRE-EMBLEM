using Fire_Emblem_View;
using Fire_Emblem.Effects;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class BeliefInLove : Skill
{


    public BeliefInLove()
        : base("Belief In Love")

    {
        tipo_de_ataque = "todos";
        // Inicializar los tipos de ataque válidos
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(tipo_de_ataque);
        UnidadesBonificadas = "oponente";
        _effects = new MultiEffect(
            new PenaltyEffect(StatType.Atk, 5),
            new PenaltyEffect(StatType.Def, 5)
        );
    }
    
    public override void AgregarCondiciones(View view)
    {
        AddCondition(new SiempreCumple());
        // Agregar la condición IniciaCombate
        AddOptionalCondition(new RivalIniciaCombate(Owner, Owner.CurrentCombat));
        AddOptionalCondition(new PorcentajeDeStatBaseRival(1, StatType.Hp, Operadores.Equal));
    }




    public override void CumpleCondiciones(Unit owner, View view)
    {
        VerificarYActivar(view); // Verifica las condiciones y activa si es necesario
    }
}