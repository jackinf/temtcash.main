using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Customer;

namespace TemtCash.Main.Api.Services
{
    public class CustomerService : ICustomerService
    {
        public Task<ServiceResult<PaginatedListResult<CustomersResponseViewModel>>> Search(CustomersRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<CustomerResponseViewModel>> GetSingle(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<int>> Create(CustomerCreateOrUpdateRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<bool>> Update(int id, CustomerCreateOrUpdateRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<bool>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}