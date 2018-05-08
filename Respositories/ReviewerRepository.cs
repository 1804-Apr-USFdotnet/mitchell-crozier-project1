using DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryInterfaces;

namespace Respositories
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly ProjectZeroDbContext _context;

        public ReviewerRepository(ProjectZeroDbContext context)
        {
            _context = context;
        }

        public IQueryable<ReviewerInfo> getAll()
        {
            return _context.ReviewerInfoes;
        }

        public ReviewerInfo GetReviewById(int revId)
        {
            var review = getAll().SingleOrDefault(x => x.reviewerId == revId);
            var reviewFind = _context.ReviewerInfoes.Find(revId);
            return reviewFind;
        }

        public bool AddReview(ReviewerInfo reviewer)
        {
            try
            {
                _context.ReviewerInfoes.Add(reviewer);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool DeleteReview(ReviewerInfo reviewer)
        {
            try
            {
                _context.ReviewerInfoes.Remove(reviewer);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool DeleteReviewById(int reviewerId)
        {
            try
            {
                var review = GetReviewById(reviewerId);
                _context.ReviewerInfoes.Remove(review);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool UpdateReview(ReviewerInfo reviewer)
        {
            try
            {
                var review = _context.ReviewerInfoes.Find(reviewer.reviewerId);
                if (review != null)
                {
                    _context.Entry(review).CurrentValues.SetValues(reviewer);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
