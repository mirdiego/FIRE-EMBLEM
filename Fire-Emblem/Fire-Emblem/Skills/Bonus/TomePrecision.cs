using Fire_Emblem_View;
using Fire_Emblem.Effects;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills.Factory;

using Fire_Emblem;



public class TomePrecision : Skill
{


    public TomePrecision()
        : base("Tome Precision")

    {
        attackType = AttackType.All;
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(attackType);
        UnidadesAfectadas = AffectedUnit.Owner;
        _effects = new MultiEffect(
            new BonusEffect(StatType.Atk, 6), new BonusEffect(StatType.Spd, 6)
        );
    }
    
    public override void AgregarCondiciones(View view)
    {
        AddCondition(new UsaMagia(Owner));
    }




    public override void CumpleCondiciones(Unit owner, View view)
    {
        VerificarYActivar(view); // Verifica las condiciones y activa si es necesario
    }
}