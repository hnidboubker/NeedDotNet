using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NeedDotNet.Server.Domain.Entities
{
    public class User : IdentityUser<long, UserLogin, UserRole, UserClaim>
    {
        public string Passsword { get; set; }

        public bool IsActive { get; set; }
        public bool IsValid { get; set; }

        public virtual ICollection<UserGroup> Groups { get; set; }
        public virtual ICollection<UserPerson> Persons { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastTimeFailed { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Removed { get; set; }

        public long? Creator { get; set; }
        public long? Updator { get; set; }
        public long? Remover { get; set; }
    }
}
