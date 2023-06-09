using System.Threading.Tasks;
using CitizenFX.Core;
using LemonUI;
using LemonUI.Menus;
using static CitizenFX.Core.Native.API;

namespace FiveMenu.Client
{
    public class Main : BaseScript
    {
        private readonly ObjectPool _pool = new ObjectPool();
        private readonly NativeMenu _menu = new NativeMenu("West Coast Menu", "Your best friend");

        // Submenus
        private readonly NativeMenu _submenu1 = new NativeMenu("Player", "Player", "Manage your player");
        private readonly NativeMenu _submenu2 = new NativeMenu("Vehicles", "Vehicles", "Manage your vehicles");
        private readonly NativeMenu _submenu3 = new NativeMenu("Weapons", "Weapons", "Manage your weapons");
        private readonly NativeMenu _submenu4 = new NativeMenu("World", "World", "Manage the server's world");

        // Nested Submenus
        private readonly NativeMenu submenu1_1 = new NativeMenu("Teleport", "Teleport", "Teleport you to your desired location");
        private readonly NativeMenu submenu1_2 = new NativeMenu("Outfits", "Outfits", "Manage your outfits");
        private readonly NativeMenu submenu1_3 = new NativeMenu("Animations", "Animations", "Manage your animations");
        private readonly NativeMenu submenu1_4 = new NativeMenu("Models", "Models", "Change your ped model to look different");

        private readonly NativeMenu submenu2_1 = new NativeMenu("Spawner Settings", "Spawner Setting", "Setup the way you want to spawn the vehicles");
        private readonly NativeMenu submenu2_2 = new NativeMenu("Spawner", "Spawner", "Spawn your favourite vehicles");
        private readonly NativeMenu submenu2_3 = new NativeMenu("Tuner", "Tuner", "Tune your vehicles");
        private readonly NativeMenu submenu2_4 = new NativeMenu("Misc", "Misc", "Enable crazy things");

        public bool superSpeedEnabled = false;
        public bool superBrakeEnabled = false;

