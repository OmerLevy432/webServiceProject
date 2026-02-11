using client.MyWs;
using System;
using System.Collections.Generic;
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

        protected static List<FoodItem> foodItems;
        protected static List<int> foodAmounts;

        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();

            if (!IsPostBack)
            {
                // init the ordered items
                orderedItems = new MyWs.OrderedItems();
                foodItems = new List<FoodItem>();
                foodAmounts = new List<int>();

                // get the food list
                FoodItemsList.DataSource = service.GetAllFoodItems();
                FoodItemsList.DataValueField = "ItemId";
                FoodItemsList.DataTextField = "ItemDescription";
                FoodItemsList.DataBind();
            }

            // parse the roleId
            int roleId;
            int.TryParse(Request.QueryString["roleId"], out roleId);

            ordersLink = string.Format(
                "<a href=\"{0}?roleId={1}\">Menu</a>",
                ResolveUrl("~/FoodPages/FoodList.aspx"),
                roleId
            );

            // initialize empty array if null
            if (foodAmounts == null)
            {
                foodAmounts = new List<int>();
            }
        }

        protected void addItemToOrder(int itemID, int itemQuantity)
        {
            for (int i = 0; i <  foodItems.Count; i++)
            {
                if (foodItems[i].ItemId == itemID)
                {
                    foodAmounts[i] += itemQuantity;
                    return;
                }
            }
            foodItems.Add(service.GetFoodItemById(itemID));
            foodAmounts.Add(itemQuantity);
        }

        protected void removeItemFromList(int itemID)
        {
            for (int i = 0; i < foodItems.Count; i++)
            {
                if (foodItems[i].ItemId == itemID)
                {
                    foodAmounts.RemoveAt(i);
                    foodItems.RemoveAt(i);
                }
            }
        }

        protected void addFoodToOrder_Click(object sender, EventArgs e)
        {
            int itemId = int.Parse(FoodItemsList.SelectedValue);
            int itemQuantity = int.Parse(FoodQuantity.Text);

            addItemToOrder(itemId, itemQuantity);

            // bind repeater
            foodRepeater.DataSource = foodItems;
            foodRepeater.DataBind();

            // bind listview
            ListView1.DataSource = foodItems;
            ListView1.DataBind();
        }

        protected void SubmitOrder_Click(object sender, EventArgs e)
        {
            int userId;
            int.TryParse(Request.QueryString["userId"], out userId);

            user = service.UserGet(userId);

            MyWs.Orders ordersHistory = user.OrderHistory;
            ordersHistory.OrderList = new MyWs.OrderedItems[0];

            orderedItems.FoodItems = foodItems.ToArray();
            orderedItems.FoodAmounts = foodAmounts.ToArray();

            service.AddOrderToHistory(ref ordersHistory, ref orderedItems);
            service.AddOrders(ordersHistory);

            Response.Redirect(string.Format("UserProfile.aspx?userId={0}", userId));
        }

        protected int GetItemCount(int index)
        {
            if (foodAmounts == null || index >= foodAmounts.Count)
            {
                return 0;
            }

            return foodAmounts[index];
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteItem")
            {
                int itemId = int.Parse(e.CommandArgument.ToString());
                removeItemFromList(itemId);
                
                ListView1.DataSource = foodItems;
                ListView1.DataBind();

                foodRepeater.DataSource = foodItems;
                foodRepeater.DataBind();
            }
        }
    }
}
