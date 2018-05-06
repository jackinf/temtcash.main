using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Customer.Request;

namespace TemtCash.Main.Api.Controllers.ForUser
{
    public class ClientController : BaseController
    {
        private readonly ICustomerService _service;
        public const string ApiEndpoint = "api/client/{clientId:int}";

        public ClientController(ILogger<ClientController> logger, ICustomerService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromRoute] int clientId, [FromQuery] CustomersRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Search(clientId, viewModel));
    }
}