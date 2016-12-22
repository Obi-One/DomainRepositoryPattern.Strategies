using System.Collections.Generic;
using ObiOne.DomainRepositoryPattern.Specialized.DI.Infra;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Test
{
    public static class VanillaConnectionList{
        public static DIConnectionInfo NewCompanyAtDeathstar = new DIConnectionInfo("deathstar", "sa", "sa123", "SBO_NewCompany", "manager", "1234", null, new Dictionary<string, object> { { "ParceiroNegocio_DefaultSerie", 61 }, { "ImagesPath", @"C:\Program Files (x86)\SAP\SAP Business One\Bitmaps\" }, { "DefaultUsage", 10 } });
        public static DIConnectionInfo LuciinProAtHercules = new DIConnectionInfo("172.16.1.132", "sa", "Luciin!4", "Luciin_PRO", "prof01", "l01prof", null, new Dictionary<string, object> { { "ParceiroNegocio_DefaultSerie", 44 }, { "ImagesPath", @"\\hercules\publico\SAP Business One 9.1\imagens\Luciin\" }, { "DefaultUsage", 5 } });
        public static DIConnectionInfo LuciinDomAtHercules = new DIConnectionInfo("172.16.1.132", "sa", "Luciin!4", "Luciin_PRO_domingo", "prof01", "l01prof", null, new Dictionary<string, object> { { "ParceiroNegocio_DefaultSerie", 44 }, { "ImagesPath", @"\\hercules\publico\SAP Business One 9.1\imagens\Luciin\" }, { "DefaultUsage", 5 } });
        public static DIConnectionInfo DistrProAtHercules = new DIConnectionInfo("172.16.1.132", "sa", "Luciin!4", "SBO_Luciin_DIST_homolog2", "prof01", "d01prof", null, new Dictionary<string, object> { { "ParceiroNegocio_DefaultSerie", 64 }, { "ImagesPath", @"\\hercules\publico\SAP Business One 9.1\imagens\Distribuidora\" }, { "DefaultUsage", 5 } });
        public static DIConnectionInfo DistrDomAtHercules = new DIConnectionInfo("172.16.1.132", "sa", "Luciin!4", "SBO_Luciin_DIST_homolog2_domingo", "prof01", "d01prof", null, new Dictionary<string, object> { { "ParceiroNegocio_DefaultSerie", 64 }, { "ImagesPath", @"\\hercules\publico\SAP Business One 9.1\imagens\Distribuidora\" }, { "DefaultUsage", 5 } });
        public static DIConnectionInfo AcademicOneAtB101 = new DIConnectionInfo("10.0.1.79", "rodolpho.brock", "Genner@2015", "SBO_AcademicOne", "rodolpho.brock", "Genner@2015", null, new Dictionary<string, object> { { "ParceiroNegocio_DefaultSerie", 62 }, { "LCM_DefaultSerie", 17 }, { "ImagesPath", @"\\B101\Share_B1\Shared Folders\SBO_AcademicOne\Bitmaps\" }, { "DefaultUsage", 13 } });
    }
}
