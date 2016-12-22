using System.Data.Entity.ModelConfiguration;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Map.Base
{
    public class ITM1MapBase<T> : EntityTypeConfiguration<T> where T : ITM1Base
    {
        public ITM1MapBase()
        {
            ToTable("ITM1");

            HasKey(aITM1 => new{aITM1.ItemCode, aITM1.PriceList});
        }
    }
}
