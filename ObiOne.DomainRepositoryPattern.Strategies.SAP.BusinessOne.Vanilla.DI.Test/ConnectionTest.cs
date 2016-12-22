using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAP.BusinessOne.DataAccess.DI.Specs.Model;
using SAP.BusinessOne.DataAccess.DI.Specs.Model.Infra;

namespace SAP.BusinessOne.DataAccess.DI.Specs.Test {
    [TestClass]
    public class ConnectionTest {
        [TestMethod]
        public void Connect_Test() {
            //ARRANGE
            var lExpectedVersion = 910160;
            var lConnectionInfo = new ConnectionInfo();

            lConnectionInfo.ServerType = EnServerType.MSSQL2012;

            //ACT
            var lConnection = new Connection();
            var lVersion = lConnection.Connect(lConnectionInfo);

            //ASSERT
            Assert.IsNotNull(lVersion);
            Assert.AreEqual(lExpectedVersion, lVersion);
        }
    }
}
