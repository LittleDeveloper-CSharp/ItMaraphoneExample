using ItMaraphoneExample.API.Data;
using ItMaraphoneExample.API.Data.Entities;
using ItMaraphoneExample.API.Handlers;
using ItMaraphoneExample.API.Hubs;
using ItMaraphoneExample.API.Infrastucture;
using ItMaraphoneExample.API.Requests.AccountRequests;
using ItMaraphoneExample.API.Requests.ProfileRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();

builder.Services.AddSignalR();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase("test");
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(x =>
{
    x.Password = new PasswordOptions
    {
        RequireNonAlphanumeric = false,
        RequireDigit = false,
        RequiredLength = 6,
        RequiredUniqueChars = 0,
        RequireLowercase = false,
        RequireUppercase = false
    };
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

//builder.Services.AddAuthorization(options =>
//{
//    options.FallbackPolicy = new AuthorizationPolicyBuilder()
//        .RequireAuthenticatedUser()
//        .Build();
//});
//var identityServiceBuilder =  builder.Services.AddIdentityCore<ApplicationUser>();
//var identityBuilder = new IdentityBuilder(identityServiceBuilder.UserType, identityServiceBuilder.Services);
//identityBuilder.AddEntityFrameworkStores<ApplicationDbContext>();
//identityBuilder.AddSignInManager<SignInManager<ApplicationUser>>();

builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssemblies(typeof(AuthorizationHandler).Assembly, typeof(AuthorizationRequest).Assembly);
    x.RegisterServicesFromAssemblies(typeof(RegistrationHandler).Assembly, typeof(RegistrationRequest).Assembly);
    x.RegisterServicesFromAssemblies(typeof(ProfileInformationHandler).Assembly, typeof(ProfileInformationRequest).Assembly);
    x.RegisterServicesFromAssemblies(typeof(UpdateProfileStatusHandler).Assembly, typeof(UpdateProfileStatusRequest).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<ChatHub>("/chat");
app.MapControllers();

app.Run();
