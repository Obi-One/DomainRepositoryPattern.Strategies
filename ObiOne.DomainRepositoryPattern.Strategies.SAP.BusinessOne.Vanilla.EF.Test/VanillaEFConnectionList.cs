using ObiOne.DomainRepositoryPattern.Specialized.EF.Infra;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Test{
    public static class VanillaEFConnectionList{
        public static EFConnectionInfo VanillaEFConnection;

        private static readonly EFConnectionInfo msrNewCompanyAtDeathstar = new EFConnectionInfo("DEATHSTAR", "sa", "sa123", "SBO_NewCompany", EnInitializer.CreateDatabaseIfNotExists);
        private static readonly EFConnectionInfo msrLuciinDomAtHercules = new EFConnectionInfo("172.16.1.132", "sa", "Luciin!4", "Luciin_PRO_domingo", EnInitializer.CreateDatabaseIfNotExists);
        private static readonly EFConnectionInfo msrAcademicOneAtB101 = new EFConnectionInfo("10.0.1.79", "rodolpho.brock", "Genner@2015", "SBO_AcademicOne", EnInitializer.CreateDatabaseIfNotExists);

        static VanillaEFConnectionList(){
            VanillaEFConnection = msrLuciinDomAtHercules;
        }
    }
}