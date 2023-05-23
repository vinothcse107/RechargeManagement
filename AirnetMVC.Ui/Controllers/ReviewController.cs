using AirnetMVC.Ui.Models;
using AirnetMVC.Ui.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirnetMVC.Ui.Controllers
{
    public class ReviewController : Controller
    {
        public ReviewRepository ReviewRepo;
        public PlansRepository PlansRepo;
        public static Guid CreatePlanId;
        public ReviewController()
        {
            ReviewRepo = new ReviewRepository();
            PlansRepo = new PlansRepository(); 
        }
        public PartialViewResult AddReview(Guid PlanId)
        {
            CreatePlanId = PlanId;
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddReview(Review review)
        {
            review.Username = Session["username"].ToString();
            review.PlanId = CreatePlanId;
            Plan plan = PlansRepo.GetPlanById(review.PlanId);
            ReviewRepo.AddReview(review);
            return RedirectToAction("View"+plan.PlanType+"Plans", "Client");
        }

        // GET: Review
        [ChildActionOnly]
        public ActionResult ReviewsPartialView(Guid Id)
        {
            var reviews = ReviewRepo.GetReviews(Id);
            ViewBag.PlanId = Id;
            return PartialView("/Views/Shared/PartialViews/ReviewsPartialView.cshtml", reviews);
        }

        public PartialViewResult EditReviewPartialView(string User, Guid Plan)
        {
            var review = ReviewRepo.GetReview(User,Plan);
            return PartialView(review);
        }
        [HttpPost]
        public ActionResult EditReviewPartialView(Review review)
        {
            ReviewRepo.EditReview(review);
            Plan plan = PlansRepo.GetPlanById(review.PlanId);
            return RedirectToAction("View"+ plan.PlanType+ "Plans", "Client");
        }
        public ActionResult DeleteReview(string User, Guid Plan)
        {
            ReviewRepo.DeleteReview(User, Plan);
            Plan plan = PlansRepo.GetPlanById(Plan);
            return RedirectToAction("View"+plan.PlanType+"Plans", "Client");
        }
    }
}