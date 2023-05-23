using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AirnetMVC.Ui.Models;

namespace AirnetMVC.Ui.Repository
{
    public class RechargeRepository
    {
        public AirnetContext context;
        public RechargeRepository()
        {
            context = new AirnetContext();
        }
        public void AddRecharge(Recharge recharge)
        {
            context.Recharges.Add(recharge);
            context.SaveChanges();
        }

        public Recharge GetRechargeById(Guid rechargeId)
        {
            Recharge recharge = context.Recharges.Find(rechargeId);
            return recharge;
        }

        public IEnumerable<Recharge> GetRechargesByUser(string user)
        {
            var x = context.Recharges.Where(w => w.UserName.Equals(user)).Include(i => i.Plans);
            return x;
        }
    }
}