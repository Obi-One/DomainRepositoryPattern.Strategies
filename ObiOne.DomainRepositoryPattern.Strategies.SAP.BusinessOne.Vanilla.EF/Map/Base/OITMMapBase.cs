using System.Data.Entity.ModelConfiguration;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Map.Base
{
    public class OITMMapBase<T> : EntityTypeConfiguration<T> where T : OITMBase
    {
        public OITMMapBase()
        {
            ToTable("OITM");

            HasKey(aOITM => aOITM.ItemCode);
        }
    }
}
