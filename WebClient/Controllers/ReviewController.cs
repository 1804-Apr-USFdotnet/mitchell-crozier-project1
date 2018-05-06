using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DbFirst;
using ServiceInterfaces;

namespace WebClient.Controllers
{
    public class ReviewController : Controller
    {
        private ProjectZeroDbContext db = new ProjectZeroDbContext();
        private readonly IRestaurantService _restaurantService;
        private readonly IReviewService _reviewService;
        private readonly ILoggingService _loggingService;

        public ReviewController(IRestaurantService restaurantService, IReviewService reviewService, ILoggingService loggingService)
        {
            _restaurantService = restaurantService;
            _reviewService = reviewService;
            _loggingService = loggingService;
        }
        // GET: Review
        public ActionResult Index()
        {
            return View(_reviewService.GetAllReviewerInfo());
        }
        
        public ActionResult AllReviews(int id)
        {
            Console.WriteLine("Here I am!");
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

            var result = _restaurantService.GetRestaurantById(id).RestaurantName;
            ViewBag.RestaurantName = result;
            ReviewerInfo reviewerInfo = new ReviewerInfo();
            return View(reviewerInfo);
        }

        // POST: Review/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewerName,Rating, restaurantId")] ReviewerInfo reviewerInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int newId = _reviewService.GetAllReviewerInfo().Select(x => x.reviewerId).Max() + 1;
                    reviewerInfo.reviewerId = newId;
                    reviewerInfo.Date = DateTime.Now;
                    var res = reviewerInfo.restaurantId;
                    _reviewService.AddReview(reviewerInfo);
                    _loggingService.Log("Created a new review with id: "+ reviewerInfo.restaurantId);
                    return RedirectToAction("Index","Restaurant");
                }
                catch (Exception e)
                {
                    _loggingService.Log(e);
                }
            }

            return RedirectToAction("Index");
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
                _reviewService.UpdateReview(reviewerInfo);
                return RedirectToAction("AllReviews", new {id = reviewerInfo.restaurantId});
            }
            return HttpNotFound();
        }

        // GET: Review/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewerInfo reviewerInfo = db.ReviewerInfoes.Find(id);
            if (reviewerInfo == null)
            {
                return HttpNotFound();
            }
            return View(reviewerInfo);
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReviewerInfo reviewerInfo = db.ReviewerInfoes.Find(id);
            db.ReviewerInfoes.Remove(reviewerInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
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
