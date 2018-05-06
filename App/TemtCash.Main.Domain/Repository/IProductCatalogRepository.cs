using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.ViewModel.Services.ProductCatalog.Request;

namespace TemtCash.Main.Domain.Repository
{
    public interface IProductCatalogRepository : ICrudRepository<Product>
    {
        Task<PaginatedListResult<Product>> Search(ProductsRequestViewModel viewModel);
        Task<PaginatedListResult<ProductCategory>> SearchProductCategories(ProductGroupsRequestViewModel viewModel);
    }
}