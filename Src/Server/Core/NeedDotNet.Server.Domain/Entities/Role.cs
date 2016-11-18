using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NeedDotNet.Server.Domain.Entities
{
    public class Role : IdentityRole<long, UserRole>
    {
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsValid { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Removed { get; set; }
        public long? Creator { get; set; }
        public long? Updator { get; set; }
        public long? Remover { get; set; }


        public bool IsTransient()
        {
            return EqualityComparer<long>.Default.Equals(Id, default(long));
        }
    }
}