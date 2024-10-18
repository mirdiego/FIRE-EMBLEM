using System.Text.Json;
using Fire_Emblem_View;
using Fire_Emblem.Teams;

namespace Fire_Emblem;

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
            if (!ValidateTeams(teams))
            {
                throw new ArgumentException("Archivo de equipos no válido");
            }
            else
            {
                StartFight(teams);
            }
            



        }
        
        catch
        {
            _view.WriteLine("Archivo de equipos no válido");
        }
    }
    private string GetTeamNumber()
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        string[] files = Directory.GetFiles(_teamsFolder);
        for (int i = 0; i < files.Length; i++)
        {
            string fileName = Path.GetFileName(files[i]);
            _view.WriteLine($"{i}: {fileName}");
        }
        int input = Convert.ToInt32(_view.ReadLine());

        return files[input]; // Devuelve el nombre del archivo completo
    }
    private bool ValidateTeams(List<Team> teams)
    {

        try
        {
            bool validTeams = true;
            foreach (Team team1 in teams)
            {

                if ((team1.HasValidNumberOfUnits(_view)) && (team1.HasUniqueUnits(_view)) &&
                    (team1.AllUnitsHaveValidSkills(_view)))
                {
                    validTeams = true;
                }
                else
                {
                    {
                        validTeams = false;
                    }
                }
            }

            return validTeams;
            
        }
        catch (Exception)
        {
            throw new ArgumentException("Archivo de equipos no válido");
        }
    }
    private List<Team> CreateTeams(string teamNumber)
    {
        List<Team> teams = new List<Team>();
        Team currentTeam = null;
        string teamFile = teamNumber + ".txt";
        string teamFilePath = Path.Combine(_teamsFolder, teamFile);
        string[] teamData = File.ReadAllLines(teamFilePath);
        var characters = JsonSerializer.Deserialize<List<Unit>>(File.ReadAllText(_charactersFilePath));

        foreach (string line in teamData)
        {
            if (line.StartsWith("Player"))
            {
                var playerName = line.Split()[0] + " " + line.Split()[1];
                currentTeam = new Team(playerName);
                teams.Add(currentTeam);
            }
            else if (!string.IsNullOrWhiteSpace(line) && currentTeam != null)
            {
                AddUnitToTeam(line, characters, currentTeam);
            }
            
        }
        
        return teams;
    }
    private void AddUnitToTeam(string line, List<Unit> characters, Team team)
    {
        try
        {
            var parts = line.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            var unitName = parts[0].Trim();
            var skills = parts.Length > 1 ? parts[1].Split(',') : new string[0];
            var unit = characters.Find(c => c.Name == unitName);
            if (unit != null)
            {
                var clonedUnit = unit.Clone(); // Crea una copia de la unidad
                foreach (var skillName in skills)
                {
                    clonedUnit.AddSkill(skillName.Trim(), _view); // Agrega las habilidades a la unidad clonada
                }
                team.AddUnit(clonedUnit); // Agrega la unidad clonada al equipo
            }
            else
            {
                throw new ArgumentException("Archivo de equipos no válido");
            }
        }
        catch (Exception)
        {
            throw new ArgumentException("Archivo de equipos no válido");
        }
    }
            private void StartFight(List<Team> teams)
        {
            int round = 1;
            while (BothTeamsHaveAliveUnits(teams))
            {
                var attackingTeam = round % 2 != 0 ? teams[0] : teams[1];
                var defendingTeam = round % 2 != 0 ? teams[1] : teams[0];

                // Selecciona la unidad atacante
                _view.WriteLine($"{attackingTeam.Name} selecciona una opción");
                attackingTeam.SelectUnit(_view);
                Unit attackingUnit = attackingTeam.SelectedUnit;
                if (attackingUnit == null)
                {
                    _view.WriteLine($"{defendingTeam.Name} ganó");
                    break;
                }

                // Selecciona la unidad defensora
                _view.WriteLine($"{defendingTeam.Name} selecciona una opción");
                defendingTeam.SelectUnit(_view);
                Unit defendingUnit = defendingTeam.SelectedUnit;
                if (defendingUnit == null)
                {
                    _view.WriteLine($"{attackingTeam.Name} ganó");
                    break;
                }
                attackingTeam.SelectedUnit.Opponent = defendingUnit;
                defendingTeam.SelectedUnit.Opponent = attackingUnit;

                // Inicia el combate
                _view.WriteLine($"Round {round}: {attackingUnit.Name} ({attackingTeam.Name}) comienza");
                var combat = new Combat(attackingUnit, defendingUnit, _view);
                combat.StartRound();

                // Eliminar unidades derrotadas de sus equipos
                attackingTeam.RemoveDefeatedUnits();
                defendingTeam.RemoveDefeatedUnits();

                round++;
            }
        }

        private bool BothTeamsHaveAliveUnits(List<Team> teams)
        {
            // Verifica si ambos equipos tienen unidades vivas
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
        
    }

