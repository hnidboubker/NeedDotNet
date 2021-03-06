﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using Microsoft.AspNet.Identity;
using NeedDotNet.Server.Core.Contexts;
using NeedDotNet.Server.Domain.Entities;

namespace NeedDotNet.Web.Services
{
    public interface IPersonService
    {
        string GetPersonByFullName(string name);
        Person CreatePerson(Person person);
    }

    public class PersonService : IPersonService
    {
        protected IPersonRepository Repository;

        public PersonService(IPersonRepository repository)
        {
            Repository = repository;
        }

        public string GetPersonByFullName(string name)
        {
            var result = Repository.GetPersonByFullName(name);
            return result;
        }

        public Person CreatePerson(Person person)
        {
          Repository.Add(person);
            return person;
        }
    }


    public interface IPersonRepository
    {
        DefaultContext DataContext { get; }
        void Add(Person person);
        void Update(Person person);
        void Remove(Person person);
        string GetPersonByFullName(string name);
        Person CreatePerson(string firstName, string lastName);
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

        public virtual string GetPersonByFullName(string name)
        {
            var query = DbSet.SingleOrDefault(o => o.Name == name);
            return query.ToString();
        }

        public Person CreatePerson(string firstName, string lastName)
        {
            var person = new Person()
            {
                Id = new long(),
                FirstName = firstName,
                LastName = lastName,
                IsRemoved = false,
                IsActive = false,
                Created = DateTime.Now,
                Creator = Thread.CurrentPrincipal.Identity.GetUserId<long>()
            };

            Add(person);

            var result = new UserPerson()
            {
                PersonId = person.Id,
                Person = person
            };
            person.Users.Add(result);
            var context = new DefaultContext();
            context.UserPersons.Add(result);
            
            return person;
        }
    }
}