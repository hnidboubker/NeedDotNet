using NeedDotNet.Web.Factories;
using NeedDotNet.Web.UoW;
using Ninject.Modules;
using Ninject.Web.Common;

namespace NeedDotNet.Web.NinjectResolution
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Kernel
                .Bind<IDatabaseFactory>()
                .To<DatabaseFactory>()
                .InRequestScope();

            Kernel
                .Bind<IUnitOfWork>()
                .To<UnitOfWork>()
                .InRequestScope();
        }
    }
}