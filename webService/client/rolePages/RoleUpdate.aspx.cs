using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace client.rolePages
{
    public partial class RoleUpdate : System.Web.UI.Page
    {
        MyWs.MainService service;
        MyWs.Roles role;
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();
            role = new MyWs.Roles();

            if (!IsPostBack)
            {
                int roleId;

                // try to parse the role id
                if (int.TryParse(Request.QueryString["RoleId"], out roleId))
                {
                    role = service.GetRoleFromId(roleId);
                    RoleIdLabel.Text = role.RoleId.ToString();
                    RoleTagBox.Text = role.RoleTag;
                }
            }
        }

        protected void UpdateRoleButtonClick(object sender, EventArgs e)
        {
            try
            {
                // load the current values into the user
                role.RoleId = int.Parse(RoleIdLabel.Text);
                role.RoleTag = RoleTagBox.Text;

                // update the role in the database
                if (service.RoleUpdate(role) != -1)
                {
                    Response.Redirect("RoleList.aspx");
                }
            }
            catch (Exception)
            {

                return;
            }
        }
    }
}