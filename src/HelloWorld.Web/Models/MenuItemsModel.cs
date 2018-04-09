using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Web.Models
{
    [Serializable]
    public class MenuItemsModel
    {
        public string Text { get; set; }
        public string URL { get; set; }
        public string Target { get; set; }
        public bool IsVisible { get; set; }

        public MenuItemsModel()
        {
            Target = "_blank";
            IsVisible = true;
        }

        public MenuItemsModel(string menuName, string url, bool visible)
        {
            Text = menuName;
            URL = url;
            Target = "_blank";
            IsVisible = visible;
        }

        public MenuItemsModel(string menuName, string url, string target, bool visible)
        {
            Text = menuName;
            URL = url;
            Target = target;
            IsVisible = visible;
        }
    }
}