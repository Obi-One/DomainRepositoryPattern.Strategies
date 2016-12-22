using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Infrastructure;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities{
    public class CRD1Base : VanillaEFEntity<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CRD1Base"/> class.
        /// </summary>
        public CRD1Base(){
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public CRD1Base(string aCardCode, string aAddress, string aAdresType, string aCountry, string aZipCode, string aBlock, string aState, string aCity, string aAddrType, string aStreet, string aStreetNo, string aBuilding) : this()
        {
            CardCode = aCardCode;
            Address = aAddress;
            AdresType = aAdresType;
            ZipCode = aZipCode;
            Country = aCountry;
            State = aState;
            City = aCity;
            Block = aBlock;
            AddrType = aAddrType;
            Street = aStreet;
            StreetNo = aStreetNo;
            Building = aBuilding;
        }

        public virtual string CardCode { get; set; }
        public virtual string Address { get; set; }
        public virtual string AdresType { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string Country { get; set; }
        public virtual string State { get; set; }
        public virtual string City { get; set; }
        public virtual string Block { get; set; }
        public virtual string AddrType { get; set; }
        public virtual string Street { get; set; }
        public virtual string StreetNo { get; set; }
        public virtual string Building { get; set; }
    }
}