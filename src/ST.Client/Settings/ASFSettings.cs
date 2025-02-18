using System;
using System.Application.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace System.Application.Settings
{
    public sealed partial class ASFSettings : SettingsHost2<ASFSettings>
    {
        /// <summary>
        /// ASF路径
        /// </summary>
        public static SerializableProperty<string> ArchiSteamFarmExePath { get; }
            = GetProperty(defaultValue: string.Empty, autoSave: true);

        /// <summary>
        /// 程序启动时自动运行ASF
        /// </summary>
        public static SerializableProperty<bool> AutoRunArchiSteamFarm { get; }
            = GetProperty(defaultValue: false, autoSave: true);

        #region ConsoleMaxLine

        /// <summary>
        /// 控制台默认最大行数
        /// </summary>
        public const int DefaultConsoleMaxLine = 200;

        /// <summary>
        /// 控制台默认最大行数范围最小值
        /// </summary>
        public const int MinRangeConsoleMaxLine = DefaultConsoleMaxLine;

        /// <summary>
        /// 控制台默认最大行数范围最大值
        /// </summary>
        public const int MaxRangeConsoleMaxLine = 5000;

        public static SerializableProperty<int> ConsoleMaxLine { get; }
            = GetProperty(defaultValue: DefaultConsoleMaxLine, autoSave: true);

        #endregion

        /// <summary>
        /// 控制台字体大小，默认值 14，Android 上单位为 sp
        /// </summary>
        public static SerializableProperty<int> ConsoleFontSize { get; }
            = GetProperty(defaultValue: 14, autoSave: true);
    }
}