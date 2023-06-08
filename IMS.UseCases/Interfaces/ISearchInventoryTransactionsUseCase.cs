using IMS.CoreBusiness;
using IMS.CoreBusiness.TransactionTypes;

namespace IMS.UseCases.Interfaces
{
    public interface ISearchInventoryTransactionsUseCase
    {
        Task<IEnumerable<InventoryTransaction>> ExecuteAsync(string inventoryName, DateTime dateFrom, DateTime dateTo, InventoryTransactionType transactionType);
    }
}