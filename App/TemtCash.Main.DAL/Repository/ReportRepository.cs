using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.ViewModel.Services.Report.Request;
using TemtCash.Main.Domain.ViewModel.Services.Report.Response;

namespace TemtCash.Main.DAL.Repository
{
    public class ReportRepository : IReportRepository
    {
        public Task<PaginatedListResult<CashInOutResponseViewModel>> CashInOut(CashInOutRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<PaginatedListResult<DeletedInvoiceRowsResponseViewModel>> DeletedInvoiceRows(DeletedInvoiceRowsRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<PaginatedListResult<PaymentTypesResponseViewModel>> PaymentTypes(PaymentTypesRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<PaginatedListResult<SellerTurnoverResponseViewModel>> SellerTurnover(SellerTurnoverRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<PaginatedListResult<TurnoverCategoriesResponseViewModel>> TurnoverCategories(TurnoverCategoriesRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<PaginatedListResult<TurnoverPaymentTypesResponseViewModel>> TurnoverPaymentTypes(TurnoverPaymentTypesRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<PaginatedListResult<TurnoverProductsResponseViewModel>> TurnoverProducts(TurnoverProductsRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<PaginatedListResult<WarehouseReportsResponseViewModel>> WarehouseReports(WarehouseReportsRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}