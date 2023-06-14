using System.Collections.Generic;
using LemonUI.Menus;

namespace FiveMenu.Client.Categories
{
    internal class Online
    {
        public static Dictionary<object, object> OnlineCategories = new Dictionary<object, object>();
        private readonly NativeItem _vehicleItem = new NativeItem("Hey bro", "dihjeidhjdwe");

        public void Main()
        {
            OnlineCategories[_vehicleItem] = new Dictionary<string, string>();
        }
    }
}
