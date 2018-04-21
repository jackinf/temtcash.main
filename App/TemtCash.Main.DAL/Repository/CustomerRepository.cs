using System;
using System.Linq;
using System.Threading.Tasks;
using SpeysCloud.Core.Extension;
using SpeysCloud.Core.Result;
using TemtCash.Main.DAL.Helper;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.ViewModel.Services.Company.Requests;
using TemtCash.Main.Domain.ViewModel.Services.Customer.Request;

namespace TemtCash.Main.DAL.Repository
{
    public class CustomerRepository : CrudRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<PaginatedListResult<Customer>> Search(CustomersRequestViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var query = BaseQuery();
            query = SearchFilter(query, viewModel);
            query = SearchSort(query, viewModel);

            return await query.ToPaginatedListResultAsync(viewModel);
        }

        protected IQueryable<Customer> SearchFilter(IQueryable<Customer> query, CustomersRequestViewModel viewModel)
        {
            return query;
        }

        protected IQueryable<Customer> SearchSort(IQueryable<Customer> query, CustomersRequestViewModel viewModel)
        {
            string sortName = viewModel.SortName?.ToUpper();
            if (sortName == CompaniesRequestViewModel.OrderFields.CompanyName)
                query = query.OrderUsingSearchOptions(viewModel, x => x.Name);
            else if (sortName == CompaniesRequestViewModel.OrderFields.ClientCode)
                query = query.OrderUsingSearchOptions(viewModel, x => x.RegCode);
            else if (sortName == CompaniesRequestViewModel.OrderFields.ContactPerson)
                query = query.OrderUsingSearchOptions(viewModel, x => x.Name);
            else if (sortName == CompaniesRequestViewModel.OrderFields.ContactPhone)
                query = query.OrderUsingSearchOptions(viewModel, x => x.Phone);
            else if (sortName == CompaniesRequestViewModel.OrderFields.ContactEmail)
                query = query.OrderUsingSearchOptions(viewModel, x => x.Email);
            else
                query = query.OrderBy(x => x.Id);
            // TODO
            //else if (sortName == CompaniesRequestViewModel.OrderFields.InvoiceFrequency)
            //    query = query.OrderUsingSearchOptions(viewModel, x => x.InvoiceFrequency);
            //else if (sortName == CompaniesRequestViewModel.OrderFields.InvoiceEmail)
            //    query = query.OrderUsingSearchOptions(viewModel, x => x.InvoiceEmail);
            //else if (sortName == CompaniesRequestViewModel.OrderFields.LastLoginTime)
            //    query = query.OrderUsingSearchOptions(viewModel, x => x.LastLoginTime);
            return query;
        }
    }
}