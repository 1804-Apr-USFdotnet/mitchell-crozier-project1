using DbFirst;
using Operations;
using RepositoryInterfaces;
using ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RestaurantService : IRestaurantService
    {
        private IRestaurantRepository restaurantRepository;
        private IReviewerRepository reviewerRepository;

        public RestaurantService(IRestaurantRepository repository, IReviewerRepository reviewRepository)
        {
            restaurantRepository = repository;
            reviewerRepository = reviewRepository;
        }
        public List<RestaurantInfo> GetAllRestaurantInfo()
        {
            return restaurantRepository.getAll().ToList();
        }

        public RestaurantInfo GetRestaurantById(int restId)
        {
            return restaurantRepository.GetRestaurantById(restId);
        }

        public bool AddRestaurant(RestaurantInfo restaurant)
        {
            return restaurantRepository.AddRestaurant(restaurant);
        }

        public bool DeleteRestaurant(RestaurantInfo restaurant)
        {
            return  restaurantRepository.DeleteRestaurant(restaurant);
        }

        public bool DeleteRestaurantById(int restaurantId)
        {
           return restaurantRepository.DeleteRestaurantById(restaurantId);
        }

        public bool UpdateRestaurant(RestaurantInfo restaurant)
        {
            return restaurantRepository.UpdateRestaurant(restaurant);
        }

        public Dictionary<RestaurantInfo, double> TopThreeRatedRestaurants()
        {
            var restaurants = restaurantRepository.getAll();
            var reviews = reviewerRepository.getAll();
            var query = new TopThreeQuery();
            var results =  query.GetTopThreeRated(restaurants, reviews);
            
            return results;
        }


        public List<RestaurantInfo> SearchByName(string name)
        {
            var restaurants = restaurantRepository.getAll();
            var search = new SearchRestaurant();
            var results = search.PartialSearch(name, restaurants);
            return results;
        }

        public Dictionary<ReviewerInfo, RestaurantInfo> AllReviewsForARestauraunt(string name)
        {
            var restaurants = SearchByName(name);
            var reviews = reviewerRepository.getAll();
            var allReviews = new AllReviewsSingleRestauraunt();
            return allReviews.GetAllReviews(name, restaurants, reviews);
        }

        public List<int> ConvertNameIntoId(string restaurantName)
        {
            var ids = restaurantRepository.getAll().Where(x => x.RestaurantName == restaurantName).Select(r => r.restaurantId).ToList();
            return ids;
        }

        public List<RestaurantInfo> SortIdAscending()
        {
            return restaurantRepository.getAll().OrderBy(x => x.restaurantId).ToList();
        }

        public List<RestaurantInfo> SortIdDescending()
        {
            return restaurantRepository.getAll().OrderByDescending(x => x.restaurantId).ToList();
        }

        public List<RestaurantInfo> SortNameAscending()
        {
            return restaurantRepository.getAll().OrderBy(x => x.RestaurantName).ToList();
        }

        public List<RestaurantInfo> SortNameDescending()
        {
            return restaurantRepository.getAll().OrderByDescending(x => x.RestaurantName).ToList();
        }
        public List<RestaurantInfo> SortIdAscending(List<RestaurantInfo> list)
        {
            return list.OrderBy(x => x.restaurantId).ToList();
        }
        public List<RestaurantInfo> SortIdDescending(List<RestaurantInfo> list)
        {
            return list.OrderByDescending(x => x.restaurantId).ToList();
        }

        public List<RestaurantInfo> SortNameAscending(List<RestaurantInfo> list)
        {
            return list.OrderBy(x => x.RestaurantName).ToList();
        }

        public List<RestaurantInfo> SortNameDescending(List<RestaurantInfo> list)
        {
            return list.OrderByDescending(x => x.RestaurantName).ToList();
        }
    }

    
}
