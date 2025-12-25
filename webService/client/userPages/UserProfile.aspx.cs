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
                int userId;

                // try to parse the userId
                if (int.TryParse(Request.QueryString["userId"], out userId))
                {
                    MyWs.MyUser user = service.UserGet(userId);

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