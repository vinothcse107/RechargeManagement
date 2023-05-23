using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AirnetMVC.Ui.Models;
namespace AirnetMVC.Ui.Repository
{
    public class PlansRepository
    {
        public AirnetContext context;
        public PlansRepository()
        {
            context = new AirnetContext();
        }
        public void AddPlan(Plan plan)
        {
            context.Plans.Add(plan);
            context.SaveChanges();

        }
        public void EditPlan(Plan plan)
        {
            context.Entry<Plan>(plan).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeletePlan(Guid planId)
        {
            context.Plans.Remove(context.Plans.Find(planId));
            context.SaveChanges();
        }
        public Plan GetPlanById(Guid planId)
        {
            Plan plan = context.Plans.Find(planId);
            return plan;
        }
        public IEnumerable<Plan> GetPrepaidPlans()
        {
            return context.Plans.Where(plan => plan.PlanType == "Prepaid");
            // return context.Plans.ToList();
        }

        public IEnumerable<Plan> GetPostpaidPlans()
        {
            return context.Plans.Where(plan => plan.PlanType == "Postpaid");
            // return context.Plans.ToList();
        }

        public IEnumerable<Plan> GetAddonPlans()
        {
            return context.Plans.Where(plan => plan.PlanType == "Addon");
            // return context.Plans.ToList();
        }



    }
}