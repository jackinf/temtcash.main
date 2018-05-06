using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Client.Request;

namespace TemtCash.Main.Api.Controllers.ForUser
{
    public class ClientController : BaseController
    {
        private readonly IClientService _service;
        public const string ApiEndpoint = "api/client";

        public ClientController(ILogger<ClientController> logger, IClientService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] ClientsRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Search(viewModel));
    }
}