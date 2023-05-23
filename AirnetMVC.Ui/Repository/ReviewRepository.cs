using AirnetMVC.Ui.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirnetMVC.Ui.Repository
{
    public class ReviewRepository
    {
        public AirnetContext context;

        public ReviewRepository()
        {
            context = new AirnetContext();
        }

        public void AddReview(Review review)
        {
            context.Reviews.Add(review);
            context.SaveChanges();
        }
        public void EditReview(Review review)
        {
            context.Entry(review).State = EntityState.Modified;
            context.SaveChanges();
        }
        public Review GetReview(string User, Guid Plan)
        {
            var Review = context.Reviews.FirstOrDefault(w => w.Username == User && w.PlanId == Plan); ;
            return Review;
        }
        public void DeleteReview(string User , Guid Plan)
        {
            var review = context.Reviews.FirstOrDefault(w => w.Username == User && w.PlanId == Plan);
            context.Reviews.Remove(review);
            context.SaveChanges();            
        }

        public IEnumerable<Review> GetReviews(Guid PlanId)
        {
            var planReviews = context.Reviews.Where(review => review.PlanId == PlanId);
            return planReviews;
        }
        public IEnumerable<Review> GetAllUserReviews(string Username)
        {
            var planReviews = context.Reviews.Where(review => review.Username == Username);
            return planReviews;
        }
        public int GetOverAllPlanRating(Guid PlanId)
        {
            var planReviews = context.Reviews.FirstOrDefault(p => p.PlanId == PlanId) != null 
                        ? (int)context.Reviews.Where(review => review.PlanId == PlanId)
                        .Select(s => s.ReviewRating).Average() : 0;
            return planReviews;
        }

    }
}