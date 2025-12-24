using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace client.rolePages
{
    public partial class RoleAdd : System.Web.UI.Page
    {
        MyWs.MainService service;
        MyWs.Roles role;
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();
        }

        protected void AddRoleButton_Click(object sender, EventArgs e)
        {

            // set info
            role = new MyWs.Roles();
            role.RoleTag = RoleTagBox.Text;
            role.RoleId = int.Parse(RoleIdBox.Text);

            /* check if the addition was successful*/
            if (service.RoleAdd(role) != -1)
            {
                Response.Redirect("RoleList.aspx");
            }
        }
    }
}