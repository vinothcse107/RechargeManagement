using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirnetMVC.Ui.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public string UserRole { get; set; }
        public virtual ICollection<Recharge> Recharges { get; set; }
        public virtual ICollection<Review> Review { get; set; }

    }
}