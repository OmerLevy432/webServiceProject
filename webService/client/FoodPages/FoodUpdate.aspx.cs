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
        MyWs.MyUser user;
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();
            foodItem = new MyWs.FoodItem();
            user = (MyWs.MyUser)Session["userObject"];

            if (!IsPostBack)
            {
                foodItem = (MyWs.FoodItem)Session["currentItem"];
                ItemCreatorIdBox.Text = foodItem.UserId.ToString();
                ItemIdBox.Text = foodItem.ItemId.ToString();
                ItemPriceBox.Text = foodItem.ItemPrice.ToString();
                ItemDescriptionBox.Text = foodItem.ItemDescription;
                ImageUrlBox.Text = foodItem.ImageUrl;
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
                foodItem.ImageUrl = ImageUrlBox.Text;   

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