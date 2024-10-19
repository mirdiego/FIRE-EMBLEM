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
            IsActive = false; 
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

    }
}