using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.Customer;

namespace TemtCash.Main.Domain.Services
{
    public interface ICustomerService
    {
        Task<ServiceResult<PaginatedListResult<CustomersResponseViewModel>>> Search(CustomersRequestViewModel viewModel);

        Task<ServiceResult<CustomerResponseViewModel>> GetSingle(int id);

        Task<ServiceResult<int>> Create(CustomerCreateOrUpdateRequestViewModel viewModel);

        Task<ServiceResult<bool>> Update(int id, CustomerCreateOrUpdateRequestViewModel viewModel);

        Task<ServiceResult<bool>> Delete(int id);
    }
}