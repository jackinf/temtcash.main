using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Supplier.Request;

namespace TemtCash.Main.Api.Controllers.ForUser
{
    public class SupplierController : BaseController
    {
        private readonly ISupplierService _service;
        public const string ApiEndpoint = "api/supplier";

        public SupplierController(ILogger<SupplierController> logger, ISupplierService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] SuppliersRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Search(viewModel));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSingle([FromRoute] int id)
            => await HandleResultAsync(() => _service.GetSingle(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SupplierCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Create(viewModel));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SupplierCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Update(id, viewModel));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
            => await HandleResultAsync(() => _service.Delete(id));
    }
}