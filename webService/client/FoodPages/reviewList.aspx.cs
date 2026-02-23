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
        MyWs.MyUser user;
        protected void Page_Load(object sender, EventArgs e)
        {
            service = new MyWs.MainService();

            if (!IsPostBack)
            {
                setReviewsOnWebsite();
                SetAddReviewButton();
            }
        }

        protected void setReviewsOnWebsite()
        {
            currentItem = (MyWs.FoodItem)Session["currentItem"];
            if (currentItem == null) return;
            
            reviewsRepeater.DataSource = service.GetItemReviews(currentItem.ItemId).reviews;
            reviewsRepeater.DataBind();

            bool thereAreReview = currentItem.itemReviews.reviews == null;
            if (thereAreReview) lblNoReviews.Visible = true;
        }

        protected void SetAddReviewButton()
        {
            user = (MyWs.MyUser)Session["userObject"];
            if (user == null) return;

            reviewTextBox.Visible = true;
            AddReviewButton.Visible = true;
        }

        protected void AddReviewButton_Click(object sender, EventArgs e)
        {
            user = (MyWs.MyUser)Session["userObject"];
            currentItem = (MyWs.FoodItem)Session["currentItem"];

            /* set the single review */
            MyWs.Review review = new MyWs.Review();
            review.content = reviewTextBox.Text;
            review.userId = user.UserId;

            /* put it within the reviews of the item */
            MyWs.Reviews reviews = new MyWs.Reviews();
            reviews.reviews = new MyWs.Review[1];
            reviews.reviews[0] = review;
            reviews.itemId = currentItem.ItemId;

            service.AddReview(reviews);

            reviewsRepeater.DataSource = service.GetItemReviews(currentItem.ItemId).reviews;
            reviewsRepeater.DataBind();
        }
    }
}