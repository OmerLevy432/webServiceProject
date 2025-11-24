using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace client
{
    public partial class userPurchaseHistory : System.Web.UI.Page
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

                    repeaterPurchases.DataSource = user.OrderHistory.OrderList;
                    repeaterPurchases.DataBind();
                }
            }
        }
    }
}