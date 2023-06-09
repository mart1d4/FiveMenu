using System.Collections.Generic;

namespace FiveMenu.Client.Data
{
    internal class ColorsData
    {
        public static readonly Dictionary<string, int[]> TireSmokeColors = new Dictionary<string, int[]>()
        {
            ["Red"] = new int[] { 244, 65, 65 },
            ["Orange"] = new int[] { 244, 167, 66 },
            ["Yellow"] = new int[] { 244, 217, 65 },
            ["Gold"] = new int[] { 181, 120, 0 },
            ["Light Green"] = new int[] { 158, 255, 84 },
            ["Dark Green"] = new int[] { 44, 94, 5 },
            ["Light Blue"] = new int[] { 65, 211, 244 },
            ["Dark Blue"] = new int[] { 24, 54, 163 },
            ["Purple"] = new int[] { 108, 24, 192 },
            ["Pink"] = new int[] { 192, 24, 172 },
            ["Black"] = new int[] { 1, 1, 1 }
        };

        public static readonly Dictionary<string, Dictionary<int, string>> VehicleColors =
            new Dictionary<string, Dictionary<int, string>>
            {
                ["Classic Colors"] = new Dictionary<int, string>()
                {
                    { 0, "BLACK" },
                    { 1, "GRAPHITE" },
                    { 2, "BLACK_STEEL" },
                    { 3, "DARK_SILVER" },
                    { 4, "SILVER" },
                    { 5, "BLUE_SILVER" },
                    { 6, "ROLLED_STEEL" },
                    { 7, "SHADOW_SILVER" },
                    { 8, "STONE_SILVER" },
                    { 9, "MIDNIGHT_SILVER" },
                    { 10, "CAST_IRON_SIL" },
                    { 11, "ANTHR_BLACK" },

                    { 27, "RED" },
                    { 28, "TORINO_RED" },
                    { 29, "FORMULA_RED" },
                    { 30, "BLAZE_RED" },
                    { 31, "GRACE_RED" },
                    { 32, "GARNET_RED" },
                    { 33, "SUNSET_RED" },
                    { 34, "CABERNET_RED" },
                    { 35, "CANDY_RED" },
                    { 36, "SUNRISE_ORANGE" },
                    { 37, "GOLD" },
                    { 38, "ORANGE" },
                    { 49, "DARK_GREEN" },
                    { 50, "RACING_GREEN" },
                    { 51, "SEA_GREEN" },
                    { 52, "OLIVE_GREEN" },
                    { 53, "BRIGHT_GREEN" },
                    { 54, "PETROL_GREEN" },

                    { 61, "GALAXY_BLUE" },
                    { 62, "DARK_BLUE" },
                    { 63, "SAXON_BLUE" },
                    { 64, "BLUE" },
                    { 65, "MARINER_BLUE" },
                    { 66, "HARBOR_BLUE" },
                    { 67, "DIAMOND_BLUE" },
                    { 68, "SURF_BLUE" },
                    { 69, "NAUTICAL_BLUE" },
                    { 70, "ULTRA_BLUE" },
                    { 71, "PURPLE" },
                    { 72, "SPIN_PURPLE" },
                    { 73, "RACING_BLUE" },
                    { 74, "LIGHT_BLUE" },

                    { 88, "YELLOW" },
                    { 89, "RACE_YELLOW" },
                    { 90, "BRONZE" },
                    { 91, "FLUR_YELLOW" },
                    { 92, "LIME_GREEN" },

                    { 94, "UMBER_BROWN" },
                    { 95, "CREEK_BROWN" },
                    { 96, "CHOCOLATE_BROWN" },
                    { 97, "MAPLE_BROWN" },
                    { 98, "SADDLE_BROWN" },
                    { 99, "STRAW_BROWN" },
                    { 100, "MOSS_BROWN" },
                    { 101, "BISON_BROWN" },
                    { 102, "WOODBEECH_BROWN" },
                    { 103, "BEECHWOOD_BROWN" },
                    { 104, "SIENNA_BROWN" },
                    { 105, "SANDY_BROWN" },
                    { 106, "BLEECHED_BROWN" },
                    { 107, "CREAM" },

                    { 111, "WHITE" },
                    { 112, "FROST_WHITE" },

                    { 135, "HOT PINK" },
                    { 136, "SALMON_PINK" },
                    { 137, "PINK" },
                    { 138, "BRIGHT_ORANGE" },

                    { 141, "MIDNIGHT_BLUE" },
                    { 142, "MIGHT_PURPLE" },
                    { 143, "WINE_RED" },
                    { 145, "BRIGHT_PURPLE" },
                    { 146, "VERY_DARK_BLUE" },
                    { 147, "BLACK_GRAPHITE" },

                    { 150, "LAVA_RED" }
                },
                ["Matte Colors"] = new Dictionary<int, string>()
                {
                    { 12, "BLACK" },
                    { 13, "GREY" },
                    { 14, "LIGHT_GREY" },

                    { 39, "RED" },
                    { 40, "DARK_RED" },
                    { 41, "ORANGE" },
                    { 42, "YELLOW" },

                    { 55, "LIME_GREEN" },

                    { 82, "DARK_BLUE" },
                    { 83, "BLUE" },
                    { 84, "MIDNIGHT_BLUE" },

                    { 128, "GREEN" },

                    { 148, "PURPLE" },
                    { 149, "MIGHT_PURPLE" },

                    { 151, "MATTE_FOR" },
                    { 152, "MATTE_OD" },
                    { 153, "MATTE_DIRT" },
                    { 154, "MATTE_DESERT" },
                    { 155, "MATTE_FOIL" }
                },
                ["Metal Colors"] = new Dictionary<int, string>()
                {
                    { 117, "BR_STEEL" },
                    { 118, "BR_BLACK_STEEL" },
                    { 119, "BR_ALUMINIUM" },

                    { 158, "GOLD_P" },
                    { 159, "GOLD_S" }
                },
                ["Util Colors"] = new Dictionary<int, string>()
                {
                    { 15, "BLACK" },
                    { 16, "FMMC_COL1_1" },
                    { 17, "DARK_SILVER" },
                    { 18, "SILVER" },
                    { 19, "BLACK_STEEL" },
                    { 20, "SHADOW_SILVER" },

                    { 43, "DARK_RED" },
                    { 44, "RED" },
                    { 45, "GARNET_RED" },

                    { 56, "DARK_GREEN" },
                    { 57, "GREEN" },

                    { 75, "DARK_BLUE" },
                    { 76, "MIDNIGHT_BLUE" },
                    { 77, "SAXON_BLUE" },
                    { 78, "NAUTICAL_BLUE" },
                    { 79, "BLUE" },
                    { 80, "FMMC_COL1_13" },
                    { 81, "BRIGHT_PURPLE" },

                    { 93, "STRAW_BROWN" },

                    { 108, "UMBER_BROWN" },
                    { 109, "MOSS_BROWN" },
                    { 110, "SANDY_BROWN" },

                    { 122, "veh_color_off_white" },

                    { 125, "BRIGHT_GREEN" },

                    { 127, "HARBOR_BLUE" },

                    { 134, "FROST_WHITE" },

                    { 139, "LIME_GREEN" },
                    { 140, "ULTRA_BLUE" },

                    { 144, "GREY" },

                    { 157, "LIGHT_BLUE" },

                    { 160, "YELLOW" }
                },
                ["Worn Colors"] = new Dictionary<int, string>()
                {
                    { 21, "BLACK" },
                    { 22, "GRAPHITE" },
                    { 23, "LIGHT_GREY" },
                    { 24, "SILVER" },
                    { 25, "BLUE_SILVER" },
                    { 26, "SHADOW_SILVER" },

                    { 46, "RED" },
                    { 47, "SALMON_PINK" },
                    { 48, "DARK_RED" },

                    { 58, "DARK_GREEN" },
                    { 59, "GREEN" },
                    { 60, "SEA_GREEN" },

                    { 85, "DARK_BLUE" },
                    { 86, "BLUE" },
                    { 87, "LIGHT_BLUE" },

                    { 113, "SANDY_BROWN" },
                    { 114, "BISON_BROWN" },
                    { 115, "CREEK_BROWN" },
                    { 116, "BLEECHED_BROWN" },

                    { 121, "veh_color_off_white" },

                    { 123, "ORANGE" },
                    { 124, "SUNRISE_ORANGE" },

                    { 126, "veh_color_taxi_yellow" },

                    { 129, "RACING_GREEN" },
                    { 130, "ORANGE" },
                    { 131, "WHITE" },
                    { 132, "FROST_WHITE" },
                    { 133, "OLIVE_GREEN" }
                }
            };
    }
}
