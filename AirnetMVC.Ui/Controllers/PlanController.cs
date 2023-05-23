using AirnetMVC.Ui.Models;
using AirnetMVC.Ui.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirnetMVC.Ui.Controllers
{
      public class PlanController : Controller
      {
            // GET: Plans
            public PlansRepository plansRepository;
            public ReviewRepository reviewsRepository;
            public PlanController()
            {
                  plansRepository = new PlansRepository();
                  reviewsRepository = new ReviewRepository();
            }
            //[Route("GetAllPlans")]

            public ActionResult ViewPrepaidPlans()
            {
                  IEnumerable<Plan> plans = plansRepository.GetPrepaidPlans();
                  return View(plans);
            }
            public ActionResult ViewPostpaidPlans()
            {
                  IEnumerable<Plan> plans = plansRepository.GetPostpaidPlans();
                  return View(plans);
            }

            public ActionResult ViewAddonPlans()
            {
                  IEnumerable<Plan> plans = plansRepository.GetAddonPlans();
                  return View(plans);
            }


            public PartialViewResult CreatePlan()
            {
                  return PartialView("~/Views/Plan/CreatePlan.cshtml");
            }
            [HttpPost]
            public ActionResult CreatePlan(Plan plan)
            {
                  plan.PlanId = Guid.NewGuid();
                  plansRepository.AddPlan(plan);

                  return RedirectToAction("View" + plan.PlanType + "Plans");
            }
            public PartialViewResult PlanDetails(Guid id)
            {
                  Plan plan = plansRepository.GetPlanById(id);
                  ViewBag.OverAllRating = new ReviewRepository().GetOverAllPlanRating(id);
                  return PartialView("~/Views/Plan/PlanDetails.cshtml",plan);
            }
            public ActionResult DeletePlan(Guid id)
            {
                  Plan plan = plansRepository.GetPlanById(id);
                  plansRepository.DeletePlan(id);
                  return RedirectToAction("View" + plan.PlanType + "Plans");
            }
            public PartialViewResult EditPlan(Guid id)
            {
                  Plan plan = plansRepository.GetPlanById(id);
                  return PartialView("~/Views/Plan/EditPlan.cshtml", plan);
            }
            [HttpPost]
            public ActionResult EditPlan(Plan plan)
            {
                  plansRepository.EditPlan(plan);
                  return RedirectToAction("View" + plan.PlanType + "Plans");
            }
      }
}