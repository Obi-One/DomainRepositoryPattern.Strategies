using System.Data.Entity.ModelConfiguration;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Map.Base
{
    public class QUT1MapBase<T> : EntityTypeConfiguration<T> where T : QUT1Base
    {
        public QUT1MapBase(){
            ToTable("QUT1");

            HasKey(aQUT1 => new { aQUT1.DocEntry, aQUT1.LineNum });

            //HasMany(aQUT1 => aQUT1.List)
            //    .WithRequired(s => s.CommomDatabaseObj)
            //    .HasForeignKey(s => s.CommomDatabaseId)
            //    .WillCascadeOnDelete(false);
        }
    }
}
