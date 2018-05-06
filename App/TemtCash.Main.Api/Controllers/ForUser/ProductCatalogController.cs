using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.ProductCatalog.Request;

namespace TemtCash.Main.Api.Controllers.ForUser
{
    public class ProductCatalogController : BaseController
    {
        private readonly IProductCatalogService _service;
        public const string ApiEndpoint = "api/product-catalog";

        public ProductCatalogController(ILogger<ProductCatalogController> logger, IProductCatalogService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] ProductsRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Search(viewModel));

        [HttpGet("groups")]
        public async Task<IActionResult> SearchListOfProductGroups([FromQuery] ProductGroupsRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.SearchListOfProductGroups(viewModel));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSingle([FromRoute] int id)
            => await HandleResultAsync(() => _service.GetSingle(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Create(viewModel));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Update(id, viewModel));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
            => await HandleResultAsync(() => _service.Delete(id));
    }
}