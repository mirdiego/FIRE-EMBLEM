using System.Collections.Generic;
using Fire_Emblem_View;
using System.Linq;

namespace Fire_Emblem.Teams
{
    public class Team
    {
        public string Name { get; private set; }
        public List<Unit> Units { get; private set; } 
        public Unit SelectedUnit { get; set; }

        public Team(string name)
        {
            Name = name;
            Units = new List<Unit>();
        }

        public bool HasAliveUnits()
        {
            return Units.Any(u => u.IsAlive);
        }

        public void AddUnit(Unit unit)
        {

                Units.Add(unit);
            
        }
        
        public void HasUniqueUnits(View view)
        {
            var unitNames = new HashSet<string>();
            if (!(Units.All(unit => unitNames.Add(unit.Name))))
            {
                throw new ArgumentException();

            }
        }

        public void AllUnitsHaveValidSkills(View view)
        {
            if (!(Units.All(unit =>
                    unit.Skills.Count <= 2 && unit.Skills.Count == unit.Skills.Distinct().Count())))
            {
                throw new ArgumentException();
            }
            
            foreach (Unit checkedunit in Units)
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
            if (!(Units.Count >= 1 && Units.Count <= 3))
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
            for (int i = 0; i < Units.Count; i++)
            {
                if (Units[i].CanBeSelected)
                {
                    view.WriteLine($"{i}: {Units[i].Name}");
                }
            }
        }
        private void TrySelectUnit(View view)
        {
            int input = Convert.ToInt32(view.ReadLine());
            if (input < 0 || input >= Units.Count || !Units[input].IsAlive)
            {
                view.WriteLine("Unidad no válida");
                SelectedUnit = null;
            }
            else
            {
                SelectedUnit = Units[input];
            }
        }

        public void RemoveDefeatedUnits()
        {
            Units.RemoveAll(u => !u.IsAlive);
        }
    }
}