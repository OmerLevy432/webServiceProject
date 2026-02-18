using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace client.userPages
{
    public partial class login : System.Web.UI.Page
    {
        MyWs.MainService service;
        public string errorMessage;

        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // try to get the user by email and password
            string email = EmailBox.Text;
            string password = PasswordBox.Text;
            MyWs.MyUser user = service.GetUserByPersonalData(email, password);

            if (user == null) errorMessage = "Failed to Login";

            Session["userObject"] = user;
            Response.Redirect("../FoodPages/FoodList.aspx");
           
        }
    }
}