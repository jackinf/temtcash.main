using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeysCloud.Main.Domain.Services;
using SpeysCloud.Main.Domain.ViewModel.Services.Dashboard;

namespace SpeysCloud.Main.Api.Controllers
{
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route("api/dashboard")]
    public class DashboardController : BaseController
    {
        private readonly IDashboardService _service;

        public DashboardController(ILogger<DashboardController> logger, IDashboardService service) : base(logger)
        {
            _service = service;
        }

        //[HttpGet("frequent-contacts")]
        //public async Task<IActionResult> FrequentContacts() 
        //    => await HandleResultAsync(() => _service.GetFrequentContacts());

        [HttpGet("recent-deliveries")]
        public async Task<IActionResult> RecentDeliveries([FromQuery] RecentDeliveriesRequestViewModel viewModel) 
            => await HandleResultAsync(() => _service.GetRecentDeliveries(viewModel));
    }
}
