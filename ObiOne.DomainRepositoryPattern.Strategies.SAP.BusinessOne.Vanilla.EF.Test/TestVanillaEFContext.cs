using ObiOne.DomainRepositoryPattern.Specialized.EF.DataContext;
using ObiOne.DomainRepositoryPattern.Specialized.EF.Infra;
using ObiOne.DomainRepositoryPattern.Specialized.EF.Model;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Infrastructure;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Test
{
    class TestVanillaEFContext : VanillaEFContext
    {
        public TestVanillaEFContext(EFConnectionInfo aEFConnectionInfo) : base(aEFConnectionInfo){
        }

        public VanillaEFRepository<TVanillaEFEntity, TVanillaEFKey> GetRepository<TVanillaEFEntity, TVanillaEFKey>() where TVanillaEFEntity : VanillaEFEntity<TVanillaEFKey>
        {
            return new TestVanillaEFRepository<TVanillaEFEntity, TVanillaEFKey>(this);
        }
    }

    internal class TestVanillaEFRepository<TVanillaEFEntity, TVanillaEFKey> : VanillaEFRepository<TVanillaEFEntity, TVanillaEFKey> where TVanillaEFEntity : EFEntity<TVanillaEFKey>{
        public TestVanillaEFRepository(EFContext aEFContext) : base(aEFContext){
        }
    }
}
