using System.Threading.Tasks;
using SpeysCloud.Core.Factory;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Report.Request;
using TemtCash.Main.Domain.ViewModel.Services.Report.Response;

namespace TemtCash.Main.Api.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;

        public ReportService(IReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<PaginatedListResult<CashInOutResponseViewModel>>> CashInOut(CashInOutRequestViewModel viewModel) 
            => ServiceResultFactory.Success(await _repository.CashInOut(viewModel));

        public async Task<ServiceResult<PaginatedListResult<DeletedInvoiceRowsResponseViewModel>>> DeletedInvoiceRows(DeletedInvoiceRowsRequestViewModel viewModel) 
            => ServiceResultFactory.Success(await _repository.DeletedInvoiceRows(viewModel));

        public async Task<ServiceResult<PaginatedListResult<PaymentTypesResponseViewModel>>> PaymentTypes(PaymentTypesRequestViewModel viewModel) 
            => ServiceResultFactory.Success(await _repository.PaymentTypes(viewModel));

        public async Task<ServiceResult<PaginatedListResult<SellerTurnoverResponseViewModel>>> SellerTurnover(SellerTurnoverRequestViewModel viewModel) 
            => ServiceResultFactory.Success(await _repository.SellerTurnover(viewModel));

        public async Task<ServiceResult<PaginatedListResult<TurnoverCategoriesResponseViewModel>>> TurnoverCategories(TurnoverCategoriesRequestViewModel viewModel) 
            => ServiceResultFactory.Success(await _repository.TurnoverCategories(viewModel));

        public async Task<ServiceResult<PaginatedListResult<TurnoverPaymentTypesResponseViewModel>>> TurnoverPaymentTypes(TurnoverPaymentTypesRequestViewModel viewModel) 
            => ServiceResultFactory.Success(await _repository.TurnoverPaymentTypes(viewModel));

        public async Task<ServiceResult<PaginatedListResult<TurnoverProductsResponseViewModel>>> TurnoverProducts(TurnoverProductsRequestViewModel viewModel) 
            => ServiceResultFactory.Success(await _repository.TurnoverProducts(viewModel));

        public async Task<ServiceResult<PaginatedListResult<WarehouseReportsResponseViewModel>>> WarehouseReports(WarehouseReportsRequestViewModel viewModel) 
            => ServiceResultFactory.Success(await _repository.WarehouseReports(viewModel));
    }
}