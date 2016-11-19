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
        
        Task<int> SaveChangesAsync();
        void AddUser(User user);
        void AddPerson(Person person);
        void AddUserToPerson(User user, Person person);
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
            DatabaseFactory = databaseFactory;
            UnitOfWork = unitOfWork;
        }

        public DefaultContext DataContext
        {
            get { return Context ?? (Context = DatabaseFactory.Get()); }
        }

       

       

        public virtual async Task<int> SaveChangesAsync()
        {
            return await UnitOfWork.SaveChangesAsync();
        }

        public void AddUser(User user)
        {
            DataContext.Users.Add(user);
            //UserManager.Create(user);
        }

        public void AddPerson(Person person)
        {
            DataContext.Persons.Add(person);
        }

        public void AddUserToPerson(User user, Person person)
        {
            var userPerson = new UserPerson()
            {
                UserId = user.Id,
                User = user,
                PersonId = person.Id,
                Person = person
            };
            DataContext.UserPersons.Add(userPerson);
        }
    }
}