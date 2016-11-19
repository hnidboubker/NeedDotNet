using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NeedDotNet.Web.Services;
using Ninject.Modules;
using Ninject.Web.Common;

namespace NeedDotNet.Web.NinjectResolution
{
    public class UserServiceModule : NinjectModule
    {
        public override void Load()
        {
            Kernel
                .Bind<IUserService>()
                .To<UserService>()
                .InRequestScope();
        }
    }
}