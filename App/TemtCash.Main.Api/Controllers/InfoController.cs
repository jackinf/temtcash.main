using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TemtCash.Main.Api.Controllers
{
    [Route("api/info")]
    public class InfoController : BaseController
    {
        public InfoController(ILogger logger) : base(logger)
        {
        }

        [AllowAnonymous, HttpGet("version")]
        public string Version() => Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }
}
