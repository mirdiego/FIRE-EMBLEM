using Fire_Emblem_View;
using Fire_Emblem.Effects;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class SandStorm : Skill
{


    public SandStorm()
        : base("Sandstorm")

    {
        tipo_de_ataque = "followup";
        // Inicializar los tipos de ataque válidos
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(tipo_de_ataque);
        UnidadesBonificadas = "dueno";
    }
    
    public override void AgregarCondiciones(View view)
    {
        AddCondition(new SiempreCumple());
    }
    
    public override void CumpleCondiciones(Unit owner, View view)
    {
        CalculateBonusOrPenalty(view);

        VerificarYActivar(view);
    }
    private void CalculateBonusOrPenalty(View view)
    {
        

        int defensaPorunocoma5 = (int)Math.Truncate((double)(Owner.BaseDefense * 1.5));
        int valor_aregado = defensaPorunocoma5 - Owner.BaseAttack;

        if (valor_aregado >= 0)
        {
            _effects = new MultiEffect(
                new BonusEffect(StatType.Atk, valor_aregado)
            );
        }
        else
        {
            _effects = new MultiEffect(
                new PenaltyEffect(StatType.Atk, (-1 * valor_aregado))
            );
        }
      

        
    }
}