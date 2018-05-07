using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DbFirst;
using Microsoft.Ajax.Utilities;
using ServiceInterfaces;


namespace WebClient.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly ILoggingService _loggingService;
        private readonly IMapper _mapper;

        public RestaurantController(IRestaurantService restaurantService, ILoggingService loggingService,  IMapper mapper)
        {
            _restaurantService = restaurantService;
            _loggingService = loggingService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return View(_restaurantService.GetAllRestaurantInfo());
        }
        // GET: Restaurant
        [HttpGet] // default type of Action
        public ActionResult Index(string search)
        {
            string query = Request.QueryString["search"];
            if (query.IsNullOrWhiteSpace())
            {
                if (search.IsNullOrWhiteSpace())
                {
                    return View(_restaurantService.GetAllRestaurantInfo());
                }
                return View(_restaurantService.SearchByName(search));
            }
            return View(_restaurantService.SearchByName(query));
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
            catch (Exception e)
            {
                // log some problem
                _loggingService.Log(e);
                return View();
            }
        }

        public ActionResult TopThreeRated()
        {
            return View(_restaurantService.TopThreeRatedRestaurants());
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

        public ActionResult SortByAscendingName(string search)
        {
            string query = Request.QueryString["search"];
            if (!query.IsNullOrWhiteSpace())
            {
                var list = _restaurantService.SearchByName(query);
                return View("Index", _restaurantService.SortNameAscending(list));
            }
            else if (!search.IsNullOrWhiteSpace())
            {
                var searchList = _restaurantService.SearchByName(search);
                return View("Index", _restaurantService.SortNameAscending(searchList));

            }
            return View("Index", _restaurantService.SortNameAscending());
        }

        public ActionResult SortByDescendingName(string search)
        {
            string query = Request.QueryString["search"];
            if (!query.IsNullOrWhiteSpace())
            {
                var list = _restaurantService.SearchByName(query);
                return View("Index", _restaurantService.SortNameDescending(list));
            }
            else if (!search.IsNullOrWhiteSpace())
            {
                var searchList = _restaurantService.SearchByName(search);
                return View("Index", _restaurantService.SortNameDescending(searchList));

            }
            return View("Index", _restaurantService.SortNameDescending());
        }

        public ActionResult SortByAscendingId(string search)
        {
            string query = Request.QueryString["search"];
            if (!query.IsNullOrWhiteSpace())
            {
                var list = _restaurantService.SearchByName(query);
                return View("Index", _restaurantService.SortIdAscending(list));
            }
            else if (!search.IsNullOrWhiteSpace())
            {
                var searchList = _restaurantService.SearchByName(search);
                return View("Index", _restaurantService.SortIdAscending(searchList));

            }
            return View("Index", _restaurantService.SortIdAscending());

        }

        public ActionResult SortByDescendingId(string search)
        {
            string query = Request.QueryString["search"];
            if (!query.IsNullOrWhiteSpace())
            {
                var list = _restaurantService.SearchByName(query);
                return View("Index", _restaurantService.SortIdDescending(list));
            }
            else if (!search.IsNullOrWhiteSpace())
            {
                var searchList = _restaurantService.SearchByName(search);
                return View("Index", _restaurantService.SortIdDescending(searchList));

            }
            return View("Index", _restaurantService.SortIdDescending());
        }

    }
}