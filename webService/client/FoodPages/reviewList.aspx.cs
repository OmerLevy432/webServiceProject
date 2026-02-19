using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace client.userPages
{
    public partial class reviewList : System.Web.UI.Page
    {
        MyWs.MainService service;
        MyWs.FoodItem currentItem;
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();

            if (!IsPostBack)
            {
                currentItem = (MyWs.FoodItem)Session["currentItem"];
                reviewsRepeater.DataSource = currentItem.itemReviews.reviews;
                reviewsRepeater.DataBind();
            }
        }
    }
}