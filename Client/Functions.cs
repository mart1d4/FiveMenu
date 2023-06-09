using CitizenFX.Core;
using System.Threading.Tasks;
using static CitizenFX.Core.Native.API;

namespace FiveMenu.Client
{
    internal class Functions : BaseScript
    {
        public static async void SpawnVehicle(string model, bool enterVehicle)
        {
            uint hash = (uint)GetHashKey(model);

            if (!IsModelInCdimage(hash) || !IsModelAVehicle(hash))
            {
                TriggerEvent("chat:addmessage", new
                {
                    color = new[] { 255, 0, 0 },
                    args = new[] { "[menu]", $"you tried to spawn an unknown vehicle ^*({model})." }
                });
                return;
            }

            Vector3 coords = GetOffsetFromEntityInWorldCoords(Game.PlayerPed.Handle, 0f, 8f, 0.5f);
            RequestCollisionAtCoord(coords.X, coords.Y, coords.Z);

            while (!HasCollisionLoadedAroundEntity(Game.PlayerPed.Handle))
            {
                await Delay(0);
            }

            Vehicle newVehicle = await World.CreateVehicle(model, coords, Game.PlayerPed.Heading);

            newVehicle.DirtLevel = 0f;
            newVehicle.RoofState = VehicleRoofState.Opened;
            SetVehicleCustomPrimaryColour(newVehicle.Handle, 0, 0, 0);
            SetVehicleCustomSecondaryColour(newVehicle.Handle, 0, 0, 0);

            if (enterVehicle)
            {
                Game.PlayerPed.SetIntoVehicle(newVehicle, VehicleSeat.Driver);
            }
        }

        public static async void TeleportToWaypoint()
        {
            if (Game.IsWaypointActive)
            {
                Vector3 position = World.WaypointPosition;
                await TeleportToCoords(position);
            }
        }

        public static Vehicle GetVehicle(bool lastVehicle = false)
        {
            if (lastVehicle)
            {
                return Game.PlayerPed.LastVehicle;
            }
            else
            {
                if (Game.PlayerPed.IsInVehicle())
                {
                    return Game.PlayerPed.CurrentVehicle;
                }
            }
            return null;
        }

        public static async Task TeleportToCoords(Vector3 pos, bool safeModeDisabled = false)
        {
            if (safeModeDisabled)
            {
                return;
            }

            Vehicle veh = GetVehicle();
            bool inVehicle()
            {
                return veh != null && veh.Exists() && Game.PlayerPed == veh.Driver;
            }

            bool vehicleRestoreVisibility = inVehicle() && veh.IsVisible;
            bool pedRestoreVisibility = Game.PlayerPed.IsVisible;

            if (inVehicle())
            {
                veh.IsPositionFrozen = true;
                if (veh.IsVisible)
                {
                    NetworkFadeOutEntity(veh.Handle, true, false);
                }
            }
            else
            {
                ClearPedTasksImmediately(Game.PlayerPed.Handle);
                Game.PlayerPed.IsPositionFrozen = true;
                if (Game.PlayerPed.IsVisible)
                {
                    NetworkFadeOutEntity(Game.PlayerPed.Handle, true, false);
                }
            }

            DoScreenFadeOut(500);
            while (!IsScreenFadedOut())
            {
                await Delay(0);
            }

            // This will be used to get the return value from the groundz native.
            float groundZ = 850.0f;

            // Bool used to determine if the groundz coord could be found.
            bool found = false;

            // Loop from 950 to 0 for the ground z coord, and take away 25 each time.
            for (float zz = 950.0f; zz >= 0f; zz -= 25f)
            {
                float z = zz;

                if (zz % 2 != 0)
                {
                    z = 950f - zz;
                }

                RequestCollisionAtCoord(pos.X, pos.Y, z);
                NewLoadSceneStart(pos.X, pos.Y, z, pos.X, pos.Y, z, 50f, 0);

                int tempTimer = GetGameTimer();

                while (IsNetworkLoadingScene())
                {
                    if (GetGameTimer() - tempTimer > 2000)
                    {
                        break;
                    }

                    await Delay(0);
                }

                if (inVehicle())
                {
                    SetEntityCoords(veh.Handle, pos.X, pos.Y, z, false, false, false, true);
                }
                else
                {
                    SetEntityCoords(Game.PlayerPed.Handle, pos.X, pos.Y, z, false, false, false, true);
                }

                tempTimer = GetGameTimer();

                while (!HasCollisionLoadedAroundEntity(Game.PlayerPed.Handle))
                {
                    if (GetGameTimer() - tempTimer > 2000)
                    {
                        break;
                    }
                    await Delay(0);
                }

                found = GetGroundZFor_3dCoord(pos.X, pos.Y, z, ref groundZ, false);

                if (found)
                {
                    if (inVehicle())
                    {
                        SetEntityCoords(veh.Handle, pos.X, pos.Y, groundZ, false, false, false, true);

                        veh.IsPositionFrozen = false;
                        veh.PlaceOnGround();
                        veh.IsPositionFrozen = true;
                    }
                    else
                    {
                        SetEntityCoords(Game.PlayerPed.Handle, pos.X, pos.Y, groundZ, false, false, false, true);
                    }
                    break;
                }

                await Delay(10);
            }

            if (!found)
            {
                Vector3 safePos = pos;
                GetNthClosestVehicleNode(pos.X, pos.Y, pos.Z, 0, ref safePos, 0, 0, 0);

                if (inVehicle())
                {
                    SetEntityCoords(veh.Handle, safePos.X, safePos.Y, safePos.Z, false, false, false, true);
                    veh.IsPositionFrozen = false;
                    veh.PlaceOnGround();
                    veh.IsPositionFrozen = true;
                }
                else
                {
                    SetEntityCoords(Game.PlayerPed.Handle, safePos.X, safePos.Y, safePos.Z, false, false, false, true);
                }
            }

            if (inVehicle())
            {
                if (vehicleRestoreVisibility)
                {
                    NetworkFadeInEntity(veh.Handle, true);
                    if (!pedRestoreVisibility)
                    {
                        Game.PlayerPed.IsVisible = false;
                    }
                }
                veh.IsPositionFrozen = false;
            }
            else
            {
                if (pedRestoreVisibility)
                {
                    NetworkFadeInEntity(Game.PlayerPed.Handle, true);
                }
                Game.PlayerPed.IsPositionFrozen = false;
            }

            DoScreenFadeIn(500);
            SetGameplayCamRelativePitch(0.0f, 1.0f);
        }
    }
}
