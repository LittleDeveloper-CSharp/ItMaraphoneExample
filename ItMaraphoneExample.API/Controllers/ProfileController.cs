using ItMaraphoneExample.API.Requests;
using ItMaraphoneExample.API.Requests.ProfileRequests;
using MediatR;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;

namespace ItMaraphoneExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var login = User.Identity.Name;
            var response = await _mediator.Send(new ProfileInformationRequest
            {
                Login = login
            });

            return Ok(response);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateStatus([FromQuery]string status)
        {
            var login = User.Identity.Name;
            await _mediator.Send(new UpdateProfileStatusRequest
            {
                Login = login,
                Status = status
            });

            return Ok();
        }
    }
}
