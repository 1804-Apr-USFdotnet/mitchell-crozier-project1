using DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    public class Queries : IQueries
    {
        private const int numOfTopRestaurants = 3;
        
        //return the top @numOfTopRestaurants rated restaurants
        public List<RestaurantInfo> TopRatedRestaurantsQuery(IEnumerable<RestaurantInfo> restaurants)
        {
            List<RestaurantInfo> restaurantList = new List<RestaurantInfo>();
            List<int> rating = new List<int>();
            int averageRating = 0;
            Dictionary<RestaurantInfo, int> ratingMap = new Dictionary<RestaurantInfo, int>();
            return restaurants.Intersect(restaurants.OrderByDescending(x => x.ReviewerInfoes)).Take(numOfTopRestaurants).ToList();
           // return restaurants.OrderByDescending(x => x.ReviewerInfoes.GroupBy(y => y.restaurauntId)).Take(numOfTopRestaurants).ToList();
            /*
            foreach (var restaurant in restaurants)
            {
                List<ReviewerInfo> reviewers= restaurant.ReviewerInfoes.ToList<ReviewerInfo>();
                Console.WriteLine(reviewers);
                foreach (var review in reviewers)
                {
                    if(review.restaurauntId == restaurant.restaurantId)
                    {
                        if(ratingMap.Count != 0)
                        {
                            averageRating = ratingMap[restaurant];
                        } else
                        {
                            averageRating = 0;
                        }
                        averageRating += 
                        ratingMap.Add()
                    }
                }
                */
            }


        }
    }

