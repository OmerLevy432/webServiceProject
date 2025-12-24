using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace client.rolePages
{
    public partial class RoleList : System.Web.UI.Page
    {
        MyWs.MainService service;
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();

            if (!IsPostBack)
            {
                roleRepeater.DataSource = service.GetAllRoles();
                roleRepeater.DataBind();
            }
        }
    }
}