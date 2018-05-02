using DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    public class SearchRestaurant
    {
        public List<RestaurantInfo> PartialSearch(string partialName, IEnumerable<RestaurantInfo> restaurants)
        {
            List<RestaurantInfo> results = new List<RestaurantInfo>();
            foreach (var restaurant in restaurants)
            {
                if (restaurant.RestaurantName.Contains(partialName))
                {
                    results.Add(restaurant);
                }
            }
            return results;
        }
    }
}
