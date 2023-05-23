using AirnetMVC.Ui.Models;
using AirnetMVC.Ui.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirnetMVC.Ui.Controllers
{
    public class ClientController : Controller
    {
        public PlansRepository plansRepository;

        public ClientController()
        {
            plansRepository = new PlansRepository();
        }

        public PartialViewResult GetPlanDetails(Guid id) {
            Plan plan = plansRepository.GetPlanById(id);
            return PartialView("~/Views/Shared/PartialViews/_PlanDetailsPartialView.cshtml", plan);
        }

        [HttpGet]
        public ActionResult ViewPrepaidPlans()
        {
            IEnumerable<Plan> plans = plansRepository.GetPrepaidPlans();
            return View(plans);
        }

        [HttpGet]
        public ActionResult ViewPostpaidPlans()
        {
            IEnumerable<Plan> plans = plansRepository.GetPostpaidPlans();
            return View(plans);
        }

        [HttpGet]
        public ActionResult ViewAddonPlans()
        {
            IEnumerable<Plan> plans = plansRepository.GetAddonPlans();
            return View(plans);
        }
    }
}