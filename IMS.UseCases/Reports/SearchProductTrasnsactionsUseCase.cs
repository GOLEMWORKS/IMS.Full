using IMS.CoreBusiness;
using IMS.CoreBusiness.TransactionTypes;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Reports
{
    public class SearchProductTrasnsactionsUseCase : ISearchProductTrasnsactionsUseCase
    {
        private readonly IProductTransactionRepository productTransactionRepository;

        public SearchProductTrasnsactionsUseCase(IProductTransactionRepository productTransactionRepository)
        {
            this.productTransactionRepository = productTransactionRepository;
        }
        public async Task<IEnumerable<ProductTransaction>> ExecuteAsync(
            string productName,
            DateTime? dateFrom,
            DateTime? dateTo,
            ProductTransactionType? transactionType)
        {
            return await this.productTransactionRepository.GetProductTransactionAsync(
                productName,
                dateFrom,
                dateTo,
                transactionType);
        }
    }
}
