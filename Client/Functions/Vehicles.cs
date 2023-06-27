using System;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace FiveMenu.Client.Functions
{
    internal class Vehicles
    {
        public static void SetVehicleColor(bool primary, int color)
        {
            int vehicleId = GetVehiclePedIsIn(GetPlayerPed(-1), false);
            Vehicle vehicle = Game.PlayerPed.CurrentVehicle;
            vehicle.Mods.InstallModKit();

            VehicleMod[] mods = vehicle.Mods.GetAllMods();
            foreach (VehicleMod mod in mods)
            {
                Debug.WriteLine($"[{mod.LocalizedModTypeName}] {mod.ModCount}");
            }

            if (vehicleId == 0 || GetPedInVehicleSeat(vehicleId, -1) != GetPlayerPed(-1) || color < 0 || color > 159)
            {
                return;
            }

            SetVehicleColours(vehicleId, color, color);
        }

        public static void SetPlaneTurbulance(bool enabled)
        {
            int vehicleId = GetVehiclePedIsIn(GetPlayerPed(-1), false);

            if (vehicleId == 0 || GetVehicleClass(vehicleId) != 16)
            {
                Debug.WriteLine($"Bruh...Vehicle Class: {GetVehicleClass(vehicleId)}");
                return;
            }

            float multiplier = enabled ? 0 : 1;
            SetPlaneTurbulenceMultiplier(vehicleId, multiplier);
        }
    }
}
