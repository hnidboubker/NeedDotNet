using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using NeedDotNet.Server.Domain.Entities;
using NeedDotNet.Web.Models;
using NeedDotNet.Web.Services;

namespace NeedDotNet.Web.Controllers
{
    public class UsersController : Controller
    {
        protected UserManager UserManager;
        protected IPersonService PersonService;


        public UsersController(UserManager userManager, IPersonService personService)
        {
            UserManager = userManager;
            PersonService = personService;
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