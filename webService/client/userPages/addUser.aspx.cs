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

            if (!IsPostBack)
            {
                // load the roles
                DDLRole.DataSource = service.GetAllRoles();
                DDLRole.DataTextField = "RoleTag";
                DDLRole.DataValueField = "RoleId";
                DDLRole.DataBind(); 
            }
        }

        protected void AddUserButton_Click(object sender, EventArgs e)
        {
            // check if a user with that email exists
            user = service.GetUserWithEmail(EmailBox.Text);

            try
            {
                if (user == null)
                {
                    // set info
                    user = new MyWs.MyUser();
                    user.UserName = UsernameBox.Text;
                    user.UserEmail = EmailBox.Text;
                    user.UserPassword = PasswordBox.Text;
                    user.RoleTag = new MyWs.Roles();
                    user.RoleTag.RoleId = int.Parse(DDLRole.SelectedValue.ToString());
                    user.OrderHistory = new MyWs.Orders();

                    // checks if the addition was successful
                    if (service.UserAdd(user) != -1)
                    {
                        Response.Redirect("UserList.aspx");
                    }
                }
            }
            catch (Exception)
            {

                return;
            }
        }
    }
}