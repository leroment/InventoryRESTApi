using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryRESTApi.Entities
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }
    }
}
