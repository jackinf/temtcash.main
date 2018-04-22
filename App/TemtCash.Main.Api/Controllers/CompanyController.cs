using System.Collections.Generic;
using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeysCloud.Core.Factory;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Company.Requests;
using TemtCash.Main.Domain.ViewModel.Services.Company.Response;

namespace TemtCash.Main.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [AllowAnonymous] // TODO: temporary
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

        //// TODO: experimenting
        //[HttpGet("fake"), AllowAnonymous]
        //public async Task<IActionResult> FakeData([FromQuery] CompaniesRequestViewModel viewModel) 
        //    => await HandleResultAsync(() =>
        //    {
        //        var list = new List<CompaniesResponseViewModel>();
        //        for (int i = 1; i <= 60; i++)
        //        {
        //            list.Add(new CompaniesResponseViewModel { Id = i, CompanyName = $"test{i:00}" });
        //        }
        //        var result = new PaginatedListResult<CompaniesResponseViewModel>
        //        {
        //            ContextObjects = list,
        //            Pages = 3,
        //            TotalCount = 60
        //        };
        //        return Task.FromResult(ServiceResultFactory.Success(result));
        //    });
    }
}
