using IMS.CoreBusiness;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
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
            try
            {
                var dbCreator = Database.GetService<IDatabaseCreator> () as RelationalDatabaseCreator;
                if (dbCreator != null)
                {
                    if (!dbCreator.CanConnect()) dbCreator.Create();
                    if (!dbCreator.HasTables()) dbCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<ProductTransaction> ProductTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductInventory>()
                .HasKey(pi => new { pi.ProductId, pi.InventoryId });

            modelBuilder.Entity<ProductInventory>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductInventories)
                .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductInventory>()
                .HasOne(pi => pi.Inventory)
                .WithMany(p => p.ProductInventories)
                .HasForeignKey(pi => pi.InventoryId);

            modelBuilder.Entity<Inventory>().HasData(
                     new Inventory { InventoryId = 1, InventoryName="Двигатель (Бензиновый)", Price=26000, Quantity=1},
                     new Inventory { InventoryId = 2, InventoryName = "Двигатель (Дизельный)", Price = 20000, Quantity = 1 },
                     new Inventory { InventoryId = 3, InventoryName = "Электродвигатель", Price = 40000, Quantity = 1 },
                     new Inventory { InventoryId = 4, InventoryName = "Трансмиссия", Price = 28700, Quantity = 1 },
                     new Inventory { InventoryId = 5, InventoryName = "Колёса", Price = 4000, Quantity = 4 },
                     new Inventory { InventoryId = 6, InventoryName = "Шины", Price = 4000, Quantity = 5 },
                     new Inventory { InventoryId = 7, InventoryName = "Кузов", Price = 74000, Quantity = 1 },
                     new Inventory { InventoryId = 8, InventoryName = "Блок батареи", Price = 70000, Quantity = 1 },
                     new Inventory { InventoryId = 9, InventoryName = "Одиночное кресло", Price = 9000, Quantity = 1 },
                     new Inventory { InventoryId = 10, InventoryName = "Кресло 2 + 1", Price = 18500, Quantity = 1 }
            );

            modelBuilder.Entity<Product>().HasData(
                     new Product { ProductId = 1, ProductName = "Автомобиль (Дизельное топливо)", ProductPrice = 2000000, ProductQuantity = 1 },
                     new Product { ProductId = 2, ProductName = "Автомобиль (Бензин)", ProductPrice = 2020000, ProductQuantity = 1 },
                     new Product { ProductId = 3, ProductName = "Электромобиль", ProductPrice = 4120000, ProductQuantity = 1 }
            );

            modelBuilder.Entity<ProductInventory>().HasData(
                    new ProductInventory { ProductId = 1, InventoryId = 2, InventoryQuantity = 1}, // Двигатель (Бензин)
                    new ProductInventory { ProductId = 1, InventoryId = 7, InventoryQuantity = 1 }, // Кузов
                    new ProductInventory { ProductId = 1, InventoryId = 5, InventoryQuantity = 4 }, // 4 колеса
                    new ProductInventory { ProductId = 1, InventoryId = 6, InventoryQuantity = 4 }, // 4 шины
                    new ProductInventory { ProductId = 1, InventoryId = 9, InventoryQuantity = 2 }, // 2 одиночных кресла
                    new ProductInventory { ProductId = 1, InventoryId = 10, InventoryQuantity = 1 } // Одно кресло 2+1
            );

            modelBuilder.Entity<ProductInventory>().HasData(
                    new ProductInventory { ProductId = 2, InventoryId = 1, InventoryQuantity = 1 }, // Двигатель (Дизель)
                    new ProductInventory { ProductId = 2, InventoryId = 7, InventoryQuantity = 1 }, // Кузов
                    new ProductInventory { ProductId = 2, InventoryId = 5, InventoryQuantity = 4 }, // 4 колеса
                    new ProductInventory { ProductId = 2, InventoryId = 6, InventoryQuantity = 4 }, // 4 шины
                    new ProductInventory { ProductId = 2, InventoryId = 9, InventoryQuantity = 2 }, // 2 одиночных кресла
                    new ProductInventory { ProductId = 2, InventoryId = 10, InventoryQuantity = 1 } // Одно кресло 2+1
            );

            modelBuilder.Entity<ProductInventory>().HasData(
                    new ProductInventory { ProductId = 3, InventoryId = 3, InventoryQuantity = 4 }, // Электродвигатель
                    new ProductInventory { ProductId = 3, InventoryId = 7, InventoryQuantity = 1 }, // Кузов
                    new ProductInventory { ProductId = 3, InventoryId = 8, InventoryQuantity = 2 }, // Блок батареи
                    new ProductInventory { ProductId = 3, InventoryId = 5, InventoryQuantity = 4 }, // 4 колеса
                    new ProductInventory { ProductId = 3, InventoryId = 6, InventoryQuantity = 4 }, // 4 шины
                    new ProductInventory { ProductId = 3, InventoryId = 9, InventoryQuantity = 2 }, // 2 одиночных кресла
                    new ProductInventory { ProductId = 3, InventoryId = 10, InventoryQuantity = 1 } // Одно кресло 2+1
            );
        }
    }
}
