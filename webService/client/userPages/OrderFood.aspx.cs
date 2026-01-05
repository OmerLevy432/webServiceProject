using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace client.userPages
{
    public partial class OrderFood : System.Web.UI.Page
    {
        MyWs.MainService service;
        public string ordersLink = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();
            if (!IsPostBack)
            {
                int roleId;

                //parse the userId
                int.TryParse(Request.QueryString["roleId"], out roleId);
                ordersLink = string.Format(
                    "<a href=\"{0}?roleId={1}\">Menu</a>",
                    ResolveUrl("~/FoodPages/FoodList.aspx"),
                    roleId
                );
            }
        }
    }
}