using System;
using System.IO;

namespace LoanManagerApp.Infrastructure
{
    internal static class AppPaths
    {
        public static string RootDirectory { get; private set; }
        public static string DataDirectory { get; private set; }
        public static string ConfigDirectory { get; private set; }
        public static string LogDirectory { get; private set; }
        public static string DatabasePath { get; private set; }
        public static string SettingsPath { get; private set; }

        public static void Initialize()
        {
            // Config・Data・Logs は実行中のexeファイルと同じ階層に配置する。
            RootDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DataDirectory = Path.Combine(RootDirectory, "Data");
            ConfigDirectory = Path.Combine(RootDirectory, "Config");
            LogDirectory = Path.Combine(RootDirectory, "Logs");
            DatabasePath = Path.Combine(DataDirectory, "loan.db");
            SettingsPath = Path.Combine(ConfigDirectory, "settings.json");

            Directory.CreateDirectory(DataDirectory);
            Directory.CreateDirectory(ConfigDirectory);
            Directory.CreateDirectory(LogDirectory);
        }
    }
}
