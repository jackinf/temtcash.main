using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.Invoice.Request;
using TemtCash.Main.Domain.ViewModel.Services.Invoice.Response;

namespace TemtCash.Main.Domain.Services
{
    public interface IInvoiceService
    {
        Task<ServiceResult<PaginatedListResult<InvoicesResponseViewModel>>> Search(InvoicesRequestViewModel viewModel);
    }
}