using IMS.CoreBusiness;

namespace IMS.UseCases.Interfaces
{
    public interface IAddProductUseCase
    {
        Task ExecuteAsync(Product product);
    }
}