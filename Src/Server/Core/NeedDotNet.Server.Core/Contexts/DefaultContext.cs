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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
