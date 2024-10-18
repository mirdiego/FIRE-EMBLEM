namespace Fire_Emblem
{
    public class AttackTypeValidator
    {
        // Método estático que devuelve una lista de tipos de ataque predefinidos
        public static List<string> GetAttackTypes(string tipo)
        {
            return tipo switch
            {
                "primero" => new List<string> { "first attack", "counter attack" },
                "unavez" => new List<string> { "first attack" },
                "todos" => new List<string> { "first attack", "counter attack", "first follow up", "second follow up", "finished combat"},
                "followup" => new List<string> { "first follow up", "second follow up" },
                _ => new List<string> { "first attack" } // Por defecto si no coincide
            };
        }
    }
}