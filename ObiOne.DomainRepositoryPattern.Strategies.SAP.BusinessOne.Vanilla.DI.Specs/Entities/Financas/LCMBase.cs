using System;
using System.Collections.Generic;
using ObiOne.DomainRepositoryPattern.Specialized.DI.Model;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Infrastructure;
using SAPbobsCOM;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.Financas
{
    public class LCMBase : VanillaDIEntity<int>
    {
        public LCMBase(){
            Series = 1; // MANUAL
            DueDate = DateTime.Now.Date;
            TaxDate = DateTime.Now.Date;
            RefDate = DateTime.Now.Date;
            LCMLinhaList = new List<LCMLinhaBase>();
        }

        public LCMBase(int aSeries, DateTime aDueDate, List<LCMLinhaBase> aLCMLinhaList) : this()
        {
            Series = aSeries;
            DueDate = aDueDate;
            LCMLinhaList = aLCMLinhaList;
        }

        public int Series { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime TaxDate { get; set; }
        public DateTime RefDate { get; set; }
        public List<LCMLinhaBase> LCMLinhaList { get; set; }

        #region Overrides of DIEntity<string>

        public override DIEntity<int> FromPersistable(dynamic aBusinessObject){
            JournalEntries lBusinessObject = aBusinessObject;

            // MASTER
            Id = lBusinessObject.JdtNum;
            Series = lBusinessObject.Series;
            DueDate = lBusinessObject.DueDate;
            TaxDate = lBusinessObject.TaxDate;
            RefDate = lBusinessObject.ReferenceDate;

            // LINHAS
            for (var lLineIndex = 0; lLineIndex < lBusinessObject.Lines.Count; lLineIndex++){
                lBusinessObject.SetCurrentLine(lLineIndex);
                LCMLinhaList.Add((LCMLinhaBase) new LCMLinhaBase().FromPersistable(lBusinessObject.Lines));
            }

            return this;
        }

        public override dynamic ToPersistable(dynamic aBusinessObject){
            JournalEntries lBusinessObject = aBusinessObject;

            // MASTER
            //lBusinessObject.JdtNum = Id;
            lBusinessObject.Series = Series;
            lBusinessObject.DueDate = DueDate;
            lBusinessObject.TaxDate = TaxDate;
            lBusinessObject.ReferenceDate = RefDate;

            // LINHAS
            var lLineIndex = 0;
            foreach (var lItem in LCMLinhaList)
            {
                lBusinessObject.Lines.SetCurrentLine(lLineIndex++);
                lItem.ToPersistable(lBusinessObject.Lines);
                lBusinessObject.Lines.Add();
            }

            return lBusinessObject;
        }

        #endregion
    }
}
