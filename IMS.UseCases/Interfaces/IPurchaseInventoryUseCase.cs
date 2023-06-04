using IMS.CoreBusiness;

namespace IMS.UseCases.Interfaces
{
    public interface IPurchaseInventoryUseCase
    {
        Task ExecuteAsync(string poNumber, Inventory inventory, int quantity, string DoneBy);
    }
}