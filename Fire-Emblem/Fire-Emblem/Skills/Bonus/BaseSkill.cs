using Fire_Emblem_View;

namespace Fire_Emblem.Skills
{
    public class BaseSkill
    {
        public string Name { get; private set; }
        public bool IsActive { get; private set; }

        public BaseSkill(string name)
        {
            Name = name;
            IsActive = false; // Las habilidades comienzan como inactivas por defecto.
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        // public abstract void ApplyEffect(Combat context, View view);
        // public abstract void RevertEffect(Combat context, View view);
    }
}