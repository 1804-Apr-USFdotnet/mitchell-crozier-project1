using Operations;
using ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Application : IApplication
    {
        private IRestaurantService restaurantService;
        private IReviewService reviewService;
        private ILoggingService loggingService;
        private IQueries queries;
        private bool isYouFinishedOrIsYouDone;
        private IInOut inOut;

        public Application(IRestaurantService restaurantService, IReviewService reviewService, ILoggingService loggingService, IInOut inOut)
        {
            this.restaurantService = restaurantService;
            this.reviewService = reviewService;
            this.loggingService = loggingService;
            this.inOut = inOut;

        }

        public void Run()
        {
            while (!isYouFinishedOrIsYouDone)
            {
                int action = 0;
                Console.WriteLine($"\nWelcome to Restaurant Reviews, what would you like to do today?" +
                                    "\n1 - View All Restaurants\n2 - View Top Three Rated Restaurants\n3 - All Reviews For a Restaurant" +
                                    "\n4 - Search\n5 - Quit");
                                    
                try
                {
                    action = Convert.ToInt32(System.Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid input!");
                    loggingService.Log(ex);
                }


                switch (action)
                {

                    case 1:
                        ViewAllRestaurants();
                        break;
                    case 2:
                        TopThreeRatedRestaurants();
                        break;
                    case 3:
                        AllReviewsForARestaurant();
                        break;
                    case 4:
                        Search();
                        break;
                    case 5:
                        Quit();
                        break;
                    default:
                        Console.WriteLine("\nThat is not an option!\n");
                        Run();
                        break;
                }
            }
        }

        private void ViewAllRestaurants()
        {
            Console.WriteLine("\nAll Restaurants:\n");
            Console.WriteLine("How do you want to sort?\n" +
                              "1: By restaurantId (Ascending)\n" +
                              "2: By restaurantId (Descending)\n" +
                              "3: By RestaurantName (Ascending)\n" +
                              "4: By RestaurantName (Descending)\n");
            int input = inOut.ReadInteger();
            switch (input)
            {
                case 1:
                    SortIdAscending();
                    break;
                case 2:
                    SortIdDescending();
                    break;
                case 3:
                    SortNameAscending();
                    break;
                case 4:
                    SortNameDescending();
                    break;
                default:
                    inOut.Output("\nThat is not an option!\n");
                    Run();
                    break;
            }

        }
        private void SortIdAscending()
        {
            var results = restaurantService.GetAllRestaurantInfo();
            var restaurantList = results.OrderBy(x => x.restaurantId);

            inOut.Output(restaurantList);
        }

        private void SortIdDescending()
        {
            var results = restaurantService.GetAllRestaurantInfo();
            var restaurantList = results.OrderByDescending(x => x.restaurantId);

            inOut.Output(restaurantList);
        }

        private void SortNameAscending()
        {
            var results = restaurantService.GetAllRestaurantInfo();
            var restaurantList = results.OrderBy(x => x.RestaurantName);

            inOut.Output(restaurantList);
        }

        private void SortNameDescending()
        {
            var results = restaurantService.GetAllRestaurantInfo();
            var restaurantList = results.OrderByDescending(x => x.RestaurantName);

            inOut.Output(restaurantList);
        }

        private void TopThreeRatedRestaurants()
        {
            string[] test = { "test", "lame", "dumb", "std" };
            string[] test2 = { "lol", "ha", "ok", "absolutely", "ridiculous" };
            var restut = test.Union(test2).Where(x => x.Length < 5).OrderBy(x => x.Length).Union(test).Reverse();
            Console.WriteLine(restut);
            Console.WriteLine();
            Console.WriteLine("Top three rated \n");
            var results = restaurantService.TopThreeRatedRestaurants();
            inOut.Output(results);
        }

        private void Search()
        {
            inOut.Output("Search for a restaurant \nEnter a full or partial restaurant name:  ");
            string name = null;
            try
            {
                name = Console.ReadLine();
            }
            catch (Exception ex)
            {
                inOut.Output("Invalid input!");
                loggingService.Log(ex);
            }
            var results = restaurantService.SearchByName(name);
            inOut.Output(results);
        }

        private void AllReviewsForARestaurant()
        {
            inOut.Output("All reviews for a restaurant \nEnter the full restaurant name");
            string name = null;
            try
            {
                name = inOut.ReadString();
            }
            catch (Exception ex)
            {
                inOut.Output("Invalid input!");
                loggingService.Log(ex);
            }
            var results = restaurantService.AllReviewsForARestauraunt(name);
            var restaurantList = results.Values.ToList();
            int restId = restaurantList[0].restaurantId;
            bool multipleLocations = false;
            foreach (var restaurant in restaurantList)
            {
                if (restaurant.restaurantId != restId)
                {
                    multipleLocations = true;
                }
            }
            if (multipleLocations)
            {
                inOut.Output(restaurantList.Select(rest => rest).Distinct());
                inOut.Output("There is more than one location for the restauraunt you entered!\nInput the id number for the restaurant you wish to select:\n");
                int input = -1;
                try
                {
                    input = inOut.ReadInteger();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid input!");
                    loggingService.Log(ex);
                }
                foreach (var review in results.Keys.ToList())
                {
                    if (input == review.restaurantId)
                    {
                        inOut.Output(review);
                    }
                }

            }
            else
            {
                foreach (var review in results.Keys.ToList())
                {
                    inOut.Output(review);
                }
            }

        }
        private void Quit()
        {
            inOut.Output("See ya later folks!");
            isYouFinishedOrIsYouDone = true;
        }



    }
}

