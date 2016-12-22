using ObiOne.DomainRepositoryPattern.Specialized.DI.Model;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Infrastructure;
using SAPbobsCOM;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.ParceiroNegocios{
    public class ParceiroNegocioFiscalBase : VanillaDIEntity<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ParceiroNegocioFiscalBase(){
            Nome = string.Empty;
            Tipo = "S";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ParceiroNegocioFiscalBase(string aCNPJ) : this(){
            CNPJ = aCNPJ;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ParceiroNegocioFiscalBase(string aCNPJ, string aInscricaoEstadual, string aCPF, string aSuframa) : this(aCNPJ)
        {
            CPF = aCPF;
            InscricaoEstadual = aInscricaoEstadual;
            Suframa = aSuframa;
        }

        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string CPF { get; set; }
        public string Suframa { get; set; }

        #region Overrides of DIEntity<string>

        public override DIEntity<string> FromPersistable(dynamic aBusinessObject){
            var lBPFiscalTaxID = (BPFiscalTaxID) aBusinessObject;

            Nome = lBPFiscalTaxID.Address;
            Tipo = lBPFiscalTaxID.AddrType == BoAddressType.bo_BillTo ? "B" : "S";
            CNPJ = lBPFiscalTaxID.TaxId0;
            InscricaoEstadual = lBPFiscalTaxID.TaxId1;
            CPF = lBPFiscalTaxID.TaxId4;
            Suframa = lBPFiscalTaxID.TaxId8;

            return this;
        }

        public override dynamic ToPersistable(dynamic aBusinessObject){
            var lBPFiscalTaxID = (BPFiscalTaxID)aBusinessObject;

            if (!string.IsNullOrWhiteSpace(Nome)) lBPFiscalTaxID.Address = Nome;
            //lBPFiscalTaxID.AddrType = Tipo == "B" ? BoAddressType.bo_BillTo : BoAddressType.bo_ShipTo; NO SETTER
            lBPFiscalTaxID.TaxId0 = CNPJ;
            lBPFiscalTaxID.TaxId1 = InscricaoEstadual;
            lBPFiscalTaxID.TaxId4 = CPF;
            lBPFiscalTaxID.TaxId8 = Suframa;

            return lBPFiscalTaxID;
        }

        #endregion
    }
}