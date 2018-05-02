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
        private ProjectZeroDbContext context;

        public ReviewerRepository(ProjectZeroDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ReviewerInfo> getAll()
        {
            return context.ReviewerInfoes;
        }
    }
}
