using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace client
{
    public partial class UserList : System.Web.UI.Page
    {
        MyWs.MainService service;

        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();

            if (!IsPostBack)
            {
                userRepeater.DataSource = service.GetAllUsers();
                userRepeater.DataBind();
            }
        }

        protected void HandleUserCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "LoginAs")
            {
                // Set the session to the impersonated user's ID
                int newUserID = int.Parse(e.CommandArgument.ToString());
                Session["userObject"] = service.UserGet(newUserID);

                // Redirect to their profile
                Response.Redirect("UserProfile.aspx");
            }
        }
    }
}