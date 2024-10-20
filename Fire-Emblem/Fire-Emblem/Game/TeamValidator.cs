using System.Text.Json;
using Fire_Emblem_View;
using Fire_Emblem.Teams;

namespace Fire_Emblem.Game;

public static class TeamValidator
{
    public static void ValidateTeams(List<Team> teams, View _view)
    {

        bool validTeams = true;
        foreach (Team team1 in teams)
        {

            team1.HasValidNumberOfUnits(_view);
            team1.HasUniqueUnits(_view);
            team1.AllUnitsHaveValidSkills(_view);
            
        }
    }
    
}