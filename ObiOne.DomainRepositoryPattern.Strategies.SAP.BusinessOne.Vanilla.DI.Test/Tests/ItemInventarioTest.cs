using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.Estoque;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Test.Tests {
    [TestClass]
    public class ItemInventarioTest {
        [TestMethod]
        public void CRUDTest(){
            try
            {
                using (var lVanillaDIContext = new VanillaDIContext(VanillaConnectionList.NewCompanyAtDeathstar))
                {
                    // ARRANGE
                    var lEntityToInsert = new ItemInventarioBase(63, "Produto de Teste"); // ?? LuciinDomAtHercules, 63 NewCompanyAtDeathstar

                    var lRepository = lVanillaDIContext.GetRepository<ItemInventarioBase, string>();

                    #region SELECT ERROR

                    try
                    {
                        // ACT - SELECT ALL
                        lRepository.Select();
                        // ASSERT
                        Assert.Fail();
                    }
                    catch (NotSupportedException lNotSupportedException)
                    {
                        Assert.IsNotNull(lNotSupportedException);
                    }
                    catch (Exception lException)
                    {
                        Assert.Fail("Exception is not the right kind of exception.\n{0}", lException);
                    }

                    #endregion

                    #region INSERT

                    // ACT - INSERT
                    lEntityToInsert = lRepository.Insert(lEntityToInsert);

                    // ASSERT - SELECT AND INSERT
                    var lEntityToSelect = lRepository.Select(lEntityToInsert.Id);

                    Assert.IsNotNull(lEntityToSelect);
                    Assert.AreEqual(lEntityToInsert.Nome, lEntityToSelect.Nome);

                    #endregion

                    #region UPDATE

                    // ACT - UPDATE
                    lEntityToInsert.Nome = "Produto de Teste Atualizado";
                    lEntityToInsert = lRepository.Update(lEntityToInsert);

                    // ASSERT - SELECT AND UPDATE
                    lEntityToSelect = lRepository.Select(lEntityToInsert.Id);

                    Assert.IsNotNull(lEntityToSelect);
                    Assert.AreEqual(lEntityToInsert.Nome, lEntityToSelect.Nome);

                    #endregion

                    #region DELETE

                    // ACT - DELETE
                    lRepository.Delete(lEntityToInsert.Id);

                    // ASSERT - SELECT AND DELETE
                    lEntityToSelect = lRepository.Select(lEntityToInsert.Id);

                    Assert.IsNull(lEntityToSelect);

                    #endregion
                }
            }
            catch (Exception lException)
            {
                Assert.IsNull(lException, lException.ToString());
            }
        }
    }
}
