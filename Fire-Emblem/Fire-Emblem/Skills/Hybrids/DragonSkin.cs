using Fire_Emblem_View;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Neutralizer;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class DragonSkin : Skill
{


    public DragonSkin()
        : base("Dragonskin")

    {
        tipo_de_ataque = "todos";
        // Inicializar los tipos de ataque válidos
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(tipo_de_ataque);
        UnidadesBonificadas = "dueno";
        _effects = new MultiEffect(
            new BonusEffect(StatType.Atk, 6),
            new BonusEffect(StatType.Spd, 6),
            new BonusEffect(StatType.Def, 6),
            new BonusEffect(StatType.Res, 6),
            new BonusNeutralizer()
            
            
        );
        
    }
    
    public override void AgregarCondiciones(View view)
    {
        AddCondition(new SiempreCumple());
        AddOptionalCondition(new RivalIniciaCombate(Owner, Owner.CurrentCombat));
        AddOptionalCondition(new PorcentajeDeStatBaseRival(0.75, StatType.Hp, Operadores.GreaterOrEqual));



    }
    
    public override void CumpleCondiciones(Unit owner, View view)
    {

        VerificarYActivar(view);
    }

}