using System.Collections.Generic;
using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicence.Request;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicense.Request;

namespace TemtCash.Main.Api.Controllers
{
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route(ApiEndpoint)]
    public class CompanyLicenceController : BaseController
    {
        private readonly ICompanyLicenceService _service;
        public const string ApiEndpoint = "api/company-licence";

        public CompanyLicenceController(ILogger<CompanyLicenceController> logger, ICompanyLicenceService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] CompanyLicencesRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Search(viewModel));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSingle([FromRoute] int id)
            => await HandleResultAsync(() => _service.GetSingle(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyLicenceCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Create(viewModel));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CompanyLicenceCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Update(id, viewModel));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
            => await HandleResultAsync(() => _service.Delete(id));

        [HttpGet("distributed-licences")]
        public async Task<IActionResult> DistributedLicences([FromQuery] CompanyLicencesRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.DistributedLicences(viewModel));

        [HttpGet("update-licences")]
        public async Task<IActionResult> UpdateLicences([FromBody] List<int> licenceIds)
            => await HandleResultAsync(() => _service.UpdateLicences(licenceIds));
    }
}