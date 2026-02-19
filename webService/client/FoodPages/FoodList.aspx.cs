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
        MyWs.MyUser user;
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();

            if (!IsPostBack)
            {
                foodRepeater.DataSource = service.GetAllFoodItems();
                foodRepeater.DataBind();

                user = (MyWs.MyUser)Session["userObject"];
                int adminId = 3;

                /* check if the user is admin */
                if (user.RoleTag.RoleId == adminId)
                {
                    updateString = "<a href='FoodUpdate.aspx?itemId=<%# Eval(\"ItemId\") %>'>update</a>";
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
    }
}