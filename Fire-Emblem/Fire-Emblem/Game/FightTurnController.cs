using Fire_Emblem_View;
using Fire_Emblem.Teams;
using Fire_Emblem.Exceptions;

namespace Fire_Emblem.Game;

public class FightTurnController
{
    public Team GetAttackingTeam(List<Team> teams, int round)
    {
        return round % 2 != 0 ? teams[0] : teams[1];
    }

    public Team GetDefendingTeam(List<Team> teams, int round)
    {
        return round % 2 != 0 ? teams[1] : teams[0];
    }

    public bool BothTeamsHaveAliveUnits(List<Team> teams, View _view)
    {
        bool team1HasAliveUnits = teams[0].HasAliveUnits();
        bool team2HasAliveUnits = teams[1].HasAliveUnits();

        if (!team1HasAliveUnits)
        {
            _view.WriteLine("Player 2 ganó");
        }
        else if (!team2HasAliveUnits)
        {
            _view.WriteLine("Player 1 ganó");
        }

        return team1HasAliveUnits && team2HasAliveUnits;
    }

    public Unit CheckIfTeamsHaveAliveUnits(Team checkedTeam, Team opponentTeam, View _view)
    {
        _view.WriteLine($"{checkedTeam.Name} selecciona una opción");
        checkedTeam.SelectUnit(_view);
        Unit checkedUnit = checkedTeam.SelectedUnit;

        if (checkedUnit == null)
        {
            throw new MatchFinishedException($"{opponentTeam.Name} ganó", _view);
        }

        return checkedUnit;
    }
}