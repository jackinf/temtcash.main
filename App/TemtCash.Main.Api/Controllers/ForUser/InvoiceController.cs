using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Invoice.Request;

namespace TemtCash.Main.Api.Controllers.ForUser
{
    public class InvoiceController : BaseController
    {
        private readonly IInvoiceService _service;
        public const string ApiEndpoint = "api/invoice";

        public InvoiceController(ILogger<InvoiceController> logger, IInvoiceService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] InvoicesRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Search(viewModel));
    }
}