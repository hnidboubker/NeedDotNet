using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NeedDotNet.Server.Core.Contexts;
using NeedDotNet.Server.Domain.Entities;

namespace NeedDotNet.Web.Services
{
    public interface IPersonService
    {
    }

    public class PersonService : IPersonService
    {
        protected IPersonRepository Repository;

        public PersonService(IPersonRepository repository)
        {
            Repository = repository;
        }
    }


    public interface IPersonRepository
    {
        DefaultContext DataContext { get; }
        void Add(Person person);
        void Update(Person person);
        void Remove(Person person);
    }

    public class PersonRepository : IPersonRepository
    {
        protected DefaultContext Context;
        protected IDbSet<Person> DbSet;

        public PersonRepository()
        {
            DbSet = DataContext.Set<Person>();
        }

        public DefaultContext DataContext
        {
            get { return Context ?? (Context = new DefaultContext()); } 
        }

        public virtual void Add(Person person)
        {
            DbSet.Add(person);
        }

        public virtual void Update(Person person)
        {
            DataContext.Entry(person).State = EntityState.Modified;
        }

        public virtual void Remove(Person person)
        {
            DbSet.Remove(person);
        }
    }
}