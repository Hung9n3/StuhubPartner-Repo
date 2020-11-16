using Microsoft.AspNetCore.Identity;

namespace Entities.Models.IdentityContext
{
    public class UserRole : IdentityUserRole<string>
    {
        public virtual User? User { get; set; }
        public virtual Role? Role { get; set; }
    }
}
