using System;

namespace LoanManagerApp.Domain
{
    public sealed class LoanListItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string RepaymentTypeName { get; set; }
        public string BonusPaymentName { get; set; }
        public long PrincipalAmount { get; set; }
        public decimal AnnualInterestRate { get; set; }
        public DateTime? NextPaymentDate { get; set; }
        public long NextPaymentAmount { get; set; }
        public long RemainingBalance { get; set; }
        public long TotalPaymentAmount { get; set; }
        public int RemainingPaymentCount { get; set; }
    }
}
