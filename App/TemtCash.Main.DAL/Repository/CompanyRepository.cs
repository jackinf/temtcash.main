using System;
using System.Linq;
using System.Threading.Tasks;
using SpeysCloud.Core.Extension;
using SpeysCloud.Core.Result;
using TemtCash.Main.DAL.Helper;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.ViewModel.Services.Company.Requests;

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
            return query;
        }

        protected IQueryable<Company> SearchSort(IQueryable<Company> query, CompaniesRequestViewModel viewModel)
        {
            string sortName = viewModel.SortName?.ToUpper();
            if (sortName == CompaniesRequestViewModel.OrderFields.CompanyName)
                query = query.OrderUsingSearchOptions(viewModel, x => x.Name);
            else if (sortName == CompaniesRequestViewModel.OrderFields.ClientCode)
                query = query.OrderUsingSearchOptions(viewModel, x => x.ClientCode);
            else if (sortName == CompaniesRequestViewModel.OrderFields.ContactPerson)
                query = query.OrderUsingSearchOptions(viewModel, x => x.ContactPerson);
            else if (sortName == CompaniesRequestViewModel.OrderFields.ContactPhone)
                query = query.OrderUsingSearchOptions(viewModel, x => x.ContactPhone);
            else if (sortName == CompaniesRequestViewModel.OrderFields.ContactEmail)
                query = query.OrderUsingSearchOptions(viewModel, x => x.ContactEmail);
            else if (sortName == CompaniesRequestViewModel.OrderFields.InvoiceFrequency)
                query = query.OrderUsingSearchOptions(viewModel, x => x.InvoiceFrequency);
            else if (sortName == CompaniesRequestViewModel.OrderFields.InvoiceEmail)
                query = query.OrderUsingSearchOptions(viewModel, x => x.InvoiceEmail);
            else if (sortName == CompaniesRequestViewModel.OrderFields.LastLoginTime)
                query = query.OrderUsingSearchOptions(viewModel, x => x.LastInfoUpdateDate);
            else
                query = query.OrderBy(x => x.Id);
            return query;
        }
    }
}