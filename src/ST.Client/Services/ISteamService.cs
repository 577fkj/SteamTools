using System.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Application.Browser2;

namespace System.Application.Services
{
    /// <summary>
    /// Steam 相关助手、工具类服务
    /// </summary>
    public interface ISteamService
    {
        static ISteamService Instance => DI.Get<ISteamService>();

        const int IPC_Call_GetLoginUsingSteamClient_Timeout_MS = 6500;
        protected const string url_localhost_auth_public = Prefix_HTTP + "127.0.0.1:27060/auth/?u=public";
        const string url_steamcommunity_ = "steamcommunity.com";
        const string url_store_steampowered_ = "store.steampowered.com";
        const string url_steamcommunity = Prefix_HTTPS + url_steamcommunity_;
        const string url_store_steampowered = Prefix_HTTPS + url_store_steampowered_;
        const string url_store_steampowered_checkclientautologin = url_store_steampowered + "/login/checkclientautologin";
        const string url_steamcommunity_checkclientautologin = url_steamcommunity + "/login/checkclientautologin";
        static readonly Uri uri_store_steampowered_checkclientautologin = new(url_store_steampowered_checkclientautologin);

        /// <summary>
        /// Steam 文件夹目录
        /// </summary>
        string? SteamDirPath { get; }

        /// <summary>
        /// Steam 主程序文件目录
        /// </summary>
        string? SteamProgramPath { get; }

        bool IsRunningSteamProcess { get; }

        /// <summary>
        /// 尝试结束 Steam 进程
        /// </summary>
        /// <returns></returns>
        bool TryKillSteamProcess();

        /// <summary>
        /// Steam 进程是否正在运行，如果正在运行，返回进程PID提示用户去任务管理器中结束进程
        /// </summary>
        /// <returns></returns>
        int? GetSteamProcessPid();

        /// <summary>
        /// 启动 Steam
        /// </summary>
        /// <param name="arguments"></param>
        void StartSteam(string? arguments = null);

        /// <summary>
        /// 获取最后一次自动登录 Steam 用户名称
        /// </summary>
        /// <returns></returns>
        string GetLastLoginUserName();

        /// <summary>
        /// 获取所有记住登录 Steam 用户信息
        /// </summary>
        /// <returns></returns>
        List<SteamUser> GetRememberUserList();

        bool UpdateAuthorizedDeviceList(IEnumerable<AuthorizedDevice> list);

        bool RemoveAuthorizedDeviceList(AuthorizedDevice list);

        /// <summary>
        /// 获取所有当前PC共享授权信息
        /// </summary>
        /// <returns></returns>
        List<AuthorizedDevice> GetAuthorizedDeviceList();

        /// <summary>
        /// 设置下次登录 Steam 用户
        /// </summary>
        /// <param name="userName"></param>
        void SetCurrentUser(string userName);

        List<SteamApp>? GetAppListJson(string filePath);

        bool UpdateAppListJson(List<SteamApp> apps, string filePath);

        bool UpdateAppListJson(string appsJsonStr, string filePath);

        void DeleteLocalUserData(SteamUser user, bool IsDeleteUserData = false);

        void UpdateLocalUserData(SteamUser user);

        /// <summary>
        /// 从steam本地客户端缓存文件中读取游戏数据
        /// </summary>
        Task<List<SteamApp>> GetAppInfos();

        Task<string> GetAppImageAsync(SteamApp app, SteamApp.LibCacheType type);

        ValueTask LoadAppImageAsync(SteamApp app);

        /// <summary>
        /// 获取已安装的SteamApp列表(包括正在下载的项)
        /// </summary>
        List<SteamApp> GetDownloadingAppList();

        /// <summary>
        /// 监听Steam下载
        /// </summary>
        void InitWatchSteamDownloading(Action<uint> changedAction, Action<uint> deleteAction);
    }
}