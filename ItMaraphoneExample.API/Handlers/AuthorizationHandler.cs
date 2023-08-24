using ItMaraphoneExample.API.Data.Entities;
using ItMaraphoneExample.API.Infrastucture;
using ItMaraphoneExample.API.Models;
using ItMaraphoneExample.API.Requests.AccountRequests;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ItMaraphoneExample.API.Handlers
{
    public class AuthorizationHandler : IRequestHandler<AuthorizationRequest, AuthorizationResult>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthorizationHandler(
            SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager, 
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthorizationResult> Handle(AuthorizationRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Login);
            if(user == null) 
                return new AuthorizationResult
                {
                    Success = false
                };

            var signResult = await _signInManager.PasswordSignInAsync(
                request.Login, 
                request.Password, 
                false, 
                false);
            if(!signResult.Succeeded)
                return new AuthorizationResult
                {
                    Success = false,
                };

            var token = _jwtTokenGenerator.CreateToken(user);
            return new AuthorizationResult
            {
                Token = token,
                Success = true
            };
        }
    }
}
