using System;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Infrastructure;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities
{
    public class SPP1Base : VanillaEFEntity<string>
    {
        public virtual string ItemCode { get; set; }
        public virtual short ListNum { get; set; }
        public string CardCode { get; set; }
        public string Currency { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
