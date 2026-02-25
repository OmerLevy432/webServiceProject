using System;
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
        public MyWs.OrderQueue notReadyQueue;
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();

            if (!IsPostBack)
            {
                notReadyQueue = (MyWs.OrderQueue)Session["notReadyQueue"];

                // check if the user has purchase history
                if (notReadyQueue != null)
                {
                    repeaterOrders.DataSource = notReadyQueue.queue;
                    repeaterOrders.DataBind();
                }
                else
                {
                    noOrdersLable.Text = "No Orders To Make";
                }
            }
        }

        protected void MakeOrderButton_Click(object sender, EventArgs e)
        {
            notReadyQueue = (MyWs.OrderQueue)Session["notReadyQueue"];
            if (notReadyQueue == null) return;

            MakeOrder(notReadyQueue);
        }

        protected void MakeOrder(MyWs.OrderQueue queue)
        {
            /* gets ready order*/
            MyWs.Orders readyOrder = service.RemoveOrderFromQueue(ref queue);

            /* get the queue of the ready orders*/
            MyWs.OrderQueue readyQueue = (MyWs.OrderQueue)Session["readyQueue"];
            if (readyQueue ==  null)
            {
                readyQueue = service.InitOrderQueue();
            }

            /* adds order to the ready queue*/
            service.AddOrderToQueue(ref readyQueue, readyOrder);
            Session["readyQueue"] = readyQueue;

            /* updates the repeater*/
            repeaterOrders.DataSource = queue.queue;
            repeaterOrders.DataBind();
        }
    }
}