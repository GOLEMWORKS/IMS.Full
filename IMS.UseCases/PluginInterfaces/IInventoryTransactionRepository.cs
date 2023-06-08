using IMS.CoreBusiness;
using IMS.CoreBusiness.TransactionTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInventoryTransactionRepository
    {
        Task<IEnumerable<InventoryTransaction>> GetInventoryTransactionAsync(string inventoryName, DateTime? dateFrom, DateTime? dateTo, InventoryTransactionType? transactionType);
        Task PurchaseAsync(string poNumber, Inventory inventory, int quantity, double inventoryPrice, string DoneBy);
    }
}
