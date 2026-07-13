using System;
using System.Collections.Generic;
using System.Linq;
using LoanManagerApp.Domain;

namespace LoanManagerApp.Services
{
    public sealed class RepaymentCalculator
    {
        private sealed class ScheduleDate
        {
            public int Number { get; set; }
            public DateTime TargetMonth { get; set; }
            public DateTime BaseDueDate { get; set; }
            public DateTime PaymentDate { get; set; }
        }

        public IList<RepaymentScheduleItem> Calculate(Loan loan)
        {
            return Calculate(loan, 600);
        }

        public IList<RepaymentScheduleItem> Calculate(Loan loan, int maximumRepaymentMonths)
        {
            ValidateLoan(loan, maximumRepaymentMonths);

            if (loan.RepaymentType == RepaymentType.LumpSum)
            {
                loan.RepaymentSettingMode = RepaymentSettingMode.ByPeriod;
                loan.UseBonusPayment = false;
                return CalculateLumpSum(loan);
            }

            if (loan.RepaymentSettingMode == RepaymentSettingMode.ByMonthlyPayment)
            {
                loan.RepaymentMonths = ResolveRepaymentMonthsByAmount(
                    loan,
                    maximumRepaymentMonths);
            }

            List<ScheduleDate> dates = CreateScheduleDates(loan);
            if (loan.UseBonusPayment)
            {
                return CalculateWithBonus(loan, dates);
            }

            switch (loan.RepaymentType)
            {
                case RepaymentType.EqualPrincipal:
                    return CalculateEqualPrincipal(loan, dates, loan.PrincipalAmount);
                default:
                    return CalculateEqualPayment(loan, dates, loan.PrincipalAmount);
            }
        }

        private static void ValidateLoan(Loan loan, int maximumRepaymentMonths)
        {
            if (loan == null)
            {
                throw new ArgumentNullException("loan");
            }

            if (loan.PrincipalAmount <= 0)
            {
                throw new ArgumentException("借入額は1円以上である必要があります。");
            }

            if (maximumRepaymentMonths <= 0)
            {
                throw new ArgumentException("返済期間の上限は1か月以上である必要があります。");
            }

            if (loan.RepaymentType == RepaymentType.LumpSum ||
                loan.RepaymentSettingMode == RepaymentSettingMode.ByPeriod)
            {
                if (loan.RepaymentMonths <= 0 || loan.RepaymentMonths > maximumRepaymentMonths)
                {
                    throw new ArgumentException(
                        "返済期間は1～" + maximumRepaymentMonths + "か月で指定してください。");
                }
            }
            else if (loan.DesiredMonthlyPaymentAmount <= 0)
            {
                throw new ArgumentException("毎月の金額は1円以上で指定してください。");
            }

            if (loan.FirstRepaymentDate.Date <= loan.BorrowDate.Date)
            {
                throw new ArgumentException("初回返済日は借入日より後の日付を指定してください。");
            }

            if (loan.MonthlyPaymentDay < 1 || loan.MonthlyPaymentDay > 31)
            {
                throw new ArgumentException("毎月の返済日は1日から31日の範囲で指定してください。");
            }

            if (loan.UseBonusPayment)
            {
                if (loan.RepaymentType == RepaymentType.LumpSum)
                {
                    throw new ArgumentException("一括返済ではボーナス払いを使用できません。");
                }

                if (loan.BonusMonth1 == loan.BonusMonth2)
                {
                    throw new ArgumentException("ボーナス払い月は異なる月を指定してください。");
                }

                if (loan.BonusPrincipalAmount <= 0 ||
                    loan.BonusPrincipalAmount >= loan.PrincipalAmount)
                {
                    throw new ArgumentException(
                        "ボーナス払い対象元金は借入額より小さい1円以上の金額を指定してください。");
                }
            }
        }

        private static int ResolveRepaymentMonthsByAmount(
            Loan loan,
            int maximumRepaymentMonths)
        {
            long normalPrincipal = GetNormalPrincipal(loan);
            int months;

            switch (loan.RepaymentType)
            {
                case RepaymentType.EqualPrincipal:
                    months = ResolveEqualPrincipalMonths(
                        loan,
                        normalPrincipal,
                        maximumRepaymentMonths);
                    break;
                default:
                    months = ResolveFixedPaymentMonths(
                        loan,
                        normalPrincipal,
                        maximumRepaymentMonths);
                    break;
            }

            return loan.UseBonusPayment
                ? EnsureBonusMonthExists(loan, months, maximumRepaymentMonths)
                : months;
        }

