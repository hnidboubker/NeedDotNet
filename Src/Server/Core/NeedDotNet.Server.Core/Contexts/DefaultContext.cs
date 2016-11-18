using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using NeedDotNet.Server.Domain.Entities;

namespace NeedDotNet.Server.Core.Contexts
{
    public class DefaultContext : IdentityDbContext<User, Role, long, UserLogin, UserRole, UserClaim>
    {
        public DefaultContext():base("Default")
        {
            
        }

        public virtual IDbSet<Group> Groups { get; set; }
        public virtual IDbSet<UserGroup> UserGroups { get; set; }
        public virtual IDbSet<RoleGroup> RoleGroups { get; set; }

        public virtual IDbSet<Person> Persons { get; set; }
        public virtual IDbSet<UserPerson> UserPersons { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
