using ObiOne.DomainRepositoryPattern.Specialized.DI.Model;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Infrastructure;
using SAPbobsCOM;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.ParceiroNegocios{
    public class ParceiroNegocioBase : VanillaDIEntity<string>{
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        public ParceiroNegocioBase(){
            Series = 1; // 1 = MANUAL (NATIVO)
        }

        public ParceiroNegocioBase(string aId, string aRazaoSocial) : this(){
            Id = aId;
            RazaoSocial = aRazaoSocial;
        }

        public ParceiroNegocioBase(int aSeries, string aRazaoSocial) : this(){
            Series = aSeries; // PASSANDO UMA SÉRIE O SAP DETERMINA O CARDCODE
            RazaoSocial = aRazaoSocial;
        }

        public int Series { get; set; }

        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public int TipoPN { get; set; }
        public bool Ativo { get; set; }
        public int CodigoGrupo { get; set; }

        public string DDD { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public string Senha { get; set; }
        public int SetorIndustrial { get; set; }

        public string ContatoPadrao { get; set; }

        public string EntregaPadrao { get; set; }

        public string Observacoes { get; set; }

        public override DIEntity<string> FromPersistable(dynamic aBusinessObject){
            var lBusinessPartners = (BusinessPartners)aBusinessObject;

            Series = lBusinessPartners.Series;
            Id = lBusinessPartners.CardCode;
            TipoPN = (int)lBusinessPartners.CardType;
            CodigoGrupo = lBusinessPartners.GroupCode;
            RazaoSocial = lBusinessPartners.CardName;
            NomeFantasia = lBusinessPartners.CardForeignName;
            Ativo = lBusinessPartners.Valid == BoYesNoEnum.tYES;
            EntregaPadrao = lBusinessPartners.ShipToDefault;
            DDD = lBusinessPartners.Phone2;
            Telefone = lBusinessPartners.Phone1;
            Email = lBusinessPartners.EmailAddress;
            Site = lBusinessPartners.Website;
            Senha = lBusinessPartners.Password;
            SetorIndustrial = lBusinessPartners.Industry;
            ContatoPadrao = lBusinessPartners.ContactPerson;
            Observacoes = lBusinessPartners.FreeText;
            
            return this;
        }

        public override dynamic ToPersistable(dynamic aBusinessObject){
            var lBusinessPartners = (BusinessPartners) aBusinessObject;

            lBusinessPartners.Series = Series;
            lBusinessPartners.CardCode = Id;
            lBusinessPartners.CardType = (BoCardTypes) TipoPN;
            lBusinessPartners.GroupCode = CodigoGrupo;
            lBusinessPartners.CardName = RazaoSocial;
            lBusinessPartners.CardForeignName = NomeFantasia;
            lBusinessPartners.Valid = Ativo ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;
            lBusinessPartners.ShipToDefault = EntregaPadrao;
            lBusinessPartners.Phone2 = DDD;
            lBusinessPartners.Phone1 = Telefone;
            lBusinessPartners.EmailAddress = Email;
            lBusinessPartners.Website = Site;
            lBusinessPartners.Password = Senha;
            lBusinessPartners.Industry = SetorIndustrial;
            lBusinessPartners.ContactPerson = ContatoPadrao;
            lBusinessPartners.FreeText = Observacoes;
           
            return lBusinessPartners;
        }
    }
}
