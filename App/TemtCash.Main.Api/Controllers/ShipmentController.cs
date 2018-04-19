using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeysCloud.Main.Domain.Services;
using SpeysCloud.Main.Domain.ViewModel.Services.Shipment;

namespace SpeysCloud.Main.Api.Controllers
{
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route("api/shipment")]
    public class ShipmentController : BaseController
    {
        private readonly IShipmentService _service;

        public ShipmentController(ILogger<ShipmentController> logger, IShipmentService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] ShipmentsRequestViewModel viewModel) 
            => await HandleResultAsync(() => _service.Search(viewModel));

        [HttpGet("{shipmentId:int}")]
        public async Task<IActionResult> GetSingle([FromRoute] int shipmentId) 
            => await HandleResultAsync(() => _service.GetSingle(shipmentId));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ShipmentCreateOrUpdateRequestViewModel viewModel) 
            => await HandleResultAsync(() => _service.Create(viewModel));

        [HttpPut("{shipmentId:int}")]
        public async Task<IActionResult> Update([FromRoute] int shipmentId, [FromBody] ShipmentCreateOrUpdateRequestViewModel viewModel) 
            => await HandleResultAsync(() => _service.Update(shipmentId, viewModel));

        [HttpDelete("{shipmentId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int shipmentId) 
            => await HandleResultAsync(() => _service.Delete(shipmentId));
    }
}
