using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Infrastructure;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities
{
    public class OITMBase : VanillaEFEntity<string>
    {
        public OITMBase(){
        }

        public OITMBase(string aItemCode, string aItemName) : this(){
            ItemCode = aItemCode;
            ItemName = aItemName;
        }

        public virtual short Series { get; set; }
        public virtual string ItemCode { get; set; }
        public virtual string ItemName { get; set; }
        public virtual string validFor { get; set; }
        public virtual string UserText { get; set; }
        public virtual string QryGroup1 { get; set; }
        public virtual string QryGroup9 { get; set; }
        public virtual string QryGroup10 { get; set; }
        public virtual string CodeBars { get; set; }
        public virtual string SellItem { get; set; }
        public virtual string PrchseItem { get; set; }
        public virtual string ItemClass { get; set; }
        public virtual string SalPackMsr { get; set; }
        public virtual string SalUnitMsr { get; set; }
        public virtual string InvntItem { get; set; }
        public virtual string PicturName { get; set; }
        public virtual int OSvcCode { get; set; }
    }
}
