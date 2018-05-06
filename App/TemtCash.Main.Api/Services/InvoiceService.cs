using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeysCloud.Core.Factory;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Invoice.Request;
using TemtCash.Main.Domain.ViewModel.Services.Invoice.Response;

namespace TemtCash.Main.Api.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _repository;

        public InvoiceService(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<PaginatedListResult<InvoicesResponseViewModel>>> Search(InvoicesRequestViewModel viewModel)
        {
            var paginatedListWithModel = await _repository.Search(viewModel);

            // Mapping
            List<InvoicesResponseViewModel> Mapping(List<Invoice> list)
            {
                return list?
                    .Select(model => new InvoicesResponseViewModel
                    {
                        Id = model.Id,
                        Number = model.Number,
                        Date = model.Date,
                        SumWithoutKm = model.NetoSum,
                        SumKm = model.VatSum,
                        SumBruto = model.BrutoSum,
                        Client = model.Customer?.Name,
                        //PaymentMethod = model
                        Seller = model.SellerName
                    })
                    .ToList();
            }

            var paginatedListWithViewModel = paginatedListWithModel.Copy(Mapping);
            return ServiceResultFactory.Success(paginatedListWithViewModel);
        }
    }
}