using DbFirst;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryInterfaces
{
    public interface IRestaurantRepository
    {
        IQueryable<RestaurantInfo> getAll();
        RestaurantInfo GetRestaurantById(int restId);
//        List<int> ConvertNameIntoId(string restaurantName);
        bool AddRestaurant(RestaurantInfo restaurant);
        bool DeleteRestaurant(RestaurantInfo restaurant);
        bool DeleteRestaurantById(int restaurantId);
        bool UpdateRestaurant(RestaurantInfo restaurant);
    }
}
