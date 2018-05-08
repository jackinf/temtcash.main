using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeysCloud.Core.Constant;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Company.Requests;
using TemtCash.Main.Domain.ViewModel.Services.Employee.Request;
using TemtCash.Main.Domain.ViewModel.Services.PointOfSale.Request;
using TemtCash.Main.Domain.ViewModel.Services.Unit.Request;

namespace TemtCash.Main.Api.Controllers.ForUser
{
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme, Roles = UserRoleName.User + "," + UserRoleName.Administrator)]
    [Route(ApiEndpoint)]
    public class SettingsController : BaseController
    {
        private readonly ICompanyService _companyService;
        private readonly IPointOfSaleService _pointOfSaleService;
        private readonly IEmployeeService _employeeService;
        private readonly IUnitService _unitService;
        public const string ApiEndpoint = "api/customer-settings";

        public SettingsController(ILogger<SettingsController> logger, ICompanyService companyService, IEmployeeService employeeService, IPointOfSaleService pointOfSaleService, IUnitService unitService) : base(logger)
        {
            _companyService = companyService;
            _employeeService = employeeService;
            _pointOfSaleService = pointOfSaleService;
            _unitService = unitService;
        }

        /*
         * My Company
         */


        [HttpGet("my-company-info")]
        public async Task<IActionResult> GetMyCompanyInfo()
            => await HandleResultAsync(() => _companyService.GetMyCompanyInfo());

        [HttpPut("my-company-info")]
        public async Task<IActionResult> UpdateMyCompanyInfo([FromRoute] int id, [FromBody] MyCompanyInfoUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _companyService.UpdateMyCompanyInfo(viewModel));

        /*
         * Point of sales
         */

        [HttpGet("point-of-sale")]
        public async Task<IActionResult> SearchPointOfSales([FromQuery] PointOfSalesRequestViewModel viewModel)
            => await HandleResultAsync(() => _pointOfSaleService.Search(viewModel));

        [HttpGet("point-of-sale/{id:int}")]
        public async Task<IActionResult> GetSinglePointOfSale([FromRoute] int id)
            => await HandleResultAsync(() => _pointOfSaleService.GetSingle(id));

        [HttpPost("point-of-sale")]
        public async Task<IActionResult> CreatePointOfSale([FromBody] PointOfSaleCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _pointOfSaleService.Create(viewModel));

        [HttpPut("point-of-sale/{id:int}")]
        public async Task<IActionResult> UpdatePointOfSale([FromRoute] int id, [FromBody] PointOfSaleCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _pointOfSaleService.Update(id, viewModel));

        [HttpDelete("point-of-sale/{id:int}")]
        public async Task<IActionResult> DeletePointOfSale([FromRoute] int id)
            => await HandleResultAsync(() => _pointOfSaleService.Delete(id));

        /*
         * Employees
         */

        [HttpGet("employee")]
        public async Task<IActionResult> SearchEmployees([FromQuery] EmployeesRequestViewModel viewModel)
            => await HandleResultAsync(() => _employeeService.Search(viewModel));

        [HttpGet("employee/{id:int}")]
        public async Task<IActionResult> GetSingleEmployee([FromRoute] int id)
            => await HandleResultAsync(() => _employeeService.GetSingle(id));

        [HttpPost("employee")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _employeeService.Create(viewModel));

        [HttpPut("employee/{id:int}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] EmployeeCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _employeeService.Update(id, viewModel));

        [HttpDelete("employee/{id:int}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
            => await HandleResultAsync(() => _employeeService.Delete(id));

        /*
         * Units
         */


        [HttpGet("unit")]
        public async Task<IActionResult> SearchUnits([FromQuery] UnitssRequestViewModel viewModel)
            => await HandleResultAsync(() => _unitService.Search(viewModel));

        [HttpGet("unit/{id:int}")]
        public async Task<IActionResult> GetSingleUnit([FromRoute] int id)
            => await HandleResultAsync(() => _unitService.GetSingle(id));

        [HttpPost("unit")]
        public async Task<IActionResult> CreateUnit([FromBody] UnitsCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _unitService.Create(viewModel));

        [HttpPut("unit/{id:int}")]
        public async Task<IActionResult> UpdateUnit([FromRoute] int id, [FromBody] UnitsCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _unitService.Update(id, viewModel));

        [HttpDelete("unit/{id:int}")]
        public async Task<IActionResult> DeleteUnit([FromRoute] int id)
            => await HandleResultAsync(() => _unitService.Delete(id));
    }
}