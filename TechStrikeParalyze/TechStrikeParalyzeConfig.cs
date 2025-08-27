using PhoenixPoint.Modding;

namespace TechStrikeParalyze
{
    public class TechStrikeParalyzeConfig : ModConfig
    {
        [ConfigField(text: "Base Damage", description: "Base damage value for the Technician Arms")]
        public int BaseDamage = 10;

        [ConfigField(text: "Piercing Damage", description: "Piercing damage value for the Technician Arms")]
        public int PiercingDamage = 40;

        [ConfigField(text: "Paralysing Damage", description: "Paralysing damage value for the Technician Arms (replaces Shock/Stun)")]
        public int ParalysingDamage = 30;

        [ConfigField(text: "Enable Paralysing Arms", description: "Enable or disable the mod functionality")]
        public bool EnableParalysingArms = true;
    }
}