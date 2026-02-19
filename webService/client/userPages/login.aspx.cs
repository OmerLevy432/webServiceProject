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
            string password = HashSHA256(PasswordBox.Text);
            MyWs.MyUser user = service.GetUserByPersonalData(email, password);

            if (user == null) errorMessage = "Failed to Login";

            Session["userObject"] = user;
            Response.Redirect("../FoodPages/FoodList.aspx");
           
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