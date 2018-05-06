using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Report.Request;

namespace TemtCash.Main.Api.Controllers.ForUser
{
    public class ReportsController : BaseController
    {
        private readonly IReportService _service;
        public const string ApiEndpoint = "api/report";

        public ReportsController(ILogger<ReportsController> logger, IReportService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet("cash-in-out")]
        public async Task<IActionResult> CashInOut([FromQuery] CashInOutRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.CashInOut(viewModel));

        [HttpGet("deleted-invoice-rows")]
        public async Task<IActionResult> DeletedInvoiceRows([FromQuery] DeletedInvoiceRowsRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.DeletedInvoiceRows(viewModel));

        [HttpGet("payment-types")]
        public async Task<IActionResult> PaymentTypes([FromQuery] PaymentTypesRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.PaymentTypes(viewModel));

        [HttpGet("seller-turnover")]
        public async Task<IActionResult> SellerTurnover([FromQuery] SellerTurnoverRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.SellerTurnover(viewModel));

        [HttpGet("turnover-categories")]
        public async Task<IActionResult> TurnoverCategories([FromQuery] TurnoverCategoriesRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.TurnoverCategories(viewModel));

        [HttpGet("turnover-payment-types")]
        public async Task<IActionResult> TurnoverPaymentTypes([FromQuery] TurnoverPaymentTypesRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.TurnoverPaymentTypes(viewModel));

        [HttpGet("turnover-products")]
        public async Task<IActionResult> TurnoverProducts([FromQuery] TurnoverProductsRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.TurnoverProducts(viewModel));

        [HttpGet("warehouse-reports")]
        public async Task<IActionResult> WarehouseReports([FromQuery] WarehouseReportsRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.WarehouseReports(viewModel));
    }
}