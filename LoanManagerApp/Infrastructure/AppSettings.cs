using System.Runtime.Serialization;

namespace LoanManagerApp.Infrastructure
{
    [DataContract]
    public sealed class AppSettings
    {
        [DataMember(Name = "interestRateDecimalPlaces", Order = 1)]
        public int InterestRateDecimalPlaces { get; set; }

        [DataMember(Name = "minimumLoanAmount", Order = 2)]
        public long MinimumLoanAmount { get; set; }

        [DataMember(Name = "maximumLoanAmount", Order = 3)]
        public long MaximumLoanAmount { get; set; }

        [DataMember(Name = "minimumRepaymentMonths", Order = 4)]
        public int MinimumRepaymentMonths { get; set; }

        [DataMember(Name = "maximumRepaymentMonths", Order = 5)]
        public int MaximumRepaymentMonths { get; set; }

        [DataMember(Name = "minimumInterestRate", Order = 6)]
        public decimal MinimumInterestRate { get; set; }

        [DataMember(Name = "maximumInterestRate", Order = 7)]
        public decimal MaximumInterestRate { get; set; }

        public static AppSettings CreateDefault()
        {
            return new AppSettings
            {
                InterestRateDecimalPlaces = 2,
                MinimumLoanAmount = 1000L,
                MaximumLoanAmount = 1000000000L,
                MinimumRepaymentMonths = 1,
                MaximumRepaymentMonths = 600,
                MinimumInterestRate = 0.00m,
                MaximumInterestRate = 99.99m
            };
        }

        public void ValidateAndRepair()
        {
            if (InterestRateDecimalPlaces < 0 || InterestRateDecimalPlaces > 6)
            {
                InterestRateDecimalPlaces = 2;
            }

            if (MinimumLoanAmount < 1)
            {
                MinimumLoanAmount = 1000L;
            }

            if (MaximumLoanAmount < MinimumLoanAmount)
            {
                MaximumLoanAmount = 1000000000L;
            }

            if (MinimumRepaymentMonths < 1)
            {
                MinimumRepaymentMonths = 1;
            }

            if (MaximumRepaymentMonths < MinimumRepaymentMonths)
            {
                MaximumRepaymentMonths = 600;
            }

            if (MinimumInterestRate < 0m)
            {
                MinimumInterestRate = 0m;
            }

            if (MaximumInterestRate < MinimumInterestRate)
            {
                MaximumInterestRate = 99.99m;
            }
        }
    }
}
