
using Fire_Emblem_View;
using Fire_Emblem.Exceptions;
using Fire_Emblem.Teams;

namespace Fire_Emblem.Game;

public class Fight
{
    private int round;
    private readonly List<Team> teams;
    private readonly View _view;
    private readonly FightTurnController _fightTurnController;

    public Fight(List<Team> _teams, View view)
    {
        _view = view;
        teams = _teams;
        round = 1;
        _fightTurnController = new FightTurnController();
    }

    public void StartFight(View view)
    {
        while (_fightTurnController.BothTeamsHaveAliveUnits(teams, _view))
        {
            var attackingTeam = _fightTurnController.GetAttackingTeam(teams, round);
            var defendingTeam = _fightTurnController.GetDefendingTeam(teams, round);

            var attackingUnit = _fightTurnController.CheckIfTeamsHaveAliveUnits(attackingTeam, defendingTeam, _view);
            var defendingUnit = _fightTurnController.CheckIfTeamsHaveAliveUnits(defendingTeam, attackingTeam, _view);

            attackingTeam.SelectedUnit.Opponent = defendingUnit;
            defendingTeam.SelectedUnit.Opponent = attackingUnit;

            _view.WriteLine($"Round {round}: {attackingUnit.Name} ({attackingTeam.Name}) comienza");
            var combat = new Combat(attackingUnit, defendingUnit, _view);
            combat.SimulateRound();

            attackingTeam.RemoveDefeatedUnits();
            defendingTeam.RemoveDefeatedUnits();
            round++;
        }
    }
}
