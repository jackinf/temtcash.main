using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Report.Request;
using TemtCash.Main.Domain.ViewModel.Services.Report.Response;

namespace TemtCash.Main.Api.Services
{
    public class ReportService : IReportService
    {
        public async Task<ServiceResult<PaginatedListResult<CashInOutResponseViewModel>>> CashInOut(CashInOutRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<PaginatedListResult<DeletedInvoiceRowsResponseViewModel>>> DeletedInvoiceRows(DeletedInvoiceRowsRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<PaginatedListResult<PaymentTypesResponseViewModel>>> PaymentTypes(PaymentTypesRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<PaginatedListResult<SellerTurnoverResponseViewModel>>> SellerTurnover(SellerTurnoverRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<PaginatedListResult<TurnoverCategoriesResponseViewModel>>> TurnoverCategories(TurnoverCategoriesRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<PaginatedListResult<TurnoverPaymentTypesResponseViewModel>>> TurnoverPaymentTypes(TurnoverPaymentTypesRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<PaginatedListResult<TurnoverProductsResponseViewModel>>> TurnoverProducts(TurnoverProductsRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<PaginatedListResult<WarehouseReportsResponseViewModel>>> WarehouseReports(WarehouseReportsRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}