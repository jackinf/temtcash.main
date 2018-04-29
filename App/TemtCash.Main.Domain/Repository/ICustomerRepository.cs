using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.ViewModel.Services.Customer.Request;

namespace TemtCash.Main.Domain.Repository
{
    public interface ICustomerRepository : ICrudRepository<Customer>
    {
        Task<Customer> GetSingleByCompanyAsync(int companyId, int id);
        Task<PaginatedListResult<Customer>> Search(CustomersRequestViewModel viewModel);
    }
}