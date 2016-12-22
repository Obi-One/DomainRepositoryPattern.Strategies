using System.Data.Entity.ModelConfiguration;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Map.Base
{
    public class OITWMapBase<T> : EntityTypeConfiguration<T> where T : OITWBase
    {
        public OITWMapBase()
        {
            ToTable("OITW");

            HasKey(aOITM => new{aOITM.ItemCode, aOITM.WhsCode});
        }
    }
}
