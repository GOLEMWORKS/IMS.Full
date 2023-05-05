using IMS.CoreBusiness;
using IMS.UseCases.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases
{
    public class ViewInventoriesByIdUseCase : IViewInventoriesByIdUseCase
    {
        private readonly IInventoryRepository inventoryRepository;

        public ViewInventoriesByIdUseCase(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public async Task<Inventory?> ExecuteAsync(int inventoryId)
        {
            return await inventoryRepository.GetInventoriesById(inventoryId);
        }
    }
}
