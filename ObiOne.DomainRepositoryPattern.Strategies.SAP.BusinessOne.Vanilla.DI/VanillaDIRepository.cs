using ObiOne.DomainRepositoryPattern.Specialized.DI.Model;
using ObiOne.DomainRepositoryPattern.Specialized.DI.Repository;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI {
    public class VanillaDIRepository<TDIEntity, TDIKey> : DIRepository<TDIEntity, TDIKey> 
        where TDIEntity : DIEntity<TDIKey>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public VanillaDIRepository(VanillaDIContext aVanillaDIContext) : base(aVanillaDIContext){
        }
    }
}
