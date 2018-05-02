using DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    public interface IQueries
    {
        List<RestaurantInfo> TopRatedRestaurantsQuery(IEnumerable<RestaurantInfo> restaurants);
    }
}
