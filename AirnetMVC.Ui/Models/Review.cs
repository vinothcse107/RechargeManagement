using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AirnetMVC.Ui.Models
{
    public class Review
    {
        [Column(Order=0) , Key, ForeignKey("User")]
        public string Username { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        // ----------------------------------------
        [Column(Order = 1), Key, ForeignKey("Plan")]
        public Guid PlanId { get; set; }
        [JsonIgnore]
        public Plan Plan { get; set; }
        // -----------------
        public string ReviewContent { get; set; }
        public float ReviewRating { get; set; }
    }
}
