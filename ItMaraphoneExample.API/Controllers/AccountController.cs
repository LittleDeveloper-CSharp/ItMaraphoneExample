using ItMaraphoneExample.API.Requests.AccountRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItMaraphoneExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("SingIn")]
        public async Task<IActionResult> SingIn([FromBody] AuthorizationRequest request)
        {
            var result = await _mediator.Send(request);
            
            return Ok(result);
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationRequest request)
        {
            var result  = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
