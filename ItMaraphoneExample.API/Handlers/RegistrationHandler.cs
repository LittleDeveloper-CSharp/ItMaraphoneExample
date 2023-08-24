using ItMaraphoneExample.API.Data.Entities;
using ItMaraphoneExample.API.Requests.AccountRequests;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ItMaraphoneExample.API.Handlers
{
    public class RegistrationHandler : IRequestHandler<RegistrationRequest, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistrationHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(RegistrationRequest request, CancellationToken cancellationToken)
        {
            var result = await _userManager.CreateAsync(new ApplicationUser
            {
                Email = request.Login,
                UserName = request.Login
            }, request.Password);

            return result.Succeeded;
        }
    }
}
