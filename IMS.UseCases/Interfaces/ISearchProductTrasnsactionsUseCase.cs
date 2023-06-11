using IMS.CoreBusiness;
using IMS.CoreBusiness.TransactionTypes;

namespace IMS.UseCases.Reports
{
    public interface ISearchProductTrasnsactionsUseCase
    {
        Task<IEnumerable<ProductTransaction>> ExecuteAsync(string productName, DateTime? dateFrom, DateTime? dateTo, ProductTransactionType? transactionType);
    }
}