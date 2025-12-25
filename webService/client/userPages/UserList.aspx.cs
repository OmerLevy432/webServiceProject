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
                userRepeater.DataSource = await service.GetAllUsersAsync();
                userRepeater.DataBind();
            }
        }

        public async Task<List<MyWs.MyUser>> CallMyWebServiceAsync(string parameter)
        {
            // This is a method from your web service's proxy class.
            // Here we assume `MyWebServiceMethodAsync` is a method exposed by the web service.

            var result = await Task.Run(() =>
            {
                // Make the synchronous call in a Task to avoid blocking the main thread
                return service.GetAllUsersAsync();
            });

            return result;
        }
    }
}