using DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterfaces
{
    public interface IReviewService
    {
        List<ReviewerInfo> GetAllReviewerInfo();
        ReviewerInfo GetReviewById(int reviewId);
        bool AddReview(ReviewerInfo review);
        bool DeleteReview(ReviewerInfo review);
        bool DeleteReviewById(int reviewId);
        bool UpdateReview(ReviewerInfo review);
        List<ReviewerInfo> GetAllReviewsForARestaurant(int restaurantId);

    }
}
