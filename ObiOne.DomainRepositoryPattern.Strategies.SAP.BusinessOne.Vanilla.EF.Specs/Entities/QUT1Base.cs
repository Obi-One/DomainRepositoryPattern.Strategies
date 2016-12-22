using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Infrastructure;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities{
    public class QUT1Base : VanillaEFEntity<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QUT1Base"/> class.
        /// </summary>
        public QUT1Base(){
        }

        public virtual int DocEntry { get; set; }
        public virtual int LineNum { get; set; }
        public virtual string ItemCode { get; set; }
        public virtual OITMBase OITMObj { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual decimal Price { get; set; }
        public virtual decimal? DiscPrcnt { get; set; }
        public virtual int? Usage { get; set; }
        public virtual decimal LineTotal { get; set; }
        public virtual string FreeTxt { get; set; }
    }
}