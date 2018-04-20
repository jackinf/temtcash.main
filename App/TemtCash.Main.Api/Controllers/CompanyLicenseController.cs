using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicense;

namespace TemtCash.Main.Api.Controllers
{
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route("api/company-license")]
    public class CompanyLicenseController : BaseController
    {
        private readonly ICompanyLicenceService _service;

        public CompanyLicenseController(ILogger<CompanyLicenseController> logger, ICompanyLicenceService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] CompanyLicensesRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Search(viewModel));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSingle([FromRoute] int id)
            => await HandleResultAsync(() => _service.GetSingle(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyLicenseCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Create(viewModel));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CompanyLicenseCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Update(id, viewModel));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
            => await HandleResultAsync(() => _service.Delete(id));
    }
}