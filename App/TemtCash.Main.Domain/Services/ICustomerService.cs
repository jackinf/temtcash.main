using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.Customer;
using TemtCash.Main.Domain.ViewModel.Services.Customer.Request;
using TemtCash.Main.Domain.ViewModel.Services.Customer.Response;

namespace TemtCash.Main.Domain.Services
{
    public interface ICustomerService
    {
        Task<ServiceResult<PaginatedListResult<CustomersResponseViewModel>>> Search(CustomersRequestViewModel viewModel);

        Task<ServiceResult<CustomerResponseViewModel>> GetSingle(int companyId, int id);

        Task<ServiceResult<int>> Create(int companyId, CustomerCreateOrUpdateRequestViewModel viewModel);

        Task<ServiceResult<bool>> Update(int companyId, int id, CustomerCreateOrUpdateRequestViewModel viewModel);

        Task<ServiceResult<bool>> Delete(int companyId, int id);
    }
}