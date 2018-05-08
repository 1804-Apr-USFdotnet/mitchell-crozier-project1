using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DbFirst;
using ServiceInterfaces;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class ReviewController : Controller
    {
        private ProjectZeroDbContext db = new ProjectZeroDbContext();
        private readonly IRestaurantService _restaurantService;
        private readonly IReviewService _reviewService;
        private readonly ILoggingService _loggingService;
        private readonly IMapper _mapper;

        public ReviewController(IRestaurantService restaurantService, IReviewService reviewService, ILoggingService loggingService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _reviewService = reviewService;
            _loggingService = loggingService;
            _mapper = mapper;
        }
        // GET: Review
        public ActionResult Index()
        {
            return View(_reviewService.GetAllReviewerInfo());
        }
        
        public ActionResult AllReviews(int id)
        {
            return View(_reviewService.GetAllReviewsForARestaurant(id));
        }   

        // GET: Review/Details/5
        public ActionResult Details(int id)
        {
            ReviewerInfo reviewerInfo = _reviewService.GetReviewById(id);
            if (reviewerInfo == null)
            {
                return HttpNotFound();
            }
            return View(reviewerInfo);
        }

        // GET: Review/Create
        public ActionResult Create(int id)
        {
//            var res = Request.Params["id"];
            //var res2 = ViewContext.RouteD

            var vRest = _mapper.Map<RestaurantViewModel>(_restaurantService.GetRestaurantById(id));
            string result = vRest.RestaurantName;
            ViewBag.RestaurantName = result;
            ReviewViewModel reviewerInfo = new ReviewViewModel();
            return View(reviewerInfo);
        }

        // POST: Review/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewerName,Rating, restaurantId")] ReviewViewModel reviewerInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int newId = _reviewService.GetAllReviewerInfo().Select(x => x.reviewerId).Max() + 1;
                    reviewerInfo.reviewerId = newId;
                    reviewerInfo.Date = DateTime.Now;
                    var res = reviewerInfo.restaurantId;
                    var review = _mapper.Map<ReviewerInfo>(reviewerInfo);
                    _reviewService.AddReview(review);
                    _loggingService.Log("Created a new review with id: " + reviewerInfo.restaurantId);
                    return RedirectToAction("AllReviews", new {id= reviewerInfo.restaurantId});
                }
                catch (Exception e)
                {
                    _loggingService.Log(e);
                }
            }

            return RedirectToAction("AllReviews" ,reviewerInfo.restaurantId);
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int id)
        {
            ReviewerInfo reviewerInfo = _reviewService.GetReviewById(id);
            if (reviewerInfo == null)
            {
                return HttpNotFound();
            }
            
            return View(reviewerInfo);
        }

        // POST: Review/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "reviewerId,restaurantId,ReviewerName,Rating,Date")] ReviewerInfo reviewerInfo)
        {
            if (ModelState.IsValid)
            {
                reviewerInfo.Date = DateTime.Now;
                reviewerInfo.RestaurantInfo = _restaurantService.GetRestaurantById(reviewerInfo.restaurantId);
                _reviewService.UpdateReview(reviewerInfo);
                return RedirectToAction("AllReviews", new {id = reviewerInfo.restaurantId});
            }
            return HttpNotFound();
        }

        // GET: Review/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                int restId = _reviewService.GetReviewById(id).restaurantId;
                
                _reviewService.DeleteReviewById(id);
                return RedirectToAction("AllReviews", new{ id = restId});
            }
            catch
            {
                return RedirectToAction("Index", "Restaurant");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
