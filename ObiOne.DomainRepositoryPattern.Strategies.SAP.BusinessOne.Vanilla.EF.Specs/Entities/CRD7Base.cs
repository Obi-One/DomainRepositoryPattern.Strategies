using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Infrastructure;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities{
    public class CRD7Base : VanillaEFEntity<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CRD7Base"/> class.
        /// </summary>
        public CRD7Base(){
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public CRD7Base(string aCardCode, string aTaxId0, string aTaxId1, string aTaxId4, string aTaxId8)
        {
            CardCode = aCardCode;
            Address = string.Empty;
            AddrType = "S";
            TaxId0 = aTaxId0;
            TaxId1 = aTaxId1;
            TaxId4 = aTaxId4;
            TaxId8 = aTaxId8;
        }

        public virtual string CardCode { get; set; }
        public virtual string Address { get; set; }
        public virtual string AddrType { get; set; }
        public virtual string TaxId0 { get; set; }
        public virtual string TaxId1 { get; set; }
        public virtual string TaxId4 { get; set; }
        public virtual string TaxId8 { get; set; }
    }
}