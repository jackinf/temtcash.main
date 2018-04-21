using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.SystemUser;

namespace TemtCash.Main.Api.Controllers
{
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route(ApiEndpoint)]
    public class SystemUserController : BaseController
    {
        private readonly ISystemUserService _service;
        public const string ApiEndpoint = "api/system-user";

        public SystemUserController(ILogger logger, ISystemUserService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] SystemUsersRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Search(viewModel));
    }
}