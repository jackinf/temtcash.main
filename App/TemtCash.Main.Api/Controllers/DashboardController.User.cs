using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TemtCash.Main.Domain.ViewModel.Services.Dashboard.Request;

namespace TemtCash.Main.Api.Controllers
{
    public partial class DashboardController
    {
        [HttpGet("company-information")]
        public async Task<IActionResult> GetCompanyInformation()
            => await HandleResultAsync(() => _service.GetCompanyInformation());

        [HttpPut("company-information")]
        public async Task<IActionResult> UpdateCompanyInformation(UpdateCompanyInformationRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.UpdateCompanyInformation(viewModel));
    }
}