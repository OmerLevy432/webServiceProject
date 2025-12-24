using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace client.FoodPages
{
    public partial class FoodUpdate : System.Web.UI.Page
    {
        MyWs.MainService service;
        MyWs.FoodItem foodItem;
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();
            foodItem = new MyWs.FoodItem();

            if (!IsPostBack)
            {
                int itemId;

                // try to parse the item id
                if (int.TryParse(Request.QueryString["itemId"], out itemId))
                {
                    foodItem = service.GetFoodItemById(itemId);
                    ItemCreatorIdBox.Text = foodItem.UserId.ToString();
                    ItemIdBox.Text = foodItem.ItemId.ToString();
                    ItemPriceBox.Text = foodItem.ItemPrice.ToString();
                    ItemDescriptionBox.Text = foodItem.ItemDescription;
                }
            }
        }

        protected void UpdateFoodButtonClick(object sender, EventArgs e)
        {
            try
            {
                // load the current values into the user
                foodItem.UserId = int.Parse(ItemCreatorIdBox.Text);
                foodItem.ItemPrice = double.Parse(ItemPriceBox.Text);
                foodItem.ItemDescription = ItemDescriptionBox.Text;
                foodItem.ItemId = int.Parse(ItemIdBox.Text);

                // update the food in the database
                if (service.FoodItemUpdate(foodItem) != -1)
                {
                    Response.Redirect("FoodList.aspx");
                }
            }
            catch (Exception)
            {

                return;
            }
        }
    }
}