using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using LoanManagerApp.Domain;
using LoanManagerApp.Services;

namespace LoanManagerApp.Infrastructure
{
    public sealed class LoanRepository
    {
        private readonly string _connectionString;

        public LoanRepository(string databasePath)
        {
            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder
            {
                DataSource = databasePath,
                Version = 3,
                ForeignKeys = true,
                JournalMode = SQLiteJournalModeEnum.Wal,
                SyncMode = SynchronizationModes.Normal
            };
            _connectionString = builder.ToString();
        }

        public void Initialize()
        {
            using (SQLiteConnection connection = OpenConnection())
            {
                CreateSchema(connection, null);
            }
        }

        private static void CreateSchema(
            SQLiteConnection connection,
            SQLiteTransaction transaction)
        {
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText = @"
CREATE TABLE IF NOT EXISTS Loans (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    PrincipalAmount INTEGER NOT NULL,
    AnnualInterestRate TEXT NOT NULL,
    RepaymentType INTEGER NOT NULL,
    InterestCalculationMethod INTEGER NOT NULL,
    BorrowDate TEXT NOT NULL,
    FirstRepaymentDate TEXT NOT NULL,
    RepaymentSettingMode INTEGER NOT NULL,
    RepaymentMonths INTEGER NOT NULL,
    DesiredMonthlyPaymentAmount INTEGER NOT NULL DEFAULT 0,
    MonthlyPaymentDay INTEGER NOT NULL,
    BonusPaymentFrequency INTEGER NOT NULL DEFAULT 0,
    BonusPrincipalAmount INTEGER NOT NULL DEFAULT 0,
    BonusMonth1 INTEGER NOT NULL DEFAULT 6,
    BonusMonth2 INTEGER NOT NULL DEFAULT 12,
    Memo TEXT NOT NULL DEFAULT '',
    CreatedAt TEXT NOT NULL,
    UpdatedAt TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS RepaymentSchedule (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    LoanId INTEGER NOT NULL,
    PaymentNumber INTEGER NOT NULL,
    TargetMonth TEXT NOT NULL,
    BaseDueDate TEXT NOT NULL,
    PaymentDate TEXT NOT NULL,
    RepaymentAmount INTEGER NOT NULL,
    PaymentAmount INTEGER NOT NULL,
    PrincipalAmount INTEGER NOT NULL,
    InterestAmount INTEGER NOT NULL,
    RemainingBalance INTEGER NOT NULL,
    IsPaymentFailed INTEGER NOT NULL DEFAULT 0,
    FailureRegisteredAt TEXT NULL,
    FailureNote TEXT NOT NULL DEFAULT '',
    ResolvedAt TEXT NULL,
    FOREIGN KEY (LoanId) REFERENCES Loans(Id) ON DELETE CASCADE,
    UNIQUE (LoanId, PaymentNumber)
);

CREATE INDEX IF NOT EXISTS IX_RepaymentSchedule_LoanId
    ON RepaymentSchedule(LoanId);
CREATE INDEX IF NOT EXISTS IX_RepaymentSchedule_PaymentDate
    ON RepaymentSchedule(PaymentDate);";
                command.ExecuteNonQuery();
            }
        }

        public IList<LoanListItem> GetLoanListItems(DateTime today)
        {
            List<LoanListItem> items = new List<LoanListItem>();
            IList<Loan> loans = GetLoans();
            foreach (Loan loan in loans)
            {
                IList<RepaymentScheduleItem> schedule = GetSchedule(loan.Id);
                RepaymentScheduleItem next = schedule
                    .Where(x => x.PaymentDate.Date >= today.Date || x.IsPaymentFailed)
                    .OrderBy(x => x.PaymentDate)
                    .ThenBy(x => x.PaymentNumber)
                    .FirstOrDefault();

                long remainingBalance = schedule.Count == 0
                    ? loan.PrincipalAmount
                    : schedule
                        .Where(x => x.PaymentDate.Date < today.Date && !x.IsPaymentFailed)
                        .OrderByDescending(x => x.PaymentNumber)
                        .Select(x => x.RemainingBalance)
                        .FirstOrDefault();

                if (!schedule.Any(x => x.PaymentDate.Date < today.Date && !x.IsPaymentFailed))
                {
                    remainingBalance = loan.PrincipalAmount;
                }

                RepaymentScheduleItem latestFailed = schedule
                    .Where(x => x.IsPaymentFailed)
                    .OrderBy(x => x.PaymentNumber)
                    .FirstOrDefault();
                if (latestFailed != null)
                {
                    remainingBalance = latestFailed.RepaymentAmount + latestFailed.RemainingBalance;
                }

                long totalPayment = schedule.Sum(x => x.PaymentAmount);
                int remainingCount = schedule.Count(x => x.PaymentDate.Date >= today.Date || x.IsPaymentFailed);

                items.Add(new LoanListItem
                {
                    Id = loan.Id,
                    Name = loan.Name,
                    RepaymentTypeName = DisplayText.RepaymentTypeShort(loan.RepaymentType),
                    BonusPaymentName = DisplayText.BonusPayment(loan.BonusPaymentFrequency),
                    PrincipalAmount = loan.PrincipalAmount,
                    AnnualInterestRate = loan.AnnualInterestRate,
                    NextPaymentDate = next == null ? (DateTime?)null : next.PaymentDate,
                    NextPaymentAmount = next == null ? 0 : next.PaymentAmount,
                    RemainingBalance = remainingBalance,
                    RemainingPaymentCount = remainingCount,
                    TotalPaymentAmount = totalPayment
                });
            }

            return items;
        }

