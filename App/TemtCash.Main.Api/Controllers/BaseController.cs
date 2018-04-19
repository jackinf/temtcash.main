using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeysCloud.Core.Result;

namespace TemtCash.Main.Api.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly ILogger _logger;

        protected BaseController(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Main wrapper around every controller action.
        /// </summary>
        /// <param name="handler"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        //[DebuggerStepThrough]
        protected async Task<IActionResult> HandleResultAsync<T>(Func<Task<ServiceResult<T>>> handler)
        {
            const int validationFailedErrorCode = 422;

            try
            {
                var result = await handler.Invoke(); // Execute the service method.

                if (result.IsSuccessful)
                    return Ok(result);

                if (!result.Validation.IsValid)
                    return StatusCode(validationFailedErrorCode, result);

                return BadRequest(result);
            }
            catch (Exception e)
            {
                var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
                _logger.LogError($"HandleResult failed! IP: {remoteIpAddress}. Reason: {e.Message}. Stacktrace: {e.StackTrace}");
                return StatusCode((int) HttpStatusCode.InternalServerError, e);
            }
        }
    }
}