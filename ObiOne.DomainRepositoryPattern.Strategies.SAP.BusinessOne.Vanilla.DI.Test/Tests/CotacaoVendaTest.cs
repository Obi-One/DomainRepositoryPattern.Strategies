using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAP.BusinessOne.DataAccess.Vanilla.Specs.Entities.DocMkt.Vendas.CotacaoVenda;

namespace SAP.BusinessOne.DataAccess.Vanilla.Test.Tests
{
    [TestClass]
    public class CotacaoVendaTest
    {
        [TestMethod]
        public void CRUDTest()
        {
            try
            {
                using (var lVanillaDIContext = new VanillaDIContext(VanillaConnectionList.LuciinDomAtHercules))
                {
                    // ARRANGE
                    var lRepository = lVanillaDIContext.GetRepository<CotacaoVenda, int>();

                    #region SELECT ALL ERROR

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
                    // ARRANGE
                    var lItemList = new List<CotacaoVendaItem>();
                        
                    var lItem = new CotacaoVendaItem("AL004/1", 2, 107.096976, "Obs do item");
                    lItem.Utilizacao = "5";

                    lItemList.Add(lItem);

                    var lEntityToInsert = new CotacaoVenda(14, "C00233", DateTime.Now, lItemList);
                    lEntityToInsert.NumeroRefExterno = "110";
                    lEntityToInsert.CodigoMeusPedidos = 210541885;
                    lEntityToInsert.Observacao = "Teste unitário";
                    lEntityToInsert.Total = (decimal?) 107.096976;


                    // ACT - INSERT
                    lEntityToInsert.Id = lRepository.Insert(lEntityToInsert).Id;

                    // ASSERT - SELECT AND INSERT
                    var lEntityToSelect = lRepository.Select(lEntityToInsert.Id);

                    Assert.IsNotNull(lEntityToSelect);
                    Assert.AreEqual(lEntityToInsert.Id, lEntityToSelect.Id);
                    Assert.AreEqual(lEntityToInsert.Series, lEntityToSelect.Series);
                    Assert.AreEqual(lEntityToInsert.NumeroRefExterno, lEntityToSelect.NumeroRefExterno);
                    Assert.AreEqual(lEntityToInsert.DataEmissao, lEntityToSelect.DataEmissao);
                    Assert.AreEqual(lEntityToInsert.DataEntrega, lEntityToSelect.DataEntrega);
                    Assert.AreEqual(lEntityToInsert.CodigoMeusPedidos, lEntityToSelect.CodigoMeusPedidos);
                    Assert.AreEqual(lEntityToInsert.ParceiroNegocioId, lEntityToSelect.ParceiroNegocioId);
                    Assert.AreEqual(lEntityToInsert.ParceiroNegocioObj, lEntityToSelect.ParceiroNegocioObj);                    
                    Assert.AreEqual(lEntityToInsert.Observacao, lEntityToSelect.Observacao);
                    Assert.AreEqual(lEntityToInsert.Total, lEntityToSelect.Total);

                    foreach (var lEntityToInsertItem in lEntityToInsert.DocMktLineList){
                        var lEntityToSelectItem = lEntityToSelect.DocMktLineList.SingleOrDefault(aItem => aItem.Id == lEntityToInsertItem.Id);

                        Assert.IsNotNull(lEntityToSelectItem);
                        Assert.AreEqual(lEntityToInsertItem.Id, lEntityToSelectItem.Id);
                        Assert.AreEqual(lEntityToInsertItem.ItemInventarioId, lEntityToSelectItem.ItemInventarioId);
                        Assert.AreEqual(lEntityToInsertItem.ItemInventarioObj, lEntityToSelectItem.ItemInventarioObj);
                        Assert.AreEqual(lEntityToInsertItem.Utilizacao, lEntityToSelectItem.Utilizacao);
                        Assert.AreEqual(lEntityToInsertItem.Quantidade, lEntityToSelectItem.Quantidade);
                        Assert.AreEqual(lEntityToInsertItem.PrecoUnitario, lEntityToSelectItem.PrecoUnitario);
                    }

                    #endregion

                    #region UPDATE

                    // ACT - UPDATE
                    lEntityToInsert.Observacao = "Teste unitário alterado";
                    lRepository.Update(lEntityToInsert);

                    // ASSERT - SELECT AND UPDATE
                    lEntityToSelect = lRepository.Select(lEntityToInsert.Id);

                    Assert.IsNotNull(lEntityToSelect);
                    Assert.AreEqual(lEntityToInsert.Observacao, lEntityToSelect.Observacao);

                    #endregion

                    #region DELETE
                    try
                    {
                        // ACT - DELETE
                        lRepository.Delete(lEntityToInsert.Id);
                        // ASSERT
                        Assert.Fail();
                    }
                    catch (ApplicationException lApplicationException)
                    {
                        Assert.IsNotNull(lApplicationException);
                    }
                    catch (Exception lException)
                    {
                        Assert.Fail("Exception is not the right kind of exception.\n{0}", lException);
                    }

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
