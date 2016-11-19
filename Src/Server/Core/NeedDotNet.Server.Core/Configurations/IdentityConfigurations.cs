using System.Data.Entity;
using NeedDotNet.Server.Domain.Entities;

namespace NeedDotNet.Server.Core.Configurations
{
    public class IdentityConfigurations
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .ToTable("User");

            modelBuilder
                .Entity<Role>()
                .ToTable("Role");

            modelBuilder
                .Entity<UserLogin>()
                .ToTable("UserLogin");

            modelBuilder
                .Entity<UserRole>()
                .ToTable("UserRole");

            modelBuilder
                .Entity<UserClaim>()
                .ToTable("UserClaim");

            modelBuilder
                .Entity<Group>()
                .ToTable("Group");
                

            modelBuilder
                .Entity<UserGroup>()
                .ToTable("UserGroup");

            modelBuilder
               .Entity<RoleGroup>()
               .ToTable("RoleGroup");

            modelBuilder
                .Entity<Person>()
                .ToTable("Person");
            modelBuilder
                .Entity<UserPerson>()
                .ToTable("UserPerson");


            modelBuilder
                .Entity<UserLogin>()
                .HasKey(o => new 
                {
                    UserId = o.UserId,
                    LoginProvider = o.LoginProvider,
                    ProviderKey = o.ProviderKey

                });

            modelBuilder
                .Entity<UserClaim>()
                .HasKey(o => new
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    ClaimType = o.ClaimType,
                    ClaimValue = o.ClaimValue
                });

            modelBuilder
                .Entity<UserRole>()
                .HasKey(o => new
                {
                    UserId = o.UserId,
                    RoleId = o.RoleId,
                });

            modelBuilder
                .Entity<UserGroup>()
                .HasKey(o => new
                {
                    UserId = o.UserId,
                    GroupId = o.GroupId,
                });

           

            modelBuilder
                .Entity<RoleGroup>()
                .HasKey(o => new
                {
                    RoleId = o.RoleId,
                    GroupId = o.GroupId,
                });

            modelBuilder
                .Entity<UserPerson>()
                .HasKey(o => new
                {
                    UserId = o.UserId,
                    PersonId = o.PersonId,
                });
        }
    }
}