        private static long GetNormalPrincipal(Loan loan)
        {
            return loan.UseBonusPayment
                ? loan.PrincipalAmount - loan.BonusPrincipalAmount
                : loan.PrincipalAmount;
        }

        private static int ResolveFixedPaymentMonths(
            Loan loan,
            long principal,
            int maximumRepaymentMonths)
        {
            long remaining = principal;
            DateTime previousDate = loan.BorrowDate.Date;

            for (int index = 0; index < maximumRepaymentMonths; index++)
            {
                ScheduleDate date = CreateScheduleDate(loan, index);
                long interest = CalculateInterest(
                    loan,
                    remaining,
                    previousDate,
                    date.PaymentDate,
                    1);

                if (loan.DesiredMonthlyPaymentAmount <= interest)
                {
                    throw new ArgumentException(
                        "毎月のお支払い額が利息以下のため、元金を返済できません。お支払い額を増やしてください。");
                }

                long principalPayment = loan.DesiredMonthlyPaymentAmount - interest;
                if (principalPayment >= remaining)
                {
                    return index + 1;
                }

                remaining -= principalPayment;
                previousDate = date.PaymentDate;
            }

            throw new ArgumentException(
                "指定した毎月の金額では最大返済期間内に完済できません。金額を増やしてください。");
        }

        private static int ResolveEqualPrincipalMonths(
            Loan loan,
            long principal,
            int maximumRepaymentMonths)
        {
            long desiredPrincipal = loan.DesiredMonthlyPaymentAmount;
            if (desiredPrincipal <= 0)
            {
                throw new ArgumentException("毎月の元金返済額は1円以上で指定してください。");
            }

            long monthsLong = (principal + desiredPrincipal - 1L) / desiredPrincipal;
            if (monthsLong < 1L)
            {
                monthsLong = 1L;
            }

            if (monthsLong > maximumRepaymentMonths)
            {
                throw new ArgumentException(
                    "指定した毎月の元金返済額では最大返済期間内に完済できません。金額を増やしてください。");
            }

            return (int)monthsLong;
        }

        private static int EnsureBonusMonthExists(
            Loan loan,
            int repaymentMonths,
            int maximumRepaymentMonths)
        {
            int months = repaymentMonths;
            while (months <= maximumRepaymentMonths)
            {
                for (int index = 0; index < months; index++)
                {
                    int month = CreateScheduleDate(loan, index).TargetMonth.Month;
                    if (month == loan.BonusMonth1 || month == loan.BonusMonth2)
                    {
                        return months;
                    }
                }

                months++;
            }

            throw new ArgumentException("最大返済期間内にボーナス払い月を設定できません。");
        }

        private static ScheduleDate CreateScheduleDate(Loan loan, int index)
        {
            DateTime firstTargetMonth = DateHelper.FirstDayOfMonth(loan.FirstRepaymentDate);
            DateTime targetMonth = firstTargetMonth.AddMonths(index);
            DateTime baseDueDate = index == 0
                ? loan.FirstRepaymentDate.Date
                : DateHelper.CreateDueDate(targetMonth, loan.MonthlyPaymentDay);

            return new ScheduleDate
            {
                Number = index + 1,
                TargetMonth = targetMonth,
                BaseDueDate = baseDueDate,
                PaymentDate = DateHelper.MoveToPreviousWeekday(baseDueDate)
            };
        }

        private static List<ScheduleDate> CreateScheduleDates(Loan loan)
        {
            List<ScheduleDate> result = new List<ScheduleDate>();
            for (int i = 0; i < loan.RepaymentMonths; i++)
            {
                result.Add(CreateScheduleDate(loan, i));
            }

            return result;
        }

