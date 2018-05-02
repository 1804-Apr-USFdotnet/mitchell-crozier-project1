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
        IEnumerable<ReviewerInfo> getAll();

    }
}
