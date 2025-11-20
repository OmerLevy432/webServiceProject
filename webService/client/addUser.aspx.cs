using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace client
{
    public partial class addUser : System.Web.UI.Page
    {
        MyWs.MainService service;
        MyWs.MyUser user;
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();
        }

        protected void AddUserButton_Click(object sender, EventArgs e)
        {
            // check if a user with that email exists
            user = service.GetUserWithEmail(EmailBox.Text);

            if (user == null)
            {
                // set info
                user = new MyWs.MyUser();
                user.UserName = UsernameBox.Text;
                user.UserEmail = EmailBox.Text;
                user.UserPassword = PasswordBox.Text;
                user.RoleTag = new MyWs.Roles();
                user.RoleTag.RoleId = int.Parse(RoleIdBox.Text);
                user.OrderHistory = new MyWs.Orders();

                service.UserAdd(user);
            }
        }
    }
}