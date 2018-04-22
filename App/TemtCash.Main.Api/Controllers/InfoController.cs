using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TemtCash.Main.Api.Controllers
{
    [Route(ApiEndpoint)]
    public class InfoController : BaseController
    {
        public const string ApiEndpoint = "api/info";

        public InfoController(ILogger<InfoController> logger) : base(logger)
        {
        }

        [AllowAnonymous, HttpGet("version")]
        public string Version() => Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }
}
