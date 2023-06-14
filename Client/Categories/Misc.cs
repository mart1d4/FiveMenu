using System.Collections.Generic;
using LemonUI.Menus;

namespace FiveMenu.Client.Categories
{
    internal class Misc
    {
        public static Dictionary<object, object> MiscCategories = new Dictionary<object, object>();
        private readonly NativeItem _vehicleItem = new NativeItem("Hey bro", "dihjeidhjdwe");

        public void Main()
        {
            MiscCategories[_vehicleItem] = new Dictionary<string, string>();
        }
    }
}
