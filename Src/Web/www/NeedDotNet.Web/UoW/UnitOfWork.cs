using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Ajax.Utilities;
using NeedDotNet.Server.Core.Contexts;
using NeedDotNet.Web.Factories;

namespace NeedDotNet.Web.UoW
{
    public interface IUnitOfWork
    {
        DefaultContext DataContext { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        protected IDatabaseFactory DatabaseFactory;
        protected DefaultContext Context;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        public DefaultContext DataContext
        {
            get { return Context ?? (Context = DatabaseFactory.Get()); }
        }

        public virtual int SaveChanges()
        {
            return DataContext.Save();
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await DataContext.SaveAsyn();
        } 
    }
}