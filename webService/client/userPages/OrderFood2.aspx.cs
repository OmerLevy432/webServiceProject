using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace client.userPages
{
    public partial class OrderFood2 : System.Web.UI.Page
    {
        MyWs.MainService service;

        List<MyWs.FoodItem> lst;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();
            lst = new List<MyWs.FoodItem>();
            
            // set item list
            ItemListDDL.DataSource = service.GetAllFoodItems();
            ItemListDDL.DataValueField = "itemId";
            ItemListDDL.DataTextField = "itemDescription";
            ItemListDDL.DataBind();

            // set quantity text
            QuantityTextBox.Text = "1";


        }

        protected void AdditemToList_Click(object sender, EventArgs e)
        {
            MyWs.FoodItem item = new MyWs.FoodItem();
            item.ItemId = int.Parse(ItemListDDL.SelectedValue.ToString());
            lst.Add((MyWs.FoodItem)ItemListDDL.SelectedItem);
        }
    }
}