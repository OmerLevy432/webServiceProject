using client.MyWs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            user.UserPassword = HashSHA256(PasswordBox.Text);
            user.RoleTag = new Roles();
            user.RoleTag.RoleId = 1;

            /* set the orders */
            user.OrderHistory = new Orders();
            List<OrderedItems> list = new List<OrderedItems>();
            user.OrderHistory.OrderList = list.ToArray();

            return user;
        }

        protected static string HashSHA256(string str)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(str);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // lowercase hex
                }

                return sb.ToString();
            }
        }
    }
}