using DynamicData.Binding;
using ReactiveUI;
using System.Application.Settings;
using System.Application.Services;
using System.Application.UI.Resx;
using System.Collections.Generic;
using System.IO;
using System.IO.FileFormats;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using static System.Application.FilePicker2;

// ReSharper disable once CheckNamespace
namespace System.Application.UI.ViewModels
{
    public partial class SettingsPageViewModel
    {
        public SettingsPageViewModel()
        {
            IconKey = nameof(SettingsPageViewModel);

            SelectLanguage = R.Languages.FirstOrDefault(x => x.Key == UISettings.Language.Value);
            this.WhenValueChanged(x => x.SelectLanguage, false)
                  .Subscribe(x => UISettings.Language.Value = x.Key);

            UpdateChannels = Enum2.GetAll<UpdateChannelType>();

            SelectFont = R.Fonts.FirstOrDefault(x => x.Value == UISettings.FontName.Value);
            this.WhenValueChanged(x => x.SelectFont, false)
                  .Subscribe(x => UISettings.FontName.Value = x.Value);

            SelectImage_Click = ReactiveCommand.CreateFromTask(async () =>
            {
                var fileTypes = !IsSupportedFileExtensionFilter ? (FilePickerFileType?)null : new FilePickerFilter(new (string, IEnumerable<string>)[] {
                    ("Image Files", new[] {
                            FileEx.BMP,
                            FileEx.JPG,
                            FileEx.JPEG,
                            FileEx.PNG,
                            FileEx.GIF,
                            FileEx.WEBP,
                        }),
                    ("All Files", new[] { "*" }),
                });
                await PickAsync(SetBackgroundImagePath, fileTypes);
            });

            ResetImage_Click = ReactiveCommand.Create(() => SetBackgroundImagePath(null));
        }

        public static SettingsPageViewModel Instance { get; } = new();

        KeyValuePair<string, string> _SelectLanguage;
        public KeyValuePair<string, string> SelectLanguage
        {
            get => _SelectLanguage;
            set => this.RaiseAndSetIfChanged(ref _SelectLanguage, value);
        }

        KeyValuePair<string, string> _SelectFont;
        public KeyValuePair<string, string> SelectFont
        {
            get => _SelectFont;
            set => this.RaiseAndSetIfChanged(ref _SelectFont, value);
        }

        public ICommand SelectImage_Click { get; }

        public ICommand ResetImage_Click { get; }

        IReadOnlyCollection<UpdateChannelType>? _UpdateChannels;
        public IReadOnlyCollection<UpdateChannelType>? UpdateChannels
        {
            get => _UpdateChannels;
            set => this.RaiseAndSetIfChanged(ref _UpdateChannels, value);
        }

        const double clickInterval = 3d;
        readonly Dictionary<string, DateTime> clickTimeRecord = new();
        public void OpenFolder(string tag)
        {
            var path = tag switch
            {
                IOPath.DirName_AppData => IOPath.AppDataDirectory,
                IOPath.DirName_Cache => IOPath.CacheDirectory,
                IApplication.LogDirName => IApplication.LogDirPath,
                _ => IOPath.BaseDirectory,
            };
            var hasKey = clickTimeRecord.TryGetValue(path, out var dt);
            var now = DateTime.Now;
            if (hasKey && (now - dt).TotalSeconds <= clickInterval) return;
            IPlatformService.Instance.OpenFolder(path);
            if (!clickTimeRecord.TryAdd(path, now)) clickTimeRecord[path] = now;
        }

        public void SetBackgroundImagePath(string? imagePath)
        {
            if (imagePath == null)
            {
                UISettings.BackgroundImagePath.Reset();
                return;
            }
            if (File.Exists(imagePath))
            {
                if (IOPath.TryOpenRead(imagePath, out var stream, out var _))
                {
                    var (isImage, _) = FileFormat.IsImage(stream);
                    if (isImage)
                    {
                        UISettings.BackgroundImagePath.Value = imagePath;
                        return;
                    }
                }
            }
            Toast.Show(AppResources.Settings_UI_CustomBackgroundImage_Error);
        }

        public static string[] GetThemes() => new[]
        {
            AppResources.Settings_UI_SystemDefault,
            AppResources.Settings_UI_Light,
            AppResources.Settings_UI_Dark,
        };

        /// <summary>
        /// 开始计算指定文件夹大小
        /// </summary>
        /// <param name="isStartCacheSizeCalc"></param>
        /// <param name="sizeFormat"></param>
        /// <param name="action"></param>
        public static void StartCacheSizeCalc(ref bool isStartCacheSizeCalc, string sizeFormat, Action<string> action, CancellationToken cancellationToken = default)
        {
            if (isStartCacheSizeCalc) return;
            isStartCacheSizeCalc = true;
            action(AppResources.Settings_General_Calcing);
            string? dirPath;
            if (sizeFormat == AppResources.Settings_General_CacheSize)
            {
                dirPath = IOPath.CacheDirectory;
            }
            else if (sizeFormat == AppResources.Settings_General_LogSize)
            {
                dirPath = IApplication.LogDirPath;
            }
            else
            {
                dirPath = null;
            }
            if (dirPath != null)
            {
                try
                {
                    Task.Run(async () =>
                    {
                        var length = IOPath.GetDirectorySize(dirPath);
                        var lenString = IOPath.GetSizeString(length);
                        await MainThread2.InvokeOnMainThreadAsync(() =>
                        {
                            action(sizeFormat.Format(lenString));
                        });
                    }, cancellationToken);
                }
                catch (OperationCanceledException)
                {

                }
            }
        }
    }
}
