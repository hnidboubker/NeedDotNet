using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using NeedDotNet.Server.Core.Contexts;
using NeedDotNet.Server.Domain.Entities;
using NeedDotNet.Web.Factories;
using NeedDotNet.Web.UoW;

namespace NeedDotNet.Web.Services
{
    public interface IUserService
    {
        User CreateUser(User user);
        Task CreateUserAsync(User user);
        Task<int> SaveChangesAsync();
        void AddUser(User user);
        void AddPerson(Person person);
    }

    public class UserService : IUserService
    {
        protected DefaultContext Context;
        protected UserManager UserManager;
        protected IDatabaseFactory DatabaseFactory;
        protected IUnitOfWork UnitOfWork;

        public UserService(UserManager userManager, IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork)
        {
            UserManager = userManager;
            this.DatabaseFactory = databaseFactory;
            this.UnitOfWork = unitOfWork;
        }

        public DefaultContext DataContext
        {
            get { return Context ?? (Context = DatabaseFactory.Get()); }
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
            return await UnitOfWork.SaveChangesAsync();
        }

        public void AddUser(User user)
        {
            DataContext.Users.Add(user);
        }

        public void AddPerson(Person person)
        {
            DataContext.Persons.Add(person);
        }
    }
}