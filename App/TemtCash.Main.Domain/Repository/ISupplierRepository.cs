using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.ViewModel.Services.Supplier.Request;

namespace TemtCash.Main.Domain.Repository
{
    public interface ISupplierRepository : ICrudRepository<Supplier>
    {
        Task<PaginatedListResult<Supplier>> Search(SuppliersRequestViewModel viewModel);
    }
}