using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.ViewModel.Services.PointOfSale.Request;

namespace TemtCash.Main.DAL.Repository
{
    public class PointOfSaleRepository : CrudRepository<Store>, IPointOfSaleRepository
    {
        public PointOfSaleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<PaginatedListResult<Store>> Search(PointOfSalesRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}