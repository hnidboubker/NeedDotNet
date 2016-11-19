using NeedDotNet.Web.Services;
using Ninject.Modules;
using Ninject.Web.Common;

namespace NeedDotNet.Web.NinjectResolution
{
    public class PersonModule : NinjectModule
    {
        public override void Load()
        {
            Kernel
                .Bind<IPersonService>()
                .To<PersonService>()
                .InRequestScope();

            Kernel
                .Bind<IPersonRepository>()
                .To<PersonRepository>()
                .InRequestScope();
        }
    }
}