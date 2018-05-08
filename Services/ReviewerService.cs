using DbFirst;
using RepositoryInterfaces;
using ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operations;

namespace Services
{
    public class ReviewerService : IReviewService
    {
        private readonly IReviewerRepository _reviewRepository;

        public ReviewerService(IReviewerRepository repository)
        {
            _reviewRepository = repository;
        }
        public List<ReviewerInfo> GetAllReviewerInfo()
        {
            Console.WriteLine(_reviewRepository.getAll());
            return _reviewRepository.getAll().ToList();
        }

        public List<ReviewerInfo> GetAllReviewsForARestaurant(int restaurantId)
        {
            var fullList = GetAllReviewerInfo();
            var allReviews = new AllReviewsSingleRestauraunt();
            return allReviews.GetAllReviews(restaurantId, fullList);
        }

        public ReviewerInfo GetReviewById(int reviewId)
        {
            return _reviewRepository.GetReviewById(reviewId);
        }

        public bool AddReview(ReviewerInfo review)
        {
            return _reviewRepository.AddReview(review);
        }

        public bool DeleteReview(ReviewerInfo review)
        {
            return _reviewRepository.DeleteReview(review);
        }

        public bool DeleteReviewById(int reviewId)
        {
            return _reviewRepository.DeleteReviewById(reviewId);
        }

        public bool UpdateReview(ReviewerInfo review)
        {
           return  _reviewRepository.UpdateReview(review);
        }
    }
}
