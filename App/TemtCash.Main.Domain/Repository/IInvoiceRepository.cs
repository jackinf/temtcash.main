using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.ViewModel.Services.Invoice.Request;

namespace TemtCash.Main.Domain.Repository
{
    public interface IInvoiceRepository
    {
        Task<PaginatedListResult<Invoice>> Search(InvoicesRequestViewModel viewModel);
    }
}