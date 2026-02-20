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
                setReviewsOnWebsite();
            }
        }

        protected void setReviewsOnWebsite()
        {
            currentItem = (MyWs.FoodItem)Session["currentItem"];
            if (currentItem == null)
            {
                lblNoReviews.Visible = true;
                return;
            }

            reviewsRepeater.DataSource = currentItem.itemReviews.reviews;
            reviewsRepeater.DataBind();
        }

        protected void AddReviewButton_Click(object sender, EventArgs e)
        {
            MyWs.Review review = new MyWs.Review();
            review.content = reviewTextBox.Text;

            MyWs.Reviews reviews = new MyWs.Reviews();
            reviews.reviews = new MyWs.Review[1];
            reviews.reviews[0] = review;
        }
    }
}