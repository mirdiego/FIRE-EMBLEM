using Fire_Emblem_View;

namespace Fire_Emblem.Effects.Neutralizer;

public abstract class Neutralizer : Effect
{
    protected List<StatType>_neutralizedStats;

    public Neutralizer()
    {
        _neutralizedStats = new List<StatType>();
    }
    public override void Apply(Unit unit, View view, Output output, Skill skill)
    {
        ApplyEffects(unit, view);
        
    }
    public abstract void ApplyEffects(Unit unit, View view);
    
    public void AddNeutralizedStat(StatType stat)
    {
        _neutralizedStats.Add(stat);
    }
    public List<StatType> GetNeutralizedStats()
    {
        return _neutralizedStats;
    }
}