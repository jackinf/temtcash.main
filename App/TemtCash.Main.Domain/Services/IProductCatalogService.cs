using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.ProductCatalog.Request;
using TemtCash.Main.Domain.ViewModel.Services.ProductCatalog.Response;

namespace TemtCash.Main.Domain.Services
{
    public interface IProductCatalogService
    {
        Task<ServiceResult<PaginatedListResult<ProductsResponseViewModel>>> Search(ProductsRequestViewModel viewModel);
        Task<ServiceResult<PaginatedListResult<ProductGroupsResponseViewModel>>> SearchListOfProductGroups(ProductGroupsRequestViewModel viewModel);
        Task<ServiceResult<ProductRequestViewModel>> GetSingle(int id);
        Task<ServiceResult<int>> Create(ProductCreateOrUpdateRequestViewModel viewModel);
        Task<ServiceResult<bool>> Update(int id, ProductCreateOrUpdateRequestViewModel viewModel);
        Task<ServiceResult<bool>> Delete(int id);
    }
}