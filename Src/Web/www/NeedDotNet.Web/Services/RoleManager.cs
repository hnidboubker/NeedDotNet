using Microsoft.AspNet.Identity;
using NeedDotNet.Server.Domain.Entities;
using NeedDotNet.Web.Infrastructure;

namespace NeedDotNet.Web.Services
{
    public class RoleManager : RoleManager<Role, long>
    {
        protected new RoleStore Store;

        public RoleManager(RoleStore store):base(store)
        {
            Store = store;
        }
    }
}