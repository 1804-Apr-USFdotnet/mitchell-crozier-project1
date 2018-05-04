﻿using DbFirst;
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

        public void AddRestaurant(RestaurantInfo restaurant)
        {
            restaurantRepository.AddRestaurant(restaurant);
        }

        public void DeleteRestaurant(RestaurantInfo restaurant)
        {
            restaurantRepository.DeleteRestaurant(restaurant);
        }

        public void DeleteRestaurantById(int restaurantId)
        {
            restaurantRepository.DeleteRestaurantById(restaurantId);
        }

        public void UpdateRestaurant(RestaurantInfo restaurant)
        {
            restaurantRepository.UpdateRestaurant(restaurant);
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
    }

    
}
