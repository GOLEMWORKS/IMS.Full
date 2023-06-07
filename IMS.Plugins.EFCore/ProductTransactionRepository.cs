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
        
        public async Task ProduceAsync(string productionNumber, Product product, int quantity, double price, string doneBy)
        {
            var prod = await db.Products
                .Include(x => x.ProductInventories)
                .ThenInclude(x => x.Inventory)
                .FirstOrDefaultAsync(x => x.ProductId == product.ProductId);

            if (prod != null)
            {
                foreach (var pi in prod.ProductInventories)
                {
                    pi.Inventory.Quantity -= quantity * pi.InventoryQuantity;
                }
            }

            this.db.ProductTransactions.Add(new ProductTransaction
            {
                ProductionNnumber = productionNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.ProductQuantity,
                ActivityType = ProductTransactionType.ProduceProduct,
                QuantityAfter = product.ProductQuantity + quantity,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price
            });

            await this.db.SaveChangesAsync();
        }
    }
}
