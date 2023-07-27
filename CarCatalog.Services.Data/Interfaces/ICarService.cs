using CarCatalog.Web.ViewModels.Home;

namespace CarCatalog.Services.Data.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeCarsAsync();
    }
}
