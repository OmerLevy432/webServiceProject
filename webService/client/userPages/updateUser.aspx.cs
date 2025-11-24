using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace client
{
    public partial class updateUser : System.Web.UI.Page
    {
        MyWs.MainService service;
        MyWs.MyUser user;

        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();
        }

        protected void GetUserButton_Click(object sender, EventArgs e)
        {
            // load the data into the text box when the get data button is pressed
            user = service.UserGet(int.Parse(UserIdBox.Text));

            UsernameBox.Text = user.UserName;
            EmailBox.Text = user.UserEmail;
            PasswordBox.Text = user.UserPassword;
            RoleIdBox.Text = user.RoleTag.RoleId.ToString();
        }

        protected void UpdateUserButton_Click(object sender, EventArgs e)
        {
            // load the current values into the user
            user.UserName = EmailBox.Text;
            user.UserEmail = EmailBox.Text;
            user.UserPassword = PasswordBox.Text;
            user.RoleTag = new MyWs.Roles();
            user.RoleTag.RoleId = int.Parse(RoleIdBox.Text);

            // update the user in the database
            service.UserUpdate(user);   
        }
    }
}