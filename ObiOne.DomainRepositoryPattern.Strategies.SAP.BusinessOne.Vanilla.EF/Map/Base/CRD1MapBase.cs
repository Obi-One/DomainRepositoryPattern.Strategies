using System.Data.Entity.ModelConfiguration;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Map.Base
{
    public class CRD1MapBase<T> : EntityTypeConfiguration<T> where T : CRD1Base
    {
        public CRD1MapBase(){
            ToTable("CRD1");

            HasKey(aCRD1 => new { aCRD1.CardCode, aCRD1.Address, aCRD1.AdresType });

            //HasMany(s => s.CompanyDatabaseList)
            //    .WithRequired(s => s.CommomDatabaseObj)
            //    .HasForeignKey(s => s.CommomDatabaseId)
            //    .WillCascadeOnDelete(false);
        }
    }
}
