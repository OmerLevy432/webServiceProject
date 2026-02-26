using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace client.userPages
{
    public partial class MakeOrders : System.Web.UI.Page
    {
        MyWs.MainService service;
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();

            if (!IsPostBack)
            {
                repeaterOrders.DataSource = service.GetOrdersByTag(false);
                repeaterOrders.DataBind();
            }
        }

        protected void MakeOrderButton_Click(object sender, EventArgs e)
        {
            service.MakeOrder();

            repeaterOrders.DataSource = service.GetOrdersByTag(false);
            repeaterOrders.DataBind();
        }
    }
}