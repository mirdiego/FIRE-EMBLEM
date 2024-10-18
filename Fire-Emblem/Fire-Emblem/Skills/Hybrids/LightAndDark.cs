using Fire_Emblem_View;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Neutralizer;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class LightAndDark : Skill
{


    public LightAndDark()
        : base("Light And Dark")

    {
        tipo_de_ataque = "todos";
        // Inicializar los tipos de ataque válidos
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(tipo_de_ataque);
        UnidadesBonificadas = "oponente";
        _effects = new MultiEffect(
            new PenaltyEffect(StatType.Atk, 5),
            new PenaltyEffect(StatType.Spd, 5),
            new PenaltyEffect(StatType.Def, 5),
            new PenaltyEffect(StatType.Res, 5),

            new BonusNeutralizer(),
            new PenaltyNeutralizer()
            
            
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