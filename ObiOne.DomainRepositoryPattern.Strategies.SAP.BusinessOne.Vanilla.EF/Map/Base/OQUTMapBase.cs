using System.Data.Entity.ModelConfiguration;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Map.Base
{
    public class OQUTMapBase<T> : EntityTypeConfiguration<T> where T : OQUTBase
    {
        public OQUTMapBase(){
            ToTable("OQUT");

            HasKey(aOQUT => aOQUT.DocEntry);
        }
    }
}
