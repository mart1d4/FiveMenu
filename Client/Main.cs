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
        private readonly NativeMenu _menu = new NativeMenu("West Coast Menu");

        private readonly Dictionary<NativeMenu, object> _subMenus = new Dictionary<NativeMenu, object>();

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
            _menu.Subtitle = $"Main menu | {playerName}";

            _subMenus[_onlineOptions] = Categories.Online.InitiateCategory(_pool);
            _subMenus[_playerOptions] = Categories.Player.InitiateCategory(_pool);
            _subMenus[_vehicleOptions] = Categories.Vehicles.InitiateCategory(_pool);
            _subMenus[_miscOptions] = Categories.Misc.MiscCategories;

            // Add submenus to main menu
            foreach (var subMenu in _subMenus)
            {
                foreach (var item in subMenu.Value as NativeMenu[])
                {
                    subMenu.Key.AddSubMenu(item);
                    _pool.Add(item);
                }

                _menu.AddSubMenu(subMenu.Key);
                _pool.Add(subMenu.Key);
            }

            // Add main menu to the pool
            _pool.Add(_menu);

            // Run ticks
            Tick += FastTick;
            Tick += NormalTick;
            Tick += LongTick;
        }

        private Task FastTick()
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

            if (Game.IsControlJustPressed(0, Control.MultiplayerInfo))
            {
                Functions.Utils.TeleportToWaypoint();
            }

            return Task.FromResult(0);
        }

        private async Task NormalTick()
        {
            await Delay(500);
        }

        private async Task LongTick()
        {
            await Delay(5000);
        }
    }
}
