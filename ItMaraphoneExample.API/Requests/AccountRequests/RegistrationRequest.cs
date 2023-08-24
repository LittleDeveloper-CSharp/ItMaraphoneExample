using MediatR;

namespace ItMaraphoneExample.API.Requests.AccountRequests
{
    public class RegistrationRequest : IRequest<bool>
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
