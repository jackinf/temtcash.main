using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.ProductCatalog.Request;
using TemtCash.Main.Domain.ViewModel.Services.ProductCatalog.Response;

namespace TemtCash.Main.Api.Services
{
    public class ProductCatalogService : IProductCatalogService
    {
        public async Task<ServiceResult<PaginatedListResult<ProductsResponseViewModel>>> Search(ProductsRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<PaginatedListResult<ProductGroupsResponseViewModel>>> SearchListOfProductGroups(ProductGroupsRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<ProductRequestViewModel>> GetSingle(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<int>> Create(ProductCreateOrUpdateRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<bool>> Update(int id, ProductCreateOrUpdateRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<bool>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}