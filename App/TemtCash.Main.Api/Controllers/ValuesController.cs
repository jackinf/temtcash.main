using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SpeysCloud.Main.Api.Controllers
{
    [Route("api/values")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get() => new [] { "value1", "value2" };

        [HttpGet("protected"), Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        public string Protected()
        {
            var usernameClaim = User.Claims.FirstOrDefault(x => x.Type.StartsWith(value: "username", ignoreCase: true, culture: CultureInfo.InvariantCulture));

            return usernameClaim?.Value ?? "unknown username";
        }

        [AllowAnonymous, HttpGet("version")]
        public string Version() => Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }
}