        private static IList<RepaymentScheduleItem> CalculateEqualPayment(
            Loan loan,
            IList<ScheduleDate> dates,
            long principalAmount)
        {
            List<RepaymentScheduleItem> result = new List<RepaymentScheduleItem>();
            long remaining = principalAmount;
            long regularPayment = loan.RepaymentSettingMode ==
                                  RepaymentSettingMode.ByMonthlyPayment
                ? loan.DesiredMonthlyPaymentAmount
                : CalculateRegularEqualPayment(loan, principalAmount, dates);
            DateTime previousDate = loan.BorrowDate.Date;

            for (int i = 0; i < dates.Count; i++)
            {
                ScheduleDate date = dates[i];
                long interest = CalculateInterest(
                    loan,
                    remaining,
                    previousDate,
                    date.PaymentDate,
                    1);
                long principal;
                long repayment;

                if (remaining <= 0)
                {
                    principal = 0;
                    interest = 0;
                    repayment = 0;
                }
                else if (i == dates.Count - 1)
                {
                    principal = remaining;
                    repayment = checked(principal + interest);
                }
                else
                {
                    repayment = regularPayment;
                    principal = repayment - interest;
                    if (principal <= 0)
                    {
                        principal = 1;
                        repayment = checked(interest + principal);
                    }

                    if (principal > remaining)
                    {
                        principal = remaining;
                        repayment = checked(principal + interest);
                    }
                }

                remaining -= principal;
                result.Add(CreateItem(
                    date,
                    principal,
                    repayment,
                    interest,
                    remaining));
                previousDate = date.PaymentDate;
            }

            return result;
        }

        private static IList<RepaymentScheduleItem> CalculateEqualPrincipal(
            Loan loan,
            IList<ScheduleDate> dates,
            long principalAmount)
        {
            List<RepaymentScheduleItem> result = new List<RepaymentScheduleItem>();
            long remaining = principalAmount;
            long regularPrincipal = loan.RepaymentSettingMode ==
                                    RepaymentSettingMode.ByMonthlyPayment
                ? loan.DesiredMonthlyPaymentAmount
                : RoundingHelper.RoundToYen(
                    (decimal)principalAmount / loan.RepaymentMonths);
            if (principalAmount > 0 && regularPrincipal < 1)
            {
                regularPrincipal = 1;
            }

            DateTime previousDate = loan.BorrowDate.Date;
            for (int i = 0; i < dates.Count; i++)
            {
                ScheduleDate date = dates[i];
                long interest = CalculateInterest(
                    loan,
                    remaining,
                    previousDate,
                    date.PaymentDate,
                    1);
                long principal = remaining <= 0
                    ? 0
                    : (i == dates.Count - 1
                        ? remaining
                        : Math.Min(regularPrincipal, remaining));
                long repayment = checked(principal + interest);
                remaining -= principal;

                result.Add(CreateItem(
                    date,
                    principal,
                    repayment,
                    interest,
                    remaining));
                previousDate = date.PaymentDate;
            }

            return result;
        }

        private static IList<RepaymentScheduleItem> CalculateLumpSum(Loan loan)
        {
            DateTime targetMonth = DateHelper.FirstDayOfMonth(loan.FirstRepaymentDate);
            DateTime baseDueDate = loan.FirstRepaymentDate.Date;
            DateTime paymentDate = DateHelper.MoveToPreviousWeekday(baseDueDate);
            long interest;

            if (loan.InterestCalculationMethod == InterestCalculationMethod.Monthly)
            {
                decimal rawInterest = loan.PrincipalAmount *
                                      (loan.AnnualInterestRate / 100m / 12m) *
                                      loan.RepaymentMonths;
                interest = RoundingHelper.RoundToYen(rawInterest);
            }
            else
            {
                interest = CalculateDailyInterest(
                    loan.PrincipalAmount,
                    loan.AnnualInterestRate,
                    loan.BorrowDate.Date,
                    paymentDate);
            }

            long payment = checked(loan.PrincipalAmount + interest);
            return new List<RepaymentScheduleItem>
            {
                new RepaymentScheduleItem
                {
                    PaymentNumber = 1,
                    TargetMonth = targetMonth,
                    BaseDueDate = baseDueDate,
                    PaymentDate = paymentDate,
                    RepaymentAmount = loan.PrincipalAmount,
                    PaymentAmount = payment,
                    PrincipalAmount = loan.PrincipalAmount,
                    InterestAmount = interest,
                    RemainingBalance = 0
                }
            };
        }

