using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.ViewModel.Services.Unit.Request;

namespace TemtCash.Main.DAL.Repository
{
    public class UnitRepository: CrudRepository<ProductUnit>, IUnitRepository
    {
        public UnitRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<PaginatedListResult<ProductUnit>> Search(UnitssRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}