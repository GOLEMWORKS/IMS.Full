using IMS.CoreBusiness;
using IMS.CoreBusiness.TransactionTypes;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        private readonly IMSContext db;

        public InventoryTransactionRepository(IMSContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<InventoryTransaction>> GetInventoryTransactionAsync(
            string inventoryName, 
            DateTime? dateFrom, 
            DateTime? dateTo, 
            InventoryTransactionType? transactionType)
        {
            var query = from it in db.InventoryTransactions
                        join inv in db.Inventories on it.InventoryId equals inv.InventoryId
                        where 
                            (string.IsNullOrWhiteSpace(inventoryName) || inv.InventoryName.Contains(inventoryName, StringComparison.OrdinalIgnoreCase)) &&
                            (!dateFrom.HasValue || it.TransactionDate >= dateFrom) &&
                            (!dateTo.HasValue || it.TransactionDate >= dateTo) &&
                            (!transactionType.HasValue || it.InventoryType == transactionType)
                        select it;

            return await query.Include(x => x.inventory).ToListAsync();
        }

        public async Task PurchaseAsync(string poNumber, Inventory inventory, int quantity, double inventoryPrice, string doneBy)
        {
            this.db.InventoryTransactions.Add(new InventoryTransaction
            {
                    POnumber = poNumber,
                    InventoryId = inventory.InventoryId,
                    QuantityBefore = inventory.Quantity,
                    InventoryType = InventoryTransactionType.PurchaseInventory,
                    QuantityAfter = inventory.Quantity + quantity,
                    TransactionDate = DateTime.Now,
                    DoneBy = doneBy,
                    Cost = inventoryPrice * quantity
            });
            await this.db.SaveChangesAsync();
        }
    }
}
