using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NeedDotNet.Server.Core.Contexts;
using NeedDotNet.Server.Domain.Entities;
using NeedDotNet.Web.Models.Users;
using NeedDotNet.Web.Services;

namespace NeedDotNet.Web.Controllers
{
    public class UsersController : Controller
    {
        protected UserManager UserManager;
        protected UserService Userservice;
        protected IPersonService PersonService;


        public UsersController(UserManager userManager, IPersonService personService, UserService userservice)
        {
            UserManager = userManager;
            PersonService = personService;
            Userservice = userservice;
        }

        // GET: Users
        public async Task<ActionResult> Index()
        {
            var results = await UserManager.Users.ToListAsync();
            var model = new List<ArchiveUserModel>();
            if (results.Any())
            {
                foreach (var result in results)
                {
                    var items = new ArchiveUserModel()
                    {
                        Id = result.Id,
                        //Name = GetName,
                        UserName = result.UserName,
                        Email = result.Email,
                        IsActive = result.IsActive,
                        Created = result.Created,
                      
                    };
                    model.Add(items);
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new RegisterUserModel();
            return View(model);
        }

        public async Task<ActionResult> Create( RegisterUserModel model)
        {
            if (ModelState.IsValid)
            {

                var user = new User();
                var newUser = new User()
                {
                    Id = new long(),
                    UserName = user.UserName,
                    Email = user.Email,
                    Passsword = user.Passsword,
                    IsActive = false,
                    IsRemoved = false,
                    Created = DateTime.Now,
                    Creator = Thread.CurrentPrincipal.Identity.GetUserId<long>()
                };
                Userservice.CreateUser(newUser);
                var context = new DefaultContext();
                context.SaveChanges();

                var person = new Person();
                var newPerson = new Person()
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    IsActive = false,
                    IsRemoved = false,
                    Created = DateTime.Now,
                    Creator = Thread.CurrentPrincipal.Identity.GetUserId<long>()
                };
                
                PersonService.CreatePerson(newPerson);
               
                context.SaveChanges();
                AddUserToPerson(newUser, newPerson);
              
                if (model != null)
                {

                    
                    newPerson.FirstName = model.FirstName;
                    newPerson.LastName = model.LastName;
                    newUser.UserName = model.UserName;
                    newUser.Email = model.Email;
                    newUser.Passsword = model.Password;

                }
              
               
                await Userservice.SaveChangesAsync();
                return RedirectToAction("Index", "Users");

            }
            return View(model);
        }

        public UserPerson AddUserToPerson(User newUser, Person newPerson)
        {
            var context = new DefaultContext();
            var result = new UserPerson()
            {
                User = newUser,
                UserId = newUser.Id,

                Person = newPerson,
                PersonId = newPerson.Id,
            };

            //context.UserPersons.Add(result);
            context.SaveChanges();
            return result;
        }

        public string GetName
        {
            get
            {
                var userPerson = new UserPerson();
                var name = PersonService.GetPersonByFullName(userPerson.Person.Name);
                return name;
            }
        }
    }
}