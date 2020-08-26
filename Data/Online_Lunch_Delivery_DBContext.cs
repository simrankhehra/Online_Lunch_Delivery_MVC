using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Lunch_Delivery_MVC.Models;

namespace Online_Lunch_Delivery_MVC.Data
{
    public class Online_Lunch_Delivery_DBContext : DbContext
    {
        public Online_Lunch_Delivery_DBContext (DbContextOptions<Online_Lunch_Delivery_DBContext> options)
            : base(options)
        {
        }

        public DbSet<Online_Lunch_Delivery_MVC.Models.Customer> Customer { get; set; }

        public DbSet<Online_Lunch_Delivery_MVC.Models.DeliveryAgent> DeliveryAgent { get; set; }

        public DbSet<Online_Lunch_Delivery_MVC.Models.LunchPack> LunchPack { get; set; }

        public DbSet<Online_Lunch_Delivery_MVC.Models.OnlineDelivery> OnlineDelivery { get; set; }
    }
}
