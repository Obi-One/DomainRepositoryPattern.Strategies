using ObiOne.DomainRepositoryPattern.Specialized.DI.Model;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Infrastructure;
using SAPbobsCOM;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.DocMkt{
    public abstract class DocumentLinesBase : VanillaDIEntity<int>{
        protected DocumentLinesBase(){
        }

        protected DocumentLinesBase(string aItemInventarioCodigoSAP, double aQuantidade, double aPrecoUnitario, double aDescontoPercentual, string aObservacao) : this(){
            ItemInventarioCodigoSAP = aItemInventarioCodigoSAP;
            Quantidade = aQuantidade;
            PrecoUnitario = (decimal?) aPrecoUnitario;
            DescontoPercentual = (decimal?) aDescontoPercentual;
            Observacao = aObservacao;
        }

        public string ItemInventarioCodigoSAP { get; set; }
        public double Quantidade { get; set; }

        public decimal? PrecoUnitario { get; set; }

        public decimal? DescontoPercentual { get; set; }

        public string Utilizacao { get; set; }
        public string Observacao { get; set; }

        public override DIEntity<int> FromPersistable(dynamic aBusinessObject){
            var lDocumentLine = (Document_Lines) aBusinessObject;

            //Id = lDocumentLine.LineNum;
            ItemInventarioCodigoSAP = lDocumentLine.ItemCode;
            Quantidade = lDocumentLine.Quantity;
            PrecoUnitario = (decimal?) lDocumentLine.UnitPrice;
            DescontoPercentual = (decimal?) lDocumentLine.DiscountPercent;
            Utilizacao = lDocumentLine.Usage;
            Observacao = lDocumentLine.FreeText;

            return this;
        }

        public override dynamic ToPersistable(dynamic aBusinessObject){
            var lDocumentLine = (Document_Lines) aBusinessObject;

            lDocumentLine.ItemCode = ItemInventarioCodigoSAP;
            lDocumentLine.Quantity = Quantidade;
            if (PrecoUnitario.HasValue){
                lDocumentLine.UnitPrice = (double) PrecoUnitario.Value;
            }
            if (DescontoPercentual.HasValue){
                lDocumentLine.DiscountPercent = (double) DescontoPercentual.Value;
            }
            lDocumentLine.Usage = Utilizacao;
            lDocumentLine.FreeText = Observacao;

            return lDocumentLine;
        }
    }
}
