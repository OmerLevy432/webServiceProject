using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace client.FoodPages
{
    public partial class FoodList : System.Web.UI.Page
    {
        MyWs.MainService service;
        public string updateString = "";
        public string addString = "";
        public string addReview = "";
        MyWs.MyUser user;
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();

            if (!IsPostBack)
            {
                foodRepeater.DataSource = service.GetAllFoodItems();
                foodRepeater.DataBind();

                user = (MyWs.MyUser)Session["userObject"];
                if (user == null) return;

                if (user.RoleTag.RoleId == 3)
                {
                    updateString = "<asp:LinkButton ID=\"btnUpdateItem\" runat=\"server\" CommandArgument=\"123\" OnCommand=\"btnUpdateItem_Command\">Update Item</asp:LinkButton>\r\n";
                    addString = "<a href=\"FoodAdd.aspx\">Add food item</a> <br />\r\n";
                }
            }
        }

        protected void btnViewReviews_Command(object sender, CommandEventArgs e)
        {
            int itemId = int.Parse(e.CommandArgument.ToString());
            Session["currentItem"] = service.GetFoodItemById(itemId);
            Response.Redirect("reviewList.aspx");
        }


        protected void foodRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // Check if we are looking at a data item (not a header or footer)
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                user = (MyWs.MyUser)Session["userObject"];

                // If user is admin, find the button and make it visible
                if (user != null && user.RoleTag.RoleId == 3)
                {
                    LinkButton btnUpdate = (LinkButton)e.Item.FindControl("btnUpdateItem");
                    if (btnUpdate != null)
                    {
                        btnUpdate.Visible = true;
                    }
                }
            }
        }
        protected void btnUpdateItem_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                int itemId = int.Parse(e.CommandArgument.ToString());
                MyWs.FoodItem selectedItem = service.GetFoodItemById(itemId);
                Session["currentItem"] = selectedItem;
                Response.Redirect("FoodUpdate.aspx");
            }
        }
    }
}