        public IList<Loan> GetLoans()
        {
            List<Loan> result = new List<Loan>();
            using (SQLiteConnection connection = OpenConnection())
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Loans ORDER BY BorrowDate ASC, PrincipalAmount DESC, Id ASC;";
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(ReadLoan(reader));
                    }
                }
            }

            return result;
        }

        public Loan GetLoan(long id)
        {
            using (SQLiteConnection connection = OpenConnection())
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Loans WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", id);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return ReadLoan(reader);
                    }
                }
            }

            return null;
        }

        public IList<RepaymentScheduleItem> GetSchedule(long loanId)
        {
            List<RepaymentScheduleItem> result = new List<RepaymentScheduleItem>();
            using (SQLiteConnection connection = OpenConnection())
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText = @"
SELECT *
FROM RepaymentSchedule
WHERE LoanId = @LoanId
ORDER BY PaymentNumber;";
                command.Parameters.AddWithValue("@LoanId", loanId);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(ReadScheduleItem(reader));
                    }
                }
            }

            return result;
        }

        public long SaveLoan(Loan loan, IList<RepaymentScheduleItem> schedule)
        {
            DateTime now = DateTime.Now;
            using (SQLiteConnection connection = OpenConnection())
            using (SQLiteTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    Dictionary<int, FailureState> oldFailures = loan.Id > 0
                        ? LoadFailureStates(connection, transaction, loan.Id)
                        : new Dictionary<int, FailureState>();

                    if (loan.Id == 0)
                    {
                        loan.CreatedAt = now;
                        loan.UpdatedAt = now;
                        InsertLoan(connection, transaction, loan);
                        loan.Id = connection.LastInsertRowId;
                    }
                    else
                    {
                        loan.UpdatedAt = now;
                        UpdateLoan(connection, transaction, loan);
                        DeleteSchedule(connection, transaction, loan.Id);
                    }

                    InsertSchedule(connection, transaction, loan.Id, schedule, oldFailures);
                    transaction.Commit();
                    return loan.Id;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DeleteLoan(long loanId)
        {
            using (SQLiteConnection connection = OpenConnection())
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Loans WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", loanId);
                command.ExecuteNonQuery();
            }
        }

        public void RegisterPaymentFailure(long scheduleId, string note)
        {
            using (SQLiteConnection connection = OpenConnection())
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText = @"
UPDATE RepaymentSchedule
SET IsPaymentFailed = 1,
    FailureRegisteredAt = @FailureRegisteredAt,
    FailureNote = @FailureNote,
    ResolvedAt = NULL
WHERE Id = @Id;";
                command.Parameters.AddWithValue("@FailureRegisteredAt", FormatDateTime(DateTime.Now));
                command.Parameters.AddWithValue("@FailureNote", note ?? string.Empty);
                command.Parameters.AddWithValue("@Id", scheduleId);
                command.ExecuteNonQuery();
            }
        }

        public void ResolvePaymentFailure(long scheduleId)
        {
            using (SQLiteConnection connection = OpenConnection())
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText = @"
UPDATE RepaymentSchedule
SET IsPaymentFailed = 0,
    ResolvedAt = @ResolvedAt
WHERE Id = @Id;";
                command.Parameters.AddWithValue("@ResolvedAt", FormatDateTime(DateTime.Now));
                command.Parameters.AddWithValue("@Id", scheduleId);
                command.ExecuteNonQuery();
            }
        }

        private SQLiteConnection OpenConnection()
        {
            SQLiteConnection connection = new SQLiteConnection(_connectionString);
            connection.Open();
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText = "PRAGMA foreign_keys = ON; PRAGMA busy_timeout = 5000;";
                command.ExecuteNonQuery();
            }
            return connection;
        }

        private static void InsertLoan(
            SQLiteConnection connection,
            SQLiteTransaction transaction,
            Loan loan)
        {
            using (SQLiteCommand command = CreateLoanCommand(connection, transaction, loan))
            {
                command.CommandText = @"
INSERT INTO Loans (
    Name, PrincipalAmount, AnnualInterestRate, RepaymentType,
    InterestCalculationMethod, BorrowDate, FirstRepaymentDate,
    RepaymentSettingMode, RepaymentMonths, DesiredMonthlyPaymentAmount,
    MonthlyPaymentDay, BonusPaymentFrequency, BonusPrincipalAmount,
    BonusMonth1, BonusMonth2, Memo, CreatedAt, UpdatedAt)
VALUES (
    @Name, @PrincipalAmount, @AnnualInterestRate, @RepaymentType,
    @InterestCalculationMethod, @BorrowDate, @FirstRepaymentDate,
    @RepaymentSettingMode, @RepaymentMonths, @DesiredMonthlyPaymentAmount,
    @MonthlyPaymentDay, @BonusPaymentFrequency, @BonusPrincipalAmount,
    @BonusMonth1, @BonusMonth2, @Memo, @CreatedAt, @UpdatedAt);";
                command.ExecuteNonQuery();
            }
        }

        private static void UpdateLoan(
            SQLiteConnection connection,
            SQLiteTransaction transaction,
            Loan loan)
        {
            using (SQLiteCommand command = CreateLoanCommand(connection, transaction, loan))
            {
                command.CommandText = @"
UPDATE Loans SET
    Name = @Name,
    PrincipalAmount = @PrincipalAmount,
    AnnualInterestRate = @AnnualInterestRate,
    RepaymentType = @RepaymentType,
    InterestCalculationMethod = @InterestCalculationMethod,
    BorrowDate = @BorrowDate,
    FirstRepaymentDate = @FirstRepaymentDate,
    RepaymentSettingMode = @RepaymentSettingMode,
    RepaymentMonths = @RepaymentMonths,
    DesiredMonthlyPaymentAmount = @DesiredMonthlyPaymentAmount,
    MonthlyPaymentDay = @MonthlyPaymentDay,
    BonusPaymentFrequency = @BonusPaymentFrequency,
    BonusPrincipalAmount = @BonusPrincipalAmount,
    BonusMonth1 = @BonusMonth1,
    BonusMonth2 = @BonusMonth2,
    Memo = @Memo,
    UpdatedAt = @UpdatedAt
WHERE Id = @Id;";
                command.Parameters.AddWithValue("@Id", loan.Id);
                command.ExecuteNonQuery();
            }
        }

        private static SQLiteCommand CreateLoanCommand(
            SQLiteConnection connection,
            SQLiteTransaction transaction,
            Loan loan)
        {
            SQLiteCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.Parameters.AddWithValue("@Name", loan.Name);
            command.Parameters.AddWithValue("@PrincipalAmount", loan.PrincipalAmount);
            command.Parameters.AddWithValue(
                "@AnnualInterestRate",
                loan.AnnualInterestRate.ToString(CultureInfo.InvariantCulture));
            command.Parameters.AddWithValue("@RepaymentType", (int)loan.RepaymentType);
            command.Parameters.AddWithValue(
                "@InterestCalculationMethod",
                (int)loan.InterestCalculationMethod);
            command.Parameters.AddWithValue("@BorrowDate", FormatDate(loan.BorrowDate));
            command.Parameters.AddWithValue(
                "@FirstRepaymentDate",
                FormatDate(loan.FirstRepaymentDate));
            command.Parameters.AddWithValue(
                "@RepaymentSettingMode",
                (int)loan.RepaymentSettingMode);
            command.Parameters.AddWithValue("@RepaymentMonths", loan.RepaymentMonths);
            command.Parameters.AddWithValue(
                "@DesiredMonthlyPaymentAmount",
                loan.DesiredMonthlyPaymentAmount);
            command.Parameters.AddWithValue("@MonthlyPaymentDay", loan.MonthlyPaymentDay);
            command.Parameters.AddWithValue("@BonusPaymentFrequency", (int)loan.BonusPaymentFrequency);
            command.Parameters.AddWithValue("@BonusPrincipalAmount", loan.BonusPrincipalAmount);
            command.Parameters.AddWithValue("@BonusMonth1", loan.BonusMonth1);
            command.Parameters.AddWithValue("@BonusMonth2", loan.BonusMonth2);
            command.Parameters.AddWithValue("@Memo", loan.Memo ?? string.Empty);
            command.Parameters.AddWithValue("@CreatedAt", FormatDateTime(loan.CreatedAt));
            command.Parameters.AddWithValue("@UpdatedAt", FormatDateTime(loan.UpdatedAt));
            return command;
        }

        private static void InsertSchedule(
            SQLiteConnection connection,
            SQLiteTransaction transaction,
            long loanId,
            IList<RepaymentScheduleItem> schedule,
            IDictionary<int, FailureState> oldFailures)
        {
            foreach (RepaymentScheduleItem item in schedule)
            {
                FailureState state;
                oldFailures.TryGetValue(item.PaymentNumber, out state);

                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText = @"
INSERT INTO RepaymentSchedule (
    LoanId, PaymentNumber, TargetMonth, BaseDueDate, PaymentDate,
    RepaymentAmount, PaymentAmount, PrincipalAmount, InterestAmount, RemainingBalance,
    IsPaymentFailed, FailureRegisteredAt, FailureNote, ResolvedAt)
VALUES (
    @LoanId, @PaymentNumber, @TargetMonth, @BaseDueDate, @PaymentDate,
    @RepaymentAmount, @PaymentAmount, @PrincipalAmount, @InterestAmount, @RemainingBalance,
    @IsPaymentFailed, @FailureRegisteredAt, @FailureNote, @ResolvedAt);";
                    command.Parameters.AddWithValue("@LoanId", loanId);
                    command.Parameters.AddWithValue("@PaymentNumber", item.PaymentNumber);
                    command.Parameters.AddWithValue("@TargetMonth", item.TargetMonth.ToString("yyyy-MM"));
                    command.Parameters.AddWithValue("@BaseDueDate", FormatDate(item.BaseDueDate));
                    command.Parameters.AddWithValue("@PaymentDate", FormatDate(item.PaymentDate));
                    command.Parameters.AddWithValue("@RepaymentAmount", item.RepaymentAmount);
                    command.Parameters.AddWithValue("@PaymentAmount", item.PaymentAmount);
                    command.Parameters.AddWithValue("@PrincipalAmount", item.PrincipalAmount);
                    command.Parameters.AddWithValue("@InterestAmount", item.InterestAmount);
                    command.Parameters.AddWithValue("@RemainingBalance", item.RemainingBalance);
                    command.Parameters.AddWithValue(
                        "@IsPaymentFailed",
                        state != null && state.IsPaymentFailed ? 1 : 0);
                    command.Parameters.AddWithValue(
                        "@FailureRegisteredAt",
                        state != null && state.FailureRegisteredAt.HasValue
                            ? (object)FormatDateTime(state.FailureRegisteredAt.Value)
                            : DBNull.Value);
                    command.Parameters.AddWithValue(
                        "@FailureNote",
                        state == null ? string.Empty : state.FailureNote);
                    command.Parameters.AddWithValue(
                        "@ResolvedAt",
                        state != null && state.ResolvedAt.HasValue
                            ? (object)FormatDateTime(state.ResolvedAt.Value)
                            : DBNull.Value);
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void DeleteSchedule(
            SQLiteConnection connection,
            SQLiteTransaction transaction,
            long loanId)
        {
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText = "DELETE FROM RepaymentSchedule WHERE LoanId = @LoanId;";
                command.Parameters.AddWithValue("@LoanId", loanId);
                command.ExecuteNonQuery();
            }
        }

        private static Dictionary<int, FailureState> LoadFailureStates(
            SQLiteConnection connection,
            SQLiteTransaction transaction,
            long loanId)
        {
            Dictionary<int, FailureState> result = new Dictionary<int, FailureState>();
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText = @"
SELECT PaymentNumber, IsPaymentFailed, FailureRegisteredAt, FailureNote, ResolvedAt
FROM RepaymentSchedule
WHERE LoanId = @LoanId;";
                command.Parameters.AddWithValue("@LoanId", loanId);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result[Convert.ToInt32(reader["PaymentNumber"])] = new FailureState
                        {
                            IsPaymentFailed = Convert.ToInt32(reader["IsPaymentFailed"]) != 0,
                            FailureRegisteredAt = ReadNullableDateTime(reader, "FailureRegisteredAt"),
                            FailureNote = Convert.ToString(reader["FailureNote"]),
                            ResolvedAt = ReadNullableDateTime(reader, "ResolvedAt")
                        };
                    }
                }
            }

            return result;
        }

        private static Loan ReadLoan(IDataRecord reader)
        {
            return new Loan
            {
                Id = Convert.ToInt64(reader["Id"]),
                Name = Convert.ToString(reader["Name"]),
                PrincipalAmount = Convert.ToInt64(reader["PrincipalAmount"]),
                AnnualInterestRate = decimal.Parse(
                    Convert.ToString(reader["AnnualInterestRate"]),
                    CultureInfo.InvariantCulture),
                RepaymentType = (RepaymentType)Convert.ToInt32(reader["RepaymentType"]),
                InterestCalculationMethod =
                    (InterestCalculationMethod)Convert.ToInt32(reader["InterestCalculationMethod"]),
                BorrowDate = ParseDate(Convert.ToString(reader["BorrowDate"])),
                FirstRepaymentDate = ParseDate(Convert.ToString(reader["FirstRepaymentDate"])),
                RepaymentSettingMode =
                    (RepaymentSettingMode)Convert.ToInt32(reader["RepaymentSettingMode"]),
                RepaymentMonths = Convert.ToInt32(reader["RepaymentMonths"]),
                DesiredMonthlyPaymentAmount =
                    Convert.ToInt64(reader["DesiredMonthlyPaymentAmount"]),
                MonthlyPaymentDay = Convert.ToInt32(reader["MonthlyPaymentDay"]),
                BonusPaymentFrequency = (BonusPaymentFrequency)Convert.ToInt32(reader["BonusPaymentFrequency"]),
                BonusPrincipalAmount = Convert.ToInt64(reader["BonusPrincipalAmount"]),
                BonusMonth1 = Convert.ToInt32(reader["BonusMonth1"]),
                BonusMonth2 = Convert.ToInt32(reader["BonusMonth2"]),
                Memo = Convert.ToString(reader["Memo"]),
                CreatedAt = ParseDateTime(Convert.ToString(reader["CreatedAt"])),
                UpdatedAt = ParseDateTime(Convert.ToString(reader["UpdatedAt"]))
            };
        }

        private static RepaymentScheduleItem ReadScheduleItem(IDataRecord reader)
        {
            return new RepaymentScheduleItem
            {
                Id = Convert.ToInt64(reader["Id"]),
                LoanId = Convert.ToInt64(reader["LoanId"]),
                PaymentNumber = Convert.ToInt32(reader["PaymentNumber"]),
                TargetMonth = DateTime.ParseExact(
                    Convert.ToString(reader["TargetMonth"]) + "-01",
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture),
                BaseDueDate = ParseDate(Convert.ToString(reader["BaseDueDate"])),
                PaymentDate = ParseDate(Convert.ToString(reader["PaymentDate"])),
                RepaymentAmount = Convert.ToInt64(reader["PrincipalAmount"]),
                PaymentAmount = Convert.ToInt64(reader["PaymentAmount"]),
                PrincipalAmount = Convert.ToInt64(reader["PrincipalAmount"]),
                InterestAmount = Convert.ToInt64(reader["InterestAmount"]),
                RemainingBalance = Convert.ToInt64(reader["RemainingBalance"]),
                IsPaymentFailed = Convert.ToInt32(reader["IsPaymentFailed"]) != 0,
                FailureRegisteredAt = ReadNullableDateTime(reader, "FailureRegisteredAt"),
                FailureNote = Convert.ToString(reader["FailureNote"]),
                ResolvedAt = ReadNullableDateTime(reader, "ResolvedAt")
            };
        }

        private static DateTime? ReadNullableDateTime(IDataRecord reader, string name)
        {
            object value = reader[name];
            if (value == null || value == DBNull.Value || string.IsNullOrWhiteSpace(Convert.ToString(value)))
            {
                return null;
            }

            return ParseDateTime(Convert.ToString(value));
        }

        private static string FormatDate(DateTime value)
        {
            return value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        private static string FormatDateTime(DateTime value)
        {
            return value.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
        }

        private static DateTime ParseDate(string value)
        {
            return DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        private static DateTime ParseDateTime(string value)
        {
            return DateTime.ParseExact(
                value,
                "yyyy-MM-dd HH:mm:ss.fff",
                CultureInfo.InvariantCulture);
        }

        private sealed class FailureState
        {
            public bool IsPaymentFailed { get; set; }
            public DateTime? FailureRegisteredAt { get; set; }
            public string FailureNote { get; set; }
            public DateTime? ResolvedAt { get; set; }
        }
    }
}
