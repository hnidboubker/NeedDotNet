using System;

namespace NeedDotNet.Web.Models
{
    public class ArchiveUserModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool  IsActive { get; set; }
        public DateTime? Created { get; set; }
    }
}