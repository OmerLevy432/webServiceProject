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
    }
}