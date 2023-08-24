using ItMaraphoneExample.API.Data.Entities;

namespace ItMaraphoneExample.API.Infrastucture
{
    public interface IJwtTokenGenerator
    {
        string CreateToken(ApplicationUser user);
    }
}
