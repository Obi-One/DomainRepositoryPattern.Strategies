using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.ParceiroNegocios;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Test.Tests{
    [TestClass]
    public class ParceiroNegocioTest{
        [TestMethod]
        public void CRUDTest(){
            try{
                using (var lVanillaDIContext = new VanillaDIContext(VanillaConnectionList.NewCompanyAtDeathstar)){
                    // ARRANGE
                    var lEntityToInsert = new ParceiroNegocioBase(61, "INSTITUTO GUGA KUERTEN"); //, "04.003.206/0001-26", "SC"); // 44 LuciinDomAtHercules, 61 NewCompanyAtDeathstar

                    var lRepository = lVanillaDIContext.GetRepository<ParceiroNegocioBase, string>();

                    #region SELECT ERROR

                    try{
                        // ACT - SELECT ALL
                        lRepository.Select();
                        // ASSERT
                        Assert.Fail();
                    } catch (NotSupportedException lNotSupportedException){
                        Assert.IsNotNull(lNotSupportedException);
                    } catch (Exception lException){
                        Assert.Fail("Exception is not the right kind of exception.\n{0}", lException);
                    }

                    #endregion

                    #region INSERT

                    // ACT - INSERT
                    var lEntityInserted = lRepository.Insert(lEntityToInsert);

                    // ASSERT - SELECT AND INSERT
                    var lEntityToSelect = lRepository.Select(lEntityInserted.Id);

                    Assert.IsNotNull(lEntityToSelect);
                    Assert.AreEqual(lEntityToInsert.RazaoSocial, lEntityToSelect.RazaoSocial);

                    #endregion

                    #region UPDATE

                    // ACT - UPDATE
                    lEntityInserted.RazaoSocial = "INSTITUTO GUGA KUERTEN Atualizado";
                    var lEntityUpdated = lRepository.Update(lEntityInserted);

                    // ASSERT - SELECT AND UPDATE
                    lEntityToSelect = lRepository.Select(lEntityUpdated.Id);

                    Assert.IsNotNull(lEntityToSelect);
                    Assert.AreEqual(lEntityInserted.RazaoSocial, lEntityToSelect.RazaoSocial);

                    #endregion

                    #region DELETE

                    // ACT - DELETE
                    lRepository.Delete(lEntityUpdated.Id);

                    // ASSERT - SELECT AND DELETE
                    lEntityToSelect = lRepository.Select(lEntityUpdated.Id);

                    Assert.IsNull(lEntityToSelect);

                    #endregion
                }
            } catch (Exception lException){
                Assert.IsNull(lException, lException.ToString());
            }
        }
    }
}
