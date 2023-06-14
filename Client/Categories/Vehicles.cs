using System.Collections.Generic;
using CitizenFX.Core;
using LemonUI.Menus;

namespace FiveMenu.Client.Categories
{
    public class Vehicles : BaseScript
    {
        // Vehicles Categories
        private static readonly NativeMenu Spawner = new NativeMenu(
            "Spawner",
            "Spawner",
            "Open this submenu to spawn vehicles."
        );

        private static readonly NativeMenu Mods = new NativeMenu(
            "Mods",
            "Mods",
            "Open this submenu to change your vehicle mods."
        );

        private static readonly NativeMenu Colors = new NativeMenu(
            "Colors",
            "Colors",
            "Open this submenu to change your vehicle colors."
        );

        private static readonly NativeMenu Neon = new NativeMenu(
            "Neon Kits",
            "Neon Kits",
            "Open this submenu to set your vehicle's neon kits."
        );

        private static readonly NativeMenu Extra = new NativeMenu(
            "Extra",
            "Extra",
            "Open this submenu to add extras to your vehicle."
        );

        private static readonly NativeMenu Doors = new NativeMenu(
            "Doors",
            "Doors",
            "Open this submenu to open or close your vehicle's doors."
        );

        public static Dictionary<object, object> VehicleCategories = new Dictionary<object, object>()
        {
            [Spawner] = new Dictionary<string, string>(),
            [Mods] = new Dictionary<string, string>(),
            [Neon] = new Dictionary<string, string>(),
            [Extra] = new Dictionary<string, string>(),
            [Spawner] = new Dictionary<string, string>(),
            [Doors] = new Dictionary<string, string>(),
        };

        public Vehicles()
        {
//            VehicleCategories[_spawner] = new Dictionary<string, string>();
//            VehicleCategories[_mods] = new Dictionary<string, string>();
//            VehicleCategories[_colors] = new Dictionary<string, string>();
//            VehicleCategories[_neon] = new Dictionary<string, string>();
//            VehicleCategories[_extra] = new Dictionary<string, string>();
//            VehicleCategories[_doors] = new Dictionary<string, string>();
            Debug.WriteLine("Debug Vehicles");
        }
    }
}
