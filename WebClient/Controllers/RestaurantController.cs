using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DbFirst;
using Microsoft.Ajax.Utilities;
using ServiceInterfaces;
using WebClient.Models;


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
            return View(_mapper.Map<IEnumerable<RestaurantViewModel>>(_restaurantService.GetAllRestaurantInfo()));
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
                    return View(_mapper.Map<IEnumerable<RestaurantViewModel>>(_restaurantService.GetAllRestaurantInfo()));
                }
                return View(_mapper.Map<IEnumerable<RestaurantViewModel>>(_restaurantService.SearchByName(search)));
            }
            return View(_mapper.Map<IEnumerable<RestaurantViewModel>>(_restaurantService.SearchByName(query)));
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int id)
        {
            return View(_mapper.Map<RestaurantViewModel>(_restaurantService.GetRestaurantById(id)));
        }

        public ActionResult Update(int id)
        {
            return View(_mapper.Map<RestaurantViewModel>(_restaurantService.GetRestaurantById(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "restaurantId, RestaurantName, City, Street, Description, Email")]RestaurantViewModel restaurant)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var restaurantInfo = _mapper.Map<RestaurantInfo>(restaurant);
                    _restaurantService.UpdateRestaurant(restaurantInfo);
                    return RedirectToAction("Details", new { id = restaurant.restaurantId});
                }
                catch (Exception e)
                {
                    _loggingService.Log("Unable to update " + restaurant.RestaurantName + "possible error with mapper or persisting to database");
                    _loggingService.Log(e);
                    return RedirectToAction("Index");
                }
            }
            _loggingService.Log("Restaurant model updated was not valid");
            return RedirectToAction("Index");
        }
        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "restaurantId,RestaurantName, City, Street, Description, Email")]RestaurantViewModel restaurant)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int newId = _restaurantService.GetAllRestaurantInfo().Select(x => x.restaurantId).Max() + 1;
                    restaurant.restaurantId = newId;
                    var restaurantInfo = _mapper.Map<RestaurantInfo>(restaurant);
                    _restaurantService.AddRestaurant(restaurantInfo);
                    _loggingService.Log("Added restaurant with an id of: " + restaurantInfo.restaurantId + " and of name:" +
                                        restaurantInfo.RestaurantName);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    _loggingService.Log(e);
                    return RedirectToAction("Index");
                }
            }
            _loggingService.Log("Restaurant model not valid for creation");
            return RedirectToAction("Index");
        }

        public ActionResult TopThreeRated()
        {
            return View(_mapper.Map<IDictionary<RestaurantViewModel, double>>(_restaurantService.TopThreeRatedRestaurants()));
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
                return View("Index", _mapper.Map<IEnumerable<RestaurantViewModel>>(_restaurantService.SortNameAscending(list)));
            }
            else if (!search.IsNullOrWhiteSpace())
            {
                var searchList = _restaurantService.SearchByName(search);
                return View("Index", _mapper.Map<IEnumerable<RestaurantViewModel>>(_restaurantService.SortNameAscending(searchList)));

            }
            return View("Index", _mapper.Map<IEnumerable<RestaurantViewModel>>(_restaurantService.SortNameAscending()));
        }

        public ActionResult SortByDescendingName(string search)
        {
            string query = Request.QueryString["search"];
            if (!query.IsNullOrWhiteSpace())
            {
                var list = _restaurantService.SearchByName(query);
                return View("Index", _mapper.Map<IEnumerable<RestaurantViewModel>>(_restaurantService.SortNameDescending(list)));
            }
            else if (!search.IsNullOrWhiteSpace())
            {
                var searchList = _restaurantService.SearchByName(search);
                return View("Index", _mapper.Map<IEnumerable<RestaurantViewModel>>(_restaurantService.SortNameDescending(searchList)));

            }
            return View("Index", _mapper.Map<IEnumerable<RestaurantViewModel>>(_restaurantService.SortNameDescending()));
        }

        public ActionResult SortByAscendingId(string search)
        {
            string query = Request.QueryString["search"];
            if (!query.IsNullOrWhiteSpace())
            {
                var list = _restaurantService.SearchByName(query);
                return View("Index", _mapper.Map<IEnumerable<RestaurantViewModel>>(_restaurantService.SortIdAscending(list)));
            }
            else if (!search.IsNullOrWhiteSpace())
            {
                var searchList = _restaurantService.SearchByName(search);
                return View("Index", _mapper.Map<IEnumerable<RestaurantViewModel>>(_restaurantService.SortIdAscending(searchList)));

            }
            return View("Index", _mapper.Map<IEnumerable<RestaurantViewModel>>(_restaurantService.SortIdAscending()));

        }

        public ActionResult SortByDescendingId(string search)
        {
            string query = Request.QueryString["search"];
            if (!query.IsNullOrWhiteSpace())
            {
                var list = _restaurantService.SearchByName(query);
                return View("Index", _mapper.Map<IEnumerable<RestaurantViewModel>>(_restaurantService.SortIdDescending(list)));
            }
            else if (!search.IsNullOrWhiteSpace())
            {
                var searchList = _restaurantService.SearchByName(search);
                return View("Index", _mapper.Map<IEnumerable<RestaurantViewModel>>(_restaurantService.SortIdDescending(searchList)));

            }
            return View("Index", _mapper.Map<IEnumerable<RestaurantViewModel>>(_restaurantService.SortIdDescending()));
        }

    }
}