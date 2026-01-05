using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace client.userPages
{
    public partial class chooseOrderUser : System.Web.UI.Page
    {
        MyWs.MainService service;
        MyWs.MyUser user;
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();
        }

        protected void order_Click(object sender, EventArgs e)
        {
            user = service.GetUserByPersonalData(userEmail.Text, userPassword.Text);
            /* check if the user exists*/
            if (user == null)
            {
                errorLabel.Text = "Password or Email are incorrect";
                return;
            }

            Response.Redirect(String.Format("OrderFood.aspx?roleId={0}", user.RoleTag.RoleId));
        }
    }
}