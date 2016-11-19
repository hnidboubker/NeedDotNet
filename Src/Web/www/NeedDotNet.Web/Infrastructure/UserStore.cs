using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using NeedDotNet.Server.Core.Contexts;
using NeedDotNet.Server.Domain.Entities;

namespace NeedDotNet.Web.Infrastructure
{
    public class UserStore : UserStore<User, Role, long, UserLogin, UserRole, UserClaim>
    {
        public UserStore():this(new DefaultContext())
        {
            
        }
        public UserStore(DbContext context) : base(context)
        {
        }
    }
}