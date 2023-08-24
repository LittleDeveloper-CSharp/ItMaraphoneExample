using ItMaraphoneExample.API.Models;
using MediatR;

namespace ItMaraphoneExample.API.Requests.AccountRequests
{
    public class AuthorizationRequest : IRequest<AuthorizationResult>
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
