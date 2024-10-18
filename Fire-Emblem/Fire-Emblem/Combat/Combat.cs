using Fire_Emblem_View;
using Fire_Emblem.Effects;

namespace Fire_Emblem;

public class Combat
{
    public Unit Starter { get; set; }
    public Unit SecondAttacker { get; set; }
    public Unit Attacker { get; set; }
    public Unit Defender { get; set; }
    View View { get; set; }
    CombatController combatController { get; set; }
    public Output Output { get; set; }
    public List<string> Attacktype { get; set; }
    
    public int Attackposition { get; set; }
    Unit Winner { get; set; }
    
    public List<Unit> Units { get; set; }
    
    public Combat(Unit attacker, Unit defender, View view)
    {
        Attacker = attacker;
        Defender = defender;
        View = view;
        Output = new Output(view);
        Attacktype = ["first attack", "counter attack", "first follow up", "second follow up", "finished combat"];
        Attackposition = 0;
        Starter = attacker;
        SecondAttacker = defender;
        Winner = null;
        Attacker.IsStarter = true;
        Defender.IsStarter = false;
        Units = new List<Unit> {Attacker, Defender};
    }
    
    public void StartRound()
    {
        PrepareRound();
        ComenzarRonda();
        GuardarMensajeSiNoHayFollowUp();
        InicializarStatsParaRonda();
        SetAsLastOpponents();
        Output.SaveResult(this);
        Output.PrintRound(View);
    }

    public void PrepareRound()
    {
        PrepareSkills();
        Attacker.SetCombat(this, View);
        Defender.SetCombat(this, View);
        CheckConditions();
    }

    private void PrepareSkills()
    {
        foreach (Unit player in Units)
        {
            player.PrepareSkills(View);
        }
    }

    private void CheckConditions()
    {
        foreach (Unit player in Units)
        {
            player.CheckConditions(View);

        }
    }
    
    public void ComenzarRonda()
    {
        while (Attacktype[Attackposition] != "finished combat")
        {
            switch (Attacktype[Attackposition])
            {
                case "first attack":
                    PerformAttack();
                    break;
                case "counter attack":
                    PerformAttack();
                    break;
              
                case "first follow up":
                    PerformFirstFollowUp();
                    break;
                case "second follow up":
                    PerformSecondFollowUp();
                    break;
            }
        }
    }
    private void PerformAttack()
    {
        ExecuteAttack();
        FinishAttack();
    }

    private void PerformFirstFollowUp()
    {
        if (FirstHasFollowUp())
        {
            ExecuteAttack();
        }

        FinishAttack();
        
    }
    private void PerformSecondFollowUp()
    {
        if (SecondHasFollowUp())
        {
            ExecuteAttack();
        }

        FinishAttack();
    }

    private void ExecuteAttack()
    {
       
        InicializarStatsParaRonda();
        AplicarSkills();
        Attacker.AttackOpponent( this, View);
        
    }

    private void GuardarMensajeSiNoHayFollowUp()
    {
        if ((!FirstHasFollowUp() & !SecondHasFollowUp()) && Winner == null)
        {
            Output.SaveFollowUpMessage();
        }
    }

    private void InicializarStatsParaRonda()
    {
        Attacker.InicializarStatsParaRonda();
        Defender.InicializarStatsParaRonda();
    }



    private void AplicarSkills()
    {
        foreach (Unit player in Units)
        {
            foreach (var skill in player.Skills)
            {
                if (skill.activo)
                {
                    skill.Apply(View, Attacktype[Attackposition], Output);
     
                }
            }
        }
    }

    private void FinishAttack()
    {
        if (!Defender.IsAlive)
        {
            Winner = Attacker;
            Attackposition = 4;
        }
        else
        {
            Attackposition++;
            SwapRoles();
        }
    }
    private void SwapRoles()
    {
        Unit temp = Attacker;
        Attacker = Defender;
        Defender = temp;
    }
    
    public bool FirstHasFollowUp()
    {
        return Starter.Speed - SecondAttacker.Speed >= 5;
    }
    public bool SecondHasFollowUp()
    {
        return SecondAttacker.Speed - Starter.Speed >= 5;
    }

    public void SetAsLastOpponents()
    {
        Attacker.LastOponentName = Defender.Name;
        Defender.LastOponentName = Attacker.Name;
    }

    public void DebugStatsyBonus()
    {
        View.WriteLine("Las stats del atacker son:");
        View.WriteLine("El ataque es: " + Attacker.Attack);
        View.WriteLine("La defensa es: " + Attacker.Defense);
        View.WriteLine("La resistencia es: " + Attacker.Resistance);
        View.WriteLine("La velocidad es: " + Attacker.Speed);
        View.WriteLine("El hp es: " + Attacker.CurrentHP);
        View.WriteLine("El hp base maximo es: " + Attacker.BaseMaxHP);
        View.WriteLine("El hp maximo es: " + Attacker.MaxHP);
        View.WriteLine("Las stats del defensor son:");
        View.WriteLine("El ataque es: " + Defender.Attack);
        View.WriteLine("La defensa es: " + Defender.Defense);
        View.WriteLine("La resistencia es: " + Defender.Resistance);
        View.WriteLine("La velocidad es: " + Defender.Speed);
        
        View.WriteLine("El hp es: " + Defender.CurrentHP);
        View.WriteLine("El hp base maximo es: " + Defender.BaseMaxHP);
        View.WriteLine("El hp maximo es: " + Defender.MaxHP);
    }
    
}