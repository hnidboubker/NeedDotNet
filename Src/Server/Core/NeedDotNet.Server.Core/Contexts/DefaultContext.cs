using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using NeedDotNet.Server.Core.Configurations;
using NeedDotNet.Server.Core.Conventions;
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
            NeedConventions.Mapp(modelBuilder);
            NeedConfigurations.Map(modelBuilder);
            IdentityConfigurations.Map(modelBuilder);
        }

        public virtual async Task<int> SaveAsyn()
        {
            return await base.SaveChangesAsync();
        }

        public virtual int Save()
        {
            return base.SaveChanges();
        }
    }
}

