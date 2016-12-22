using ObiOne.DomainRepositoryPattern.Specialized.DI.Model;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Infrastructure;
using SAPbobsCOM;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.Administracao.Geral.ParceiroNegocios
{
    public class CondicaoPagamentoBase : VanillaDIEntity<int>
    {
        #region Overrides of DIEntity<int>

        public override DIEntity<int> FromPersistable(dynamic aBusinessObject){
            var lPaymentTermsTypes = (PaymentTermsTypes)aBusinessObject;

            Id = lPaymentTermsTypes.GroupNumber;

            return this;
        }

        public override dynamic ToPersistable(dynamic aBusinessObject){
            var lPaymentTermsTypes = (PaymentTermsTypes)aBusinessObject;

            //lPaymentTermsTypes.GroupNumber = Id;
            
            return lPaymentTermsTypes;
        }

        #endregion
    }
}
