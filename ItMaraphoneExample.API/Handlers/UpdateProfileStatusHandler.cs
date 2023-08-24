using ItMaraphoneExample.API.Data;
using ItMaraphoneExample.API.Data.Entities;
using ItMaraphoneExample.API.Requests.ProfileRequests;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ItMaraphoneExample.API.Handlers
{
    public class UpdateProfileStatusHandler : IRequestHandler<UpdateProfileStatusRequest>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdateProfileStatusHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task Handle(UpdateProfileStatusRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Login);
            user.Status = request.Status;
            
            await _userManager.UpdateAsync(user);
        }
    }
}
