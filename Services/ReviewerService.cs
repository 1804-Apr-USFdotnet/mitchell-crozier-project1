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
        private IReviewerRepository reviewRepository;

        public ReviewerService(IReviewerRepository repository)
        {
            reviewRepository = repository;
        }
        public List<ReviewerInfo> GetAllReviewerInfo()
        {
            Console.WriteLine(reviewRepository.getAll());
            return reviewRepository.getAll().ToList();
        }
    }
}
