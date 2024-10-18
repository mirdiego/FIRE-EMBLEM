using Fire_Emblem_View;

namespace Fire_Emblem.Outputs;

public class AttackOutput
{
    public string PrimerJugador { get; set; }
    public string SegundoJugador { get; set; }
    public string FollowUpPrimerJugador { get; set; }
    public string FollowUpSegundoJugador { get; set; }
    
    public void  AddAttackOutputPrimerJugador(Unit attacker, Unit defender, int damage)
    {
        PrimerJugador = $"{attacker.Name} ataca a {defender.Name} con {damage} de daño";
    }
    public void AddAttackOutputSegundoJugador(Unit attacker, Unit defender, int damage)
    {
        SegundoJugador = $"{attacker.Name} ataca a {defender.Name} con {damage} de daño";
    }   
    public void AddFollowUpPrimerJugador(Unit attacker, Unit defender, int damage)
    {
        FollowUpPrimerJugador = $"{attacker.Name} ataca a {defender.Name} con {damage} de daño";;
    }
    public void AddFollowUpSegundoJugador(Unit attacker, Unit defender, int damage)
    {
        FollowUpSegundoJugador = $"{attacker.Name} ataca a {defender.Name} con {damage} de daño";;
    }
    public void PrintAttackOutput(View EstaView)
    {
        if (!string.IsNullOrEmpty(PrimerJugador))
        {
            EstaView.WriteLine(PrimerJugador);
        }

        if (!string.IsNullOrEmpty(SegundoJugador))
        {
            EstaView.WriteLine(SegundoJugador);
        }

        if (!string.IsNullOrEmpty(FollowUpPrimerJugador))
        {
            EstaView.WriteLine(FollowUpPrimerJugador);
        }

        if (!string.IsNullOrEmpty(FollowUpSegundoJugador))
        {
            EstaView.WriteLine(FollowUpSegundoJugador);
        }
    }

}