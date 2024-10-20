using Fire_Emblem_View;

namespace Fire_Emblem;

public class SkillController
{
    private readonly Combat _combat;

    public SkillController(Combat combat)
    {
        _combat = combat;
    }

    public void PrepareSkills(View view)
    {
        foreach (Unit player in _combat.Units)
        {
            player.PrepareSkills(view);
        }
    }

    public void CheckConditions(View view)
    {
        foreach (Unit player in _combat.Units)
        {
            player.CheckConditions(view);
        }
    }
    public void PrepareSkills(Unit unit, View view)
    {
        foreach (Skill skill in unit.Skills)
        {
            skill.CalculateBonus(view);
        }
    }

    public void CheckConditions(Unit unit, View view)
    {
        foreach (Skill skill in unit.Skills)
        {
            skill.CumpleCondiciones(unit, view);
        }
    }


}