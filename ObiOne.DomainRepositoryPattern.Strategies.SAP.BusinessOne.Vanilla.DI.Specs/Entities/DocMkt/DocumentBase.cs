using System;
using System.Collections.Generic;
using ObiOne.DomainRepositoryPattern.Specialized.DI.Model;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Infrastructure;
using SAPbobsCOM;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.DocMkt
{
    public abstract class DocumentBase<TDocumentLine> : VanillaDIEntity<int> where TDocumentLine : DocumentLinesBase
    {
        private DateTime mDataEmissao;
        private DateTime mDataEntrega;
        private decimal? mTotal;

        /// <summary>
        /// Initializes a new instance of the <see cref="SAP.BusinessOne.DataAccess.Vanilla.Specs.Entities.DocMkt"/> class.
        /// </summary>
        protected DocumentBase(){
            Series = 0; // MANUAL
            NumeroRefExterno = string.Empty;
            DataEmissao = DateTime.Now;
            DataEntrega = DateTime.Now;
            DocumentLineList = new List<TDocumentLine>();
        }

        protected DocumentBase(int aSeries, string aParceiroNegocioCodigoSAP, DateTime aDataEntrega, List<TDocumentLine> aDocumentLineList) : this(){
            Series = aSeries;
            ParceiroNegocioCodigoSAP = aParceiroNegocioCodigoSAP;
            DataEntrega = aDataEntrega;
            DocumentLineList = aDocumentLineList;
        }

        public int Series { get; set; }
        public string ParceiroNegocioCodigoSAP { get; set; }
        public DateTime DataEmissao { get { return mDataEmissao; } set { mDataEmissao = value.Date; } }

        public DateTime DataEntrega { get { return mDataEntrega; } set { mDataEntrega = value.Date; } }

        public string NumeroRefExterno { get; set; }

        public decimal? Total
        {
            get { return mTotal; }
            set
            {
                mTotal = value.HasValue
                             ? (decimal?) Math.Round(value.Value, 2)
                             : null;
            }
        }

        public string Observacao { get; set; }
        public string ObservacaoFinal { get; set; }

        public List<TDocumentLine> DocumentLineList { get; set; }

        public override DIEntity<int> FromPersistable(dynamic aBusinessObject){
            var lDocuments = (Documents)aBusinessObject;

            Id = lDocuments.DocEntry;
            Series = lDocuments.Series;
            ParceiroNegocioCodigoSAP = lDocuments.CardCode;
            DataEntrega = lDocuments.DocDueDate;
            NumeroRefExterno = lDocuments.NumAtCard;
            Total = (decimal?) lDocuments.DocTotal;
            DataEmissao = lDocuments.DocDate;
            Observacao = lDocuments.Comments;
            ObservacaoFinal = lDocuments.ClosingRemarks;

            var lDocumentLine = lDocuments.Lines;
            DocumentLineList.FromPersistable<TDocumentLine, int>(lDocumentLine, aLine => aLine.Id == lDocumentLine.LineNum);

            return this;
        }

        public override dynamic ToPersistable(dynamic aBusinessObject){
            var lDocuments = (Documents)aBusinessObject;

            //lDocuments.DocEntry = Id;
            lDocuments.Series = Series;
            lDocuments.CardCode = ParceiroNegocioCodigoSAP;
            lDocuments.DocDueDate = DataEntrega;
            lDocuments.NumAtCard = NumeroRefExterno;
            if (Total.HasValue){
                lDocuments.DocTotal = (double) Total.Value;
            }
            lDocuments.DocDate = DataEmissao;
            lDocuments.Comments = Observacao;
            lDocuments.ClosingRemarks = ObservacaoFinal;

            var lLineIndex = 0;
            foreach (var lItem in DocumentLineList)
            {
                lDocuments.Lines.SetCurrentLine(lLineIndex++);
                lItem.ToPersistable(lDocuments.Lines);
                lDocuments.Lines.Add();
            }

            return lDocuments;
        }
    }
}
