using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }

    public class PersonRepository : IPersonRepository
    {
        
    }
}