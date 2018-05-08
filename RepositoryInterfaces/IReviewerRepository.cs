using DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces
{
    public interface IReviewerRepository
    {
        IQueryable<ReviewerInfo> getAll();
        ReviewerInfo GetReviewById(int revId);
        bool AddReview(ReviewerInfo review);
        bool DeleteReview(ReviewerInfo review);
        bool DeleteReviewById(int reviewId);
        bool UpdateReview(ReviewerInfo review);

    }
}
