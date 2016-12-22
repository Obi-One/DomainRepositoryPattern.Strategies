using ObiOne.DomainRepositoryPattern.Specialized.DI.Model;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Infrastructure;
using SAPbobsCOM;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.ParceiroNegocios{
    public class ParceiroNegocioEnderecoBase : VanillaDIEntity<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ParceiroNegocioEnderecoBase(){
            Nome = "ENTREGA";
            Tipo = "S";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ParceiroNegocioEnderecoBase(string aEstado) : this(){
            Estado = aEstado;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ParceiroNegocioEnderecoBase(string aNome, string aTipo, string aCEP, string aPais, string aEstado, string aCidade, string aBairro, string aTipoLogradouro, string aLogradouro,  string aNumero, string aComplemento) : this(aEstado)
        {
            Nome = aNome;
            Tipo = aTipo;
            CEP = aCEP;
            Pais = aPais;
            Estado = aEstado;
            Cidade = aCidade;
            Bairro = aBairro;
            TipoLogradouro = aTipoLogradouro;
            Logradouro = aLogradouro;
            Numero = aNumero;
            Complemento = aComplemento;
        }

        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string CEP { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string TipoLogradouro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        #region Overrides of DIEntity<string>

        public override DIEntity<string> FromPersistable(dynamic aBusinessObject){
            var lBPAddresses = (BPAddresses) aBusinessObject;

            Tipo = (lBPAddresses.AddressType == BoAddressType.bo_BillTo ? "B" : "S");
            Nome = lBPAddresses.AddressName;
            TipoLogradouro = lBPAddresses.TypeOfAddress;
            Logradouro = lBPAddresses.Street;
            Numero = lBPAddresses.StreetNo;
            Complemento = lBPAddresses.BuildingFloorRoom;
            CEP = lBPAddresses.ZipCode;
            Bairro = lBPAddresses.Block;
            Pais = lBPAddresses.Country;
            Estado = lBPAddresses.State;
            Cidade = lBPAddresses.City;

            return this;
        }

        public override dynamic ToPersistable(dynamic aBusinessObject){
            var lBPAddresses = (BPAddresses)aBusinessObject;

            lBPAddresses.AddressType = Tipo == "B" ? BoAddressType.bo_BillTo : BoAddressType.bo_ShipTo;
            lBPAddresses.AddressName = Nome;
            lBPAddresses.TypeOfAddress = TipoLogradouro;
            lBPAddresses.Street = Logradouro;
            lBPAddresses.StreetNo = Numero;
            lBPAddresses.BuildingFloorRoom = Complemento;
            lBPAddresses.ZipCode = CEP;
            lBPAddresses.Block = Bairro;
            lBPAddresses.Country = Pais;
            lBPAddresses.State = Estado;
            lBPAddresses.City = Cidade;

            return lBPAddresses;
        }

        #endregion
    }
}