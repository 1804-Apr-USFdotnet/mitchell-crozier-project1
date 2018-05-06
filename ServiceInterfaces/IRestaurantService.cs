using DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterfaces
{
    public interface IRestaurantService
    {
        List<RestaurantInfo> GetAllRestaurantInfo();
        RestaurantInfo GetRestaurantById(int restId);
        void AddRestaurant(RestaurantInfo restaurant);
        void DeleteRestaurant(RestaurantInfo restaurant);
        void DeleteRestaurantById(int restaurantId);
        void UpdateRestaurant(RestaurantInfo restaurant);
        Dictionary<RestaurantInfo, double> TopThreeRatedRestaurants();
        List<RestaurantInfo> SearchByName(string name);
        Dictionary<ReviewerInfo, RestaurantInfo> AllReviewsForARestauraunt(string name);
        List<RestaurantInfo> SortIdAscending();
        List<RestaurantInfo> SortIdDescending();
        List<RestaurantInfo> SortNameAscending();
        List<RestaurantInfo> SortNameDescending();
        List<RestaurantInfo> SortIdAscending(List<RestaurantInfo> list);
        List<RestaurantInfo> SortIdDescending(List<RestaurantInfo> list);
        List<RestaurantInfo> SortNameAscending(List<RestaurantInfo> list);
        List<RestaurantInfo> SortNameDescending(List<RestaurantInfo> list);

    }
}
