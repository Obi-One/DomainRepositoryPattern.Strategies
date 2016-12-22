using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.Financas;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Test.Tests
{
    [TestClass]
    public class LCMTest
    {
        [TestMethod]
        public void CRUDTest()
        {
            try
            {
                using (var lVanillaDIContext = new VanillaDIContext(VanillaConnectionList.NewCompanyAtDeathstar))
                {
                    // ARRANGE
                    var lEmptyEntity = new LCMBase();

                    var lLCMList = new List<LCMLinhaBase>();
                    lLCMList.Add(new LCMLinhaBase(EnAccountType.BusinessPartner, "C00005", EnAmountType.Debit, 100m, DateTime.Now));
                    lLCMList.Add(new LCMLinhaBase(EnAccountType.GLAccount, "1.1.1.2.1", EnAmountType.Credit, 100m, DateTime.Now));

                    var lEntityToInsert = new LCMBase(0, DateTime.Now, lLCMList);// 44 LuciinDomAtHercules, 61 NewCompanyAtDeathstar

                    var lRepository = lVanillaDIContext.GetRepository<LCMBase, int>();

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

                    //#region INSERT

                    //// ACT - INSERT
                    //lEntityToInsert = lRepository.Insert(lEntityToInsert);

                    //// ASSERT - SELECT AND INSERT
                    //var lEntityToSelect = lRepository.Select(lEntityToInsert.Id);

                    //Assert.IsNotNull(lEntityToSelect);
                    //Assert.AreEqual(lEntityToInsert.RazaoSocial, lEntityToSelect.RazaoSocial);

                    //#endregion

                    //#region UPDATE

                    //// ACT - UPDATE
                    //lEntityToInsert.RazaoSocial = "INSTITUTO GUGA KUERTEN Atualizado";
                    //lEntityToInsert = lRepository.Update(lEntityToInsert);

                    //// ASSERT - SELECT AND UPDATE
                    //lEntityToSelect = lRepository.Select(lEntityToInsert.Id);

                    //Assert.IsNotNull(lEntityToSelect);
                    //Assert.AreEqual(lEntityToInsert.RazaoSocial, lEntityToSelect.RazaoSocial);

                    //#endregion

                    //#region DELETE

                    //// ACT - DELETE
                    //lRepository.Delete(lEntityToInsert.Id);

                    //// ASSERT - SELECT AND DELETE
                    //lEntityToSelect = lRepository.Select(lEntityToInsert.Id);

                    //Assert.IsNull(lEntityToSelect);

                    //#endregion
                }
            }
            catch (Exception lException)
            {
                Assert.IsNull(lException, lException.ToString());
            }
        }
    }
}
