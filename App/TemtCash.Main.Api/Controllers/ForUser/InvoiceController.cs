using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeysCloud.Core.Constant;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Invoice.Request;

namespace TemtCash.Main.Api.Controllers.ForUser
{
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme, Roles = UserRoleName.User + "," + UserRoleName.Administrator)]
    [Route(ApiEndpoint)]
    public class InvoiceController : BaseController
    {
        private readonly IInvoiceService _service;
        public const string ApiEndpoint = "api/invoice";

        public InvoiceController(ILogger<InvoiceController> logger, IInvoiceService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] InvoicesRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Search(viewModel));
    }
}