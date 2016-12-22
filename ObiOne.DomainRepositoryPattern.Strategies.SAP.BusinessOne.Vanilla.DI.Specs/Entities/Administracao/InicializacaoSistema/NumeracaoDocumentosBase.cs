using ObiOne.DomainRepositoryPattern.Specialized.DI.Model;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Infrastructure;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.Administracao.InicializacaoSistema
{
    public class NumeracaoDocumentosBase : VanillaDIEntity<int>
    {
        public string CodigoObjeto { get; set; }

        public string CodigoSubObjeto { get; set; }

        public short CodigoNumeracao { get; set; }

        #region Overrides of DIEntity<int>

        public override DIEntity<int> FromPersistable(dynamic aBusinessObject){

            throw new System.NotImplementedException();
        }

        public override dynamic ToPersistable(dynamic aBusinessObject){
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
