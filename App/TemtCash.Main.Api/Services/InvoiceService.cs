using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Invoice.Request;
using TemtCash.Main.Domain.ViewModel.Services.Invoice.Response;

namespace TemtCash.Main.Api.Services
{
    public class InvoiceService : IInvoiceService
    {
        public async Task<ServiceResult<PaginatedListResult<InvoicesResponseViewModel>>> Search(InvoicesRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}