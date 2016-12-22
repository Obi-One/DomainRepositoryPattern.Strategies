using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Infrastructure;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities
{
    public class OCRDBase : VanillaEFEntity<string>
    {
        public OCRDBase(){
        }

        public OCRDBase(string aCardCode, string aCardName) : this(){
            CardCode = aCardCode;
            CardName = aCardName;
        }

        public OCRDBase(short aSeries, string aCardName){
            Series = aSeries;
            CardName = aCardName;
        }

        public virtual short Series { get; set; }
        public virtual string CardCode { get; set; }
        public virtual string CardType { get; set; }
        public virtual string CardName { get; set; }
        public virtual string CardFName { get; set; }
        public virtual string E_Mail { get; set; }
        public virtual string Phone1 { get; set; }
        public virtual string Phone2 { get; set; }
        public virtual string Free_Text { get; set; }
        public virtual string validFor { get; set; }
        public virtual string ShipToDef { get; set; }
    }
}
