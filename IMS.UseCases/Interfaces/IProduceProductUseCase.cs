using IMS.CoreBusiness;

namespace IMS.UseCases.Interfaces
{
    public interface IProduceProductUseCase
    {
        Task ExecuteAsync(string productionNumber, Product product, int quantity, double price, string doneBy);
    }
}