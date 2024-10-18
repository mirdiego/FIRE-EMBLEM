using Fire_Emblem_View;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Neutralizer;
using FireEmblem;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

using Fire_Emblem;



public class CloseDef : Skill
{


    public CloseDef()
        : base("Close Def")

    {
        tipo_de_ataque = "todos";
        // Inicializar los tipos de ataque válidos
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(tipo_de_ataque);
        UnidadesBonificadas = "dueno";
        _effects = new MultiEffect(
            new BonusEffect(StatType.Def, 8),
            new BonusEffect(StatType.Res, 8),
            new BonusNeutralizer()
            
            
        );
        
    }
    
    public override void AgregarCondiciones(View view)
    {
        AddCondition(new RivalIniciaCombate(Owner, Owner.CurrentCombat));
        AddOptionalCondition(new RivalUsaArma(Owner, "Sword"));
        AddOptionalCondition(new RivalUsaArma(Owner, "Axe"));
        AddOptionalCondition(new RivalUsaArma(Owner, "Lance"));


    }
    
    public override void CumpleCondiciones(Unit owner, View view)
    {

        VerificarYActivar(view);
    }

}