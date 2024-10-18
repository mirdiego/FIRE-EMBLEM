using Fire_Emblem_View;
using Fire_Emblem.Effects;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class LifeAndDeath : Skill
{


    public LifeAndDeath()
        : base("Life And Death")

    {
        tipo_de_ataque = "todos";
        // Inicializar los tipos de ataque válidos
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(tipo_de_ataque);
        UnidadesBonificadas = "dueno";
        _effects = new MultiEffect(
            new BonusEffect(StatType.Atk, 6),
            new BonusEffect(StatType.Spd, 6),
            new PenaltyEffect(StatType.Def, 5),
            new PenaltyEffect(StatType.Res, 5)

            
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