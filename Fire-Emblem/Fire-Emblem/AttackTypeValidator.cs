namespace Fire_Emblem
{
    public class AttackTypeValidator
    {
        // Método estático que devuelve una lista de tipos de ataque predefinidos
        public static List<string> GetAttackTypes(AttackType tipo)
        {
            return tipo switch
            {
                AttackType.First => new List<string> { "first attack", "counter attack" },
                AttackType.Start => new List<string> { "first attack" },
                AttackType.All => new List<string> { "first attack", "counter attack", "first follow up", "second follow up", "finished combat"},
                AttackType.FollowUp => new List<string> { "first follow up", "second follow up" },
                _ => new List<string> { "first attack" } // Por defecto si no coincide
            };
        }
    }
}