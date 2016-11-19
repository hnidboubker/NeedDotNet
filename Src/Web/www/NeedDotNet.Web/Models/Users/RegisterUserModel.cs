using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeedDotNet.Web.Models.Users
{
    public class RegisterUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}