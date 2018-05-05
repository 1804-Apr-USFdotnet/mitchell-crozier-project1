using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbFirst;
using ServiceInterfaces;


namespace WebClient.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly ILoggingService _loggingService;

        public RestaurantController(IRestaurantService restaurantService, IReviewService reviewService, ILoggingService loggingService)
        {
            _restaurantService = restaurantService;
            _loggingService = loggingService;
        }
        // GET: Restaurant
        [HttpGet]// default type of Action
        public ActionResult Index()
        {
            return View(_restaurantService.GetAllRestaurantInfo());
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int id)
        {
            return View(_restaurantService.GetRestaurantById(id));
        }

        public ActionResult Update(int id)
        {
            return View(_restaurantService.GetRestaurantById(id));
        }
        
        [HttpPost]
        public ActionResult Update(RestaurantInfo restaurant)
        {

            _restaurantService.UpdateRestaurant(restaurant);
            return RedirectToAction("Index");
        }
        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        [HttpPost]
        public ActionResult Create(RestaurantInfo restaurant)
        {
            try
            {
                int newId = _restaurantService.GetAllRestaurantInfo().Select(x => x.restaurantId).Max() + 1;
                restaurant.restaurantId = newId;
                _restaurantService.AddRestaurant(restaurant);
                // log that it worked
                _loggingService.Log("Added restaurant with an id of: " + restaurant.restaurantId + " and of name:" + restaurant.RestaurantName);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                // log some problem
                _loggingService.Log(e);
                return View();
            }
        }
        
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _restaurantService.DeleteRestaurantById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SortByAscendingName()
        {
            return View("Index",_restaurantService.SortNameAscending());
        }
        public ActionResult SortByDescendingName()
        {
            return View("Index",_restaurantService.SortNameDescending());
        }
        public ActionResult SortByAscendingId()
        {
            return View("Index", _restaurantService.SortIdAscending());
        }
        public ActionResult SortByDescendingId()
        {
            return View("Index", _restaurantService.SortIdDescending());
        }

    }
}