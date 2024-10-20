using Fire_Emblem_View;

namespace Fire_Emblem.Teams;

public class TeamController
{
    private Team team;
    public TeamController(Team _team)
    {
        team = _team;
    }

    public bool HasAliveUnits()
    {
        return team.Units.Any(u => u.IsAlive);
    }

    public void AddUnit(Unit unit)
    {

            team.Units.Add(unit);
        
    }
    
    public void HasUniqueUnits(View view)
    {
        var unitNames = new HashSet<string>();
        if (!(team.Units.All(unit => unitNames.Add(unit.Name))))
        {
            throw new ArgumentException();

        }
    }

    public void AllUnitsHaveValidSkills(View view)
    {
        if (!(team.Units.All(unit =>
                unit.Skills.Count <= 2 && unit.Skills.Count == unit.Skills.Distinct().Count())))
        {
            throw new ArgumentException();
        }
        
        foreach (Unit checkedunit in team.Units)
        {
            foreach (Skill skill in checkedunit.Skills)
            {
                foreach (Skill skill2 in checkedunit.Skills)
                {
                    if ((skill != skill2) && skill.Name == skill2.Name)
                    {
                        throw new ArgumentException();
                    }
                }
            }
        }
        
    }

    public void HasValidNumberOfUnits(View view)
    {
        if (!(team.Units.Count >= 1 && team.Units.Count <= 3))
        {
            throw new ArgumentException();

        }
    }

    public void SelectUnit(View view)
    {
        PrintUnitNames(view);
        TrySelectUnit(view);
    }

    private void PrintUnitNames(View view)
    {
        for (int i = 0; i < team.Units.Count; i++)
        {
            if (team.Units[i].CanBeSelected)
            {
                view.WriteLine($"{i}: {team.Units[i].Name}");
            }
        }
    }
    private void TrySelectUnit(View view)
    {
        int input = Convert.ToInt32(view.ReadLine());
        if (input < 0 || input >= team.Units.Count || !team.Units[input].IsAlive)
        {
            view.WriteLine("Unidad no válida");
            team.SelectedUnit = null;
        }
        else
        {
            team.SelectedUnit = team.Units[input];
        }
    }

    public void RemoveDefeatedUnits()
    {
        team.Units.RemoveAll(u => !u.IsAlive);
    }
    
}