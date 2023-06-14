using System.Collections.Generic;
using LemonUI.Menus;

namespace FiveMenu.Client.Categories
{
    internal class Player
    {
        public static Dictionary<object, object> PlayerCategories = new Dictionary<object, object>();
        private readonly NativeItem _vehicleItem = new NativeItem("Hey bro", "dihjeidhjdwe");

        public void Main()
        {
            PlayerCategories[_vehicleItem] = new Dictionary<string, string>();
        }
    }
}
