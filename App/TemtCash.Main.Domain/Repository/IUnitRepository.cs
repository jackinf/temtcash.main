using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.ViewModel.Services.Unit.Request;

namespace TemtCash.Main.Domain.Repository
{
    public interface IUnitRepository : ICrudRepository<ProductUnit>
    {
        Task<PaginatedListResult<ProductUnit>> Search(UnitssRequestViewModel viewModel);
    }
}