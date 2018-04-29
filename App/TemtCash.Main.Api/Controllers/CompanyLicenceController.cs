using System.Collections.Generic;
using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicence.Request;

namespace TemtCash.Main.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [AllowAnonymous] // TODO: temporary
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

        [HttpGet("company/{id:int}")]
        public async Task<IActionResult> SearchByCompany([FromRoute] int id, [FromQuery] CompanyLicencesRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Search(viewModel)); // TODO filter by id

        [HttpGet("company/{companyId:int}/{id:int}")]
        public async Task<IActionResult> GetSingle([FromRoute] int companyId, [FromRoute] int id)
            => await HandleResultAsync(() => _service.GetSingle(companyId, id));

        [HttpPost("company/{companyId:int}")]
        public async Task<IActionResult> Create([FromRoute] int companyId, [FromBody] CompanyLicenceCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Create(companyId, viewModel));

        [HttpPut("company/{companyId:int}/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int companyId, [FromRoute] int id, [FromBody] CompanyLicenceCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Update(companyId, id, viewModel));

        [HttpDelete("company/{companyId:int}/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int companyId, [FromRoute] int id)
            => await HandleResultAsync(() => _service.Delete(companyId, id));

        [HttpGet("distributed-licences")]
        public async Task<IActionResult> DistributedLicences([FromQuery] CompanyLicencesRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.DistributedLicences(viewModel));

        [HttpPut("update-licences")]
        public async Task<IActionResult> UpdateLicences([FromBody] List<int> licenceIds)
            => await HandleResultAsync(() => _service.UpdateLicences(licenceIds));
    }
}