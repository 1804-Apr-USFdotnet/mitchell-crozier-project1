using DbFirst;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryInterfaces
{
    public interface IRestaurantRepository
    {
        IQueryable<RestaurantInfo> getAll();
        RestaurantInfo GetRestaurantById(int restId);
        List<int> ConvertNameIntoId(string restaurantName);
        void AddRestaurant(RestaurantInfo restaurant);
        void DeleteRestaurant(RestaurantInfo restaurant);
        void DeleteRestaurantById(int restaurantId);
        void UpdateRestaurant(RestaurantInfo restaurant);
    }
}
