using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.ViewModel.Services.Invoice.Request;

namespace TemtCash.Main.DAL.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public Task<PaginatedListResult<Invoice>> Search(InvoicesRequestViewModel viewModel)
        {
            // TODO: include client into result
            throw new System.NotImplementedException();
        }
    }
}