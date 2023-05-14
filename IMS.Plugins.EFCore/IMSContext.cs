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
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>().HasData(
                     new Inventory { InventoryId = 1, InventoryName="Двигатель (Бензиновый)", Price=26000, Quantity=1},
                     new Inventory { InventoryId = 2, InventoryName = "Двигатель (Дизельный)", Price = 20000, Quantity = 1 },
                     new Inventory { InventoryId = 3, InventoryName = "Электродвигатель", Price = 40000, Quantity = 1 },
                     new Inventory { InventoryId = 4, InventoryName = "Трансмиссия", Price = 28700, Quantity = 1 },
                     new Inventory { InventoryId = 5, InventoryName = "Колёса", Price = 4000, Quantity = 4 },
                     new Inventory { InventoryId = 6, InventoryName = "Шины", Price = 4000, Quantity = 5 },
                     new Inventory { InventoryId = 7, InventoryName = "Кузов", Price = 74000, Quantity = 1 },
                     new Inventory { InventoryId = 8, InventoryName = "Блок батареи", Price = 70000, Quantity = 1 }
            );

            modelBuilder.Entity<Product>().HasData(
                     new Product { ProductId = 1, ProductName = "Автомобиль (Дизельное топливо)", ProductPrice = 2000000, ProductQuantity = 1 },
                     new Product { ProductId = 2, ProductName = "Автомобиль (Бензин)", ProductPrice = 2020000, ProductQuantity = 1 },
                     new Product { ProductId = 3, ProductName = "Электромобиль", ProductPrice = 4120000, ProductQuantity = 1 }
            );
        }
    }
}
