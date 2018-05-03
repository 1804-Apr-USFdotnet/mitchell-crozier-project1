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

        public RestaurantRepository(ProjectZeroDbContext context)
        {
            _context = context;
        }

        public IEnumerable<RestaurantInfo> getAll()
        {
            return _context.RestaurantInfoes;
        }

        public RestaurantInfo GetRestaurantById(int restId)
        {
            var rest = getAll().SingleOrDefault(x => x.restaurantId == restId);
            var restFind = _context.RestaurantInfoes.Find(restId);
            return rest;

        }
        public List<int> ConvertNameIntoId(string restaurantName)
        {
            var ids = _context.RestaurantInfoes.Where(x => x.RestaurantName == restaurantName).Select(r => r.restaurantId).ToList();
            return ids;
        }

        public void AddRestaurant(RestaurantInfo restaurant)
        {
            _context.RestaurantInfoes.Add(restaurant);
            _context.SaveChanges();
        }

        public void DeleteRestaurant(RestaurantInfo restaurant)
        {
            _context.RestaurantInfoes.Remove(restaurant);
            _context.SaveChanges();
        }

        public void DeleteRestaurantById(int restaurantId)
        {
            var rest = GetRestaurantById(restaurantId);
            _context.RestaurantInfoes.Remove(rest);
            _context.SaveChanges();
        }

        public void UpdateRestaurant(RestaurantInfo restaurant)
        {
            var rest = _context.RestaurantInfoes.Find(restaurant.restaurantId);
            if (rest != null)
            {
                _context.Entry(rest).CurrentValues.SetValues(restaurant);
                _context.SaveChanges();
            }
        }



    }
}
