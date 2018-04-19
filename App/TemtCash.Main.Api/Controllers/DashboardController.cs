using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemtCash.Main.Domain.Services;

namespace TemtCash.Main.Api.Controllers
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
    }
}
