using ObiOne.DomainRepositoryPattern.Specialized.DI.DataContext;
using ObiOne.DomainRepositoryPattern.Specialized.DI.Infra;
using ObiOne.DomainRepositoryPattern.Specialized.DI.Model;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.Administracao.Geral.ParceiroNegocios;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.Administracao.InicializacaoSistema;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.Estoque;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.Financas;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.ParceiroNegocios;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI
{
    public class VanillaDIContext : DIContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public VanillaDIContext(DIConnectionInfo aDIConnectionInfo) : base(aDIConnectionInfo){
        }

        

        public virtual VanillaDIRepository<TVanillaDIEntity, TVanillaDIKey> GetRepository<TVanillaDIEntity, TVanillaDIKey>() where TVanillaDIEntity : DIEntity<TVanillaDIKey>{
            return new VanillaDIRepository<TVanillaDIEntity, TVanillaDIKey>(this);
        }

        #region Overrides of DIContext

        protected override void OnModelCreating(EntitiesMapping aEntitiesMapping)
        {
            aEntitiesMapping.MapObjectType<NumeracaoDocumentosBase>(EnObjectTypes.oNotExposed, m => m.Id);
            aEntitiesMapping.MapObjectType<ParceiroNegocioBase>(EnObjectTypes.oBusinessPartners, m => m.Id);
            aEntitiesMapping.MapObjectType<GrupoPNBase>(EnObjectTypes.oBusinessPartnerGroups, m => m.Id);
            aEntitiesMapping.MapObjectType<SetorIndustrialBase>(EnObjectTypes.oIndustries, m => m.Id);
            aEntitiesMapping.MapObjectType<CondicaoPagamentoBase>(EnObjectTypes.oPaymentTermsTypes, m => m.Id);
            aEntitiesMapping.MapObjectType<ItemInventarioBase>(EnObjectTypes.oItems, m => m.Id);
            aEntitiesMapping.MapObjectType<LCMBase>(EnObjectTypes.oJournalEntries, m => m.Id);
            //aEntitiesMapping.MapObjectType<CotacaoVenda>(EnObjectTypes.oQuotations, m => m.Id);
        }

        #endregion
    }
}
