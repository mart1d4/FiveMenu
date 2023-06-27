using System.Collections.Generic;
using LemonUI.Menus;

namespace FiveMenu.Client.Categories
{
    internal class Misc
    {
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

        public static NativeMenu[] MiscCategories =
        {
            Spawner, Mods, Colors, Neon, Extra, Doors
        };

        public void Main()
        {
        }
    }
}
