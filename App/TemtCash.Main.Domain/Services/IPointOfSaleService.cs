using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.PointOfSale.Request;
using TemtCash.Main.Domain.ViewModel.Services.PointOfSale.Response;

namespace TemtCash.Main.Domain.Services
{
    public interface IPointOfSaleService
    {
        Task<ServiceResult<PaginatedListResult<PointOfSalesResponseViewModel>>> Search(PointOfSalesRequestViewModel viewModel);
        Task<ServiceResult<PointOfSaleResponseViewModel>> GetSingle(int id);
        Task<ServiceResult<int>> Create(PointOfSaleCreateOrUpdateRequestViewModel viewModel);
        Task<ServiceResult<bool>> Update(int id, PointOfSaleCreateOrUpdateRequestViewModel viewModel);
        Task<ServiceResult<bool>> Delete(int id);
    }
}