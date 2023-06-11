using IMS.CoreBusiness;
using IMS.CoreBusiness.TransactionTypes;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.EFCore
{
    public class ProductTransactionRepository : IProductTransactionRepository
    {
        private readonly IMSContext db;
        private readonly IProductRepository productRepository;

        public ProductTransactionRepository(
            IMSContext db,
            IProductRepository productRepository)
        {
            this.db = db;
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductTransaction>> GetProductTransactionAsync(
            string productName, 
            DateTime? dateFrom, 
            DateTime? dateTo, 
            ProductTransactionType? transactionType)
        {
            var query = from pt in db.ProductTransactions
                        join prod in db.Products on pt.ProductId equals prod.ProductId
                        where 
                            (string.IsNullOrEmpty(productName) || prod.ProductName.Contains(productName, StringComparison.OrdinalIgnoreCase)) &&
                            (!dateFrom.HasValue || pt.TransactionDate >= dateFrom.Value.Date) &&
                            (!dateTo.HasValue || pt.TransactionDate <= dateTo.Value.Date) &&
                            (!transactionType.HasValue || pt.ActivityType == transactionType)
                        select pt;

            return await query.Include(x => x.Product).ToListAsync();
        }

        public async Task ProduceAsync(string productionNumber, Product product, int quantity, double price, string doneBy)
        {
            var prod = await this.productRepository.GetProductByIdAsync(product.ProductId);

            if (prod != null)
            {
                foreach (var pi in prod.ProductInventories)
                {
                    int qtyBefore = pi.Inventory.Quantity;
                    pi.Inventory.Quantity -= quantity * pi.InventoryQuantity;

                    this.db.InventoryTransactions.Add(new InventoryTransaction
                    {
                        POnumber = productionNumber,
                        InventoryId = pi.Inventory.InventoryId,
                        QuantityBefore = qtyBefore,
                        InventoryType = InventoryTransactionType.ProduceProduct,
                        QuantityAfter = pi.Inventory.Quantity,
                        TransactionDate = DateTime.Now,
                        DoneBy = doneBy,
                        Cost = price
                    });
                    await this.db.SaveChangesAsync();
                }
            }

            this.db.ProductTransactions.Add(new ProductTransaction
            {
                ProductionNumber = productionNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.ProductQuantity,
                ActivityType = ProductTransactionType.ProduceProduct,
                QuantityAfter = product.ProductQuantity + quantity,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price,
            });

            await this.db.SaveChangesAsync();
        }

        public async Task SellProductAsync(string salesOrderNumber, Product product, int quantity, double price, string doneDy)
        {
            this.db.ProductTransactions.Add(new ProductTransaction
            {
                SalesOrderNumber = salesOrderNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.ProductQuantity,
                QuantityAfter = product.ProductQuantity - quantity,
                TransactionDate = DateTime.Now,
                DoneBy = doneDy,
                UnitPrice = price,
                ActivityType= ProductTransactionType.SellProduct
            });

            await this.db.SaveChangesAsync();
        }
    }
}
