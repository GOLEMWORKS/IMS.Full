using IMS.CoreBusiness;

namespace IMS.UseCases.Interfaces
{
    public interface IEditProductUseCase
    {
        Task ExecutionAsync(Product product);
    }
}