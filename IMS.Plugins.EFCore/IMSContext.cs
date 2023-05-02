using IMS.CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore
{
    public class IMSContext : DbContext
    {
        public IMSContext(DbContextOptions options) : base(options)
        {        
        }

        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>().HasData(
                     new Inventory { InventoryId = 1, InventoryName="Двигатель", Price=20000, Quantity=1},
                     new Inventory { InventoryId = 2, InventoryName = "Трансмиссия", Price = 28700, Quantity = 1 },
                     new Inventory { InventoryId = 3, InventoryName = "Колёса", Price = 4000, Quantity = 4 },
                     new Inventory { InventoryId = 4, InventoryName = "Шины", Price = 4000, Quantity = 5 },
                     new Inventory { InventoryId = 5, InventoryName = "Кузов", Price = 74000, Quantity = 1 }
            );
        }
    }
}
