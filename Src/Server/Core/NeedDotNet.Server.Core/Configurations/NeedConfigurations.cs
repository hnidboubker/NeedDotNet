using System.Data.Entity;
using NeedDotNet.Server.Core.Contexts;

namespace NeedDotNet.Server.Core.Configurations
{
    public class NeedConfigurations
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof (DefaultContext).Assembly);
        }
    }
}