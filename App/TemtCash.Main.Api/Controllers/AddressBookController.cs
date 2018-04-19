using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeysCloud.Main.Domain.Services;
using SpeysCloud.Main.Domain.ViewModel.Services.AddressBook;

namespace SpeysCloud.Main.Api.Controllers
{
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route("api/addressbook")]
    public class AddressBookController : BaseController
    {
        private readonly IAddressService _service;

        public AddressBookController(ILogger<AddressBookController> logger, IAddressService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Addresses([FromQuery] AddressesRequestViewModel viewModel) 
            => await HandleResultAsync(() => _service.GetAddresses(viewModel));

        [HttpGet("{addressId:int}")]
        public async Task<IActionResult> Address([FromRoute] int addressId) 
            => await HandleResultAsync(() => _service.GetAddress(addressId));

        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] AddressCreateOrUpdateRequestViewModel viewModel) 
            => await HandleResultAsync(() => _service.CreateAddress(viewModel));

        [HttpPut("{addressId:int}")]
        public async Task<IActionResult> UpdateAddress([FromRoute] int addressId, [FromBody] AddressCreateOrUpdateRequestViewModel viewModel) 
            => await HandleResultAsync(() => _service.UpdateAddress(addressId, viewModel));

        [HttpDelete("{addressId:int}")]
        public async Task<IActionResult> DeleteAddress([FromRoute] int addressId) 
            => await HandleResultAsync(() => _service.DeleteAddress(addressId));

        [HttpGet("{userId:int}/shipment-contact")]
        public async Task<IActionResult> GetSingleShipmentContact([FromRoute] int userId)
            => await HandleResultAsync(() => _service.GetSingleShipmentContact(userId));
    }
}
