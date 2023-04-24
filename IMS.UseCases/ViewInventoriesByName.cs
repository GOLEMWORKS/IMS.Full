using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases
{
    public class ViewInventoriesByName
    {
        private readonly IInventoryRepository inventoryRepository;

        public ViewInventoriesByName(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name)
        {
            return await this.inventoryRepository.GetInventoriesByName(name);
        }
    }
}