using System.Text.Json;
using Fire_Emblem;
using Fire_Emblem_View;
using Fire_Emblem.Teams;

public class TeamBuilder
{
    private  string[] teamData;
    private  Team currentTeam;
    private  List<Unit> characters;
    private List<Team> teams;
    

    public TeamBuilder(string teamNumber, string _teamsFolder, string _charactersFilePath, View _view)
    {
        currentTeam = null;
        string teamFile = teamNumber + ".txt";
        string teamFilePath = Path.Combine(_teamsFolder, teamFile);
        teamData = File.ReadAllLines(teamFilePath);
        characters = JsonSerializer.Deserialize<List<Unit>>(File.ReadAllText(_charactersFilePath));
        teams = new List<Team>();
    }
    
    public List<Team> AddUnitsToTeams(View view)
    {
        foreach (string line in teamData)
        {
            CheckLines(line, view);
        }
        return teams;
    }

    private void CheckLines(string line, View view)
    {
        if (line.StartsWith("Player"))
        {
            var playerName = line.Split()[0] + " " + line.Split()[1];
            currentTeam = new Team(playerName);
            teams.Add(currentTeam);
        }
        else if (!string.IsNullOrWhiteSpace(line) && currentTeam != null)
        {
            AddUnitToTeam(line, characters, currentTeam,view);
        }
    }
    private void AddUnitToTeam(string line, List<Unit> characters, Team team, View _view)
    {
            UnitCreator unitCreator = new UnitCreator(line, characters, team);
            unitCreator.CloneUnit(_view);
    }
}