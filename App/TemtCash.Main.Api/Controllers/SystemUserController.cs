using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TemtCash.Main.Api.Controllers
{
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route("api/system-user")]
    public class SystemUserController : BaseController
    {
        public SystemUserController(ILogger logger) : base(logger)
        {
        }
    }
}