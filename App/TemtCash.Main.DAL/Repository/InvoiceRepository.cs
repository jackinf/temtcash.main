using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpeysCloud.Core.Extension;
using SpeysCloud.Core.Result;
using TemtCash.Main.DAL.Helper;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.ViewModel.Services.Invoice.Request;

namespace TemtCash.Main.DAL.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedListResult<Invoice>> Search(InvoicesRequestViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var query = BaseQuery();
            query = SearchFilter(query, viewModel);
            query = SearchSort(query, viewModel);

            return await query.ToPaginatedListResultAsync(viewModel);
        }

        protected IQueryable<Invoice> SearchFilter(IQueryable<Invoice> query, InvoicesRequestViewModel viewModel)
        {
            return query;
        }

        protected IQueryable<Invoice> SearchSort(IQueryable<Invoice> query, InvoicesRequestViewModel viewModel)
        {
            string sortName = viewModel.SortName?.ToUpper();
            if (sortName == InvoicesRequestViewModel.OrderFields.Number)
                query = query.OrderUsingSearchOptions(viewModel, x => x.Number);
            else if (sortName == InvoicesRequestViewModel.OrderFields.Date)
                query = query.OrderUsingSearchOptions(viewModel, x => x.Date);
            else if (sortName == InvoicesRequestViewModel.OrderFields.SumWithoutKm)
                query = query.OrderUsingSearchOptions(viewModel, x => x.NetoSum);
            else if (sortName == InvoicesRequestViewModel.OrderFields.SumKm)
                query = query.OrderUsingSearchOptions(viewModel, x => x.VatSum);
            else if (sortName == InvoicesRequestViewModel.OrderFields.SumBruto)
                query = query.OrderUsingSearchOptions(viewModel, x => x.BrutoSum);
            else if (sortName == InvoicesRequestViewModel.OrderFields.Client)
                query = query.OrderUsingSearchOptions(viewModel, x => x.Customer.Name);
            //else if (sortName == InvoicesRequestViewModel.OrderFields.PaymentMethod) // TODO
                //query = query.OrderUsingSearchOptions(viewModel, x => x.PaymentMethod);
            else if (sortName == InvoicesRequestViewModel.OrderFields.Seller)
                query = query.OrderUsingSearchOptions(viewModel, x => x.Number);
            else
                query = query.OrderBy(x => x.Id);
            return query;
        }

        protected IQueryable<Invoice> BaseQuery() => _context.Invoices.Include(x => x.Customer).Where(x => x.DeletedOn == null);
    }
}