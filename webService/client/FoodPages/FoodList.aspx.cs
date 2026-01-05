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
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();

            if (!IsPostBack)
            {
                foodRepeater.DataSource = service.GetAllFoodItems();
                foodRepeater.DataBind();

                int roleId;
                int adminId = 3;
                int.TryParse(Request.QueryString["roleId"], out roleId);

                /* check if the user is admin */
                if (roleId == adminId)
                {
                    updateString = "<a href='FoodUpdate.aspx?itemId=<%# Eval(\"ItemId\") %>'>update</a>";
                    addString = "<a href=\"FoodAdd.aspx\">Add food item</a> <br />\r\n";
                }
            }
        }
    }
}