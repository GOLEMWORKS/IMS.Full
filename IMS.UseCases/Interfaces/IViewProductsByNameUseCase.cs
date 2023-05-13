using IMS.CoreBusiness;

namespace IMS.UseCases.Products
{
    public interface IViewProductsByNameUseCase
    {
        Task<List<Product>> ExecuteAsync(string name = "");
    }
}