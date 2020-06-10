using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeysCloud.Core.Constant;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Company.Requests;

namespace TemtCash.Main.Api.Controllers.ForAdmin
{
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme, Roles = UserRoleName.Administrator)]
    [Route(ApiEndpoint)]
    public class CompanyController : BaseController
    {
        private readonly ICompanyService _service;
        public const string ApiEndpoint = "api/company";

        public CompanyController(ILogger<CompanyController> logger, ICompanyService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] CompaniesRequestViewModel viewModel) 
            => await HandleResultAsync(() => _service.Search(viewModel));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSingle([FromRoute] int id) 
            => await HandleResultAsync(() => _service.GetSingle(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyCreateOrUpdateRequestViewModel viewModel) 
            => await HandleResultAsync(() => _service.Create(viewModel));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CompanyCreateOrUpdateRequestViewModel viewModel) 
            => await HandleResultAsync(() => _service.Update(id, viewModel));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id) 
            => await HandleResultAsync(() => _service.Delete(id));
    }
}
