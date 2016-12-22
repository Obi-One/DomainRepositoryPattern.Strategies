using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Infrastructure;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities
{
    public class OITWBase : VanillaEFEntity<string>
    {
        public virtual string ItemCode { get; set; }
        public virtual string WhsCode { get; set; }
        public virtual decimal OnHand { get; set; }
        public virtual decimal IsCommited { get; set; }
        public virtual decimal OnOrder { get; set; }
    }
}
