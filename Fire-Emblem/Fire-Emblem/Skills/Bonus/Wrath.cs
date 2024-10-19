using Fire_Emblem_View;
using Fire_Emblem.Effects;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class Wrath : Skill
{


    public Wrath()
        : base("Wrath")

    {
        attackType = AttackType.All;
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(attackType);
        UnidadesAfectadas = AffectedUnit.Owner;
        _effects = new MultiEffect(
            new BonusPercentageInAnotherStatEffect(StatType.Atk, 1, StatType.MaxHP),
            new BonusPercentageInAnotherStatEffect(StatType.Spd, 1, StatType.MaxHP)
            
        );
    }
    
    public override void AgregarCondiciones(View view)
    {
        AddCondition(new SiempreCumple());

    }




    public override void CumpleCondiciones(Unit owner, View view)
    {
        VerificarYActivar(view); // Verifica las condiciones y activa si es necesario
    }
}