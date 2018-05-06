using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.ViewModel.Services.Supplier.Request;

namespace TemtCash.Main.DAL.Repository
{
    public class SupplierRepository : CrudRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<PaginatedListResult<Supplier>> Search(SuppliersRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}