using client.MyWs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace client.userPages
{
    public partial class signUp : System.Web.UI.Page
    {
        MyWs.MainService service;
        public string errorMessage;

        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();
        }

        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            MyUser user = CreateUser();
            if (service.UserAdd(user) == 0)
            {
                errorMessage = "Error With Sign Up";
            }
            Session["userObject"] = user;
            Response.Redirect("../FoodPages/FoodList.aspx");
        }

        protected MyUser CreateUser()
        {
            MyUser user = new MyUser();
            user.UserName = UserNameBox.Text;
            user.UserEmail = EmailBox.Text;
            user.UserPassword = PasswordBox.Text;
            user.RoleTag = new Roles();
            user.RoleTag.RoleId = 1;
            user.OrderHistory = new Orders();

            return user;
        }
    }
}