using CitizenFX.Core;
using LemonUI.Menus;
using LemonUI;
using static CitizenFX.Core.Native.API;

namespace FiveMenu.Client.Categories
{
    internal class Player
    {
        private static readonly NativeMenu PlayerOptions = new NativeMenu(
            "Player Options",
            "Player Options",
            "Open this submenu to manage your player."
        );

        private static readonly NativeMenu PlayerAppearance = new NativeMenu(
            "Player Appearance",
            "Player Appearance",
            "Open this submenu to change your appearance."
        );

        private static readonly NativeMenu Weapons = new NativeMenu(
            "Weapons",
            "Weapons",
            "Open this submenu to manage your weapons."
        );

        private static readonly NativeMenu Misc = new NativeMenu(
            "Miscellaneous",
            "Miscellaneous",
            "Open this submenu to set your vehicle's neon kits."
        );

        public static NativeMenu[] InitiateCategory(ObjectPool pool)
        {
            NativeItem getAllWeapons = new NativeItem(
                "Get All Weapons",
                "Gives you all the weapons that exist."
            );
            NativeItem removeAllWeapons = new NativeItem(
                "Remove All Weapons",
                "Removes all weapons from your inventory."
            );

            NativeCheckboxItem unlimitedAmmo = new NativeCheckboxItem(
                "Unlimited Ammo",
                "You don't need bullets anymore.",
                false
            );
            NativeCheckboxItem noReload = new NativeCheckboxItem(
                "No Reload",
                "No need to reload, your clip is always full.",
                false
            );

            getAllWeapons.Activated += (sender, args) =>
            {
                foreach (var model in Data.WeaponData.WeaponHashes)
                {
                    Functions.Utils.GiveWeapon(model);
                }
            };
            removeAllWeapons.Activated += (sender, args) =>
            {
                foreach (var model in Data.WeaponData.WeaponHashes)
                {
                    Functions.Utils.RemoveWeapon(model);
                }
            };
            unlimitedAmmo.Activated += (sender, args) =>
            {
                foreach (var model in Data.WeaponData.WeaponHashes)
                {
                    uint hash = (uint)GetHashKey(model);
                    if (!HasPedGotWeapon(GetPlayerPed(-1), hash, false) || !IsWeaponValid(hash))
                    {
                        return;
                    }

                    SetPedInfiniteAmmo(GetPlayerPed(-1), unlimitedAmmo.Checked, hash);
                }
            };
            noReload.Activated += (sender, args) => { SetPedInfiniteAmmoClip(GetPlayerPed(-1), noReload.Checked); };

            Weapons.Add(getAllWeapons);
            Weapons.Add(removeAllWeapons);
            Weapons.Add(unlimitedAmmo);
            Weapons.Add(noReload);

            NativeCheckboxItem playerInvincible = new NativeCheckboxItem(
                "Player Invincible",
                "Makes you unable to die. Literally.",
                false
            );

            playerInvincible.Activated += (sender, args) =>
            {
                SetEntityInvincible(GetPlayerPed(-1), playerInvincible.Checked);
            };

            NativeItem teleportToWp = new NativeItem(
                "Teleport To Waypoint",
                "Teleports you to the waypoint you set."
            );

            teleportToWp.Activated += (sender, args) => { Functions.Utils.TeleportToWaypoint(); };

            Misc.Add(playerInvincible);
            Misc.Add(teleportToWp);

            NativeMenu[] playerCategories =
            {
                PlayerOptions, PlayerAppearance, Weapons, Misc
            };

            return playerCategories;
        }
    }
}
