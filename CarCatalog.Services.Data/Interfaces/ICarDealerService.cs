namespace CarCatalog.Services.Data.Interfaces
{
    public interface ICarDealerService
    {
        Task<int?> GetIdOfDealershipByNameAsync(string name);
    }
}
