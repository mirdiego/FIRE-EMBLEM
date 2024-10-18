using Fire_Emblem_View;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Neutralizer;
using Fire_Emblem.Outputs;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class AgneasArrow : Skill
{


    public AgneasArrow()
        : base("Agnea´s Arrow")

    {
        tipo_de_ataque = "todos";
        // Inicializar los tipos de ataque válidos
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(tipo_de_ataque);
        UnidadesBonificadas = "dueno";
        




        _effects = new MultiEffect(
            new PenaltyNeutralizer()
            
            
        );
    }
    
    public override void AgregarCondiciones(View view)
    {
        // Agregar la condición IniciaCombate
        AddCondition(new SiempreCumple());
    }




    public override void CumpleCondiciones(Unit owner, View view)
    {
        VerificarYActivar(view); // Verifica las condiciones y activa si es necesario
    }
}