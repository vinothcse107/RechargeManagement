using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirnetMVC.Ui.Models
{
    public class Plan
    {
        [Key]
        public Guid PlanId { get; set; }
        public string PlanType { get; set; }
        public string Data { get; set; }
        public string PlanName { get; set; }
        public int PlanValidity { get; set; }
        public string PlanDetails { get; set; }
        public int PlanPrice { get; set; }
        public string PlanOffers { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<Recharge> Recharges { get; set; }

    }
}
