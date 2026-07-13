using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace LoanManagerApp.Infrastructure
{
    internal sealed class SettingsService
    {
        public AppSettings Load()
        {
            if (!File.Exists(AppPaths.SettingsPath))
            {
                AppSettings defaults = AppSettings.CreateDefault();
                Save(defaults);
                Logger.Info("settings.json が存在しないため初期設定を作成しました。");
                return defaults;
            }

            try
            {
                AppSettings settings;
                using (FileStream stream = File.OpenRead(AppPaths.SettingsPath))
                {
                    DataContractJsonSerializer serializer =
                        new DataContractJsonSerializer(typeof(AppSettings));
                    settings = serializer.ReadObject(stream) as AppSettings;
                    if (settings == null)
                    {
                        throw new InvalidDataException("設定データを読み込めませんでした。");
                    }
                }

                // 読み取り用ストリームを閉じてから、補正済み設定を保存する。
                settings.ValidateAndRepair();
                Save(settings);
                return settings;
            }
            catch (Exception ex)
            {
                Logger.Error("settings.json の読み込みに失敗しました。初期設定を使用します。", ex);
                BackupBrokenSettings();
                AppSettings defaults = AppSettings.CreateDefault();
                Save(defaults);
                return defaults;
            }
        }

        public void Save(AppSettings settings)
        {
            settings.ValidateAndRepair();
            string temporaryPath = AppPaths.SettingsPath + ".tmp";

            DataContractJsonSerializerSettings serializerSettings =
                new DataContractJsonSerializerSettings
                {
                    UseSimpleDictionaryFormat = true
                };

            DataContractJsonSerializer serializer =
                new DataContractJsonSerializer(typeof(AppSettings), serializerSettings);

            using (MemoryStream memory = new MemoryStream())
            {
                serializer.WriteObject(memory, settings);
                string json = Encoding.UTF8.GetString(memory.ToArray());
                string formatted = FormatSimpleJson(json);
                File.WriteAllText(temporaryPath, formatted, new UTF8Encoding(false));
            }

            if (File.Exists(AppPaths.SettingsPath))
            {
                File.Delete(AppPaths.SettingsPath);
            }

            File.Move(temporaryPath, AppPaths.SettingsPath);
        }

        private static void BackupBrokenSettings()
        {
            try
            {
                if (!File.Exists(AppPaths.SettingsPath))
                {
                    return;
                }

                string backupPath = AppPaths.SettingsPath + ".broken_" +
                                    DateTime.Now.ToString("yyyyMMdd_HHmmss");
                File.Copy(AppPaths.SettingsPath, backupPath, true);
            }
            catch (Exception ex)
            {
                Logger.Error("破損した設定ファイルのバックアップに失敗しました。", ex);
            }
        }

        private static string FormatSimpleJson(string json)
        {
            StringBuilder builder = new StringBuilder();
            bool inString = false;
            int indent = 0;

            for (int i = 0; i < json.Length; i++)
            {
                char c = json[i];
                if (c == '"' && (i == 0 || json[i - 1] != '\\'))
                {
                    inString = !inString;
                }

                if (inString)
                {
                    builder.Append(c);
                    continue;
                }

                if (c == '{' || c == '[')
                {
                    builder.Append(c);
                    builder.AppendLine();
                    indent++;
                    builder.Append(new string(' ', indent * 2));
                }
                else if (c == '}' || c == ']')
                {
                    builder.AppendLine();
                    indent--;
                    builder.Append(new string(' ', indent * 2));
                    builder.Append(c);
                }
                else if (c == ',')
                {
                    builder.Append(c);
                    builder.AppendLine();
                    builder.Append(new string(' ', indent * 2));
                }
                else if (c == ':')
                {
                    builder.Append(": ");
                }
                else if (!char.IsWhiteSpace(c))
                {
                    builder.Append(c);
                }
            }

            builder.AppendLine();
            return builder.ToString();
        }
    }
}
