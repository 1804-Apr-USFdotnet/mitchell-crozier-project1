using DbFirst;
using RepositoryInterfaces;
using ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ReviewerInfo GetReviewById(int reviewId)
        {
            return _reviewRepository.GetReviewById(reviewId);
        }

        public void AddReview(ReviewerInfo review)
        {
            _reviewRepository.AddReview(review);
        }

        public void DeleteReview(ReviewerInfo review)
        {
            _reviewRepository.DeleteReview(review);
        }

        public void DeleteReviewById(int reviewId)
        {
            _reviewRepository.DeleteReviewById(reviewId);
        }

        public void UpdateReview(ReviewerInfo review)
        {
            _reviewRepository.UpdateReview(review);
        }
    }
}