        private static IList<RepaymentScheduleItem> CalculateWithBonus(
            Loan loan,
            IList<ScheduleDate> dates)
        {
            List<int> bonusIndexes = dates
                .Select((value, index) => new { value, index })
                .Where(x => x.value.TargetMonth.Month == loan.BonusMonth1 ||
                            x.value.TargetMonth.Month == loan.BonusMonth2)
                .Select(x => x.index)
                .ToList();

            if (bonusIndexes.Count == 0)
            {
                throw new ArgumentException("返済期間内にボーナス払い月がありません。");
            }

            long normalPrincipalAmount = loan.PrincipalAmount - loan.BonusPrincipalAmount;
            long normalRemaining = normalPrincipalAmount;
            long bonusRemaining = loan.BonusPrincipalAmount;

            long normalRegularPayment = 0;
            long normalRegularPrincipal = 0;
            if (loan.RepaymentType == RepaymentType.EqualPrincipal)
            {
                normalRegularPrincipal = loan.RepaymentSettingMode ==
                                         RepaymentSettingMode.ByMonthlyPayment
                    ? loan.DesiredMonthlyPaymentAmount
                    : RoundingHelper.RoundToYen(
                        (decimal)normalPrincipalAmount / dates.Count);
                if (normalPrincipalAmount > 0 && normalRegularPrincipal < 1)
                {
                    normalRegularPrincipal = 1;
                }
            }
            else
            {
                normalRegularPayment = loan.RepaymentSettingMode ==
                                       RepaymentSettingMode.ByMonthlyPayment
                    ? loan.DesiredMonthlyPaymentAmount
                    : CalculateRegularEqualPayment(
                        loan,
                        normalPrincipalAmount,
                        dates);
            }

            long bonusRegularPrincipal = RoundingHelper.RoundToYen(
                (decimal)loan.BonusPrincipalAmount / bonusIndexes.Count);
            if (bonusRegularPrincipal < 1)
            {
                bonusRegularPrincipal = 1;
            }

            List<RepaymentScheduleItem> result = new List<RepaymentScheduleItem>();
            DateTime previousDate = loan.BorrowDate.Date;
            decimal accruedBonusInterestRaw = 0m;

            for (int i = 0; i < dates.Count; i++)
            {
                ScheduleDate date = dates[i];
                long normalInterest = CalculateInterest(
                    loan,
                    normalRemaining,
                    previousDate,
                    date.PaymentDate,
                    1);
                decimal bonusInterestRaw = CalculateInterestRaw(
                    loan,
                    bonusRemaining,
                    previousDate,
                    date.PaymentDate,
                    1);
                accruedBonusInterestRaw += bonusInterestRaw;

                long normalPrincipal;
                long normalRepayment;
                if (normalRemaining <= 0)
                {
                    normalPrincipal = 0;
                    normalInterest = 0;
                    normalRepayment = 0;
                }
                else if (loan.RepaymentType == RepaymentType.EqualPrincipal)
                {
                    normalPrincipal = i == dates.Count - 1
                        ? normalRemaining
                        : Math.Min(normalRegularPrincipal, normalRemaining);
                    normalRepayment = checked(normalPrincipal + normalInterest);
                }
                else if (i == dates.Count - 1)
                {
                    normalPrincipal = normalRemaining;
                    normalRepayment = checked(normalPrincipal + normalInterest);
                }
                else
                {
                    normalRepayment = normalRegularPayment;
                    normalPrincipal = normalRepayment - normalInterest;
                    if (normalPrincipal <= 0)
                    {
                        normalPrincipal = 1;
                        normalRepayment = checked(normalInterest + normalPrincipal);
                    }

                    if (normalPrincipal > normalRemaining)
                    {
                        normalPrincipal = normalRemaining;
                        normalRepayment = checked(normalPrincipal + normalInterest);
                    }
                }

                bool isBonusMonth = bonusIndexes.Contains(i);
                long bonusPrincipal = 0;
                long bonusInterest = 0;
                long bonusPayment = 0;

                if (isBonusMonth)
                {
                    bool isLastBonus = i == bonusIndexes[bonusIndexes.Count - 1];
                    bonusPrincipal = isLastBonus
                        ? bonusRemaining
                        : Math.Min(bonusRegularPrincipal, bonusRemaining);
                    bonusInterest = RoundingHelper.RoundToYen(accruedBonusInterestRaw);
                    bonusPayment = checked(bonusPrincipal + bonusInterest);
                    accruedBonusInterestRaw = 0m;
                }

                normalRemaining -= normalPrincipal;
                bonusRemaining -= bonusPrincipal;

                long totalPrincipal = checked(normalPrincipal + bonusPrincipal);
                long totalInterest = checked(normalInterest + bonusInterest);
                long paymentAmount = checked(normalRepayment + bonusPayment);
                long totalRemaining = checked(normalRemaining + bonusRemaining);

                result.Add(CreateItem(
                    date,
                    totalPrincipal,
                    paymentAmount,
                    totalInterest,
                    totalRemaining));
                previousDate = date.PaymentDate;
            }

            return result;
        }

