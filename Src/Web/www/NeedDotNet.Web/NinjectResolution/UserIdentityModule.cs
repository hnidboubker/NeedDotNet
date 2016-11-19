using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NeedDotNet.Server.Domain.Entities;
using NeedDotNet.Web.Infrastructure;
using NeedDotNet.Web.Services;
using Ninject.Modules;
using Ninject.Web.Common;

namespace NeedDotNet.Web.NinjectResolution
{
    internal class UserIdentityModule : NinjectModule
    {
        public override void Load()
        {
            Kernel
                .Bind<UserManager<User, long>>()
                .To<UserManager>()
                .InRequestScope();

            Kernel
                .Bind<UserStore<User, Role, long, UserLogin, UserRole, UserClaim>>()
                .To<UserStore>()
                .InRequestScope();
        }
    }
}