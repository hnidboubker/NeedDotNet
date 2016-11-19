using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NeedDotNet.Server.Core.Conventions
{
    public class NeedConventions
    {
        public static void Mapp(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Conventions.Remove<OneToOneConstraintIntroductionConvention>();

            modelBuilder
                .Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}