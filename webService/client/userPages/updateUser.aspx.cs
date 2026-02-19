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
            if (!IsPostBack)
            {       
                MyWs.MyUser user = (MyWs.MyUser)Session["userObject"];
                UsernameBox.Text = user.UserName;
                EmailBox.Text = user.UserEmail;
                PasswordBox.Text = user.UserPassword;
                UserIdLiteral.Text = user.UserId.ToString();

                // load the roles
                DDLRole.DataSource = service.GetAllRoles();
                DDLRole.DataTextField = "RoleTag";
                DDLRole.DataValueField = "RoleId";
                DDLRole.DataBind();

                DDLRole.SelectedValue = user.RoleTag.RoleId.ToString();
            }
        }

        protected void UpdateUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                user = (MyWs.MyUser)Session["userObject"];

                // load the current values into the user
                user.UserId = int.Parse(UserIdLiteral.Text);
                user.UserName = UsernameBox.Text;
                user.UserEmail = EmailBox.Text;
                user.UserPassword = PasswordBox.Text;
                user.RoleTag = new MyWs.Roles();

                // checks if the update was successful
                if (service.UserUpdate(user) != -1)
                {
                    Response.Redirect("UserList.aspx");
                }
            }
            catch (Exception)
            {

                return;
            }
        }
    }
}