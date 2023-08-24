using MediatR;

namespace ItMaraphoneExample.API.Requests.ProfileRequests
{
    public class UpdateProfileStatusRequest : IRequest
    {
        public string Login { get; set; }

        public string Status { get; set; }
    }
}
