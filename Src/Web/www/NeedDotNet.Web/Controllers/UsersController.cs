using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NeedDotNet.Web.Models;
using NeedDotNet.Web.Services;

namespace NeedDotNet.Web.Controllers
{
    public class UsersController : Controller
    {
        protected UserManager UserManager;

        public UsersController(UserManager userManager)
        {
            this.UserManager = userManager;
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
                      
                    };
                    model.Add(items);
                }
            }
            return View(model);
        }
    }
}