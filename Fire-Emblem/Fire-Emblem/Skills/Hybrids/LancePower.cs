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
        tipo_de_ataque = "todos";
        // Inicializar los tipos de ataque válidos
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(tipo_de_ataque);
        UnidadesBonificadas = "dueno";
        _effects = new MultiEffect(
            new BonusEffect(StatType.Atk, 10),
            new PenaltyEffect(StatType.Def, 10)
            
            
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