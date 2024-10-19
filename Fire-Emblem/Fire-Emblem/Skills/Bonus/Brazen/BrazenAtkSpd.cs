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
        attackType = AttackType.All;
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(attackType);
        UnidadesAfectadas = AffectedUnit.Owner;
        _effects = new MultiEffect(
            new BonusEffect(StatType.Atk, 10),
            new BonusEffect(StatType.Spd, 10)
        );
    }
    
    public override void AgregarCondiciones(View view)
    {
        AddCondition(new PorcentajeDeStatBase(0.8, StatType.Hp, Operadores.LessOrEqual));
    }




    public override void CumpleCondiciones(Unit owner, View view)
    {
        VerificarYActivar(view); // Verifica las condiciones y activa si es necesario
    }
}