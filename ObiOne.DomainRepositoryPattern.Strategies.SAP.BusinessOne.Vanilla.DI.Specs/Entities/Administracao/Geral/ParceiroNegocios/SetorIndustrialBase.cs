using ObiOne.DomainRepositoryPattern.Specialized.DI.Model;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Infrastructure;
using SAPbobsCOM;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.Administracao.Geral.ParceiroNegocios
{
    public class SetorIndustrialBase : VanillaDIEntity<int>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        #region Overrides of DIEntity<string>

        public override DIEntity<int> FromPersistable(dynamic aBusinessObject){
            var lIndustries = (Industries)aBusinessObject;

            Id = lIndustries.IndustryCode;
            Nome = lIndustries.IndustryName;
            Descricao = lIndustries.IndustryDescription;

            return this;
        }

        public override dynamic ToPersistable(dynamic aBusinessObject){
            var lIndustries = (Industries)aBusinessObject;

            //lIndustries.IndustryCode = Id;
            lIndustries.IndustryName = Nome;
            lIndustries.IndustryDescription = Descricao;

            return lIndustries;
        }

        #endregion
    }
}
