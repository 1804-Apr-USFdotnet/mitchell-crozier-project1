using DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
   public class TopThreeQuery
    {
        private const int numOfTopRestaurants = 3;
        public Dictionary<RestaurantInfo, double> GetTopThreeRated(IEnumerable<RestaurantInfo> restuarants, IEnumerable<ReviewerInfo> reviewsList)
        {    
            //Shout out to my boi Rafael for the crazy linq command

            var results = reviewsList.GroupBy(x => x.restaurantId,
                x => new { x.restaurantId, x.Rating }).Join(restuarants, x => x.Key, y => y.restaurantId,
                (x, y) => new { RestaurantInfo = y, AvgRating = x.Average(s => s.Rating) });

            
            results.ToDictionary(t => t.RestaurantInfo, t => t.AvgRating);
            double one = 0, two = 0, three = 0;
            RestaurantInfo resOne = null, resTwo = null, resThree = null;
            foreach (var result in results)
            {
                if(result.AvgRating > one)
                {
                    one = result.AvgRating;
                    resOne = result.RestaurantInfo;
                }
                else if (result.AvgRating > two)
                {
                    two = result.AvgRating;
                    resTwo = result.RestaurantInfo;

                }
                else if(result.AvgRating > three)
                {
                    three = result.AvgRating;
                    resThree = result.RestaurantInfo;
                }               
            }
            Dictionary<RestaurantInfo, double> topThreeDict = new Dictionary<RestaurantInfo, double>();
            topThreeDict.Add(resOne, one);
            topThreeDict.Add(resTwo, two);
            topThreeDict.Add(resThree, three);
            return topThreeDict;




        }
    }
}
