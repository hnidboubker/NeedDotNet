using NeedDotNet.Server.Core.Contexts;

namespace NeedDotNet.Web.Factories
{
    public interface IDatabaseFactory
    {
        DefaultContext DataContext { get; }
        DefaultContext Get();
        void Dispose(bool disposing);
        void Dispose();
    }
}