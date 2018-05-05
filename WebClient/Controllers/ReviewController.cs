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

        public ReviewController(IRestaurantService restaurantService, IReviewService reviewService)
        {
            _restaurantService = restaurantService;
            _reviewService = reviewService;
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
        public ActionResult Create()
        {
            ViewBag.restaurantId = new SelectList(db.RestaurantInfoes, "restaurantId", "RestaurantName");
            return View();
        }

        // POST: Review/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "reviewerId,restaurantId,ReviewerName,Rating,Date")] ReviewerInfo reviewerInfo)
        {
            if (ModelState.IsValid)
            {
                _reviewService.AddReview(reviewerInfo);
                return RedirectToAction("Index");
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

            var result = new SelectList(_restaurantService.GetAllRestaurantInfo(), "restaurantId", "RestaurantName", reviewerInfo.restaurantId);
            ViewBag.restaurantId = result;
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
                db.Entry(reviewerInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.restaurantId = new SelectList(db.RestaurantInfoes, "restaurantId", "RestaurantName", reviewerInfo.restaurantId);
            return View(reviewerInfo);
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
