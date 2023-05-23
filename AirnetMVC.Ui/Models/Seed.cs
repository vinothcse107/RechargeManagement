
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AirnetMVC.Ui.Models
{
    public class Seed
    {
        public AirnetContext _context;

        private string BasePath = @"C:\Users\2271353\Downloads\AirnetMVC-master\AirnetMVC-master\AirnetMVC.Ui\Models\Data\";
        //private string BasePath = @"C:\Users\vinos\Downloads\AirnetMVC-master (1)\AirnetMVC-master\AirnetMVC.Ui\Models\Data\";
        public Seed(AirnetContext context)
        {
            _context = context;

            if (CreateInitDb())
            {
                SeedUsers();
                SeedPlans();
                SeedRecharges();
                SeedReviews();
            }
        }
        public bool CreateInitDb()
        {
            if (_context.Database.CreateIfNotExists()) return true;
            return false;
        }
        public void SeedUsers()
        {
            var path = $"{BasePath}Users.json";
            var Data = System.IO.File.ReadAllText(path);
            var JsonData = JsonSerializer.Deserialize<List<User>>(Data);

            foreach (var x in JsonData)
            {
                Console.WriteLine(x);
                _context.Users.Add(x);
            }
            _context.SaveChanges();

            Console.WriteLine("Users Seeding Done");
        }
        public void SeedPlans()
        {
            var path = $"{BasePath}Plans.json";
            var Data = System.IO.File.ReadAllText(path);
            var JsonData = JsonSerializer.Deserialize<List<Plan>>(Data);

            foreach (var x in JsonData)
            {
                Console.WriteLine(x);
                _context.Plans.Add(x);
            }
            _context.SaveChanges();
        }
        public void SeedRecharges()
        {
            var path = $"{BasePath}Recharges.json";
            var Data = System.IO.File.ReadAllText(path);
            var JsonData = JsonSerializer.Deserialize<List<Recharge>>(Data);

            foreach (var x in JsonData)
            {
                Console.WriteLine(x);
                _context.Recharges.Add(x);
            }
            _context.SaveChanges();
        }

        public void SeedReviews()
        {
            var path = $"{BasePath}Reviews.json";
            var Data = System.IO.File.ReadAllText(path);
            var JsonData = JsonSerializer.Deserialize<List<Review>>(Data);

            foreach (var x in JsonData)
            {
                Console.WriteLine(x);
                _context.Reviews.Add(x);
            }
            _context.SaveChanges();
        }
    }
}
