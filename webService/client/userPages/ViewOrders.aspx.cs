using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace client.userPages
{
    public partial class ViewOrders : System.Web.UI.Page
    {
        MyWs.MainService service;
        public MyWs.OrderQueue readyQueue;
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();

            if (!IsPostBack)
            {
                readyQueue = (MyWs.OrderQueue)Session["readyQueue"];

                // check if the user has purchase history
                if (readyQueue != null)
                {
                    repeaterOrders.DataSource = readyQueue.queue;
                    repeaterOrders.DataBind();
                }
            }
        }
    }
}