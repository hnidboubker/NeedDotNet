using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using NeedDotNet.Server.Core.Contexts;
using NeedDotNet.Server.Domain.Entities;

namespace NeedDotNet.Web.Services
{
    public interface IUserService
    {
        User CreateUser(User user);
        Task CreateUserAsync(User user);
        Task<int> SaveChangesAsync();
    }

    public class UserService : IUserService
    {
        protected UserManager UserManager;

        public UserService(UserManager userManager)
        {
            UserManager = userManager;
        }

        public virtual User CreateUser(User user)
        {
            
            UserManager.Create(user);
            
            return user;
        }

        public virtual async Task CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public virtual  async Task<int> SaveChangesAsync()
        {
            var context = new DefaultContext();
            return await context.SaveChangesAsync();
        }
    }
}