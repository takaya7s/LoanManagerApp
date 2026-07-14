using System;

namespace LoanManagerApp.Domain
{
    public sealed class Loan
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long PrincipalAmount { get; set; }
        public decimal AnnualInterestRate { get; set; }
        public RepaymentType RepaymentType { get; set; }
        public InterestCalculationMethod InterestCalculationMethod { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime FirstRepaymentDate { get; set; }
        public RepaymentSettingMode RepaymentSettingMode { get; set; }
        public int RepaymentMonths { get; set; }
        // 元利均等では毎月のお支払い額、元金均等では毎月の元金返済額。
        public long DesiredMonthlyPaymentAmount { get; set; }
        public int MonthlyPaymentDay { get; set; }
        public BonusPaymentFrequency BonusPaymentFrequency { get; set; }
        public bool UseBonusPayment
        {
            get { return BonusPaymentFrequency != global::LoanManagerApp.Domain.BonusPaymentFrequency.None; }
        }
        // 指定したボーナス月ごとに通常返済へ上乗せする元金額。
        public long BonusPrincipalAmount { get; set; }
        public int BonusMonth1 { get; set; }
        public int BonusMonth2 { get; set; }
        public string Memo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Loan()
        {
            Name = string.Empty;
            Memo = string.Empty;
        }
    }
}
