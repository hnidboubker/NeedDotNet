using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NeedDotNet.Server.Domain.Entities;
using NeedDotNet.Web.Infrastructure;
using NeedDotNet.Web.Services;
using Ninject.Modules;
using Ninject.Web.Common;

namespace NeedDotNet.Web.NinjectResolution
{
    public class RoleIdentityModule : NinjectModule
    {
        public override void Load()
        {
            Kernel
                .Bind<RoleManager<Role, long>>()
                .To<RoleManager>()
                .InRequestScope();

            Kernel
                .Bind<RoleStore<Role, long, UserRole>>()
                .To<RoleStore>()
                .InRequestScope();
        }
    }
}