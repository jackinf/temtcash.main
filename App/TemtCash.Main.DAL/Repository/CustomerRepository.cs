using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.ViewModel.Services.Customer;

namespace TemtCash.Main.DAL.Repository
{
    public class CustomerRepository : CrudRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<PaginatedListResult<Customer>> Search(CustomersRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}