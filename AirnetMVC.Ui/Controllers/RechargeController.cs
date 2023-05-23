using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirnetMVC.Ui.Models;
using AirnetMVC.Ui.Repository;

namespace AirnetMVC.Ui.Controllers
{
    //[Route("[controller")]
    public class RechargeController : Controller
    {
        public RechargeRepository rechargeRepository;
        public static Guid SetPlanId;
        public RechargeController()
        {
            rechargeRepository = new RechargeRepository();          
        }
        public PartialViewResult AddRecharge(Guid id)
        {
            SetPlanId = id;
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddRecharge(Recharge recharge)
        {          
            recharge.RechargeId = Guid.NewGuid();
            recharge.UserName = Session["username"].ToString();
            recharge.PlanId = SetPlanId;
            recharge.RechargeTime = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss tt"));

            rechargeRepository.AddRecharge(recharge);
            return RedirectToAction("RechargeHistory");
        }
        public ActionResult RechargeDetails(Guid id)
        {
            Recharge recharge = rechargeRepository.GetRechargeById(id);
            return View(recharge);
        }
        public ActionResult RechargeHistory()
        {
            var recharge = rechargeRepository.GetRechargesByUser(Session["username"].ToString());
            return View(recharge);
        }


    }
}