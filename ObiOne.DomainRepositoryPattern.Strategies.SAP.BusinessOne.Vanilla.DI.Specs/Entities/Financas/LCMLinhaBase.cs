using System;
using ObiOne.DomainRepositoryPattern.Specialized.DI.Model;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Infrastructure;
using SAPbobsCOM;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.Financas
{
    public class LCMLinhaBase : VanillaDIEntity<int>
    {
        public LCMLinhaBase(){
        }

        public LCMLinhaBase(EnAccountType aAccountType, string aAccount, EnAmountType aAmountType, decimal aAmount, DateTime aDueDate) : this()
        {
            AccountType = aAccountType;
            Account = aAccount;
            AmountType = aAmountType;
            Amount = aAmount;
            DueDate = aDueDate;
            TaxDate = DateTime.Now.Date;
            RefDate = DateTime.Now.Date;
        }

        public LCMLinhaBase(string aAccount, decimal aAmount) : this(EnAccountType.GLAccount, aAccount, EnAmountType.Debit, aAmount, DateTime.Now.Date)
        {
        }

        public DateTime DueDate { get; set; }
        public DateTime TaxDate { get; set; }
        public DateTime RefDate { get; set; }
        public EnAccountType AccountType { get; set; }
        public string Account { get; set; }
        public EnAmountType AmountType { get; set; }
        public decimal Amount { get; set; }



        #region Overrides of DIEntity<int>

        public override DIEntity<int> FromPersistable(dynamic aBusinessObject){
            JournalEntries_Lines lBusinessObject = aBusinessObject;

            //
            DueDate = lBusinessObject.DueDate;
            TaxDate = lBusinessObject.TaxDate;
            RefDate = lBusinessObject.ReferenceDate1;

            if (!string.IsNullOrWhiteSpace(lBusinessObject.ShortName)){
                AccountType = EnAccountType.BusinessPartner;
                Account = lBusinessObject.ShortName;
            } else{
                AccountType = EnAccountType.GLAccount;
                Account = lBusinessObject.AccountCode;
            }

            if (lBusinessObject.Debit > 0){
                AmountType = EnAmountType.Debit;
                Amount = new decimal(lBusinessObject.Debit);
            } else{
                AmountType = EnAmountType.Credit;
                Amount = new decimal(lBusinessObject.Credit);
            }

            return this;
        }

        public override dynamic ToPersistable(dynamic aBusinessObject){
            JournalEntries_Lines lBusinessObject = aBusinessObject;

            //
            lBusinessObject.DueDate = DueDate;
            lBusinessObject.TaxDate = TaxDate;
            lBusinessObject.ReferenceDate1 = RefDate;

            switch (AccountType){
                case EnAccountType.BusinessPartner:
                    lBusinessObject.ShortName = Account;
                    break;
                case EnAccountType.GLAccount:
                    lBusinessObject.AccountCode = Account;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (AmountType){
                case EnAmountType.Debit:
                    lBusinessObject.Debit = (double) Amount;
                    break;
                case EnAmountType.Credit:
                    lBusinessObject.Credit = (double) Amount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return lBusinessObject;
        }

        #endregion
    }
}
