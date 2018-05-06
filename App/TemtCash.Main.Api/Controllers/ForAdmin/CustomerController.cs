using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeysCloud.Core.Constant;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Customer.Request;

namespace TemtCash.Main.Api.Controllers.ForAdmin
{
    /// <summary>
    /// Company user
    /// </summary>
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme, Roles = UserRoleName.Administrator)]
    [Route(ApiEndpoint)]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _service;
        public const string ApiEndpoint = "api/customer";

        public CustomerController(ILogger<CustomerController> logger, ICustomerService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] CustomersRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Search(viewModel));

        [HttpGet("company/{id:int}")]
        public async Task<IActionResult> SearchByCompany([FromRoute] int companyId, [FromQuery] CustomersRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Search(viewModel)); // TODO: filter by company id

        [HttpGet("company/{companyId:int}/{id:int}")]
        public async Task<IActionResult> GetSingle([FromRoute] int companyId, [FromRoute] int id)
            => await HandleResultAsync(() => _service.GetSingle(companyId, id));

        [HttpPost("company/{companyId:int}")]
        public async Task<IActionResult> Create([FromRoute] int companyId, [FromBody] CustomerCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Create(companyId, viewModel));

        [HttpPut("company/{companyId:int}/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int companyId, [FromRoute] int id, [FromBody] CustomerCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Update(companyId, id, viewModel));

        [HttpDelete("company/{companyId:int}/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int companyId, [FromRoute] int id)
            => await HandleResultAsync(() => _service.Delete(companyId, id));
    }
}