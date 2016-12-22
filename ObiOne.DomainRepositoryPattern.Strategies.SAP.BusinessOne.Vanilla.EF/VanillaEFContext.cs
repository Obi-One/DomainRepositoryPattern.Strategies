using System.Reflection;
using ObiOne.DomainRepositoryPattern.Specialized.EF.DataContext;
using ObiOne.DomainRepositoryPattern.Specialized.EF.Infra;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF {
    public abstract class VanillaEFContext : EFContext {
        protected VanillaEFContext(EFConnectionInfo aEFConnectionInfo) : base(aEFConnectionInfo) {
            MyDbContext.ModelConfigurationsAssembly = Assembly.GetAssembly(typeof (VanillaEFContext));
        }

        //public DbSet<OCRDBase> OCRDBaseSet { get; set; }
        //public DbSet<OITMBase> OITMBaseSet { get; set; }
        //public DbSet<OITWBase> OITWBaseSet { get; set; }
        //public DbSet<ONNMBase> ONNMBaseSet { get; set; }
        //public DbSet<OQUTBase> OQUTBaseSet { get; set; }

    }
}
