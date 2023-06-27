using System.Collections.Generic;
using CitizenFX.Core;
using LemonUI.Menus;
using LemonUI;
using static CitizenFX.Core.Native.API;

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

        private static readonly NativeMenu Extras = new NativeMenu(
            "Extras",
            "Extras",
            "Open this submenu to add extras to your vehicle."
        );

        private static readonly NativeMenu Options = new NativeMenu(
            "Options",
            "Options",
            "Open this submenu to set general vehicle options."
        );

        public static Dictionary<string, bool> Config = new Dictionary<string, bool>()
        {
            ["spawnInsideVehicle"] = false,
            ["invincibleVehicle"] = false,
        };

        public static NativeMenu[] InitiateCategory(ObjectPool pool)
        {
            NativeCheckboxItem enterVehicle = new NativeCheckboxItem(
                "Spawn Inside Vehicle",
                "Teleports you into the vehicle when you spawn it.",
                Config["spawnInsideVehicle"]
            );
            NativeCheckboxItem invicibleVehicle = new NativeCheckboxItem(
                "Invincible vehicle",
                "Makes the vehicle invincible.",
                Config["invincibleVehicle"]
            );

            enterVehicle.Activated += (sender, args) => { Config["spawnInsideVehicle"] = enterVehicle.Checked; };
            invicibleVehicle.Activated += (sender, args) => { Config["invincibleVehicle"] = invicibleVehicle.Checked; };

            Spawner.Add(enterVehicle);
            Spawner.Add(invicibleVehicle);

            foreach (var brand in Data.VehicleData.ModdedVehicles)
            {
                NativeMenu menu = new NativeMenu(
                    brand.Key,
                    brand.Key,
                    $"Open this submenu to see the {brand.Key} vehicles."
                );

                foreach (var car in brand.Value)
                {
                    NativeItem item = new NativeItem(car.Key, $"Spawns the {car.Key}");

                    item.Activated += (sender, args) =>
                    {
                        Functions.Utils.SpawnVehicle(car.Value, Config["spawnInsideVehicle"],
                            Config["invincibleVehicle"]);
                    };

                    menu.Add(item);
                }

                Spawner.AddSubMenu(menu);
                pool.Add(menu);
            }

            NativeCheckboxItem disableTurbulance = new NativeCheckboxItem(
                "Disable Plane Turubulance",
                "Disables plane turbulance.",
                false
            );

            disableTurbulance.Activated += (sender, args) =>
            {
                Functions.Vehicles.SetPlaneTurbulance(disableTurbulance.Checked);
            };

            Options.Add(disableTurbulance);

            NativeMenu colorPrimary = new NativeMenu(
                "Set Primary Color",
                "Set Primary Color",
                "Open this submenu to change your vehicle's primary color."
            );

            NativeMenu colorSecondary = new NativeMenu(
                "Set Secondary Color",
                "Set Secondary Color",
                "Open this submenu to change your vehicle's secondary color."
            );

            AddColors(pool, colorPrimary, true);
            AddColors(pool, colorSecondary, false);

            Colors.AddSubMenu(colorPrimary);
            Colors.AddSubMenu(colorSecondary);
            pool.Add(colorPrimary);
            pool.Add(colorSecondary);

            NativeMenu[] vehicleCategories =
            {
                Spawner, Mods, Extras, Colors, Options
            };

            return vehicleCategories;
        }

        public static void AddColors(ObjectPool pool, NativeMenu parentMenu, bool primary)
        {
            foreach (var category in Data.ColorsData.VehicleColors)
            {
                NativeMenu menu = new NativeMenu(
                    category.Key,
                    category.Key,
                    $"Open this submenu to see the {category.Key.ToLower()}."
                );

                foreach (var color in category.Value)
                {
                    NativeItem item = new NativeItem(Functions.Utils.BeautyString(color.Value),
                        $"Changes your vehicle color to {Functions.Utils.BeautyString(color.Value)}");

                    item.Activated += (sender, args) => { Functions.Vehicles.SetVehicleColor(primary, color.Key); };

                    menu.Add(item);
                }

                NativeItem chrome = new NativeItem("Chrome", "Changes your vehicle color to chrome");

                chrome.Activated += (sender, args) => { Functions.Vehicles.SetVehicleColor(primary, 120); };

                menu.Add(chrome);

                parentMenu.AddSubMenu(menu);
                pool.Add(menu);
            }
        }
    }
}
