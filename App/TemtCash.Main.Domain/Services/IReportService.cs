using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.Report.Request;
using TemtCash.Main.Domain.ViewModel.Services.Report.Response;

namespace TemtCash.Main.Domain.Services
{
    public interface IReportService
    {
        Task<ServiceResult<PaginatedListResult<CashInOutResponseViewModel>>> CashInOut(CashInOutRequestViewModel viewModel);
        Task<ServiceResult<PaginatedListResult<DeletedInvoiceRowsResponseViewModel>>> DeletedInvoiceRows(DeletedInvoiceRowsRequestViewModel viewModel);
        Task<ServiceResult<PaginatedListResult<PaymentTypesResponseViewModel>>> PaymentTypes(PaymentTypesRequestViewModel viewModel);
        Task<ServiceResult<PaginatedListResult<SellerTurnoverResponseViewModel>>> SellerTurnover(SellerTurnoverRequestViewModel viewModel);
        Task<ServiceResult<PaginatedListResult<TurnoverCategoriesResponseViewModel>>> TurnoverCategories(TurnoverCategoriesRequestViewModel viewModel);
        Task<ServiceResult<PaginatedListResult<TurnoverPaymentTypesResponseViewModel>>> TurnoverPaymentTypes(TurnoverPaymentTypesRequestViewModel viewModel);
        Task<ServiceResult<PaginatedListResult<TurnoverProductsResponseViewModel>>> TurnoverProducts(TurnoverProductsRequestViewModel viewModel);
        Task<ServiceResult<PaginatedListResult<WarehouseReportsResponseViewModel>>> WarehouseReports(WarehouseReportsRequestViewModel viewModel);
    }
}