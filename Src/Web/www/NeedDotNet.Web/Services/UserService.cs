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
        void CreateUser(string userName, string email, string password);
        Task<int> SaveChangesAsync();
    }

    public class UserService : IUserService
    {
        protected UserManager UserManager;

        public UserService(UserManager userManager)
        {
            UserManager = userManager;
        }

        public void CreateUser(string userName, string email, string password)
        {
            var user = new User()
            {
                Id = new long(),
                UserName = userName,
                Email = email,
                Passsword = password,
                IsRemoved = false,
                IsActive = false,
                Created = DateTime.Now,
                Creator = Thread.CurrentPrincipal.Identity.GetUserId<long>()
            };
            UserManager.Create(user);
            var result = new UserPerson()
            {
                UserId = user.Id,
                User = user
            };
            var context = new DefaultContext();
            context.UserPersons.Add(result);
        }

        public virtual  async Task<int> SaveChangesAsync()
        {
            var context = new DefaultContext();
            return await context.SaveChangesAsync();
        }
    }
}