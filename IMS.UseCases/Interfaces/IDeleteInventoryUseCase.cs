namespace IMS.UseCases.Interfaces
{
    public interface IDeleteInventoryUseCase
    {
        Task ExecuteAsync(int id);
    }
}