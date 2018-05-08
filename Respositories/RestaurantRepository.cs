using RepositoryInterfaces;
using DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ProjectZeroDbContext _context;
        private readonly IReviewerRepository _reviewerRepository;

        public RestaurantRepository(ProjectZeroDbContext context, IReviewerRepository reviewerRepository)
        {
            _context = context;
            _reviewerRepository = reviewerRepository;
        }

        public IQueryable<RestaurantInfo> getAll()
        {
            return _context.RestaurantInfoes;
        }

        public RestaurantInfo GetRestaurantById(int restId)
        {
            var rest = getAll().SingleOrDefault(x => x.restaurantId == restId);
            var restFind = _context.RestaurantInfoes.Find(restId);
            return rest;
        }
//        public List<int> ConvertNameIntoId(string restaurantName)
//        {
//            var ids = _context.RestaurantInfoes.Where(x => x.RestaurantName == restaurantName).Select(r => r.restaurantId).ToList();
//            return ids;
//        }

        public bool AddRestaurant(RestaurantInfo restaurant)
        {
            try
            {
                _context.RestaurantInfoes.Add(restaurant);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool DeleteRestaurant(RestaurantInfo restaurant)
        {
            try
            {
                _context.RestaurantInfoes.Remove(restaurant);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool DeleteRestaurantById(int restId)
        {
            var rest = GetRestaurantById(restId);
            var reviews = _reviewerRepository.getAll();
            var count1 = reviews.Count();
            var selectedReviews = reviews.Where(x => x.restaurantId == restId);
            var count2 = selectedReviews.Count();
            foreach (var review in selectedReviews)
            {
                _context.ReviewerInfoes.Remove(review);
            }

            try
            {
                _context.RestaurantInfoes.Remove(rest);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool UpdateRestaurant(RestaurantInfo restaurant)
        {
            var rest = _context.RestaurantInfoes.Find(restaurant.restaurantId);
            if (rest != null)
            {
                try
                {
                    _context.Entry(rest).CurrentValues.SetValues(restaurant);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                }

                return true;
            }

            return false;
        }
        




    }
}
