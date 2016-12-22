using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Test.Tests{
    [TestClass]
    public class OCRDTest{
        [TestMethod]
        public void CRUDTest(){
            try{
                using (var lVanillaEFContext = new TestVanillaEFContext(VanillaEFConnectionList.VanillaEFConnection)){
                    // ARRANGE
                    var lSeriesRepo = lVanillaEFContext.GetRepository<ONNMBase, string>();
                    var lDefaultSerie = lSeriesRepo.Select()
                                                   .Single(aONNM => aONNM.ObjectCode == "2" && aONNM.DocSubType == "C")
                                                   .DfltSeries;

                    var lRepository = lVanillaEFContext.GetRepository<OCRDBase, string>();
                    var lEntityToInsert = new OCRDBase(lDefaultSerie, "Parceiro de Negócio de Teste");

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
                        lEntityToInsert.CardName = "Parceiro de Negócio de Teste Atualizado";
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

                    var lSomeEntity = new OCRDBase();
                    foreach (var lEntity in lEntityList){
                        Assert.IsNotNull(lEntity);
                        Assert.IsNotNull(lEntity.CardCode);
                        lSomeEntity = lEntity;
                    }

                    #endregion

                    #region SELECT

                    // ACT - SELECT
                    var lEntityToRetrieve = lRepository.Select(lSomeEntity.CardCode);

                    // ASSERT
                    Assert.IsNotNull(lEntityToRetrieve);
                    Assert.AreEqual(lSomeEntity.CardName, lEntityToRetrieve.CardName);

                    #endregion

                    #region DELETE

                    try{
                        // ACT - DELETE
                        lRepository.Delete(lSomeEntity.CardCode);
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
