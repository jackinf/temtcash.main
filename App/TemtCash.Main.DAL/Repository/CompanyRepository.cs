using System;
using System.Linq;
using System.Threading.Tasks;
using SpeysCloud.Core.Extension;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.ViewModel.Services.Company;

namespace TemtCash.Main.DAL.Repository
{
    public class CompanyRepository : CrudRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context) { }

        public async Task<PaginatedListResult<Company>> Search(CompaniesRequestViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var query = BaseQuery();
            query = SearchFilter(query, viewModel);
            query = SearchSort(query, viewModel);

            return await query.ToPaginatedListResultAsync(viewModel);
        }

        protected IQueryable<Company> SearchFilter(IQueryable<Company> query, CompaniesRequestViewModel viewModel)
        {
            // TODO: Implement filtering
            return query;
        }

        protected IOrderedQueryable<Company> SearchSort(IQueryable<Company> query, CompaniesRequestViewModel viewModel)
        {
            string sortName = viewModel.SortName?.ToUpper();
            // TODO: Implement sorting
            return query.OrderBy(x => x.Id);
        }
    }
}