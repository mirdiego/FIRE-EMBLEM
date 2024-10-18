using Fire_Emblem_View;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Neutralizer;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;



public class LullSpdDef : Skill
{
    public LullSpdDef()
        : base("Lull Spd/Def")

    {
        tipo_de_ataque = "todos";
        // Inicializar los tipos de ataque válidos
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(tipo_de_ataque);
        UnidadesBonificadas = "oponente";
        _effects = new MultiEffect(
            new PenaltyEffect(StatType.Spd, 3),
            new PenaltyEffect(StatType.Def, 3),
            new BonusStatNeutralizer(StatType.Spd),
            new BonusStatNeutralizer(StatType.Def)

            
            
        );
        
    }
    
    public override void AgregarCondiciones(View view)
    {
        AddCondition(new SiempreCumple());



    }
    
    public override void CumpleCondiciones(Unit owner, View view)
    {

        VerificarYActivar(view);
    }
}