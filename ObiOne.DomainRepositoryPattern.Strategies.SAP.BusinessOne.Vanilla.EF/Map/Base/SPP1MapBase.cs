using System.Data.Entity.ModelConfiguration;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Map.Base
{
    public class SPP1MapBase<T> : EntityTypeConfiguration<T> where T : SPP1Base
    {
        public SPP1MapBase()
        {
            ToTable("SPP1");

            HasKey(aITM1 => new { aITM1.ItemCode, aITM1.ListNum, aITM1.CardCode });
        }
    }
}
