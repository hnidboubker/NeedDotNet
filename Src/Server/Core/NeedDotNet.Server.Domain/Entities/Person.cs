using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeedDotNet.Server.Domain.Entities
{
    public class Person
    {
        public long Id { get; set; }
        public string PhotoUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Name
        {
            get { return String.Format("{0} {1}", LastName, FirstName); }
        }

        public DateTime? DateOfBirth { get; set; }
        [NotMapped]
        public int? Age { get; set; }

        public virtual ICollection<UserPerson> Users { get; set; }
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