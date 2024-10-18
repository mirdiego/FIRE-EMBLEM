using Fire_Emblem_View;
using Fire_Emblem.Effects;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills.Factory;

using Fire_Emblem;



public class BrazenAtkSpd : Skill
{


    public BrazenAtkSpd()
        : base("Brazen Atk/Spd")

    {
        tipo_de_ataque = "todos";
        // Inicializar los tipos de ataque válidos
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(tipo_de_ataque);
        UnidadesBonificadas = "dueno";
        




        _effects = new MultiEffect(
            new BonusEffect(StatType.Atk, 10),
            new BonusEffect(StatType.Spd, 10)
            
            
        );
    }
    
    public override void AgregarCondiciones(View view)
    {
        // Agregar la condición IniciaCombate
        AddCondition(new PorcentajeDeStatBase(0.8, StatType.Hp, Operadores.LessOrEqual));
    }




    public override void CumpleCondiciones(Unit owner, View view)
    {
        VerificarYActivar(view); // Verifica las condiciones y activa si es necesario
    }
}