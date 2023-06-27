using System.Collections.Generic;

namespace FiveMenu.Client.Data
{
    internal class WeaponData
    {
        #region weapon names

        public static string[] WeaponHashes =
        {
            "weapon_advancedrifle",
            "weapon_appistol",
            "weapon_assaultrifle",
            "weapon_assaultrifle_mk2",
            "weapon_assaultshotgun",
            "weapon_assaultsmg",
            "weapon_autoshotgun",
            "weapon_bat",
            "weapon_ball",
            "weapon_battleaxe",
            "weapon_bottle",
            "weapon_bullpuprifle",
            "weapon_bullpuprifle_mk2",
            "weapon_bullpupshotgun",
            "weapon_bzgas",
            "weapon_carbinerifle",
            "weapon_carbinerifle_mk2",
            "weapon_combatmg",
            "weapon_combatmg_mk2",
            "weapon_combatpdw",
            "weapon_combatpistol",
            "weapon_compactlauncher",
            "weapon_compactrifle",
            "weapon_crowbar",
            "weapon_dagger",
            "weapon_dbshotgun",
            "weapon_doubleaction",
            "weapon_fireextinguisher",
            "weapon_firework",
            "weapon_flare",
            "weapon_flaregun",
            "weapon_flashlight",
            "weapon_golfclub",
            "weapon_grenade",
            "weapon_grenadelauncher",
            "weapon_gusenberg",
            "weapon_hammer",
            "weapon_hatchet",
            "weapon_heavypistol",
            "weapon_heavyshotgun",
            "weapon_heavysniper",
            "weapon_heavysniper_mk2",
            "weapon_hominglauncher",
            "weapon_knife",
            "weapon_knuckle",
            "weapon_machete",
            "weapon_machinepistol",
            "weapon_marksmanpistol",
            "weapon_marksmanrifle",
            "weapon_marksmanrifle_mk2",
            "weapon_mg",
            "weapon_microsmg",
            "weapon_minigun",
            "weapon_minismg",
            "weapon_molotov",
            "weapon_musket",
            "weapon_nightstick",
            "weapon_petrolcan",
            "weapon_pipebomb",
            "weapon_pistol",
            "weapon_pistol50",
            "weapon_pistol_mk2",
            "weapon_poolcue",
            "weapon_proxmine",
            "weapon_pumpshotgun",
            "weapon_pumpshotgun_mk2",
            "weapon_railgun",
            "weapon_revolver",
            "weapon_revolver_mk2",
            "weapon_rpg",
            "weapon_sawnoffshotgun",
            "weapon_smg",
            "weapon_smg_mk2",
            "weapon_smokegrenade",
            "weapon_sniperrifle",
            "weapon_snowball",
            "weapon_snspistol",
            "weapon_snspistol_mk2",
            "weapon_specialcarbine",
            "weapon_specialcarbine_mk2",
            "weapon_stickybomb",
            "weapon_stungun",
            "weapon_switchblade",
            "weapon_unarmed",
            "weapon_vintagepistol",
            "weapon_wrench",
            "weapon_raypistol",
            "weapon_raycarbine",
            "weapon_rayminigun",
            "weapon_stone_hatchet",
            "weapon_ceramicpistol",
            "weapon_navyrevolver",
            "weapon_hazardcan",
            "weapon_gadgetpistol",
            "weapon_militaryrifle",
            "weapon_combatshotgun"
        };

        #endregion

        #region weapon tints

        public static readonly Dictionary<string, int> WeaponTints = new Dictionary<string, int>()
        {
            ["Black"] = 0,
            ["Green"] = 1,
            ["Gold"] = 2,
            ["Pink"] = 3,
            ["Army"] = 4,
            ["LSPD"] = 5,
            ["Orange"] = 6,
            ["Platinum"] = 7,
        };

        #endregion

        #region weapon mk2 tints

        public static readonly Dictionary<string, int> WeaponTintsMk2 = new Dictionary<string, int>()
        {
            ["Classic Black"] = 0,
            ["Classic Gray"] = 1,
            ["Classic Two Tone"] = 2,
            ["Classic White"] = 3,
            ["Classic Beige"] = 4,
            ["Classic Green"] = 5,
            ["Classic Blue"] = 6,
            ["Classic Earth"] = 7,
            ["Classic Brown & Black"] = 8,
            ["Red Contrast"] = 9,
            ["Blue Contrast"] = 10,
            ["Yellow Contrast"] = 11,
            ["Orange Contrast"] = 12,
            ["Bold Pink"] = 13,
            ["Bold Purple & Yellow"] = 14,
            ["Bold Orange"] = 15,
            ["Bold Green & Purple"] = 16,
            ["Bold Red Features"] = 17,
            ["Bold Green Features"] = 18,
            ["Bold Cyan Features"] = 19,
            ["Bold Yellow Features"] = 20,
            ["Bold Red & White"] = 21,
            ["Bold Blue & White"] = 22,
            ["Metallic Gold"] = 23,
            ["Metallic Platinum"] = 24,
            ["Metallic Gray & Lilac"] = 25,
            ["Metallic Purple & Lime"] = 26,
            ["Metallic Red"] = 27,
            ["Metallic Green"] = 28,
            ["Metallic Blue"] = 29,
            ["Metallic White & Aqua"] = 30,
            ["Metallic Red & Yellow"] = 31
        };

        #endregion
    }
}