        private static long CalculateRegularEqualPayment(
            Loan loan,
            long principal,
            IList<ScheduleDate> dates)
        {
            long payment = CalculateEqualMonthlyPayment(
                principal,
                loan.AnnualInterestRate,
                dates.Count);

            if (dates.Count <= 1 || principal <= 0)
            {
                return payment;
            }

            long maximumInterest = 0;
            DateTime previousDate = loan.BorrowDate.Date;
            foreach (ScheduleDate date in dates)
            {
                long interest = CalculateInterest(
                    loan,
                    principal,
                    previousDate,
                    date.PaymentDate,
                    1);
                if (interest > maximumInterest)
                {
                    maximumInterest = interest;
                }
                previousDate = date.PaymentDate;
            }

            if (payment <= maximumInterest)
            {
                payment = checked(maximumInterest + 1);
            }

            return payment;
        }

        private static long CalculateEqualMonthlyPayment(
            long principal,
            decimal annualRate,
            int months)
        {
            if (principal <= 0)
            {
                return 0;
            }

            if (annualRate == 0m)
            {
                return RoundingHelper.RoundToYen((decimal)principal / months);
            }

            double monthlyRate = (double)(annualRate / 100m / 12m);
            double factor = Math.Pow(1d + monthlyRate, months);
            decimal rawPayment = (decimal)(
                (double)principal * monthlyRate * factor / (factor - 1d));
            long payment = RoundingHelper.RoundToYen(rawPayment);
            return Math.Max(1L, payment);
        }

        private static long CalculateInterest(
            Loan loan,
            long remainingBalance,
            DateTime previousDate,
            DateTime paymentDate,
            int monthlyPeriods)
        {
            decimal raw = CalculateInterestRaw(
                loan,
                remainingBalance,
                previousDate,
                paymentDate,
                monthlyPeriods);
            return RoundingHelper.RoundToYen(raw);
        }

        private static decimal CalculateInterestRaw(
            Loan loan,
            long remainingBalance,
            DateTime previousDate,
            DateTime paymentDate,
            int monthlyPeriods)
        {
            if (remainingBalance <= 0 || loan.AnnualInterestRate == 0m)
            {
                return 0m;
            }

            if (loan.InterestCalculationMethod == InterestCalculationMethod.Monthly)
            {
                return remainingBalance *
                       (loan.AnnualInterestRate / 100m / 12m) *
                       monthlyPeriods;
            }

            return CalculateDailyInterestRaw(
                remainingBalance,
                loan.AnnualInterestRate,
                previousDate,
                paymentDate);
        }

        private static long CalculateDailyInterest(
            long remainingBalance,
            decimal annualRate,
            DateTime fromDate,
            DateTime toDate)
        {
            decimal raw = CalculateDailyInterestRaw(
                remainingBalance,
                annualRate,
                fromDate,
                toDate);
            return RoundingHelper.RoundToYen(raw);
        }

        private static decimal CalculateDailyInterestRaw(
            long remainingBalance,
            decimal annualRate,
            DateTime fromDate,
            DateTime toDate)
        {
            DateTime current = fromDate.Date;
            DateTime end = toDate.Date;
            if (end <= current)
            {
                return 0m;
            }

            decimal total = 0m;
            while (current < end)
            {
                DateTime nextYear = new DateTime(current.Year + 1, 1, 1);
                DateTime segmentEnd = end < nextYear ? end : nextYear;
                int days = (segmentEnd - current).Days;
                int daysInYear = DateTime.IsLeapYear(current.Year) ? 366 : 365;
                total += remainingBalance *
                         (annualRate / 100m) *
                         days / daysInYear;
                current = segmentEnd;
            }

            return total;
        }

        private static RepaymentScheduleItem CreateItem(
            ScheduleDate date,
            long repaymentAmount,
            long paymentAmount,
            long interest,
            long remaining)
        {
            return new RepaymentScheduleItem
            {
                PaymentNumber = date.Number,
                TargetMonth = date.TargetMonth,
                BaseDueDate = date.BaseDueDate,
                PaymentDate = date.PaymentDate,
                RepaymentAmount = repaymentAmount,
                PaymentAmount = paymentAmount,
                PrincipalAmount = repaymentAmount,
                InterestAmount = interest,
                RemainingBalance = remaining
            };
        }
    }
}
