using Base.Core;
using Base.Defs;
using PhoenixPoint.Common.Core;
using PhoenixPoint.Common.Game;
using PhoenixPoint.Modding;
using PhoenixPoint.Tactical.Entities.DamageKeywords;
using PhoenixPoint.Tactical.Entities.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TechStrikeParalyze
{
    public class TechStrikeParalyzeMain : ModMain
    {
        internal static readonly DefRepository Repo = GameUtl.GameComponent<DefRepository>();
        internal static readonly SharedData Shared = GameUtl.GameComponent<SharedData>();

        public new TechStrikeParalyzeConfig Config => (TechStrikeParalyzeConfig)base.Config;

        public override void OnModEnabled()
        {
            Logger.LogInfo("TechStrikeParalyze: Mod enabled");
            
            try
            {
                ModifyTechnicianArms();
                Logger.LogInfo("TechStrikeParalyze: Technician Arms configured successfully");
            }
            catch (Exception ex)
            {
                Logger.LogError($"TechStrikeParalyze: Initialization error - {ex.Message}");
            }
        }

        public override void OnModDisabled()
        {
            Logger.LogInfo("TechStrikeParalyze: Mod disabled");
        }

        public override void OnConfigChanged()
        {
            Logger.LogInfo("TechStrikeParalyze: Config changed");
            
            try
            {
                ModifyTechnicianArms();
            }
            catch (Exception ex)
            {
                Logger.LogError($"TechStrikeParalyze: Config change error - {ex.Message}");
            }
        }

        private void ModifyTechnicianArms()
        {
            if (!Config.EnableParalysingArms)
            {
                Logger.LogInfo("TechStrikeParalyze: Mod disabled in config");
                return;
            }

            // Find the Technician Arms weapon
            WeaponDef techArmsWeapon = Repo.GetAllDefs<WeaponDef>()
                .FirstOrDefault(w => w.name.Equals("NJ_Technician_MechArms_WeaponDef"));

            if (techArmsWeapon?.DamagePayload == null)
            {
                Logger.LogWarning("TechStrikeParalyze: Technician Arms weapon not found or invalid");
                return;
            }

            // Get damage keyword definitions
            DamageKeywordDef damageKeyword = Shared.SharedDamageKeywords.DamageKeyword;
            DamageKeywordDef piercingKeyword = Shared.SharedDamageKeywords.PiercingKeyword;
            DamageKeywordDef paralysingKeyword = Shared.SharedDamageKeywords.ParalysingKeyword;

            if (damageKeyword == null || piercingKeyword == null || paralysingKeyword == null)
            {
                Logger.LogWarning("TechStrikeParalyze: Required damage keywords not found");
                return;
            }

            // Create new damage configuration
            var newDamageKeywords = new List<DamageKeywordPair>
            {
                new DamageKeywordPair { DamageKeywordDef = damageKeyword, Value = Config.BaseDamage },
                new DamageKeywordPair { DamageKeywordDef = piercingKeyword, Value = Config.PiercingDamage },
                new DamageKeywordPair { DamageKeywordDef = paralysingKeyword, Value = Config.ParalysingDamage }
            };

            // Apply the changes
            techArmsWeapon.DamagePayload.DamageKeywords = newDamageKeywords;

            Logger.LogInfo($"TechStrikeParalyze: Applied damage - Base: {Config.BaseDamage}, " +
                          $"Piercing: {Config.PiercingDamage}, Paralysing: {Config.ParalysingDamage}");
        }
    }
}