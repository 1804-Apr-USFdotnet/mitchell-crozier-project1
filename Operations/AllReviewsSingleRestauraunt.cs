﻿using DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    public class AllReviewsSingleRestauraunt
    {
        public Dictionary<ReviewerInfo, RestaurantInfo> GetAllReviews(string name, List<RestaurantInfo> restaurants, IEnumerable<ReviewerInfo> reviews)
        {
            Dictionary<ReviewerInfo, RestaurantInfo> results = new Dictionary<ReviewerInfo, RestaurantInfo>();
            
            foreach (var review in reviews)
            {
                foreach (var restaurant in restaurants)
                {
                    if (restaurant.restaurantId == review.restaurantId && restaurant.RestaurantName == name)
                    {
                        results.Add(review, restaurant);
                    }
                }
            }
            return results;
        }

        public List<ReviewerInfo> GetAllReviews(int restId, List<ReviewerInfo> reviews)
        {
            List<ReviewerInfo> reviewList = new List<ReviewerInfo>();
            foreach (var review in reviews)
            {
                if (review.restaurantId == restId)
                {
                    reviewList.Add(review);
                }
            }

            return reviewList;
        }
    }
}

