using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.ViewModel.Services.PointOfSale.Request;

namespace TemtCash.Main.Domain.Repository
{
    public interface IPointOfSaleRepository : ICrudRepository<Store>
    {
        Task<PaginatedListResult<Store>> Search(PointOfSalesRequestViewModel viewModel);
    }
}