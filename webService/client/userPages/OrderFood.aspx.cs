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
    public partial class OrderFood : System.Web.UI.Page
    {
        MyWs.MainService service;
        static MyWs.OrderedItems orderedItems;
        MyWs.FoodItem item;
        MyWs.MyUser user;
        public string ordersLink = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();
            if (!IsPostBack)
            {
                // init the ordered items
                orderedItems = new MyWs.OrderedItems();
            }

            // parse the userId
            int roleId;
            int.TryParse(Request.QueryString["roleId"], out roleId);
            ordersLink = string.Format(
                "<a href=\"{0}?roleId={1}\">Menu</a>",
                ResolveUrl("~/FoodPages/FoodList.aspx"),
                roleId
            );
        }

        protected void addFoodToOrder_Click(object sender, EventArgs e)
        {
            item = service.GetFoodItemById(int.Parse(itemIdEntry.Text));
            service.AddItemToOrder(ref orderedItems, ref item);

            // set the items to be viewed on the website
            foodRepeater.DataSource = orderedItems.FoodItems;
            foodRepeater.DataBind();
        }

        protected void SubmitOrder_Click(object sender, EventArgs e)
        {
            // load the user from the database
            int userId;
            int.TryParse(Request.QueryString["userId"], out userId);
            user = service.UserGet(userId);

            // add the ordered items to the order history of the user
            MyWs.Orders ordersHistory = user.OrderHistory;
            ordersHistory.OrderList = new MyWs.OrderedItems[0];
            service.AddOrderToHistory(ref ordersHistory, ref orderedItems);

            service.AddOrders(ordersHistory);
            Response.Redirect(string.Format("UserProfile.aspx?userId={0}", userId));
        }
    }
}