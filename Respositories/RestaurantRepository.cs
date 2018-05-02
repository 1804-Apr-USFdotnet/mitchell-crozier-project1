using RepositoryInterfaces;
using DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private ProjectZeroDbContext context;

        public RestaurantRepository(ProjectZeroDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<RestaurantInfo> getAll()
        {
            return context.RestaurantInfoes;
        }
        public List<int> ConvertNameIntoId(string restaurantName)
        {
            var ids = context.RestaurantInfoes.Where(x => x.RestaurantName == restaurantName).Select(r => r.restaurantId).ToList();
            return ids;
        }


    }
}
