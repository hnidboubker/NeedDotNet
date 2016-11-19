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
    public class RoleStore : RoleStore<Role, long, UserRole>
    {
        public RoleStore():this(new DefaultContext())
        {
            
        }
        public RoleStore(DbContext context) : base(context)
        {
        }
    }
}