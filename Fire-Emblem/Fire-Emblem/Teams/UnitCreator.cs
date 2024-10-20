using Fire_Emblem_View;

namespace Fire_Emblem.Teams;

public class UnitCreator
{
    private string unitName;
    private string[] skills;
    private Team team;
    private List<Unit> characters;
        
    public UnitCreator(string line, List<Unit> _characters, Team team)
    {
        var parts = line.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        unitName = parts[0].Trim();
        skills = parts.Length > 1 ? parts[1].Split(',') : new string[0];
        characters = _characters;
        this.team = team;
        
    }

    public void CloneUnit(View _view)
    {

        var unit = characters.Find(c => c.Name == unitName);
        if (unit != null)
        {
            AddToTeam(unit, _view);
        }
        else
        {
            throw new ArgumentException();
        }
    }

    private void AddToTeam(Unit unit, View _view)
    {
        var clonedUnit = unit.Clone();
        foreach (var skillName in skills)
        {
            clonedUnit.AddSkill(skillName.Trim(), _view);
        }

        team.AddUnit(clonedUnit);
    }
}