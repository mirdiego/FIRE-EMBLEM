using Fire_Emblem_View;
using Fire_Emblem.Effects;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class BrazenDefRes : Skill
{


    public BrazenDefRes()
        : base("Brazen Def/Res")

    {
        attackType = AttackType.All;
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(attackType);
        UnidadesAfectadas = AffectedUnit.Owner;
        _effects = new MultiEffect(
            new BonusEffect(StatType.Def, 10),
            new BonusEffect(StatType.Res, 10)
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