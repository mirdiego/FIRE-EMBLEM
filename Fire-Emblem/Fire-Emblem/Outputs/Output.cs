using System.Collections.Specialized;
using Fire_Emblem_View;
using Fire_Emblem.Outputs;

namespace Fire_Emblem;

public class Output
{
    public string FollowUpMessage { get; set; }
    // lista para los ataques
    public AttackOutput Attacks { get; set; }
    // lista para los daños
    public DamageOutput Damages { get; set; }
    // lista para bonus
    public TriangleBonus Triangle { get; set; }
    // lista para penaltys
    public PenaltyOutput Penaltys { get; set; }
    // lista neutralizacion de bonus
    public NeutralizationBonusOutput NeutralizationBonus { get; set; }
    // lista neutralizacion de penaltys
    public NeutralizationPenaltyOutput NeutralizationPenaltys { get; set; }
    // lista de habilidades activadas
    public SkillOutput Skills { get; set; }
    // lista de habilidades activadas
    public string AdvantageOutput { get; set; }
    
    private View EstaView { get; set; }
    
    public string Result { get; set; }
    
    public Output(View view)
    {
        Attacks = new AttackOutput();
        Damages = new DamageOutput();
        Triangle = new TriangleBonus();
        Penaltys = new PenaltyOutput();
        NeutralizationBonus = new NeutralizationBonusOutput();
        NeutralizationPenaltys = new NeutralizationPenaltyOutput();
        Skills = new SkillOutput();
        AdvantageOutput = "";
        EstaView = view;
    }
    public void AddNeutralizationBonus(string playerName, bool isStarter)
    {
        NeutralizationBonus.AddMessage( playerName, isStarter);
    }
    public void AddEspecificNeutralizationBonus(string playerName, bool isStarter, StatType stat)
    {
        NeutralizationBonus.AddEspecificStatMessage( playerName, isStarter, stat);
    }
    public void AddNeutralizationPenalty(string playerName, bool isStarter)
    {
        NeutralizationPenaltys.AddMessage( playerName, isStarter);
    }

    public void SaveAttack(Combat combat, int damage)
    {
        if (combat.Attacktype[combat.Attackposition] == "first attack")
        {
            Attacks.AddAttackOutputPrimerJugador(combat.Attacker, combat.Defender, damage);
        }
        else if (combat.Attacktype[combat.Attackposition] == "counter attack")
        {
            Attacks.AddAttackOutputSegundoJugador(combat.Attacker, combat.Defender, damage);
        }
        else if (combat.Attacktype[combat.Attackposition] == "first follow up")
        {
            Attacks.AddFollowUpPrimerJugador(combat.Attacker, combat.Defender, damage);
        }
        else if (combat.Attacktype[combat.Attackposition] == "second follow up")
        {
            Attacks.AddFollowUpSegundoJugador(combat.Attacker, combat.Defender, damage);
        }
    }

    public void SaveTriangleBonus(double weaponTriangleBonus, Combat combat)
    {
        Triangle.SaveTriangleBonus(weaponTriangleBonus, combat);

    }

    public void SaveFollowUpMessage()
    {
        FollowUpMessage = $"Ninguna unidad puede hacer un follow up";
    }

    public void SaveResult(Combat combat)
    {
        Result = $"{combat.Starter.Name} ({combat.Starter.CurrentHP}) : {combat.SecondAttacker.Name} ({combat.SecondAttacker.CurrentHP})";
    }

    public void PrintRound(View EstaView)
    {
        EstaView.WriteLine(Triangle.TriangleBonusMessage);
        string firstplayerskillMessages = Skills.GetFirstPlayerCombinedSkillMessages(EstaView);
        if (!string.IsNullOrEmpty(firstplayerskillMessages))
        {
            EstaView.WriteLine(firstplayerskillMessages);
        }
        var secondneutralizationBonusMessages = NeutralizationBonus.GetSecondPlayerMessages();
        foreach (var message in secondneutralizationBonusMessages)
        {
            EstaView.WriteLine(message);
        }
        var secondneutralizationPenaltyMessages = NeutralizationPenaltys.GetSecondPlayerMessages();
        foreach (var message in secondneutralizationPenaltyMessages)
        {
            EstaView.WriteLine(message);
        }
        
        string secondplayerskillMessages = Skills.GetSecondPlayerCombinedSkillMessages(EstaView);
        if (!string.IsNullOrEmpty(secondplayerskillMessages))
        {
            EstaView.WriteLine(secondplayerskillMessages);
        }
        var firstneutralizationBonusMessages = NeutralizationBonus.GetFirstPlayerMessages();
        foreach (var message in firstneutralizationBonusMessages)
        {
            EstaView.WriteLine(message);
        }
        var firstneutralizationPenaltyMessages = NeutralizationPenaltys.GetFirstPlayerMessages();
        foreach (var message in firstneutralizationPenaltyMessages)
        {
            EstaView.WriteLine(message);
        }

        Attacks.PrintAttackOutput(EstaView);
        if (FollowUpMessage != null)
        {
            EstaView.WriteLine(FollowUpMessage);
        }

        EstaView.WriteLine(Result);
        
        
    }
}