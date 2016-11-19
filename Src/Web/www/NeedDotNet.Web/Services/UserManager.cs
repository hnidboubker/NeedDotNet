using System;
using System.Threading;
using Microsoft.AspNet.Identity;
using NeedDotNet.Server.Domain.Entities;
using NeedDotNet.Web.Infrastructure;

namespace NeedDotNet.Web.Services
{
    public class UserManager : UserManager<User, long>
    {
        protected new UserStore Store;

        public UserManager(UserStore store):base(store)
        {
            Store = store;
        }

        
    }
}