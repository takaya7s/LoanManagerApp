using LoanManagerApp.Domain;

namespace LoanManagerApp.Services
{
    internal static class DisplayText
    {
        public static string RepaymentType(RepaymentType value)
        {
            switch (value)
            {
                case LoanManagerApp.Domain.RepaymentType.EqualPrincipal:
                    return "元金均等返済（元金が一定でお支払い額は徐々に減少）";
                case LoanManagerApp.Domain.RepaymentType.LumpSum:
                    return "一括返済（期日に元金と利息をまとめて支払い）";
                default:
                    return "元利均等返済（元金と利息を含むお支払い額が原則一定）";
            }
        }

        public static string RepaymentTypeShort(RepaymentType value)
        {
            switch (value)
            {
                case LoanManagerApp.Domain.RepaymentType.EqualPrincipal:
                    return "元金均等返済";
                case LoanManagerApp.Domain.RepaymentType.LumpSum:
                    return "一括返済";
                default:
                    return "元利均等返済";
            }
        }

        public static string InterestMethod(InterestCalculationMethod value)
        {
            return value == InterestCalculationMethod.Daily ? "日割り計算" : "月割り計算";
        }

        public static string RepaymentSetting(RepaymentSettingMode value)
        {
            return value == LoanManagerApp.Domain.RepaymentSettingMode.ByMonthlyPayment
                ? "毎月の金額で設定"
                : "返済期間で設定";
        }

        public static string BonusPayment(BonusPaymentFrequency value)
        {
            switch (value)
            {
                case BonusPaymentFrequency.OncePerYear:
                    return "年1回";
                case BonusPaymentFrequency.TwicePerYear:
                    return "年2回";
                default:
                    return "なし";
            }
        }
    }
}
