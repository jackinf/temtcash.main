using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.Supplier.Request;
using TemtCash.Main.Domain.ViewModel.Services.Supplier.Response;

namespace TemtCash.Main.Domain.Services
{
    public interface ISupplierService
    {
        Task<ServiceResult<PaginatedListResult<SuppliersResponseViewModel>>> Search(SuppliersRequestViewModel viewModel);
        Task<ServiceResult<SupplierResponseViewModel>> GetSingle(int id);
        Task<ServiceResult<int>> Create(SupplierCreateOrUpdateRequestViewModel viewModel);
        Task<ServiceResult<bool>> Update(int id, SupplierCreateOrUpdateRequestViewModel viewModel);
        Task<ServiceResult<bool>> Delete(int id);
    }
}