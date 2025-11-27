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

                // update the user in the database
                service.FoodItemUpdate(foodItem);
            }
            catch (Exception)
            {

                return;
            }
        }

        protected void GetFoodItemClick(object sender, EventArgs e)
        {
            try
            {
                // load the data into the text box when the get data button is pressed
                foodItem = service.GetFoodItemById(int.Parse(ItemIdBox.Text));

                ItemPriceBox.Text = foodItem.ItemPrice.ToString();
                ItemDescriptionBox.Text = foodItem.ItemDescription;
                ItemIdBox.Text = foodItem.ItemId.ToString();
                ItemCreatorIdBox.Text = foodItem.UserId.ToString();
            }
            catch (Exception)
            {

                return;
            }
        }
    }
}