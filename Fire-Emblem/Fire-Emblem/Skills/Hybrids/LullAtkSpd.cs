using Fire_Emblem_View;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.Neutralizer;
using FireEmblem.Effects;

namespace Fire_Emblem.Skills;

public class LullAtkSpd : Skill
{
    public LullAtkSpd()
        : base("Lull Atk/Spd")

    {
        tipo_de_ataque = "todos";
        // Inicializar los tipos de ataque válidos
        _ValidAttackType = AttackTypeValidator.GetAttackTypes(tipo_de_ataque);
        UnidadesBonificadas = "oponente";
        _effects = new MultiEffect(
            new PenaltyEffect(StatType.Atk, 3),
            new PenaltyEffect(StatType.Spd, 3),
            new BonusStatNeutralizer(StatType.Atk),
            new BonusStatNeutralizer(StatType.Spd)

            
            
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