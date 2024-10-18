using Fire_Emblem;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Fire_Emblem.Weapon;
using Fire_Emblem_View;
using Fire_Emblem.Skills;


namespace Fire_Emblem
{
    public class Unit
    {
        [JsonPropertyName("Name")] public string Name { get; set; }
        [JsonPropertyName("Weapon")] public string WeaponType { get; set; }
        [JsonIgnore] public Weapon.Weapon Weapon => new Weapon.Weapon(WeaponType);
        [JsonPropertyName("Gender")] public string Gender { get; set; }
        [JsonPropertyName("DeathQuote")] public string DeathQuote { get; set; }

        private string hpString; // Campo privado para el manejo interno de HP como string

        [JsonPropertyName("HP")]
        public string HpString
        {
            get => hpString;
            set
            {
                hpString = value;
                if (int.TryParse(hpString, out var result))
                {
                    MaxHP = result;
                    CurrentHP = MaxHP;
                    BaseMaxHP = result; // Asigna el valor del HP deserializado como base.
                }
                else
                {
                    MaxHP = 0;
                    CurrentHP = 0;
                    BaseMaxHP = 0;
                }
            }
        }

        public int BaseMaxHP { get; private set; } // Valor base de MaxHP
        public int MaxHP { get; private set; }
        public int CurrentHP { get; set; }

        private string attackString;

        [JsonPropertyName("Atk")]
        public string AttackString
        {
            get => attackString;
            set
            {
                attackString = value;
                if (int.TryParse(attackString, out var result))
                {
                    Attack = result;
                    BaseAttack = result; // Asigna el valor del ataque deserializado como base.
                }
                else
                {
                    Attack = 0;
                    BaseAttack = 0;
                }
            }
        }

        public int BaseAttack { get; private set; } // Valor base de Attack
        public int Attack { get; private set; }

        private string speedString;

        [JsonPropertyName("Spd")]
        public string SpeedString
        {
            get => speedString;
            set
            {
                speedString = value;
                if (int.TryParse(speedString, out var result))
                {
                    Speed = result;
                    BaseSpeed = result; // Asigna el valor de la velocidad deserializado como base.
                }
                else
                {
                    Speed = 0;
                    BaseSpeed = 0;
                }
            }
        }

        public int BaseSpeed { get; private set; } // Valor base de Speed
        public int Speed { get; private set; }

        private string defenseString;

        [JsonPropertyName("Def")]
        public string DefenseString
        {
            get => defenseString;
            set
            {
                defenseString = value;
                if (int.TryParse(defenseString, out var result))
                {
                    Defense = result;
                    BaseDefense = result; // Asigna el valor de la defensa deserializado como base.
                }
                else
                {
                    Defense = 0;
                    BaseDefense = 0;
                }
            }
        }

        public int BaseDefense { get; private set; } // Valor base de Defense
        public string LastOponentName { get; set; }

        public int Defense { get; private set; }


        private string resistanceString;

        [JsonPropertyName("Res")]
        public string ResistanceString
        {
            get => resistanceString;
            set
            {
                resistanceString = value;
                if (int.TryParse(resistanceString, out var result))
                {
                    Resistance = result;
                    BaseResistance = result; // Asigna el valor de la resistencia deserializado como base.
                }
                else
                {
                    Resistance = 0;
                    BaseResistance = 0;
                }
            }
        }

        public int BaseResistance { get; private set; } // Valor base de Resistance
        public int Resistance { get; private set; }


        public bool IsAlive { get; set; } = true;

        public List<Skill> Skills { get; private set; }




        // Constructor sin parámetros que inicializa la lista de habilidades
        public Unit()
        {
            Skills = new List<Skill>();
        }


        // Método para agregar habilidades a la unidad, evitando duplicados
        public Unit Clone()
        {
            return new Unit
            {
                Name = this.Name,
                WeaponType = this.WeaponType,
                Gender = this.Gender,
                DeathQuote = this.DeathQuote,
                MaxHP = this.MaxHP,
                CurrentHP = this.CurrentHP,
                Attack = this.Attack,
                Defense = this.Defense,
                Speed = this.Speed,
                Resistance = this.Resistance,
                BaseMaxHP = this.BaseMaxHP,
                BaseAttack = this.BaseAttack,
                BaseDefense = this.BaseDefense,
                BaseSpeed = this.BaseSpeed,
                BaseResistance = this.BaseResistance,
                Skills = new List<Skill>(this.Skills),
            };
        }


        public bool CanBeSelected
        {
            get
            {
                // Aquí puedes añadir más lógica si hay otros criterios para que una unidad pueda ser seleccionada
                return IsAlive;
            }
        }

        // Método para agregar habilidades a la unidad, evitando duplicados

        public void AddSkill(string skillName, View view)
        {
            try
            {
                Skill skill = SkillFactory.CreateSkill(skillName, view);
                skill.SetOwner(this, view);
                Skills.Add(skill);

            }
            catch (ArgumentException)
            {
                // Imprime un mensaje de error y lanza una excepción genérica
                throw new ArgumentException("Archivo de equipos no válido");

            }
        }
        

        public void PrepareSkills(View view)
        {
            foreach (Skill skill in Skills)
            {
                skill.CalculateBonus(view);
            }
        }

        public void CheckConditions(View view)
        {
            foreach (var skill in Skills)
            {
                skill.CumpleCondiciones(this, view);
            }
        }

        public Unit Opponent { get; set; }

