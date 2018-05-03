using DbFirst;
using System.Collections.Generic;

namespace RepositoryInterfaces
{
    public interface IRestaurantRepository
    {
        IEnumerable<RestaurantInfo> getAll();
        RestaurantInfo GetRestaurantById(int restId);
        List<int> ConvertNameIntoId(string restaurantName);
        void AddRestaurant(RestaurantInfo restaurant);
        void DeleteRestaurant(RestaurantInfo restaurant);
        void DeleteRestaurantById(int restaurantId);
        void UpdateRestaurant(RestaurantInfo restaurant);
    }
}
