using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpeysCloud.Core.Extension;
using SpeysCloud.Core.Result;
using TemtCash.Main.DAL.Helper;
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

        public async Task<PaginatedListResult<Product>> Search(ProductsRequestViewModel viewModel)
        {
            IQueryable<Product> SearchFilter(IQueryable<Product> queryInner)
            {
                return queryInner;
            }

            IQueryable<Product> SearchSort(IQueryable<Product> queryInner)
            {
                string sortName = viewModel.SortName?.ToUpper();
                if (sortName == ProductsRequestViewModel.OrderFields.ProductName)
                    queryInner = queryInner.OrderUsingSearchOptions(viewModel, x => x.Name);
                else if (sortName == ProductsRequestViewModel.OrderFields.Code)
                    queryInner = queryInner.OrderUsingSearchOptions(viewModel, x => x.Code);
                else if (sortName == ProductsRequestViewModel.OrderFields.EanCode)
                    queryInner = queryInner.OrderUsingSearchOptions(viewModel, x => x.EanCode);
                else if (sortName == ProductsRequestViewModel.OrderFields.SellPriceBruto)
                    queryInner = queryInner.OrderUsingSearchOptions(viewModel, x => x.Price);
                else if (sortName == ProductsRequestViewModel.OrderFields.Type)
                    queryInner = queryInner.OrderUsingSearchOptions(viewModel, x => x.ProductType);
                else if (sortName == ProductsRequestViewModel.OrderFields.ProductGroup)
                    queryInner = queryInner.Include(x => x.ProductCategory).OrderUsingSearchOptions(viewModel, x => x.ProductCategory.Name);
                else
                    queryInner = queryInner.OrderBy(x => x.Id);
                return queryInner;
            }

            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var query = BaseQuery();
            query = SearchFilter(query);
            query = SearchSort(query);

            return await query.ToPaginatedListResultAsync(viewModel);
        }

        public async Task<PaginatedListResult<ProductCategory>> SearchProductCategories(ProductGroupsRequestViewModel viewModel)
        {
            IQueryable<ProductCategory> SearchFilter(IQueryable<ProductCategory> queryInner)
            {
                return queryInner;
            }

            IQueryable<ProductCategory> SearchSort(IQueryable<ProductCategory> queryInner)
            {
                var sortName = viewModel.SortName?.ToUpper();
                if (sortName == ProductGroupsRequestViewModel.OrderFields.Name)
                    queryInner = queryInner.OrderUsingSearchOptions(viewModel, x => x.Name);
                else if (sortName == ProductGroupsRequestViewModel.OrderFields.KmPercent)
                    queryInner = queryInner.OrderUsingSearchOptions(viewModel, x => x.Vat);
                else
                    queryInner = queryInner.OrderBy(x => x.Id);
                return queryInner;
            }

            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var query = Context.ProductCategories.Where(x => x.DeletedOn == null);
            query = SearchFilter(query);
            query = SearchSort(query);

            return await query.ToPaginatedListResultAsync(viewModel);
        }
    }
}