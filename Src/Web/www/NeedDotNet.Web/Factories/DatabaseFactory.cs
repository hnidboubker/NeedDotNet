using System;
using NeedDotNet.Server.Core.Contexts;
using NeedDotNet.Web.Infrastructure;

namespace NeedDotNet.Web.Factories
{
    public class DatabaseFactory : IDatabaseFactory
    {
        protected DefaultContext Context;
        private bool _disposed;

        public DefaultContext DataContext
        {
            get { return Context ?? (Context = new DefaultContext()); }
        }

        public DefaultContext Get()
        {
            return Context ?? (Context = DataContext);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DataContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}