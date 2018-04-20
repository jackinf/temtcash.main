using System.Linq;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.ViewModel.Services.Company;

namespace TemtCash.Main.DAL.Repository
{
    public class CompanyRepository : CrudRepository<Company, CompaniesRequestViewModel>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context) { }

        protected override IQueryable<Company> SearchFilter(IQueryable<Company> query, CompaniesRequestViewModel viewModel)
        {
            // TODO: Implement filtering
            return base.SearchFilter(query, viewModel);
        }

        protected override IOrderedQueryable<Company> SearchSort(IQueryable<Company> query, CompaniesRequestViewModel viewModel)
        {
            string sortName = viewModel.SortName?.ToUpper();
            // TODO: Implement sorting
            return base.SearchSort(query, viewModel);
        }
    }
}