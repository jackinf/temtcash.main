using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemtCash.Main.Domain.Services;

namespace TemtCash.Main.Api.Controllers
{
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route(ApiEndpoint)]
    public class DashboardController : BaseController
    {
        private readonly IDashboardService _service;
        public const string ApiEndpoint = "api/dashboard";

        public DashboardController(ILogger<DashboardController> logger, IDashboardService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet("info-channel-message")]
        public async Task<IActionResult> InfoChannelMessages()
            => await HandleResultAsync(() => _service.InfoChannelMessages());

        [HttpGet("info-channel-message/{id:int}")]
        public async Task<IActionResult> InfoChannelMessages(int id)
            => await HandleResultAsync(() => _service.InfoChannelMessage(id));
    }
}
