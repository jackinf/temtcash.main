using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.ViewModel.Services.ProductCatalog.Request;

namespace TemtCash.Main.DAL.Repository
{
    public class ProductCatalogRepository : CrudRepository<Product>, IProductCatalogRepository
    {
        public ProductCatalogRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<PaginatedListResult<Product>> Search(ProductsRequestViewModel viewModel)
        {
            // TODO: include product category
            throw new System.NotImplementedException();
        }

        public Task<PaginatedListResult<ProductCategory>> SearchProductCategories(ProductGroupsRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}