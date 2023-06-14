using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using LemonUI.Menus;
using LemonUI;
using static CitizenFX.Core.Native.API;

namespace FiveMenu.Client
{
    public class Main : BaseScript
    {
        private readonly ObjectPool _pool = new ObjectPool();
        private readonly NativeMenu _menu = new NativeMenu("West Coast Menu", "Main menu | mart1d4");

        private readonly Dictionary<object, object> _subMenus = new Dictionary<object, object>();

        // Main Submenus
        private readonly NativeMenu _onlineOptions = new NativeMenu(
            "Online Options",
            "Online Options",
            "Open this submenu for online related categories."
        );

        private readonly NativeMenu _playerOptions = new NativeMenu(
            "Player Options",
            "Player Options",
            "Open this submenu for player related categories."
        );

        private readonly NativeMenu _vehicleOptions = new NativeMenu(
            "Vehicle Options",
            "Vehicle Options",
            "Open this submenu for vehicle related categories."
        );

        private readonly NativeMenu _miscOptions = new NativeMenu(
            "Misc Options",
            "Misc Options",
            "Open this submenu for miscellaneous related categories."
        );

        public Dictionary<string, object> Config = new Dictionary<string, object>()
        {
            ["playerInvincible"] = false
        };

        public Main()
        {
            string playerName = GetPlayerName(-1);
            _menu.Description = playerName;

            _subMenus[_onlineOptions] = Categories.Online.OnlineCategories;
            _subMenus[_playerOptions] = Categories.Player.PlayerCategories;
            _subMenus[_vehicleOptions] = Categories.Vehicles.VehicleCategories;
            _subMenus[_miscOptions] = Categories.Misc.MiscCategories;

            // Add submenus to main menu
            foreach (var subMenu in _subMenus)
            {
                foreach (var item in subMenu.Value as Dictionary<object, object>)
                {
                    if (item.Key.GetType() == typeof(NativeMenu))
                    {
                        Debug.WriteLine($"Key: {item.Key} | Value: {item.Value}");
                        NativeMenu menu = subMenu.Key as NativeMenu;
                        menu.Add(item.Key as NativeMenu);
                        _pool.Add(item.Key as NativeMenu);
                    }
                }

                _menu.AddSubMenu(subMenu.Key as NativeMenu);
                _pool.Add(subMenu.Key as NativeMenu);
            }

            // Add main menu to the pool
            _pool.Add(_menu);

            // Run ticks
            Tick += OnTick;
//            Tick += FastTick;
//            Tick += LongTick;
        }

        [Tick]
        private Task OnTick()
        {
            _pool.Process();

            Debug.WriteLine("dklnweijkhbnfuojwehbn");

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

            if (Game.IsControlJustPressed(0, Control.MultiplayerInfo))
            {
                Functions.Utils.TeleportToWaypoint();
            }

            return Task.FromResult(0);
        }

//        [Tick]
//        private async Task FastTick()
//        {
//            await Delay(500);
//        }
//
//        [Tick]
//        private async Task LongTick()
//        {
//            await Delay(5000);
//        }
    }
}
