using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webService.App_Code
{
    public class Review
    {
        public string content { set; get; }
        public int reviewId { set; get; }
        public int userId { set; get; }

        public Review() { }
        public Review(string content, int reviewId, int userId)
        {
            this.content = content;
            this.reviewId = reviewId;
            this.userId = userId;
        }

        public Review(Review review)
        {
            this.content = review.content;
            this.reviewId = review.reviewId;
            this.userId = review.userId;
        }
    }
}