using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.InfoChannelMessage;

namespace TemtCash.Main.Api.Controllers
{
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    [Route("api/info-channel-message")]
    public class InfoChannelMessageController : BaseController
    {
        private readonly IInfoChannelMessageService _service;

        public InfoChannelMessageController(ILogger logger, IInfoChannelMessageService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] InfoChannelMessagesRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Search(viewModel));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSingle([FromRoute] int id)
            => await HandleResultAsync(() => _service.GetSingle(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InfoChannelMessageCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Create(viewModel));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] InfoChannelMessageCreateOrUpdateRequestViewModel viewModel)
            => await HandleResultAsync(() => _service.Update(id, viewModel));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
            => await HandleResultAsync(() => _service.Delete(id));
    }
}