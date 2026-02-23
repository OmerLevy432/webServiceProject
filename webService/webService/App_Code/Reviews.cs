using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web; 

namespace webService.App_Code
{
    public class Reviews: IDbAction
    {
        public int itemId { set; get; }
        public List<Review> reviews { set; get; }

        public Reviews()
        {
            this.reviews = new List<Review>();
        }
        public Reviews(int itemId)
        {
            this.itemId = itemId;
            this.Init();
        }

        public Reviews(Reviews reviwesObject)
        {
            foreach (Review review in reviwesObject.reviews)
            {
                this.reviews.Add(new Review(review));
            }
        }

        public int Init()
        {
            this.reviews = new List<Review>();

            // create string query and execute it
            string query = string.Format("select * from reviews where itemId = {0}", this.itemId);
            DataSet allReviews = DbQ.ExecuteQuery(query);

            int amountOfReviews = allReviews.Tables[0].Rows.Count;

            // adds all the reviews to the list
            for (int i = 0; i < amountOfReviews; i++)
            {
                Review currentReview = new Review(allReviews.Tables[0].Rows[i]["content"].ToString(),
                                                  int.Parse(allReviews.Tables[0].Rows[i]["id"].ToString()),
                                                  int.Parse(allReviews.Tables[0].Rows[i]["userId"].ToString()));
                this.reviews.Add(currentReview);    
            }

            return 1;
        }

        public int AddNew()
        {
            int i = 0;
            string query = "";
            int rowsChanged = 0;

            for (i = 0; i < this.reviews.Count; i++)
            {
                query = string.Format("insert into reviews (itemId, content, userId) values ('{0}', '{1}', '{2}')",
                    this.itemId, this.reviews[i].content, this.reviews[i].userId);
                rowsChanged += DbQ.ExecuteNonQuery(query);
            }

            return rowsChanged;
        }

        public int Update()
        {
            int i = 0;
            string query = "";
            int rowsChanged = 0;

            for (i = 0; i < this.reviews.Count; i++)
            {
                query = string.Format("update orders set id='{0}', content='{1}', userid='{2}' where itemId={3};", this.reviews[i].reviewId,
                    this.reviews[i].content, this.reviews[i].userId, this.itemId);
                rowsChanged += DbQ.ExecuteNonQuery(query);
            }

            return rowsChanged;
        }

        public int Delete()
        {
            int i = 0;
            string query = "";
            int rowsChanged = 0;

            for (i = 0; i < this.reviews.Count; i++)
            {
                this.reviews.RemoveAt(i);
                query = string.Format("delete from orders where itemId={0}", this.itemId);
                rowsChanged += DbQ.ExecuteNonQuery(query);
            }

            return rowsChanged;
        }
    }

    
}