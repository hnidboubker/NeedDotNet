using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
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
                        Name = GetName,
                        UserName = result.UserName,
                        Email = result.Email,
                        IsActive = result.IsActive
                      
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

        public async Task<ActionResult> Create(RegisterUserModel model)
        {
            if (ModelState.IsValid)
            {
               PersonService.CreatePerson(model.FirstName, model.LastName);
               Userservice.CreateUser(model.UserName, model.Email, model.Password);
               
                await Userservice.SaveChangesAsync();
                return RedirectToAction("Index", "Users");

            }
            return View(model);
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