using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.EFCore
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IMSContext db;

        public InventoryRepository(IMSContext db)
        {
            this.db = db;
        }
        async Task<IEnumerable<Inventory>> IInventoryRepository.GetInventoriesByName(string name)
        {
           return await this.db.Inventories.Where(x => x.InventoryName.Contains(name) ||
                                            string.IsNullOrWhiteSpace(name)).ToListAsync();
            //29.02
        }
    }
}