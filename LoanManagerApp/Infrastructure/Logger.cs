using System;
using System.IO;
using System.Text;

namespace LoanManagerApp.Infrastructure
{
    internal static class Logger
    {
        private static readonly object SyncRoot = new object();
        private static string _logFilePath;

        public static string LogFilePath
        {
            get { return _logFilePath; }
        }

        public static void Initialize(DateTime startupDateTime)
        {
            string baseName = startupDateTime.ToString("yyyyMMdd_HHmmss");
            string candidate = Path.Combine(AppPaths.LogDirectory, baseName + ".log");
            int suffix = 1;

            while (File.Exists(candidate))
            {
                candidate = Path.Combine(
                    AppPaths.LogDirectory,
                    baseName + "_" + suffix.ToString("00") + ".log");
                suffix++;
            }

            _logFilePath = candidate;
            Write("INFO", "アプリケーションを起動しました。");
        }

        public static void Info(string message)
        {
            Write("INFO", message);
        }

        public static void Warn(string message)
        {
            Write("WARN", message);
        }

        public static void Error(string message, Exception exception)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(message);
            if (exception != null)
            {
                builder.AppendLine();
                builder.Append(exception.ToString());
            }

            Write("ERROR", builder.ToString());
        }

        private static void Write(string level, string message)
        {
            if (string.IsNullOrEmpty(_logFilePath))
            {
                return;
            }

            string line = string.Format(
                "{0:yyyy-MM-dd HH:mm:ss.fff} [{1}] {2}{3}",
                DateTime.Now,
                level,
                message,
                Environment.NewLine);

            lock (SyncRoot)
            {
                try
                {
                    File.AppendAllText(_logFilePath, line, new UTF8Encoding(false));
                }
                catch
                {
                    // ログ出力失敗でアプリ本体を停止させない。
                }
            }
        }
    }
}
