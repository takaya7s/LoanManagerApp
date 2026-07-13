using System;

namespace LoanManagerApp.Domain
{
    public sealed class RepaymentScheduleItem
    {
        public long Id { get; set; }
        public long LoanId { get; set; }
        public int PaymentNumber { get; set; }
        public DateTime TargetMonth { get; set; }
        public DateTime BaseDueDate { get; set; }
        public DateTime PaymentDate { get; set; }

        // その回に返済する元金。ボーナス月は通常分とボーナス分の元金合計。
        public long RepaymentAmount { get; set; }

        // 実際に支払う合計額。返済額（元金）と利息の合計。
        public long PaymentAmount { get; set; }

        // 内部保存用。RepaymentAmount と同じ元金額を保持します。
        public long PrincipalAmount { get; set; }
        public long InterestAmount { get; set; }
        public long RemainingBalance { get; set; }
        public bool IsPaymentFailed { get; set; }
        public DateTime? FailureRegisteredAt { get; set; }
        public string FailureNote { get; set; }
        public DateTime? ResolvedAt { get; set; }

        public RepaymentScheduleItem()
        {
            FailureNote = string.Empty;
        }
    }
}
