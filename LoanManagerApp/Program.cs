using System;
using System.Threading;
using System.Windows.Forms;
using LoanManagerApp.Forms;
using LoanManagerApp.Infrastructure;

namespace LoanManagerApp
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            DateTime startupDateTime = DateTime.Now;

            try
            {
                AppPaths.Initialize();
                Logger.Initialize(startupDateTime);

                Application.ThreadException += ApplicationThreadException;
                AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;

                SettingsService settingsService = new SettingsService();
                AppSettings settings = settingsService.Load();

                LoanRepository repository = new LoanRepository(AppPaths.DatabasePath);
                repository.Initialize();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm(settings, repository));

                Logger.Info("アプリケーションを終了しました。");
            }
            catch (Exception ex)
            {
                try
                {
                    Logger.Error("起動処理で致命的なエラーが発生しました。", ex);
                }
                catch
                {
                    // ログ初期化前の例外を考慮する。
                }

                MessageBox.Show(
                    "アプリケーションを起動できませんでした。\r\n\r\n" + ex.Message +
                    (string.IsNullOrEmpty(Logger.LogFilePath) ? string.Empty : "\r\n\r\nログ: " + Logger.LogFilePath),
                    "起動エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Logger.Error("画面処理で未処理例外が発生しました。", e.Exception);
            MessageBox.Show(
                "予期しないエラーが発生しました。\r\n\r\n" + e.Exception.Message +
                "\r\n\r\nログ: " + Logger.LogFilePath,
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;
            Logger.Error("未処理の致命的な例外が発生しました。", exception);
        }
    }
}
