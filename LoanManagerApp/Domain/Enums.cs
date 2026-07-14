namespace LoanManagerApp.Domain
{
    public enum RepaymentType
    {
        EqualPayment = 0,
        EqualPrincipal = 1,
        LumpSum = 2
    }

    public enum InterestCalculationMethod
    {
        Monthly = 0,
        Daily = 1
    }

    public enum RepaymentSettingMode
    {
        ByPeriod = 0,
        ByMonthlyPayment = 1
    }

    public enum BonusPaymentFrequency
    {
        None = 0,
        OncePerYear = 1,
        TwicePerYear = 2
    }
}
