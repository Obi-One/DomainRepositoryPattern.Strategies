using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Infrastructure;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities
{
    public class ITM1Base : VanillaEFEntity<string>
    {
        public virtual string ItemCode { get; set; }
        public virtual short PriceList { get; set; }
        public decimal Price { get; set; }
    }
}
