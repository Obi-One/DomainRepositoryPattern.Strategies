using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Test.Tests{
    [TestClass]
    public class OITMBaseTest{
        [TestMethod]
        public void CRUDTest(){
            try{
                using (var lVanillaEFContext = new TestVanillaEFContext(VanillaEFConnectionList.VanillaEFConnection)){
                    // ARRANGE
                    var lRepository = lVanillaEFContext.GetRepository<OITMBase, string>();
                    var lEntityToInsert = new OITMBase("T00001", "Item de Inventário de Teste");

                    #region INSERT

                    try{
                        // ACT - INSERT
                        lRepository.Insert(lEntityToInsert);
                        // ASSERT
                        Assert.Fail();
                    } catch (NotSupportedException lNotSupportedException){
                        Assert.IsNotNull(lNotSupportedException);
                    } catch (Exception lException){
                        Assert.Fail("Exception is not the right kind of exception.\n{0}", lException);
                    }

                    #endregion

                    #region UPDATE

                    try{
                        // ARRANGE
                        lEntityToInsert.ItemName = "Item de Inventário de Teste Atualizado";
                        // ACT - UPDATE
                        lRepository.Update(lEntityToInsert);
                        // ASSERT
                        Assert.Fail();
                    } catch (NotSupportedException lNotSupportedException){
                        Assert.IsNotNull(lNotSupportedException);
                    } catch (Exception lException){
                        Assert.Fail("Exception is not the right kind of exception.\n{0}", lException);
                    }

                    #endregion

                    #region SELECT ALL

                    // ACT - SELECT ALL
                    var lEntityList = lRepository.Select();

                    // ASSERT
                    Assert.AreEqual(true, lEntityList.Any());

                    var lSomeEntity = new OITMBase();
                    foreach (var lEntity in lEntityList){
                        Assert.IsNotNull(lEntity);
                        Assert.IsNotNull(lEntity.ItemCode);
                        //Assert.AreEqual(true, lEntity.CRD1List.Any());
                        lSomeEntity = lEntity;
                    }

                    #endregion

                    #region SELECT

                    // ACT - SELECT
                    var lEntityToRetrieve = lRepository.Select(lSomeEntity.ItemCode);

                    // ASSERT
                    Assert.IsNotNull(lEntityToRetrieve);
                    Assert.AreEqual(lSomeEntity.ItemName, lEntityToRetrieve.ItemName);

                    #endregion

                    #region DELETE

                    try{
                        // ACT - DELETE
                        lRepository.Delete(lSomeEntity.ItemCode);
                        // ASSERT
                        Assert.Fail();
                    } catch (NotSupportedException lNotSupportedException){
                        Assert.IsNotNull(lNotSupportedException);
                    } catch (Exception lException){
                        Assert.Fail("Exception is not the right kind of exception.\n{0}", lException);
                    }

                    #endregion

                }
            } catch (Exception lException){
                Assert.IsNull(lException, lException.ToString());
            }
        }
    }
}