        public Main()
        {
            // Nested vehicle array with the vehicles brand
            string[,][] vehicleList = Data.vehicleList;

            NativeItem teleportWaypoint = new NativeItem("Teleport to waypoint", "Teleports you to your waypoint, if you set one");
            NativeItem teleportRandom = new NativeItem("Teleport to random position", "Teleports you to a random position in West Coast City");
            NativeListItem<string> teleportPlayer = new NativeListItem<string>("Telport to player", "Teleports you to a player of your choice", "You suck");
            NativeListItem<string> teleportList = new NativeListItem<string>("Teleport to location", "Select the place where you want to be teleported", "Abracadabra");

            teleportWaypoint.Activated += (sender, args) =>
            {
                if (Game.IsWaypointActive)
                {
                    Functions.TeleportToWaypoint();
                }
                else
                {
                    Debug.WriteLine("No waypoint set");
                }
            };

            submenu1_1.Add(teleportWaypoint);
            submenu1_1.Add(teleportRandom);
            submenu1_1.Add(teleportPlayer);
            submenu1_1.Add(teleportList);

            NativeCheckboxItem enterVehicle = new NativeCheckboxItem("Enter vehicle on spawn", "Makes your player enter the vehicle when you spawn it.", true);
            NativeCheckboxItem invicibleVehicle = new NativeCheckboxItem("Invincible vehicle", "Makes the vehicle invincible.", false);
            NativeCheckboxItem engineVehicle = new NativeCheckboxItem("Engine on", "Whether to spawn the vehicle with the engine turned on or off.", true);

            submenu2_1.Add(enterVehicle);
            submenu2_1.Add(invicibleVehicle);
            submenu2_1.Add(engineVehicle);

            NativeCheckboxItem superSpeed = new NativeCheckboxItem("Super speed", "Makes your vehicle go super fast when pressing Z.", false);
            NativeCheckboxItem superHandbrake = new NativeCheckboxItem("Super handbrake", "Makes your vehicle stop abruptly when presing the space bar.", false);

            superSpeed.Activated += (sender, args) =>
            {
                if (superSpeed.Checked)
                {
                    superSpeedEnabled = true;
                }
                else
                {
                    superSpeedEnabled = false;
                }
            };

            superHandbrake.Activated += (sender, args) =>
            {
                if (superHandbrake.Checked)
                {
                    superBrakeEnabled = true;
                }
                else
                {
                    superBrakeEnabled = false;
                }
            };

            submenu2_4.Add(superSpeed);
            submenu2_4.Add(superHandbrake);

            // Loop array to add _menu item with for loop
            for (int i = 0; i < vehicleList.GetLength(0); i++)
            {
                NativeMenu vehicleSubmenu = new NativeMenu(vehicleList[i, 0][0], vehicleList[i, 0][0]);

                for (int k = 0; k < vehicleList[i, 1].Length; k++)
                {
                    NativeItem vehicleItem = new NativeItem(vehicleList[i, 1][k], "Spawns a " + vehicleList[i, 1][k]);
                    string model = vehicleList[i, 2][k];

                    vehicleItem.Activated += (sender, item) =>
                    {
                        Functions.SpawnVehicle(model, enterVehicle.Checked);
                    };

                    vehicleSubmenu.Add(vehicleItem);
                }

                submenu2_2.Add(vehicleSubmenu);
                _pool.Add(vehicleSubmenu);
            }

            // Subemenus
            _menu.Add(_submenu1);
            _menu.Add(_submenu2);
            _menu.Add(_submenu3);
            _menu.Add(_submenu4);

            _pool.Add(_submenu1);
            _pool.Add(_submenu2);
            _pool.Add(_submenu3);
            _pool.Add(_submenu4);

            // Nested Submenus
            _submenu1.Add(submenu1_1);
            _submenu1.Add(submenu1_2);
            _submenu1.Add(submenu1_3);
            _submenu1.Add(submenu1_4);

            _pool.Add(submenu1_1);
            _pool.Add(submenu1_2);
            _pool.Add(submenu1_3);
            _pool.Add(submenu1_4);

            _submenu2.Add(submenu2_1);
            _submenu2.Add(submenu2_2);
            _submenu2.Add(submenu2_3);
            _submenu2.Add(submenu2_4);

            _pool.Add(submenu2_1);
            _pool.Add(submenu2_2);
            _pool.Add(submenu2_3);
            _pool.Add(submenu2_4);

            _pool.Add(_menu);

            Tick += OnTick;
        }

        [Tick]
        private Task OnTick()
        {
            _pool.Process();

            if (Game.IsControlJustPressed(0, Control.VehicleDuck))
            {
                if (_pool.AreAnyVisible)
                {
                    _pool.HideAll();
                }
                else
                {
                    _menu.Visible = true;
                }
            }

            if (Game.IsControlJustPressed(0, Control.InteractionMenu))
            {
                _pool.HideAll();
            }

            if (Game.IsControlJustPressed(0, Control.MultiplayerInfo) && superSpeedEnabled)
            {
                if (Game.PlayerPed.IsInVehicle())
                {
                    Vector3 cameraRotation = GetGameplayCamRot(0);
                    Game.PlayerPed.CurrentVehicle.Heading = cameraRotation.Z;
                    Game.PlayerPed.CurrentVehicle.Rotation = new Vector3(0f, 0f, cameraRotation.Z);

                    Game.PlayerPed.CurrentVehicle.Speed = 2000f;
                }
            }

            if (Game.IsControlJustPressed(0, Control.VehicleHandbrake) && superBrakeEnabled)
            {
                if (Game.PlayerPed.IsInVehicle())
                {
                    Game.PlayerPed.CurrentVehicle.Speed = 0f;
                }
            }

            return Task.FromResult(0);
        }
    }
}
