using Microsoft.AspNet.Identity.EntityFramework;

namespace NeedDotNet.Server.Domain.Entities
{
    public class UserRole : IdentityUserRole<long>
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}