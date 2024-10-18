using Fire_Emblem_View;
using Fire_Emblem.Effects;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class Perceptive : Skill
{


    public Perceptive()
        : base("Perceptive")

    {
        tipo_de_ataque = "todos";
        // Inicializar los tipos de ataque válidos
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(tipo_de_ataque);
        UnidadesBonificadas = "dueno";
        




        _effects = new MultiEffect(
            new BonusEffect(StatType.Spd, 12),
            new BonusPercentageOfSameStatEffect(StatType.Spd, 0.25)
            
            
        );
    }
    
    public override void AgregarCondiciones(View view)
    {
        // Agregar la condición IniciaCombate
        AddCondition(new IniciaCombate(Owner, Owner.CurrentCombat));
    }




    public override void CumpleCondiciones(Unit owner, View view)
    {
        VerificarYActivar(view); // Verifica las condiciones y activa si es necesario
    }
}