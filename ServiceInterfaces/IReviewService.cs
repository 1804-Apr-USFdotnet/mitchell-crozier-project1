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
        void AddReview(ReviewerInfo review);
        void DeleteReview(ReviewerInfo review);
        void DeleteReviewById(int reviewId);
        void UpdateReview(ReviewerInfo review);
        List<ReviewerInfo> GetAllReviewsForARestaurant(int restaurantId);

    }
}
