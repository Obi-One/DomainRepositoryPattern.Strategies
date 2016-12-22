using ObiOne.DomainRepositoryPattern.Specialized.DI.Model;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Infrastructure;
using SAPbobsCOM;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.Administracao.Geral.ParceiroNegocios
{
    public class GrupoPNBase : VanillaDIEntity<int>
    {
        public string Descricao { get; set; }
        public int TipoGrupo { get; set; }

        #region Overrides of DIEntity<string>

        public override DIEntity<int> FromPersistable(dynamic aBusinessObject){
            var lBusinessPartnerGroups = (BusinessPartnerGroups)aBusinessObject;

            Id = lBusinessPartnerGroups.Code;
            Descricao = lBusinessPartnerGroups.Name;
            TipoGrupo = (int) lBusinessPartnerGroups.Type;

            return this;
        }

        public override dynamic ToPersistable(dynamic aBusinessObject){
            var lBusinessPartnerGroups = (BusinessPartnerGroups)aBusinessObject;

            //lBusinessPartnerGroups.Code = Id;
            lBusinessPartnerGroups.Name = Descricao;
            lBusinessPartnerGroups.Type = (BoBusinessPartnerGroupTypes) TipoGrupo;

            return lBusinessPartnerGroups;
        }

        #endregion
    }
}
