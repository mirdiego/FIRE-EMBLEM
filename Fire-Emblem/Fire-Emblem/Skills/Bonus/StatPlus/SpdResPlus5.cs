using Fire_Emblem_View;
using Fire_Emblem.Effects;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class SpdResPlus5 : Skill
{


    public SpdResPlus5()
        : base("Spd/Res +5")

    {
        attackType = AttackType.All;
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(attackType);
        UnidadesAfectadas = AffectedUnit.Owner;
        _effects = new MultiEffect(
            new BonusEffect(StatType.Res, 5),
            new BonusEffect(StatType.Spd, 5)
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