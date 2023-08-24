using Microsoft.AspNetCore.Identity;

namespace ItMaraphoneExample.API.Data.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? Status { get; set; }

        public virtual IEnumerable<Message> Messages { get; set; } = new HashSet<Message>();
    }
}
