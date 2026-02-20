using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace client.FoodPages
{
    public partial class FoodAdd : System.Web.UI.Page
    {
        MyWs.MainService service;
        MyWs.FoodItem foodItem;
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();
        }

        protected void AddFoodButton_Click(object sender, EventArgs e)
        {
            // set info
            foodItem = new MyWs.FoodItem();
            foodItem.ItemDescription = DescriptionBox.Text;
            foodItem.ItemPrice = double.Parse(PriceBox.Text);
            foodItem.UserId = int.Parse(CreatorIdBox.Text);
            foodItem.ImageUrl = ImageUrlBox.Text;

            if (service.FoodItemAdd(foodItem) != -1)
            {
                Response.Redirect("FoodList.aspx");
            }
        }
    }
}