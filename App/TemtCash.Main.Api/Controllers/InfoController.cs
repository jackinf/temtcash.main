using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TemtCash.Main.Api.Controllers
{
    [Route("api/info")]
    public class InfoController : Controller
    {
        [AllowAnonymous, HttpGet("version")]
        public string Version() => Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }
}
