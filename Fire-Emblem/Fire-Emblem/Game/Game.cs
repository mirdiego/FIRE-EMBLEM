using System.Text.Json;
using Fire_Emblem_View;
using Fire_Emblem.Game;
using Fire_Emblem.Teams;

namespace Fire_Emblem.Name;

public class Game
{
    private View _view;
    private string _teamsFolder;
    private string _charactersFilePath = @"..\..\Debug\net8.0\characters.json";
    public List<Unit> Units { get; private set; } = new List<Unit>();
    
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
    }

    public void Play()
    {
        string teamFileName = GetTeamNumber();
        string teamFileNumber = Path.GetFileNameWithoutExtension(teamFileName);
        try
        {
            List<Team> teams = CreateTeams(teamFileNumber);
            TeamValidator.ValidateTeams(teams, _view);
            StartFight(teams);
        }
        catch (Exception )
        {
            _view.WriteLine("Archivo de equipos no válido");
        }
    }
    private string GetTeamNumber()
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        string[] files = Directory.GetFiles(_teamsFolder);
        ShowFiles(files);
        int input = Convert.ToInt32(_view.ReadLine());
        return files[input]; 
    }

    private void ShowFiles(string[] files)
    {
        for (int i = 0; i < files.Length; i++)
        {
            string fileName = Path.GetFileName(files[i]);
            _view.WriteLine($"{i}: {fileName}");
        }
    }

    private List<Team> CreateTeams(string teamNumber)
    {
        TeamBuilder teamBuilder = new TeamBuilder(teamNumber, _teamsFolder, _charactersFilePath, _view);
        List<Team> teams = teamBuilder.AddUnitsToTeams( _view);
        return teams;
    }

    private void StartFight(List<Team> teams)
    {
        Fight fight = new Fight(teams, _view);
        fight.StartFight(_view);
    }
}

