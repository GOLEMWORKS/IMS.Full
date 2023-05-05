using IMS.CoreBusiness;

namespace IMS.UseCases.Interfaces
{
    public interface IViewInventoriesByIdUseCase
    {
        Task<Inventory?> ExecuteAsync(int inventoryId);
    }
}