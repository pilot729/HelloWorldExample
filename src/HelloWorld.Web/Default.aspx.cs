using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StructureMap;
using HelloWorld.Web.Models;

namespace HelloWorld.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var menuItems = new List<MenuItemsModel>();

                menuItems.Clear();

                menuItems.Add(new MenuItemsModel("Click here for greeting", ResolveUrl("~/#/helloWorld"), true));

                rptAdmin.DataSource = menuItems.Where(x => x.IsVisible);
                rptAdmin.DataBind();

                divAdmin.Visible = menuItems.Any(x => x.IsVisible);
            }
        }
    }
}