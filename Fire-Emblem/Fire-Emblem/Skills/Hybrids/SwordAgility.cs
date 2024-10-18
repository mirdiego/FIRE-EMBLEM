using Fire_Emblem_View;
using Fire_Emblem.Effects;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class SwordAgility : Skill
{


    public SwordAgility()
        : base("Sword Agility")

    {
        tipo_de_ataque = "todos";
        // Inicializar los tipos de ataque válidos
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(tipo_de_ataque);
        UnidadesBonificadas = "dueno";
        _effects = new MultiEffect(
            new BonusEffect(StatType.Spd, 12),
            new PenaltyEffect(StatType.Atk, 6)
            
            
        );
        
    }
    
    public override void AgregarCondiciones(View view)
    {
        AddCondition(new UsaArma(Owner, "Sword"));
    }
    
    public override void CumpleCondiciones(Unit owner, View view)
    {

        VerificarYActivar(view);
    }

}