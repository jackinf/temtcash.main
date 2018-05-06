using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Supplier.Request;
using TemtCash.Main.Domain.ViewModel.Services.Supplier.Response;

namespace TemtCash.Main.Api.Services
{
    public class SupplierService : ISupplierService
    {
        public async Task<ServiceResult<PaginatedListResult<SuppliersResponseViewModel>>> Search(SuppliersRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<SupplierResponseViewModel>> GetSingle(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<int>> Create(SupplierCreateOrUpdateRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<bool>> Update(int id, SupplierCreateOrUpdateRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<bool>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}