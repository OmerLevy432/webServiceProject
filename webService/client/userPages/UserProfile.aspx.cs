using client.MyWs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace client.userPages
{
    public partial class UserProfile : System.Web.UI.Page
    {
        MyWs.MainService service;
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();

            if (!IsPostBack)
            {   
                MyWs.MyUser user = (MyUser)Session["userObject"];

                // check if the user has purchase history
                if (user.OrderHistory.OrderList.Length > 0)
                {
                    repeaterPurchases.DataSource = user.OrderHistory.OrderList;
                    repeaterPurchases.DataBind();
                }
                else
                {
                    noOrdersLable.Text = "No orders yet...";
                }

                presentUserInformatiom(user);  
            }
        }

        protected void presentUserInformatiom(MyWs.MyUser user)
        {
            List<MyWs.MyUser> users = new List<MyWs.MyUser>();
            users.Add(user);

            userRepeater.DataSource = users;
            userRepeater.DataBind();
        }
    }
}