using ItMaraphoneExample.API.Data;
using ItMaraphoneExample.API.Models;
using ItMaraphoneExample.API.Requests.ProfileRequests;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ItMaraphoneExample.API.Handlers
{
    public class ProfileInformationHandler : IRequestHandler<ProfileInformationRequest, UserDto>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProfileInformationHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<UserDto> Handle(ProfileInformationRequest request, CancellationToken cancellationToken)
        {
            var user = await _applicationDbContext.Users.SingleOrDefaultAsync(x => x.UserName == request.Login);
            return new UserDto
            {
                Login = user.UserName,
                Status = user.Status,
            };
        }
    }
}
