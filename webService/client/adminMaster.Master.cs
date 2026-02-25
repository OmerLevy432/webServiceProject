using client.MyWs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace client
{
    public partial class adminMaster : System.Web.UI.MasterPage
    {
        MyWs.MainService service;
        public string allowedPages;

        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();

            MyUser user = (MyUser)Session["userObject"];
            if (user == null) return;

            switch (user.RoleTag.RoleId)
            {
                case 1:
                case 2:
                    allowedPages += "<a href=\"" + ResolveUrl("~/userPages/UserProfile.aspx") + "\">Profile</a>\n";
                    allowedPages += "<a href=\"" + ResolveUrl("~/userPages/MakeOrders.aspx") + "\">Make Order</a>\n";
                    break;

                case 3:
                    allowedPages += "<a href=\"" + ResolveUrl("~/userPages/MakeOrders.aspx") + "\">Make Order</a>\n";
                    allowedPages += "<a href=\"" + ResolveUrl("~/userPages/UserProfile.aspx") + "\">Profile</a>\n";
                    allowedPages += "<a href=\"" + ResolveUrl("~/userPages/chooseOrderUser.aspx") + "\">Order</a>\n";
                    allowedPages += "<a href=\"" + ResolveUrl("~/rolePages/RoleList.aspx") + "\">Role List</a>\n";
                    allowedPages += "<a href=\"" + ResolveUrl("~/userPages/UserList.aspx") + "\">User List</a>\n";
                    break;

            }
        }
    }
}