using ObiOne.DomainRepositoryPattern.Specialized.DI.Model;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Infrastructure;
using SAPbobsCOM;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.DocMkt
{
    public class DocumentTaxExtensionBase : VanillaDIEntity<int>
    {
        public string Incoterms { get; set; }

        #region Overrides of DIEntity<int>

        public override DIEntity<int> FromPersistable(dynamic aBusinessObject){
            var lTaxExtension = (TaxExtension)aBusinessObject;

            Incoterms = lTaxExtension.Incoterms;

            return this;
        }

        public override dynamic ToPersistable(dynamic aBusinessObject){
            var lTaxExtension = (TaxExtension)aBusinessObject;

            lTaxExtension.Incoterms = Incoterms;

            return lTaxExtension;
        }

        #endregion
    }
}
