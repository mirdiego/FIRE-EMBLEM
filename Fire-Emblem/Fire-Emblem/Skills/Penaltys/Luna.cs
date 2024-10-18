using Fire_Emblem_View;
using Fire_Emblem.Effects;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class Luna : Skill
{


    public Luna()
        : base("Luna")

    {
        tipo_de_ataque = "primero";
        // Inicializar los tipos de ataque válidos
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(tipo_de_ataque);
        UnidadesBonificadas = "oponente";
        _effects = new MultiEffect(
            new PenaltyPercentageInRivalStat(StatType.Def, StatType.Def),
            new PenaltyPercentageInRivalStat(StatType.Res, StatType.Res)
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