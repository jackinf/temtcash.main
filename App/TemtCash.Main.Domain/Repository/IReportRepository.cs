using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.Report.Request;
using TemtCash.Main.Domain.ViewModel.Services.Report.Response;

namespace TemtCash.Main.Domain.Repository
{
    public interface IReportRepository
    {
        Task<PaginatedListResult<CashInOutResponseViewModel>> CashInOut(CashInOutRequestViewModel viewModel);
        Task<PaginatedListResult<DeletedInvoiceRowsResponseViewModel>> DeletedInvoiceRows(DeletedInvoiceRowsRequestViewModel viewModel);
        Task<PaginatedListResult<PaymentTypesResponseViewModel>> PaymentTypes(PaymentTypesRequestViewModel viewModel);
        Task<PaginatedListResult<SellerTurnoverResponseViewModel>> SellerTurnover(SellerTurnoverRequestViewModel viewModel);
        Task<PaginatedListResult<TurnoverCategoriesResponseViewModel>> TurnoverCategories(TurnoverCategoriesRequestViewModel viewModel);
        Task<PaginatedListResult<TurnoverPaymentTypesResponseViewModel>> TurnoverPaymentTypes(TurnoverPaymentTypesRequestViewModel viewModel);
        Task<PaginatedListResult<TurnoverProductsResponseViewModel>> TurnoverProducts(TurnoverProductsRequestViewModel viewModel);
        Task<PaginatedListResult<WarehouseReportsResponseViewModel>> WarehouseReports(WarehouseReportsRequestViewModel viewModel);
    }
}