        public void AttackOpponent(Combat combat, View EstaView)
        {
            int damage = CalculateDamage(combat);
            combat.Output.SaveAttack(combat, damage);

            ApplyDamage(damage);
        }

        private int CalculateDamage(Combat combat)
        {
            double baseDamage = CalculateBaseDamage(combat);
            int defense = GetDefenseBasedOnWeaponType(combat.Defender, combat.Attacker.WeaponType);
            int damage = Math.Max(0, Convert.ToInt32(Math.Floor(baseDamage)) - defense);
            return damage;
        }

        private double CalculateBaseDamage(Combat combat)
        {
            double weaponTriangleBonus =
                WeaponController.GetWeaponTriangleBonusAgainst(combat.Attacker.Weapon, combat.Defender.Weapon);
            if (combat.Attacktype[combat.Attackposition] == "first attack")
            {
                SaveBonusAdvantage(weaponTriangleBonus, combat);
            }

            return combat.Attacker.Attack * weaponTriangleBonus;
        }

        private void SaveBonusAdvantage(double weaponTriangleBonus, Combat combat)
        {
            combat.Output.SaveTriangleBonus(weaponTriangleBonus, combat);

        }

        private int GetDefenseBasedOnWeaponType(Unit defender, string attackerWeaponType)
        {
            return attackerWeaponType == "Magic" ? defender.Resistance : defender.Defense;
        }

        private void ApplyDamage(int damage)
        {
            Opponent.CurrentHP -= damage;
            if (Opponent.CurrentHP <= 0)
            {
                Opponent.CurrentHP = 0;
                Opponent.IsAlive = false;
            }
        }

        public void DecreaseStat(StatType stat, int value)
        {
            switch (stat)
            {
                case StatType.Atk:
                    Attack -= value;
                    PenaltyAttack += value;
                    break;
                case StatType.Def:
                    Defense -= value;
                    PenaltyDefense += value;
                    break;
                case StatType.Res:
                    Resistance -= value;
                    PenaltyResistance += value;
                    break;
                case StatType.Spd:
                    Speed -= value;
                    PenaltySpeed += value;
                    break;
                case StatType.MaxHP:
                    MaxHP -= value;
                    PenaltyMaxHP += value;
                    break;
                default:
                    throw new ApplicationException("Tipo de estadística no válido.");
            }
        }
        public void IncreaseStat(StatType stat, int value)
        {
            switch (stat)
            {
                case StatType.Atk:
                    Attack += value;
                    BonusAttack += value;
                    break;
                case StatType.Def:
                    Defense += value;
                    BonusDefense += value;
                    break;
                case StatType.Res:
                    Resistance += value;
                    BonusResistance += value;
                    break;
                case StatType.Spd:
                    Speed += value;
                    BonusSpeed += value;
                    break;
                case StatType.MaxHP:
                    MaxHP += value;
                    BonusMaxHP += value;
                    break;
                default:
                    throw new ApplicationException("Tipo de estadística no válido.");
            }
        }




        public void IncreaseAttack(int value)
        {
            Attack += value;
            BonusAttack += value;
        }

        public void IncreaseDefense(int value)
        {
            BonusDefense += value;
            Defense += value;
        }

        public void IncreaseSpeed(int value)
        {
            BonusSpeed += value;
            Speed += value;
        }

        public void IncreaseResistance(int value)
        {
            BonusResistance += value;

            Resistance += value;
        }

        public void IncreaseCurrentHP(int value)
        {
            CurrentHP += value;
            BonusHP += value;

        }

public void IncreaseMaxHP(int value)
        {
            BonusMaxHP += value;
            MaxHP += value;
            CurrentHP += value; // Suponiendo que deseas aumentar la HP actual junto con el MaxHP
        }

        public int BonusAttack;
        public int BonusDefense;
        public int BonusSpeed;
        public int BonusResistance;
        public int BonusHP;
        public int BonusMaxHP;
        
        public int PenaltyAttack;
        public int PenaltyDefense;
        public int PenaltySpeed;
        public int PenaltyResistance;
        public int PenaltyHP;
        public int PenaltyMaxHP;
        public void InicializarStatsParaRonda()
        {
            Attack = BaseAttack;
            Defense = BaseDefense;
            Speed = BaseSpeed;
            Resistance = BaseResistance;
            MaxHP = BaseMaxHP;
            
        }
        public Combat CurrentCombat { get; set; }

        public void SetCombat(Combat combat, View view)
        {
            CurrentCombat = combat;
        }
        public bool IsStarter { get; set; }

        public void SetStarter()
        {
            
            IsStarter = true;
        }
        public void SetNotStarter()
        {
            IsStarter = false;
        }

        public void PrintStats(View view)
        {
            view.WriteLine($"Nombre: {Name}");
            view.WriteLine($"HP: {CurrentHP}/{MaxHP}");
            view.WriteLine($"Ataque: {Attack}");
            view.WriteLine($"Defensa: {Defense}");
            view.WriteLine($"Velocidad: {Speed}");
            view.WriteLine($"Resistencia: {Resistance}");
        }

        public void PrintBaseStats(View view)
        {
            view.WriteLine("Las stats base son:");
            view.WriteLine("Ataque: " + BaseAttack);
            view.WriteLine("Defensa: " + BaseDefense);
            view.WriteLine("Velocidad: " + BaseSpeed);
            view.WriteLine("Resistencia: " + BaseResistance);
            view.WriteLine("HP: " + BaseMaxHP);
        }

    }
}