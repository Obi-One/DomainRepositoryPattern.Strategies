using System.Data.Entity.ModelConfiguration;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Map.Base
{
    public class CRD7MapBase<T> : EntityTypeConfiguration<T> where T : CRD7Base
    {
        public CRD7MapBase(){
            ToTable("CRD7");

            HasKey(aCRD7 => new{aCRD7.CardCode, aCRD7.Address, aCRD7.AddrType});

            //HasRequired(aCRD7 => aCRD7.OCRDObj)
            //    .WithRequiredPrincipal(aOCRD => aOCRD.CRD7Obj);

            //HasMany(s => s.CompanyDatabaseList)
            //    .WithRequired(s => s.CommomDatabaseObj)
            //    .HasForeignKey(s => s.CommomDatabaseId)
            //    .WillCascadeOnDelete(false);
        }
    }
}
