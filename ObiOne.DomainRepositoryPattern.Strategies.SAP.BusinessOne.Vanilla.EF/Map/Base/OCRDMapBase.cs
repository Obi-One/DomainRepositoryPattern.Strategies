using System.Data.Entity.ModelConfiguration;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Map.Base
{
    public class OCRDMapBase<T> : EntityTypeConfiguration<T> where T : OCRDBase
    {
        public OCRDMapBase(){
            ToTable("OCRD");

            HasKey(aOCRD => aOCRD.CardCode);
        }
    }
}
