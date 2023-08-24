using ItMaraphoneExample.API.Models;
using MediatR;

namespace ItMaraphoneExample.API.Requests.ProfileRequests
{
    public class ProfileInformationRequest : IRequest<UserDto>
    {
        public string Login { get; set; }
    }
}
