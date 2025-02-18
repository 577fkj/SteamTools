// Copyright (c) The Avalonia Project. All rights reserved.
// Licensed under the MIT license. See licence.md file in the project root for full license information.

// Slightly modified and extended version for the use in SQRLDotNetClientUI

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

internal static class UnmanagedMethods
{
    //[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    //public static extern IntPtr LoadImage(IntPtr hinst, string lpszName, uint uType, int cxDesired, int cyDesired, uint fuLoad);

    ///// <summary>
    ///// Creates, updates or deletes the taskbar icon.
    ///// </summary>
    //[DllImport("shell32", CharSet = CharSet.Unicode)]
    //public static extern bool Shell_NotifyIcon(NIM cmd, NOTIFYICONDATA data);

    //[DllImport("user32.dll")]
    //public static extern void PostQuitMessage(int nExitCode);

    //[DllImport("user32.dll", ExactSpelling = true)]
    //public static extern bool SetForegroundWindow(IntPtr hWnd);

    //[DllImport("user32.dll")]
    //public static extern IntPtr CreatePopupMenu();

    //[DllImport("user32.dll", CharSet = CharSet.Auto)]
    //public static extern bool InsertMenuItem(IntPtr hMenu, uint uItem, bool fByPosition, [In] ref MENUITEMINFO lpmii);

    //[DllImport("user32.dll", CharSet = CharSet.Unicode)]
    //public static extern bool AppendMenu(IntPtr hMenu, MenuFlags uFlags, uint uIDNewItem, string lpNewItem);

    //[DllImport("user32.dll")]
    //public static extern uint TrackPopupMenuEx(IntPtr hmenu, UFLAGS uFlags, int x, int y, IntPtr hwnd, IntPtr lptpm);

    //[DllImport("wtsapi32.dll", SetLastError = true)]
    //public static extern bool WTSRegisterSessionNotification(IntPtr hWnd, [MarshalAs(UnmanagedType.U4)] int dwFlags);

    //[DllImport("wtsapi32.dll", SetLastError = true)]
    //public static extern bool WTSUnRegisterSessionNotification(IntPtr hWnd);

    //[DllImport("user32.dll", CharSet = CharSet.Auto)]
    //[return: MarshalAs(UnmanagedType.Bool)]
    //public static extern bool SystemParametersInfo(uint uAction, uint uParam, ref bool lpvParam, int fWinIni);

    //[DllImport("user32.dll")]
    //public static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

    // constants that can be passed for the WTSRegisterSessionNotification
    // dwFlags parameter
    public const int NOTIFY_FOR_THIS_SESSION = 0;
    public const int NOTIFY_FOR_ALL_SESSIONS = 1;

    // lParam values for WM_ENDSESSION message
    public const int ENDSESSION_CLOSEAPP = 0x1;
    public const int ENDSESSION_CRITICAL = 0x40000000;
    public const int ENDSESSION_LOGOFF = unchecked((int)0x80000000);

    public const uint IMAGE_BITMAP = 0;
    public const uint IMAGE_ICON = 1;
    public const uint IMAGE_CURSOR = 2;

    public const uint LR_DEFAULTSIZE = 0x00000040;
    public const uint LR_LOADFROMFILE = 0x00000010;

    public static IntPtr HWND_BROADCAST = new IntPtr(0xffff);
    public static IntPtr HWND_TOP = new IntPtr(0);
    public static IntPtr HWND_BOTTOM = new IntPtr(1);
    public static IntPtr HWND_TOPMOST = new IntPtr(-1);
    public static IntPtr HWND_NOTOPMOST = new IntPtr(-2);
    public static IntPtr HWND_MESSAGE = new IntPtr(-3);

    public const uint WS_POPUP = 0x80000000;
    public const uint WS_VISIBLE = 0x10000000;

    public const int WTS_CONSOLE_CONNECT = 0x1; // A session was connected to the console terminal.
    public const int WTS_CONSOLE_DISCONNECT = 0x2; // A session was disconnected from the console terminal.
    public const int WTS_REMOTE_CONNECT = 0x3; // A session was connected to the remote terminal.
    public const int WTS_REMOTE_DISCONNECT = 0x4; // A session was disconnected from the remote terminal.
    public const int WTS_SESSION_LOGON = 0x5; // A user has logged on to the session.
    public const int WTS_SESSION_LOGOFF = 0x6; // A user has logged off the session.
    public const int WTS_SESSION_LOCK = 0x7; // A session has been locked.
    public const int WTS_SESSION_UNLOCK = 0x8; // A session has been unlocked.
    public const int WTS_SESSION_REMOTE_CONTROL = 0x9; // A session has changed its remote controlled status.

    public const int PBT_APMQUERYSUSPEND = 0x0000;
    public const int PBT_APMQUERYSTANDBY = 0x0001;
    public const int PBT_APMQUERYSUSPENDFAILED = 0x0002;
    public const int PBT_APMQUERYSTANDBYFAILED = 0x0003;
    public const int PBT_APMSUSPEND = 0x0004;
    public const int PBT_APMSTANDBY = 0x0005;
    public const int PBT_APMRESUMECRITICAL = 0x0006;
    public const int PBT_APMRESUMESUSPEND = 0x0007;
    public const int PBT_APMRESUMESTANDBY = 0x0008;
    public const int PBT_APMBATTERYLOW = 0x0009;
    public const int PBT_APMPOWERSTATUSCHANGE = 0x000A;
    public const int PBT_APMOEMEVENT = 0x000B;

    [StructLayout(LayoutKind.Sequential)]
    public struct LASTINPUTINFO
    {
        public static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));

        [MarshalAs(UnmanagedType.U4)]
        public uint cbSize;
        [MarshalAs(UnmanagedType.U4)]
        public uint dwTime;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class NOTIFYICONDATA
    {
        public int cbSize = Marshal.SizeOf<NOTIFYICONDATA>();
        public IntPtr hWnd;
        public int uID;
        public NIF uFlags;
        public int uCallbackMessage;
        public IntPtr hIcon;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string? szTip;
        public int dwState = 0;
        public int dwStateMask = 0;
        /// <summary>
        /// String with the text for a balloon ToolTip. It can have a maximum of 255 characters.
        /// To remove the ToolTip, set the NIF_INFO flag in uFlags and set szInfo to an empty string.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string? szInfo;
        public int uTimeoutOrVersion;
        /// <summary>
        /// String containing a title for a balloon ToolTip. This title appears in boldface
        /// above the text. It can have a maximum of 63 characters.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string? szInfoTitle;
        public NIIF dwInfoFlags;

        /// <summary>
        /// Windows Vista (Shell32.dll version 6.0.6) and later. The handle of a customized
        /// balloon icon provided by the application that should be used independently
        /// of the tray icon. If this member is non-NULL and the <see cref="NIIF.USER"/>
        /// flag is set, this icon is used as the balloon icon.<br/>
        /// If this member is NULL, the legacy behavior is carried out.
        /// </summary>
        //public IntPtr CustomBalloonIconHandle;
    }

    public enum NIM : uint
    {
        ADD = 0x00000000,
        MODIFY = 0x00000001,
        DELETE = 0x00000002,
        SETFOCUS = 0x00000003,
        SETVERSION = 0x00000004
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class MENUITEMINFO
    {
        public int cbSize = Marshal.SizeOf(typeof(MENUITEMINFO));
        public MIIM fMask;
        public uint fType;
        public uint fState;
        public uint wID;
        public IntPtr hSubMenu;
        public IntPtr hbmpChecked;
        public IntPtr hbmpUnchecked;
        public IntPtr dwItemData;
        public string dwTypeData = null;
        public uint cch; // length of dwTypeData
        public IntPtr hbmpItem;

        public MENUITEMINFO()
        {
        }
        public MENUITEMINFO(MIIM pfMask)
        {
            fMask = pfMask;
        }
    }

    /// <summary>
    /// Custom Win32 window messages for the NotifyIcon
    /// </summary>
    public enum CustomWindowsMessage : uint
    {
        WM_TRAYICON = (uint)WindowsMessage.WM_APP + 1024,
        WM_TRAYMOUSE = (uint)WindowsMessage.WM_USER + 1024
    }

    public enum SysCommands : int
    {
        SC_SIZE = 0xF000,
        SC_MOVE = 0xF010,
        SC_MINIMIZE = 0xF020,
        SC_MAXIMIZE = 0xF030,
        SC_NEXTWINDOW = 0xF040,
        SC_PREVWINDOW = 0xF050,
        SC_CLOSE = 0xF060,
        SC_VSCROLL = 0xF070,
        SC_HSCROLL = 0xF080,
        SC_MOUSEMENU = 0xF090,
        SC_KEYMENU = 0xF100,
        SC_ARRANGE = 0xF110,
        SC_RESTORE = 0xF120,
        SC_TASKLIST = 0xF130,
        SC_SCREENSAVE = 0xF140,
        SC_HOTKEY = 0xF150,
        //#if(WINVER >= 0x0400) //Win95
        SC_DEFAULT = 0xF160,
        SC_MONITORPOWER = 0xF170,
        SC_CONTEXTHELP = 0xF180,
        SC_SEPARATOR = 0xF00F,
        //#endif /* WINVER >= 0x0400 */

        //#if(WINVER >= 0x0600) //Vista
        SCF_ISSECURE = 0x00000001,
        //#endif /* WINVER >= 0x0600 */

        /*
         * Obsolete names
         */
        SC_ICON = SC_MINIMIZE,
        SC_ZOOM = SC_MAXIMIZE,
    }

    [Flags]
    public enum MIIM
    {
        BITMAP = 0x00000080,
        CHECKMARKS = 0x00000008,
        DATA = 0x00000020,
        FTYPE = 0x00000100,
        ID = 0x00000002,
        STATE = 0x00000001,
        STRING = 0x00000040,
        SUBMENU = 0x00000004,
        TYPE = 0x00000010
    }

    [Flags]
    public enum MenuFlags : uint
    {
        MF_STRING = 0,
        MF_BYPOSITION = 0x400,
        MF_SEPARATOR = 0x800,
        MF_REMOVE = 0x1000,
    }

    [Flags]
    public enum UFLAGS : uint
    {
        TPM_LEFTALIGN = 0x0000,
        TPM_CENTERALIGN = 0x0004,
        TPM_RIGHTALIGN = 0x0008,
        TPM_TOPALIGN = 0x0000,
        TPM_VCENTERALIGN = 0x0010,
        TPM_BOTTOMALIGN = 0x0020,
        TPM_HORIZONTAL = 0x0000,
        TPM_VERTICAL = 0x0040,
        TPM_NONOTIFY = 0x0080,
        TPM_RETURNCMD = 0x0100
    }

    // End extensions for SQRLDotNetClientUI

    public const int CW_USEDEFAULT = unchecked((int)0x80000000);

    public delegate void TimerProc(IntPtr hWnd, uint uMsg, IntPtr nIDEvent, uint dwTime);

    public delegate void TimeCallback(uint uTimerID, uint uMsg, UIntPtr dwUser, UIntPtr dw1, UIntPtr dw2);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void WaitOrTimerCallback(IntPtr lpParameter, bool timerOrWaitFired);

    public delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    public static readonly IntPtr DPI_AWARENESS_CONTEXT_UNAWARE = new IntPtr(-1);
    public static readonly IntPtr DPI_AWARENESS_CONTEXT_SYSTEM_AWARE = new IntPtr(-2);
    public static readonly IntPtr DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE = new IntPtr(-3);
    public static readonly IntPtr DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = new IntPtr(-4);

    public enum Cursor
    {
        IDC_ARROW = 32512,
        IDC_IBEAM = 32513,
        IDC_WAIT = 32514,
        IDC_CROSS = 32515,
        IDC_UPARROW = 32516,
        IDC_SIZE = 32640,
        IDC_ICON = 32641,
        IDC_SIZENWSE = 32642,
        IDC_SIZENESW = 32643,
        IDC_SIZEWE = 32644,
        IDC_SIZENS = 32645,
        IDC_SIZEALL = 32646,
        IDC_NO = 32648,
        IDC_HAND = 32649,
        IDC_APPSTARTING = 32650,
        IDC_HELP = 32651
    }

    public enum MouseActivate : int
    {
        MA_ACTIVATE = 1,
        MA_ACTIVATEANDEAT = 2,
        MA_NOACTIVATE = 3,
        MA_NOACTIVATEANDEAT = 4
    }

    [Flags]
    public enum SetWindowPosFlags : uint
    {
        SWP_ASYNCWINDOWPOS = 0x4000,
        SWP_DEFERERASE = 0x2000,
        SWP_DRAWFRAME = 0x0020,
        SWP_FRAMECHANGED = 0x0020,
        SWP_HIDEWINDOW = 0x0080,
        SWP_NOACTIVATE = 0x0010,
        SWP_NOCOPYBITS = 0x0100,
        SWP_NOMOVE = 0x0002,
        SWP_NOOWNERZORDER = 0x0200,
        SWP_NOREDRAW = 0x0008,
        SWP_NOREPOSITION = 0x0200,
        SWP_NOSENDCHANGING = 0x0400,
        SWP_NOSIZE = 0x0001,
        SWP_NOZORDER = 0x0004,
        SWP_SHOWWINDOW = 0x0040,

        SWP_RESIZE = SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOZORDER
    }

    public static class WindowPosZOrder
    {
        public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        public static readonly IntPtr HWND_TOP = new IntPtr(0);
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
    }

    public enum SizeCommand
    {
        Restored,
        Minimized,
        Maximized,
        MaxShow,
        MaxHide,
    }

    public enum ShowWindowCommand
    {
        Hide = 0,
        Normal = 1,
        ShowMinimized = 2,
        Maximize = 3,
        ShowMaximized = 3,
        ShowNoActivate = 4,
        Show = 5,
        Minimize = 6,
        ShowMinNoActive = 7,
        ShowNA = 8,
        Restore = 9,
        ShowDefault = 10,
        ForceMinimize = 11
    }

    public enum SystemMetric
    {
        SM_CXSCREEN = 0,  // 0x00
        SM_CYSCREEN = 1,  // 0x01
        SM_CXVSCROLL = 2,  // 0x02
        SM_CYHSCROLL = 3,  // 0x03
        SM_CYCAPTION = 4,  // 0x04
        SM_CXBORDER = 5,  // 0x05
        SM_CYBORDER = 6,  // 0x06
        SM_CXDLGFRAME = 7,  // 0x07
        SM_CXFIXEDFRAME = 7,  // 0x07
        SM_CYDLGFRAME = 8,  // 0x08
        SM_CYFIXEDFRAME = 8,  // 0x08
        SM_CYVTHUMB = 9,  // 0x09
        SM_CXHTHUMB = 10, // 0x0A
        SM_CXICON = 11, // 0x0B
        SM_CYICON = 12, // 0x0C
        SM_CXCURSOR = 13, // 0x0D
        SM_CYCURSOR = 14, // 0x0E
        SM_CYMENU = 15, // 0x0F
        SM_CXFULLSCREEN = 16, // 0x10
        SM_CYFULLSCREEN = 17, // 0x11
        SM_CYKANJIWINDOW = 18, // 0x12
        SM_MOUSEPRESENT = 19, // 0x13
        SM_CYVSCROLL = 20, // 0x14
        SM_CXHSCROLL = 21, // 0x15
        SM_DEBUG = 22, // 0x16
        SM_SWAPBUTTON = 23, // 0x17
        SM_CXMIN = 28, // 0x1C
        SM_CYMIN = 29, // 0x1D
        SM_CXSIZE = 30, // 0x1E
        SM_CYSIZE = 31, // 0x1F
        SM_CXSIZEFRAME = 32, // 0x20
        SM_CXFRAME = 32, // 0x20
        SM_CYSIZEFRAME = 33, // 0x21
        SM_CYFRAME = 33, // 0x21
        SM_CXMINTRACK = 34, // 0x22
        SM_CYMINTRACK = 35, // 0x23
        SM_CXDOUBLECLK = 36, // 0x24
        SM_CYDOUBLECLK = 37, // 0x25
        SM_CXICONSPACING = 38, // 0x26
        SM_CYICONSPACING = 39, // 0x27
        SM_MENUDROPALIGNMENT = 40, // 0x28
        SM_PENWINDOWS = 41, // 0x29
        SM_DBCSENABLED = 42, // 0x2A
        SM_CMOUSEBUTTONS = 43, // 0x2B
        SM_SECURE = 44, // 0x2C
        SM_CXEDGE = 45, // 0x2D
        SM_CYEDGE = 46, // 0x2E
        SM_CXMINSPACING = 47, // 0x2F
        SM_CYMINSPACING = 48, // 0x30
        SM_CXSMICON = 49, // 0x31
        SM_CYSMICON = 50, // 0x32
        SM_CYSMCAPTION = 51, // 0x33
        SM_CXSMSIZE = 52, // 0x34
        SM_CYSMSIZE = 53, // 0x35
        SM_CXMENUSIZE = 54, // 0x36
        SM_CYMENUSIZE = 55, // 0x37
        SM_ARRANGE = 56, // 0x38
        SM_CXMINIMIZED = 57, // 0x39
        SM_CYMINIMIZED = 58, // 0x3A
        SM_CXMAXTRACK = 59, // 0x3B
        SM_CYMAXTRACK = 60, // 0x3C
        SM_CXMAXIMIZED = 61, // 0x3D
        SM_CYMAXIMIZED = 62, // 0x3E
        SM_NETWORK = 63, // 0x3F
        SM_CLEANBOOT = 67, // 0x43
        SM_CXDRAG = 68, // 0x44
        SM_CYDRAG = 69, // 0x45
        SM_SHOWSOUNDS = 70, // 0x46
        SM_CXMENUCHECK = 71, // 0x47
        SM_CYMENUCHECK = 72, // 0x48
        SM_SLOWMACHINE = 73, // 0x49
        SM_MIDEASTENABLED = 74, // 0x4A
        SM_MOUSEWHEELPRESENT = 75, // 0x4B
        SM_XVIRTUALSCREEN = 76, // 0x4C
        SM_YVIRTUALSCREEN = 77, // 0x4D
        SM_CXVIRTUALSCREEN = 78, // 0x4E
        SM_CYVIRTUALSCREEN = 79, // 0x4F
        SM_CMONITORS = 80, // 0x50
        SM_SAMEDISPLAYFORMAT = 81, // 0x51
        SM_IMMENABLED = 82, // 0x52
        SM_CXFOCUSBORDER = 83, // 0x53
        SM_CYFOCUSBORDER = 84, // 0x54
        SM_TABLETPC = 86, // 0x56
        SM_MEDIACENTER = 87, // 0x57
        SM_STARTER = 88, // 0x58
        SM_SERVERR2 = 89, // 0x59
        SM_MOUSEHORIZONTALWHEELPRESENT = 91, // 0x5B
        SM_CXPADDEDBORDER = 92, // 0x5C
        SM_DIGITIZER = 94, // 0x5E
        SM_MAXIMUMTOUCHES = 95, // 0x5F

        SM_REMOTESESSION = 0x1000, // 0x1000
        SM_SHUTTINGDOWN = 0x2000, // 0x2000
        SM_REMOTECONTROL = 0x2001, // 0x2001

        SM_CONVERTABLESLATEMODE = 0x2003,
        SM_SYSTEMDOCKED = 0x2004,
    }

    [Flags]
    public enum ModifierKeys
    {
        MK_CONTROL = 0x0008,

        MK_LBUTTON = 0x0001,

        MK_MBUTTON = 0x0010,

        MK_RBUTTON = 0x0002,

        MK_SHIFT = 0x0004,

        MK_ALT = 0x0020,

        MK_XBUTTON1 = 0x0020,

        MK_XBUTTON2 = 0x0040
    }

    public enum VirtualKeyStates : int
    {
        VK_LBUTTON = 0x01,
        VK_RBUTTON = 0x02,
        VK_CANCEL = 0x03,
        VK_MBUTTON = 0x04,
        VK_XBUTTON1 = 0x05,
        VK_XBUTTON2 = 0x06,
        VK_BACK = 0x08,
        VK_TAB = 0x09,
        VK_CLEAR = 0x0C,
        VK_RETURN = 0x0D,
        VK_SHIFT = 0x10,
        VK_CONTROL = 0x11,
        VK_MENU = 0x12,
        VK_PAUSE = 0x13,
        VK_CAPITAL = 0x14,
        VK_KANA = 0x15,
        VK_HANGEUL = 0x15,
        VK_HANGUL = 0x15,
        VK_JUNJA = 0x17,
        VK_FINAL = 0x18,
        VK_HANJA = 0x19,
        VK_KANJI = 0x19,
        VK_ESCAPE = 0x1B,
        VK_CONVERT = 0x1C,
        VK_NONCONVERT = 0x1D,
        VK_ACCEPT = 0x1E,
        VK_MODECHANGE = 0x1F,
        VK_SPACE = 0x20,
        VK_PRIOR = 0x21,
        VK_NEXT = 0x22,
        VK_END = 0x23,
        VK_HOME = 0x24,
        VK_LEFT = 0x25,
        VK_UP = 0x26,
        VK_RIGHT = 0x27,
        VK_DOWN = 0x28,
        VK_SELECT = 0x29,
        VK_PRINT = 0x2A,
        VK_EXECUTE = 0x2B,
        VK_SNAPSHOT = 0x2C,
        VK_INSERT = 0x2D,
        VK_DELETE = 0x2E,
        VK_HELP = 0x2F,
        VK_LWIN = 0x5B,
        VK_RWIN = 0x5C,
        VK_APPS = 0x5D,
        VK_SLEEP = 0x5F,
        VK_NUMPAD0 = 0x60,
        VK_NUMPAD1 = 0x61,
        VK_NUMPAD2 = 0x62,
        VK_NUMPAD3 = 0x63,
        VK_NUMPAD4 = 0x64,
        VK_NUMPAD5 = 0x65,
        VK_NUMPAD6 = 0x66,
        VK_NUMPAD7 = 0x67,
        VK_NUMPAD8 = 0x68,
        VK_NUMPAD9 = 0x69,
        VK_MULTIPLY = 0x6A,
        VK_ADD = 0x6B,
        VK_SEPARATOR = 0x6C,
        VK_SUBTRACT = 0x6D,
        VK_DECIMAL = 0x6E,
        VK_DIVIDE = 0x6F,
        VK_F1 = 0x70,
        VK_F2 = 0x71,
        VK_F3 = 0x72,
        VK_F4 = 0x73,
        VK_F5 = 0x74,
        VK_F6 = 0x75,
        VK_F7 = 0x76,
        VK_F8 = 0x77,
        VK_F9 = 0x78,
        VK_F10 = 0x79,
        VK_F11 = 0x7A,
        VK_F12 = 0x7B,
        VK_F13 = 0x7C,
        VK_F14 = 0x7D,
        VK_F15 = 0x7E,
        VK_F16 = 0x7F,
        VK_F17 = 0x80,
        VK_F18 = 0x81,
        VK_F19 = 0x82,
        VK_F20 = 0x83,
        VK_F21 = 0x84,
        VK_F22 = 0x85,
        VK_F23 = 0x86,
        VK_F24 = 0x87,
        VK_NUMLOCK = 0x90,
        VK_SCROLL = 0x91,
        VK_OEM_NEC_EQUAL = 0x92,
        VK_OEM_FJ_JISHO = 0x92,
        VK_OEM_FJ_MASSHOU = 0x93,
        VK_OEM_FJ_TOUROKU = 0x94,
        VK_OEM_FJ_LOYA = 0x95,
        VK_OEM_FJ_ROYA = 0x96,
        VK_LSHIFT = 0xA0,
        VK_RSHIFT = 0xA1,
        VK_LCONTROL = 0xA2,
        VK_RCONTROL = 0xA3,
        VK_LMENU = 0xA4,
        VK_RMENU = 0xA5,
        VK_BROWSER_BACK = 0xA6,
        VK_BROWSER_FORWARD = 0xA7,
        VK_BROWSER_REFRESH = 0xA8,
        VK_BROWSER_STOP = 0xA9,
        VK_BROWSER_SEARCH = 0xAA,
        VK_BROWSER_FAVORITES = 0xAB,
        VK_BROWSER_HOME = 0xAC,
        VK_VOLUME_MUTE = 0xAD,
        VK_VOLUME_DOWN = 0xAE,
        VK_VOLUME_UP = 0xAF,
        VK_MEDIA_NEXT_TRACK = 0xB0,
        VK_MEDIA_PREV_TRACK = 0xB1,
        VK_MEDIA_STOP = 0xB2,
        VK_MEDIA_PLAY_PAUSE = 0xB3,
        VK_LAUNCH_MAIL = 0xB4,
        VK_LAUNCH_MEDIA_SELECT = 0xB5,
        VK_LAUNCH_APP1 = 0xB6,
        VK_LAUNCH_APP2 = 0xB7,
        VK_OEM_1 = 0xBA,
        VK_OEM_PLUS = 0xBB,
        VK_OEM_COMMA = 0xBC,
        VK_OEM_MINUS = 0xBD,
        VK_OEM_PERIOD = 0xBE,
        VK_OEM_2 = 0xBF,
        VK_OEM_3 = 0xC0,
        VK_OEM_4 = 0xDB,
        VK_OEM_5 = 0xDC,
        VK_OEM_6 = 0xDD,
        VK_OEM_7 = 0xDE,
        VK_OEM_8 = 0xDF,
        VK_OEM_AX = 0xE1,
        VK_OEM_102 = 0xE2,
        VK_ICO_HELP = 0xE3,
        VK_ICO_00 = 0xE4,
        VK_PROCESSKEY = 0xE5,
        VK_ICO_CLEAR = 0xE6,
        VK_PACKET = 0xE7,
        VK_OEM_RESET = 0xE9,
        VK_OEM_JUMP = 0xEA,
        VK_OEM_PA1 = 0xEB,
        VK_OEM_PA2 = 0xEC,
        VK_OEM_PA3 = 0xED,
        VK_OEM_WSCTRL = 0xEE,
        VK_OEM_CUSEL = 0xEF,
        VK_OEM_ATTN = 0xF0,
        VK_OEM_FINISH = 0xF1,
        VK_OEM_COPY = 0xF2,
        VK_OEM_AUTO = 0xF3,
        VK_OEM_ENLW = 0xF4,
        VK_OEM_BACKTAB = 0xF5,
        VK_ATTN = 0xF6,
        VK_CRSEL = 0xF7,
        VK_EXSEL = 0xF8,
        VK_EREOF = 0xF9,
        VK_PLAY = 0xFA,
        VK_ZOOM = 0xFB,
        VK_NONAME = 0xFC,
        VK_PA1 = 0xFD,
        VK_OEM_CLEAR = 0xFE
    }

    public enum WindowActivate
    {
        WA_INACTIVE,
        WA_ACTIVE,
        WA_CLICKACTIVE,
    }

    public enum HitTestValues
    {
        HTERROR = -2,
        HTTRANSPARENT = -1,
        HTNOWHERE = 0,
        HTCLIENT = 1,
        HTCAPTION = 2,
        HTSYSMENU = 3,
        HTGROWBOX = 4,
        HTMENU = 5,
        HTHSCROLL = 6,
        HTVSCROLL = 7,
        HTMINBUTTON = 8,
        HTMAXBUTTON = 9,
        HTLEFT = 10,
        HTRIGHT = 11,
        HTTOP = 12,
        HTTOPLEFT = 13,
        HTTOPRIGHT = 14,
        HTBOTTOM = 15,
        HTBOTTOMLEFT = 16,
        HTBOTTOMRIGHT = 17,
        HTBORDER = 18,
        HTOBJECT = 19,
        HTCLOSE = 20,
        HTHELP = 21
    }

    [Flags]
    public enum WindowStyles : uint
    {
        WS_BORDER = 0x800000,
        WS_CAPTION = 0xc00000,
        WS_CHILD = 0x40000000,
        WS_CLIPCHILDREN = 0x2000000,
        WS_CLIPSIBLINGS = 0x4000000,
        WS_DISABLED = 0x8000000,
        WS_DLGFRAME = 0x400000,
        WS_GROUP = 0x20000,
        WS_HSCROLL = 0x100000,
        WS_MAXIMIZE = 0x1000000,
        WS_MAXIMIZEBOX = 0x10000,
        WS_MINIMIZE = 0x20000000,
        WS_MINIMIZEBOX = 0x20000,
        WS_OVERLAPPED = 0x0,
        WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_SIZEFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
        WS_POPUP = 0x80000000u,
        WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,
        WS_SIZEFRAME = 0x40000,
        WS_SYSMENU = 0x80000,
        WS_TABSTOP = 0x10000,
        WS_VISIBLE = 0x10000000,
        WS_VSCROLL = 0x200000,
        WS_EX_DLGMODALFRAME = 0x00000001,
        WS_EX_NOPARENTNOTIFY = 0x00000004,
        WS_EX_TOPMOST = 0x00000008,
        WS_EX_ACCEPTFILES = 0x00000010,
        WS_EX_TRANSPARENT = 0x00000020,
        WS_EX_MDICHILD = 0x00000040,
        WS_EX_TOOLWINDOW = 0x00000080,
        WS_EX_WINDOWEDGE = 0x00000100,
        WS_EX_CLIENTEDGE = 0x00000200,
        WS_EX_CONTEXTHELP = 0x00000400,
        WS_EX_RIGHT = 0x00001000,
        WS_EX_LEFT = 0x00000000,
        WS_EX_RTLREADING = 0x00002000,
        WS_EX_LTRREADING = 0x00000000,
        WS_EX_LEFTSCROLLBAR = 0x00004000,
        WS_EX_RIGHTSCROLLBAR = 0x00000000,
        WS_EX_CONTROLPARENT = 0x00010000,
        WS_EX_STATICEDGE = 0x00020000,
        WS_EX_APPWINDOW = 0x00040000,
        WS_EX_OVERLAPPEDWINDOW = WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE,
        WS_EX_PALETTEWINDOW = WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST,
        WS_EX_LAYERED = 0x00080000,
        WS_EX_NOINHERITLAYOUT = 0x00100000,
        WS_EX_LAYOUTRTL = 0x00400000,
        WS_EX_COMPOSITED = 0x02000000,
        WS_EX_NOACTIVATE = 0x08000000
    }

    [Flags]
    public enum ClassStyles : uint
    {
        CS_VREDRAW = 0x0001,
        CS_HREDRAW = 0x0002,
        CS_DBLCLKS = 0x0008,
        CS_OWNDC = 0x0020,
        CS_CLASSDC = 0x0040,
        CS_PARENTDC = 0x0080,
        CS_NOCLOSE = 0x0200,
        CS_SAVEBITS = 0x0800,
        CS_BYTEALIGNCLIENT = 0x1000,
        CS_BYTEALIGNWINDOW = 0x2000,
        CS_GLOBALCLASS = 0x4000,
        CS_IME = 0x00010000,
        CS_DROPSHADOW = 0x00020000
    }

    public enum WindowsMessage : uint
    {
        WM_NULL = 0x0000,
        WM_CREATE = 0x0001,
        WM_DESTROY = 0x0002,
        WM_MOVE = 0x0003,
        WM_SIZE = 0x0005,
        WM_ACTIVATE = 0x0006,
        WM_SETFOCUS = 0x0007,
        WM_KILLFOCUS = 0x0008,
        WM_ENABLE = 0x000A,
        WM_SETREDRAW = 0x000B,
        WM_SETTEXT = 0x000C,
        WM_GETTEXT = 0x000D,
        WM_GETTEXTLENGTH = 0x000E,
        WM_PAINT = 0x000F,
        WM_CLOSE = 0x0010,
        WM_QUERYENDSESSION = 0x0011,
        WM_QUERYOPEN = 0x0013,
        WM_ENDSESSION = 0x0016,
        WM_QUIT = 0x0012,
        WM_ERASEBKGND = 0x0014,
        WM_SYSCOLORCHANGE = 0x0015,
        WM_SHOWWINDOW = 0x0018,
        WM_WININICHANGE = 0x001A,
        WM_SETTINGCHANGE = WM_WININICHANGE,
        WM_DEVMODECHANGE = 0x001B,
        WM_ACTIVATEAPP = 0x001C,
        WM_FONTCHANGE = 0x001D,
        WM_TIMECHANGE = 0x001E,
        WM_CANCELMODE = 0x001F,
        WM_SETCURSOR = 0x0020,
        WM_MOUSEACTIVATE = 0x0021,
        WM_CHILDACTIVATE = 0x0022,
        WM_QUEUESYNC = 0x0023,
        WM_GETMINMAXINFO = 0x0024,
        WM_PAINTICON = 0x0026,
        WM_ICONERASEBKGND = 0x0027,
        WM_NEXTDLGCTL = 0x0028,
        WM_SPOOLERSTATUS = 0x002A,
        WM_DRAWITEM = 0x002B,
        WM_MEASUREITEM = 0x002C,
        WM_DELETEITEM = 0x002D,
        WM_VKEYTOITEM = 0x002E,
        WM_CHARTOITEM = 0x002F,
        WM_SETFONT = 0x0030,
        WM_GETFONT = 0x0031,
        WM_SETHOTKEY = 0x0032,
        WM_GETHOTKEY = 0x0033,
        WM_QUERYDRAGICON = 0x0037,
        WM_COMPAREITEM = 0x0039,
        WM_GETOBJECT = 0x003D,
        WM_COMPACTING = 0x0041,
        WM_WINDOWPOSCHANGING = 0x0046,
        WM_WINDOWPOSCHANGED = 0x0047,
        WM_COPYDATA = 0x004A,
        WM_CANCELJOURNAL = 0x004B,
        WM_NOTIFY = 0x004E,
        WM_INPUTLANGCHANGEREQUEST = 0x0050,
        WM_INPUTLANGCHANGE = 0x0051,
        WM_TCARD = 0x0052,
        WM_HELP = 0x0053,
        WM_USERCHANGED = 0x0054,
        WM_NOTIFYFORMAT = 0x0055,
        WM_CONTEXTMENU = 0x007B,
        WM_STYLECHANGING = 0x007C,
        WM_STYLECHANGED = 0x007D,
        WM_DISPLAYCHANGE = 0x007E,
        WM_GETICON = 0x007F,
        WM_SETICON = 0x0080,
        WM_NCCREATE = 0x0081,
        WM_NCDESTROY = 0x0082,
        WM_NCCALCSIZE = 0x0083,
        WM_NCHITTEST = 0x0084,
        WM_NCPAINT = 0x0085,
        WM_NCACTIVATE = 0x0086,
        WM_GETDLGCODE = 0x0087,
        WM_SYNCPAINT = 0x0088,
        WM_NCMOUSEMOVE = 0x00A0,
        WM_NCLBUTTONDOWN = 0x00A1,
        WM_NCLBUTTONUP = 0x00A2,
        WM_NCLBUTTONDBLCLK = 0x00A3,
        WM_NCRBUTTONDOWN = 0x00A4,
        WM_NCRBUTTONUP = 0x00A5,
        WM_NCRBUTTONDBLCLK = 0x00A6,
        WM_NCMBUTTONDOWN = 0x00A7,
        WM_NCMBUTTONUP = 0x00A8,
        WM_NCMBUTTONDBLCLK = 0x00A9,
        WM_NCXBUTTONDOWN = 0x00AB,
        WM_NCXBUTTONUP = 0x00AC,
        WM_NCXBUTTONDBLCLK = 0x00AD,
        WM_INPUT_DEVICE_CHANGE = 0x00FE,
        WM_INPUT = 0x00FF,
        WM_KEYFIRST = 0x0100,
        WM_KEYDOWN = 0x0100,
        WM_KEYUP = 0x0101,
        WM_CHAR = 0x0102,
        WM_DEADCHAR = 0x0103,
        WM_SYSKEYDOWN = 0x0104,
        WM_SYSKEYUP = 0x0105,
        WM_SYSCHAR = 0x0106,
        WM_SYSDEADCHAR = 0x0107,
        WM_UNICHAR = 0x0109,
        WM_KEYLAST = 0x0109,
        WM_IME_STARTCOMPOSITION = 0x010D,
        WM_IME_ENDCOMPOSITION = 0x010E,
        WM_IME_COMPOSITION = 0x010F,
        WM_IME_KEYLAST = 0x010F,
        WM_INITDIALOG = 0x0110,
        WM_COMMAND = 0x0111,
        WM_SYSCOMMAND = 0x0112,
        WM_TIMER = 0x0113,
        WM_HSCROLL = 0x0114,
        WM_VSCROLL = 0x0115,
        WM_INITMENU = 0x0116,
        WM_INITMENUPOPUP = 0x0117,
        WM_MENUSELECT = 0x011F,
        WM_MENUCHAR = 0x0120,
        WM_ENTERIDLE = 0x0121,
        WM_MENURBUTTONUP = 0x0122,
        WM_MENUDRAG = 0x0123,
        WM_MENUGETOBJECT = 0x0124,
        WM_UNINITMENUPOPUP = 0x0125,
        WM_MENUCOMMAND = 0x0126,
        WM_CHANGEUISTATE = 0x0127,
        WM_UPDATEUISTATE = 0x0128,
        WM_QUERYUISTATE = 0x0129,
        WM_CTLCOLORMSGBOX = 0x0132,
        WM_CTLCOLOREDIT = 0x0133,
        WM_CTLCOLORLISTBOX = 0x0134,
        WM_CTLCOLORBTN = 0x0135,
        WM_CTLCOLORDLG = 0x0136,
        WM_CTLCOLORSCROLLBAR = 0x0137,
        WM_CTLCOLORSTATIC = 0x0138,
        WM_MOUSEFIRST = 0x0200,
        WM_MOUSEMOVE = 0x0200,
        WM_LBUTTONDOWN = 0x0201,
        WM_LBUTTONUP = 0x0202,
        WM_LBUTTONDBLCLK = 0x0203,
        WM_RBUTTONDOWN = 0x0204,
        WM_RBUTTONUP = 0x0205,
        WM_RBUTTONDBLCLK = 0x0206,
        WM_MBUTTONDOWN = 0x0207,
        WM_MBUTTONUP = 0x0208,
        WM_MBUTTONDBLCLK = 0x0209,
        WM_MOUSEWHEEL = 0x020A,
        WM_XBUTTONDOWN = 0x020B,
        WM_XBUTTONUP = 0x020C,
        WM_XBUTTONDBLCLK = 0x020D,
        WM_MOUSEHWHEEL = 0x020E,
        WM_MOUSELAST = 0x020E,
        WM_PARENTNOTIFY = 0x0210,
        WM_ENTERMENULOOP = 0x0211,
        WM_EXITMENULOOP = 0x0212,
        WM_NEXTMENU = 0x0213,
        WM_SIZING = 0x0214,
        WM_CAPTURECHANGED = 0x0215,
        WM_MOVING = 0x0216,
        WM_POWERBROADCAST = 0x0218,
        WM_DEVICECHANGE = 0x0219,
        WM_MDICREATE = 0x0220,
        WM_MDIDESTROY = 0x0221,
        WM_MDIACTIVATE = 0x0222,
        WM_MDIRESTORE = 0x0223,
        WM_MDINEXT = 0x0224,
        WM_MDIMAXIMIZE = 0x0225,
        WM_MDITILE = 0x0226,
        WM_MDICASCADE = 0x0227,
        WM_MDIICONARRANGE = 0x0228,
        WM_MDIGETACTIVE = 0x0229,
        WM_MDISETMENU = 0x0230,
        WM_ENTERSIZEMOVE = 0x0231,
        WM_EXITSIZEMOVE = 0x0232,
        WM_DROPFILES = 0x0233,
        WM_MDIREFRESHMENU = 0x0234,
        WM_IME_SETCONTEXT = 0x0281,
        WM_IME_NOTIFY = 0x0282,
        WM_IME_CONTROL = 0x0283,
        WM_IME_COMPOSITIONFULL = 0x0284,
        WM_IME_SELECT = 0x0285,
        WM_IME_CHAR = 0x0286,
        WM_IME_REQUEST = 0x0288,
        WM_IME_KEYDOWN = 0x0290,
        WM_IME_KEYUP = 0x0291,
        WM_MOUSEHOVER = 0x02A1,
        WM_MOUSELEAVE = 0x02A3,
        WM_NCMOUSEHOVER = 0x02A0,
        WM_NCMOUSELEAVE = 0x02A2,
        WM_WTSSESSION_CHANGE = 0x02B1,
        WM_TABLET_FIRST = 0x02c0,
        WM_TABLET_LAST = 0x02df,
        WM_DPICHANGED = 0x02E0,
        WM_CUT = 0x0300,
        WM_COPY = 0x0301,
        WM_PASTE = 0x0302,
        WM_CLEAR = 0x0303,
        WM_UNDO = 0x0304,
        WM_RENDERFORMAT = 0x0305,
        WM_RENDERALLFORMATS = 0x0306,
        WM_DESTROYCLIPBOARD = 0x0307,
        WM_DRAWCLIPBOARD = 0x0308,
        WM_PAINTCLIPBOARD = 0x0309,
        WM_VSCROLLCLIPBOARD = 0x030A,
        WM_SIZECLIPBOARD = 0x030B,
        WM_ASKCBFORMATNAME = 0x030C,
        WM_CHANGECBCHAIN = 0x030D,
        WM_HSCROLLCLIPBOARD = 0x030E,
        WM_QUERYNEWPALETTE = 0x030F,
        WM_PALETTEISCHANGING = 0x0310,
        WM_PALETTECHANGED = 0x0311,
        WM_HOTKEY = 0x0312,
        WM_PRINT = 0x0317,
        WM_PRINTCLIENT = 0x0318,
        WM_APPCOMMAND = 0x0319,
        WM_THEMECHANGED = 0x031A,
        WM_CLIPBOARDUPDATE = 0x031D,
        WM_DWMCOMPOSITIONCHANGED = 0x031E,
        WM_DWMNCRENDERINGCHANGED = 0x031F,
        WM_DWMCOLORIZATIONCOLORCHANGED = 0x0320,
        WM_DWMWINDOWMAXIMIZEDCHANGE = 0x0321,
        WM_GETTITLEBARINFOEX = 0x033F,
        WM_HANDHELDFIRST = 0x0358,
        WM_HANDHELDLAST = 0x035F,
        WM_AFXFIRST = 0x0360,
        WM_AFXLAST = 0x037F,
        WM_PENWINFIRST = 0x0380,
        WM_PENWINLAST = 0x038F,
        WM_TOUCH = 0x0240,
        WM_APP = 0x8000,
        WM_USER = 0x0400,

        WM_DISPATCH_WORK_ITEM = WM_USER,
    }

    public enum MapVirtualKeyMapTypes : uint
    {
        MAPVK_VK_TO_VSC = 0x00,
        MAPVK_VSC_TO_VK = 0x01,
        MAPVK_VK_TO_CHAR = 0x02,
        MAPVK_VSC_TO_VK_EX = 0x03,
    }

    public enum BitmapCompressionMode : uint
    {
        BI_RGB = 0,
        BI_RLE8 = 1,
        BI_RLE4 = 2,
        BI_BITFIELDS = 3,
        BI_JPEG = 4,
        BI_PNG = 5
    }

    public enum DIBColorTable
    {
        DIB_RGB_COLORS = 0,     /* color table in RGBs */
        DIB_PAL_COLORS          /* color table in palette indices */
    }

    public enum WindowLongParam
    {
        GWL_WNDPROC = -4,
        GWL_HINSTANCE = -6,
        GWL_HWNDPARENT = -8,
        GWL_ID = -12,
        GWL_STYLE = -16,
        GWL_EXSTYLE = -20,
        GWL_USERDATA = -21
    }

    public enum MenuCharParam
    {
        MNC_IGNORE = 0,
        MNC_CLOSE = 1,
        MNC_EXECUTE = 2,
        MNC_SELECT = 3
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RGBQUAD
    {
        public byte rgbBlue;
        public byte rgbGreen;
        public byte rgbRed;
        public byte rgbReserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPINFOHEADER
    {
        public uint biSize;
        public int biWidth;
        public int biHeight;
        public ushort biPlanes;
        public ushort biBitCount;
        public uint biCompression;
        public uint biSizeImage;
        public int biXPelsPerMeter;
        public int biYPelsPerMeter;
        public uint biClrUsed;
        public uint biClrImportant;

        public void Init()
        {
            biSize = (uint)Marshal.SizeOf(this);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPINFO
    {
        // C# cannot inlay structs in structs so must expand directly here
        //
        //[StructLayout(LayoutKind.Sequential)]
        //public struct BITMAPINFOHEADER
        //{
        public uint biSize;
        public int biWidth;
        public int biHeight;
        public ushort biPlanes;
        public ushort biBitCount;
        public BitmapCompressionMode biCompression;
        public uint biSizeImage;
        public int biXPelsPerMeter;
        public int biYPelsPerMeter;
        public uint biClrUsed;
        public uint biClrImportant;
        //}

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public uint[] cols;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MINMAXINFO
    {
        public POINT ptReserved;
        public POINT ptMaxSize;
        public POINT ptMaxPosition;
        public POINT ptMinTrackSize;
        public POINT ptMaxTrackSize;
    }

    public const int SizeOf_BITMAPINFOHEADER = 40;

    //[DllImport("user32.dll", SetLastError = true)]
    //public static extern IntPtr GetDC(IntPtr hWnd);

    //[DllImport("gdi32.dll")]
    //public static extern int SetDIBitsToDevice(IntPtr hdc, int XDest, int YDest,
    //    uint dwWidth, uint dwHeight,
    //    int XSrc, int YSrc,
    //    uint uStartScan, uint cScanLines,
    //   IntPtr lpvBits, [In] ref BITMAPINFO lpbmi, uint fuColorUse);

    //[DllImport("user32.dll")]
    //public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

    //[DllImport("user32.dll", SetLastError = true)]
    //public static extern bool AdjustWindowRectEx(ref RECT lpRect, uint dwStyle, bool bMenu, uint dwExStyle);

    //[DllImport("user32.dll")]
    //public static extern IntPtr BeginPaint(IntPtr hwnd, out PAINTSTRUCT lpPaint);

    //[DllImport("user32.dll")]
    //public static extern bool ClientToScreen(IntPtr hWnd, ref POINT lpPoint);

    //[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    //public static extern IntPtr CreateWindowEx(
    //   int dwExStyle,
    //   uint lpClassName,
    //   string lpWindowName,
    //   uint dwStyle,
    //   int x,
    //   int y,
    //   int nWidth,
    //   int nHeight,
    //   IntPtr hWndParent,
    //   IntPtr hMenu,
    //   IntPtr hInstance,
    //   IntPtr lpParam);

    //[DllImport("user32.dll", EntryPoint = "DefWindowProcW")]
    //public static extern IntPtr DefWindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    //[DllImport("user32.dll", EntryPoint = "DispatchMessageW")]
    //public static extern IntPtr DispatchMessage(ref MSG lpmsg);

    //[DllImport("user32.dll", SetLastError = true)]
    //public static extern bool DestroyWindow(IntPtr hwnd);

    //[DllImport("user32.dll")]
    //public static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

    //[DllImport("user32.dll")]
    //public static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT lpPaint);

    //[DllImport("user32.dll")]
    //public static extern uint GetCaretBlinkTime();

    //[DllImport("user32.dll")]
    //public static extern bool GetClientRect(IntPtr hwnd, out RECT lpRect);

    //[DllImport("user32.dll")]
    //public static extern bool GetCursorPos(out POINT lpPoint);

    //[DllImport("user32.dll")]
    //public static extern uint GetDoubleClickTime();

    //[DllImport("user32.dll")]
    //public static extern bool GetKeyboardState(byte[] lpKeyState);

    //[DllImport("user32.dll", EntryPoint = "MapVirtualKeyW")]
    //public static extern uint MapVirtualKey(uint uCode, uint uMapType);

    //[DllImport("user32.dll", EntryPoint = "GetMessageW")]
    //public static extern sbyte GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

    //[DllImport("user32.dll")]
    //public static extern int GetMessageTime();

    //[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    //public static extern IntPtr GetModuleHandle(string lpModuleName);

    //[DllImport("user32.dll")]
    //public static extern int GetSystemMetrics(SystemMetric smIndex);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern uint GetWindowLongPtr(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll", SetLastError = true, EntryPoint = "GetWindowLong")]
    public static extern uint GetWindowLong32b(IntPtr hWnd, int nIndex);

    //public static uint GetWindowLong(IntPtr hWnd, int nIndex)
    //{
    //    if (IntPtr.Size == 4)
    //    {
    //        return GetWindowLong32b(hWnd, nIndex);
    //    }
    //    else
    //    {
    //        return GetWindowLongPtr(hWnd, nIndex);
    //    }
    //}

    [DllImport("user32.dll", SetLastError = true, EntryPoint = "SetWindowLong")]
    private static extern uint SetWindowLong32b(IntPtr hWnd, int nIndex, uint value);

    [DllImport("user32.dll", SetLastError = true, EntryPoint = "SetWindowLongPtr")]
    private static extern IntPtr SetWindowLong64b(IntPtr hWnd, int nIndex, IntPtr value);

    //public static uint SetWindowLong(IntPtr hWnd, int nIndex, uint value)
    //{
    //    if (IntPtr.Size == 4)
    //    {
    //        return SetWindowLong32b(hWnd, nIndex, value);
    //    }
    //    else
    //    {
    //        return (uint)SetWindowLong64b(hWnd, nIndex, new IntPtr((uint)value)).ToInt32();
    //    }
    //}

    //public static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr handle)
    //{
    //    if (IntPtr.Size == 4)
    //    {
    //        return new IntPtr(SetWindowLong32b(hWnd, nIndex, (uint)handle.ToInt32()));
    //    }
    //    else
    //    {
    //        return SetWindowLong64b(hWnd, nIndex, handle);
    //    }
    //}

    //[DllImport("user32.dll", SetLastError = true)]
    //public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

    //[DllImport("user32.dll")]
    //public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

    //[DllImport("user32.dll")]
    //public static extern bool GetUpdateRect(IntPtr hwnd, out RECT lpRect, bool bErase);

    //[DllImport("user32.dll")]
    //public static extern bool InvalidateRect(IntPtr hWnd, ref RECT lpRect, bool bErase);

    //[DllImport("user32.dll")]
    //public static extern bool IsWindowEnabled(IntPtr hWnd);

    //[DllImport("user32.dll")]
    //public static extern bool IsWindowUnicode(IntPtr hWnd);

    //[DllImport("user32.dll")]
    //public static extern bool IsWindowVisible(IntPtr hWnd);

    //[DllImport("user32.dll")]
    //public static extern bool KillTimer(IntPtr hWnd, IntPtr uIDEvent);

    //[DllImport("user32.dll")]
    //public static extern IntPtr LoadCursor(IntPtr hInstance, IntPtr lpCursorName);

    //[DllImport("user32.dll")]
    //public static extern bool PeekMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);

    //[DllImport("user32")]
    //public static extern IntPtr GetMessageExtraInfo();

    //[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "RegisterClassExW")]
    //public static extern ushort RegisterClassEx(ref WNDCLASSEX lpwcx);

    //[DllImport("user32.dll")]
    //public static extern void RegisterTouchWindow(IntPtr hWnd, int flags);

    //[DllImport("user32.dll")]
    //public static extern bool ReleaseCapture();

    //[DllImport("user32.dll")]
    //public static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);

    //[DllImport("user32.dll", SetLastError = true)]
    //public static extern IntPtr SetActiveWindow(IntPtr hWnd);

    //[DllImport("user32.dll")]
    //public static extern IntPtr SetCapture(IntPtr hWnd);

    //[DllImport("user32.dll")]
    //public static extern IntPtr SetTimer(IntPtr hWnd, IntPtr nIDEvent, uint uElapse, TimerProc lpTimerFunc);
    //[DllImport("user32.dll", SetLastError = true)]
    //public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    //[DllImport("user32.dll")]
    //public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SetWindowPosFlags uFlags);
    //[DllImport("user32.dll")]
    //public static extern bool SetFocus(IntPtr hWnd);
    //[DllImport("user32.dll")]
    //public static extern bool SetParent(IntPtr hWnd, IntPtr hWndNewParent);
    //[DllImport("user32.dll")]
    //public static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommand nCmdShow);

    //[DllImport("kernel32.dll", SetLastError = true)]
    //public static extern IntPtr CreateTimerQueue();

    //[DllImport("kernel32.dll", SetLastError = true)]
    //public static extern bool DeleteTimerQueueEx(IntPtr TimerQueue, IntPtr CompletionEvent);

    //[DllImport("kernel32.dll", SetLastError = true)]
    //[return: MarshalAs(UnmanagedType.Bool)]
    //public static extern bool CreateTimerQueueTimer(
    //    out IntPtr phNewTimer,
    //    IntPtr TimerQueue,
    //    WaitOrTimerCallback Callback,
    //    IntPtr Parameter,
    //    uint DueTime,
    //    uint Period,
    //    uint Flags);

    //[DllImport("kernel32.dll", SetLastError = true)]
    //public static extern bool DeleteTimerQueueTimer(IntPtr TimerQueue, IntPtr Timer, IntPtr CompletionEvent);

    //[DllImport("user32.dll")]
    //public static extern int ToUnicode(
    //    uint virtualKeyCode,
    //    uint scanCode,
    //    byte[] keyboardState,
    //    [Out, MarshalAs(UnmanagedType.LPWStr, SizeConst = 64)]
    //        StringBuilder receivingBuffer,
    //    int bufferSize,
    //    uint flags);

    //[DllImport("user32.dll", SetLastError = true)]
    //public static extern bool TrackMouseEvent(ref TRACKMOUSEEVENT lpEventTrack);

    //[DllImport("user32.dll")]
    //public static extern bool TranslateMessage(ref MSG lpMsg);

    //[DllImport("user32.dll", CharSet = CharSet.Unicode)]
    //public static extern bool UnregisterClass(string lpClassName, IntPtr hInstance);

    //[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "SetWindowTextW")]
    //public static extern bool SetWindowText(IntPtr hwnd, string lpString);

    public enum ClassLongIndex : int
    {
        GCLP_MENUNAME = -8,
        GCLP_HBRBACKGROUND = -10,
        GCLP_HCURSOR = -12,
        GCLP_HICON = -14,
        GCLP_HMODULE = -16,
        GCL_CBWNDEXTRA = -18,
        GCL_CBCLSEXTRA = -20,
        GCLP_WNDPROC = -24,
        GCL_STYLE = -26,
        GCLP_HICONSM = -34,
        GCW_ATOM = -32
    }

    [DllImport("user32.dll", EntryPoint = "SetClassLongPtr")]
    private static extern IntPtr SetClassLong64(IntPtr hWnd, ClassLongIndex nIndex, IntPtr dwNewLong);

    [DllImport("user32.dll", EntryPoint = "SetClassLong")]
    private static extern IntPtr SetClassLong32(IntPtr hWnd, ClassLongIndex nIndex, IntPtr dwNewLong);

    //public static IntPtr SetClassLong(IntPtr hWnd, ClassLongIndex nIndex, IntPtr dwNewLong)
    //{
    //    if (IntPtr.Size == 4)
    //    {
    //        return SetClassLong32(hWnd, nIndex, dwNewLong);
    //    }

    //    return SetClassLong64(hWnd, nIndex, dwNewLong);
    //}

    //public static IntPtr GetClassLongPtr(IntPtr hWnd, int nIndex)
    //{
    //    if (IntPtr.Size > 4)
    //        return GetClassLongPtr64(hWnd, nIndex);
    //    else
    //        return new IntPtr(GetClassLongPtr32(hWnd, nIndex));
    //}

    //[DllImport("user32.dll", EntryPoint = "GetClassLong")]
    //public static extern uint GetClassLongPtr32(IntPtr hWnd, int nIndex);

    //[DllImport("user32.dll", EntryPoint = "GetClassLongPtr")]
    //public static extern IntPtr GetClassLongPtr64(IntPtr hWnd, int nIndex);

    //[DllImport("user32.dll", EntryPoint = "SetCursor")]
    //internal static extern IntPtr SetCursor(IntPtr hCursor);

    //[DllImport("ole32.dll", PreserveSig = true)]
    //internal static extern int CoCreateInstance(ref Guid clsid,
    //    IntPtr ignore1, int ignore2, ref Guid iid, [MarshalAs(UnmanagedType.IUnknown), Out] out object pUnkOuter);

    //[DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    //internal static extern int SHCreateItemFromParsingName([MarshalAs(UnmanagedType.LPWStr)] string pszPath, IntPtr pbc, ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IShellItem ppv);

    //[DllImport("user32.dll", SetLastError = true)]
    //public static extern bool OpenClipboard(IntPtr hWndOwner);

    //[DllImport("user32.dll", SetLastError = true)]
    //public static extern bool CloseClipboard();

    //[DllImport("user32.dll")]
    //public static extern bool EmptyClipboard();

    //[DllImport("user32.dll")]
    //public static extern IntPtr GetClipboardData(ClipboardFormat uFormat);

    //[DllImport("user32.dll")]
    //public static extern IntPtr SetClipboardData(ClipboardFormat uFormat, IntPtr hMem);

    //[DllImport("kernel32.dll", ExactSpelling = true)]
    //public static extern IntPtr GlobalLock(IntPtr handle);

    //[DllImport("kernel32.dll", ExactSpelling = true)]
    //public static extern bool GlobalUnlock(IntPtr handle);

    //[DllImport("kernel32.dll", ExactSpelling = true)]
    //public static extern IntPtr GlobalAlloc(int uFlags, int dwBytes);

    //[DllImport("kernel32.dll", ExactSpelling = true)]
    //public static extern IntPtr GlobalFree(IntPtr hMem);

    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr LoadLibrary(string fileName);

    //[DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    //public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

    //[DllImport("comdlg32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSaveFileNameW")]
    //public static extern bool GetSaveFileName(IntPtr lpofn);

    //[DllImport("comdlg32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetOpenFileNameW")]
    //public static extern bool GetOpenFileName(IntPtr lpofn);

    //[DllImport("comdlg32.dll")]
    //public static extern int CommDlgExtendedError();

    //public static bool ShCoreAvailable => LoadLibrary("shcore.dll") != IntPtr.Zero;

    //[DllImport("shcore.dll")]
    //public static extern void SetProcessDpiAwareness(PROCESS_DPI_AWARENESS value);

    //[DllImport("user32.dll", SetLastError = true)]
    //public static extern bool SetProcessDpiAwarenessContext(IntPtr dpiAWarenessContext);

    //[DllImport("shcore.dll")]
    //public static extern long GetDpiForMonitor(IntPtr hmonitor, MONITOR_DPI_TYPE dpiType, out uint dpiX, out uint dpiY);

    //[DllImport("gdi32.dll")]
    //public static extern int GetDeviceCaps(IntPtr hdc, DEVICECAP nIndex);

    //[DllImport("shcore.dll")]
    //public static extern void GetScaleFactorForMonitor(IntPtr hMon, out uint pScale);

    //[DllImport("user32.dll", SetLastError = true)]
    //public static extern bool SetProcessDPIAware();

    //[DllImport("user32.dll")]
    //public static extern IntPtr MonitorFromPoint(POINT pt, MONITOR dwFlags);

    //[DllImport("user32.dll")]
    //public static extern IntPtr MonitorFromRect(RECT rect, MONITOR dwFlags);

    //[DllImport("user32.dll")]
    //public static extern IntPtr MonitorFromWindow(IntPtr hwnd, MONITOR dwFlags);

    //[DllImport("user32", EntryPoint = "GetMonitorInfoW", ExactSpelling = true, CharSet = CharSet.Unicode)]
    //[return: MarshalAs(UnmanagedType.Bool)]
    //public static extern bool GetMonitorInfo([In] IntPtr hMonitor, ref MONITORINFO lpmi);

    //[DllImport("user32")]
    //public static extern bool CloseTouchInputHandle(IntPtr hTouchInput);

    //[return: MarshalAs(UnmanagedType.Bool)]
    //[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "PostMessageW")]
    //public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    //[DllImport("gdi32.dll")]
    //public static extern int SetDIBitsToDevice(IntPtr hdc, int XDest, int YDest, uint
    //        dwWidth, uint dwHeight, int XSrc, int YSrc, uint uStartScan, uint cScanLines,
    //    IntPtr lpvBits, [In] ref BITMAPINFOHEADER lpbmi, uint fuColorUse);

    //[DllImport("kernel32.dll", SetLastError = true)]
    //[return: MarshalAs(UnmanagedType.Bool)]
    //public static extern bool CloseHandle(IntPtr hObject);
    //[DllImport("gdi32.dll", SetLastError = true)]
    //public static extern IntPtr CreateDIBSection(IntPtr hDC, ref BITMAPINFOHEADER pBitmapInfo, int un, out IntPtr lplpVoid, IntPtr handle, int dw);
    //[DllImport("gdi32.dll")]
    //public static extern int DeleteObject(IntPtr hObject);
    //[DllImport("gdi32.dll", SetLastError = true)]
    //public static extern IntPtr CreateCompatibleDC(IntPtr hdc);
    //[DllImport("gdi32.dll")]
    //public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

    //[DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    //public static extern IntPtr CreateFileMapping(IntPtr hFile,
    //    IntPtr lpFileMappingAttributes,
    //    uint flProtect,
    //    uint dwMaximumSizeHigh,
    //    uint dwMaximumSizeLow,
    //    string lpName);

    //[DllImport("msvcrt.dll", EntryPoint = "memcpy", SetLastError = false, CallingConvention = CallingConvention.Cdecl)]
    //public static extern IntPtr CopyMemory(IntPtr dest, IntPtr src, UIntPtr count);

    //[DllImport("ole32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    //public static extern HRESULT RegisterDragDrop(IntPtr hwnd, IDropTarget target);

    //[DllImport("ole32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    //public static extern HRESULT RevokeDragDrop(IntPtr hwnd);

    //[DllImport("ole32.dll", EntryPoint = "OleInitialize")]
    //public static extern HRESULT OleInitialize(IntPtr val);

    //[DllImport("ole32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    //internal static extern void ReleaseStgMedium(ref STGMEDIUM medium);

    //[DllImport("user32.dll", BestFitMapping = false, CharSet = CharSet.Auto, SetLastError = true)]
    //public static extern int GetClipboardFormatName(int format, StringBuilder lpString, int cchMax);

    //[DllImport("user32.dll", BestFitMapping = false, CharSet = CharSet.Auto, SetLastError = true)]
    //public static extern int RegisterClipboardFormat(string format);

    //[DllImport("kernel32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
    //public static extern IntPtr GlobalSize(IntPtr hGlobal);

    //[DllImport("shell32.dll", BestFitMapping = false, CharSet = CharSet.Auto)]
    //public static extern int DragQueryFile(IntPtr hDrop, int iFile, StringBuilder lpszFile, int cch);

    //[DllImport("ole32.dll", CharSet = CharSet.Auto, ExactSpelling = true, PreserveSig = false)]
    //internal static extern void DoDragDrop(IOleDataObject dataObject, IDropSource dropSource, int allowedEffects, out int finalEffect);

    //public enum MONITOR
    //{
    //    MONITOR_DEFAULTTONULL = 0x00000000,
    //    MONITOR_DEFAULTTOPRIMARY = 0x00000001,
    //    MONITOR_DEFAULTTONEAREST = 0x00000002,
    //}

    [StructLayout(LayoutKind.Sequential)]
    internal struct MONITORINFO
    {
        public int cbSize;
        public RECT rcMonitor;
        public RECT rcWork;
        public int dwFlags;

        public static MONITORINFO Create()
        {
            return new MONITORINFO() { cbSize = Marshal.SizeOf<MONITORINFO>() };
        }

        public enum MonitorOptions : uint
        {
            MONITOR_DEFAULTTONULL = 0x00000000,
            MONITOR_DEFAULTTOPRIMARY = 0x00000001,
            MONITOR_DEFAULTTONEAREST = 0x00000002
        }
    }

    public enum DEVICECAP
    {
        HORZRES = 8,
        DESKTOPHORZRES = 118
    }

    public enum PROCESS_DPI_AWARENESS
    {
        PROCESS_DPI_UNAWARE = 0,
        PROCESS_SYSTEM_DPI_AWARE = 1,
        PROCESS_PER_MONITOR_DPI_AWARE = 2
    }

    public enum MONITOR_DPI_TYPE
    {
        MDT_EFFECTIVE_DPI = 0,
        MDT_ANGULAR_DPI = 1,
        MDT_RAW_DPI = 2,
        MDT_DEFAULT = MDT_EFFECTIVE_DPI
    }

    public enum ClipboardFormat
    {
        /// <summary>
        /// Text format. Each line ends with a carriage return/linefeed (CR-LF) combination. A null character signals the end of the data. Use this format for ANSI text.
        /// </summary>
        CF_TEXT = 1,
        /// <summary>
        /// A handle to a bitmap
        /// </summary>
        CF_BITMAP = 2,
        /// <summary>
        /// A memory object containing a BITMAPINFO structure followed by the bitmap bits.
        /// </summary>
        CF_DIB = 3,
        /// <summary>
        /// Unicode text format. Each line ends with a carriage return/linefeed (CR-LF) combination. A null character signals the end of the data.
        /// </summary>
        CF_UNICODETEXT = 13,
        /// <summary>
        /// A handle to type HDROP that identifies a list of files.
        /// </summary>
        CF_HDROP = 15,
    }

    public struct MSG
    {
        public IntPtr hwnd;
        public uint message;
        public IntPtr wParam;
        public IntPtr lParam;
        public uint time;
        public POINT pt;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PAINTSTRUCT
    {
        public IntPtr hdc;
        public bool fErase;
        public RECT rcPaint;
        public bool fRestore;
        public bool fIncUpdate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] rgbReserved;
    }

    public struct POINT
    {
        public int X;
        public int Y;
    }

    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;

        public int Width => right - left;

        public int Height => bottom - top;

        public void Offset(POINT pt)
        {
            left += pt.X;
            right += pt.X;
            top += pt.Y;
            bottom += pt.Y;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPOS
    {
        public IntPtr hwnd;
        public IntPtr hwndInsertAfter;
        public int x;
        public int y;
        public int cx;
        public int cy;
        public uint flags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NCCALCSIZE_PARAMS
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public RECT[] rgrc;
        public WINDOWPOS lppos;
    }

    public struct TRACKMOUSEEVENT
    {
        public int cbSize;
        public uint dwFlags;
        public IntPtr hwndTrack;
        public int dwHoverTime;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPLACEMENT
    {
        /// <summary>
        /// The length of the structure, in bytes. Before calling the GetWindowPlacement or SetWindowPlacement functions, set this member to sizeof(WINDOWPLACEMENT).
        /// <para>
        /// GetWindowPlacement and SetWindowPlacement fail if this member is not set correctly.
        /// </para>
        /// </summary>
        public int Length;

        /// <summary>
        /// Specifies flags that control the position of the minimized window and the method by which the window is restored.
        /// </summary>
        public int Flags;

        /// <summary>
        /// The current show state of the window.
        /// </summary>
        public ShowWindowCommand ShowCmd;

        /// <summary>
        /// The coordinates of the window's upper-left corner when the window is minimized.
        /// </summary>
        public POINT MinPosition;

        /// <summary>
        /// The coordinates of the window's upper-left corner when the window is maximized.
        /// </summary>
        public POINT MaxPosition;

        /// <summary>
        /// The window's coordinates when the window is in the restored position.
        /// </summary>
        public RECT NormalPosition;

        /// <summary>
        /// Gets the default (empty) value.
        /// </summary>
        public static WINDOWPLACEMENT Default
        {
            get
            {
                WINDOWPLACEMENT result = new WINDOWPLACEMENT();
                result.Length = Marshal.SizeOf(result);
                return result;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WNDCLASSEX
    {
        public int cbSize;
        public int style;
        public WndProc lpfnWndProc;
        public int cbClsExtra;
        public int cbWndExtra;
        public IntPtr hInstance;
        public IntPtr hIcon;
        public IntPtr hCursor;
        public IntPtr hbrBackground;
        public string lpszMenuName;
        public string lpszClassName;
        public IntPtr hIconSm;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TOUCHINPUT
    {
        public int X;
        public int Y;
        public IntPtr Source;
        public uint Id;
        public TouchInputFlags Flags;
        public int Mask;
        public uint Time;
        public IntPtr ExtraInfo;
        public int CxContact;
        public int CyContact;
    }

    [Flags]
    public enum TouchInputFlags
    {
        /// <summary>
        /// Movement has occurred. Cannot be combined with TOUCHEVENTF_DOWN.
        /// </summary>
        TOUCHEVENTF_MOVE = 0x0001,

        /// <summary>
        /// The corresponding touch point was established through a new contact. Cannot be combined with TOUCHEVENTF_MOVE or TOUCHEVENTF_UP.
        /// </summary>
        TOUCHEVENTF_DOWN = 0x0002,

        /// <summary>
        /// A touch point was removed.
        /// </summary>
        TOUCHEVENTF_UP = 0x0004,

        /// <summary>
        /// A touch point is in range. This flag is used to enable touch hover support on compatible hardware. Applications that do not want support for hover can ignore this flag.
        /// </summary>
        TOUCHEVENTF_INRANGE = 0x0008,

        /// <summary>
        /// Indicates that this TOUCHINPUT structure corresponds to a primary contact point. See the following text for more information on primary touch points.
        /// </summary>
        TOUCHEVENTF_PRIMARY = 0x0010,

        /// <summary>
        /// When received using GetTouchInputInfo, this input was not coalesced.
        /// </summary>
        TOUCHEVENTF_NOCOALESCE = 0x0020,

        /// <summary>
        /// The touch event came from the user's palm.
        /// </summary>
        TOUCHEVENTF_PALM = 0x0080
    }

    [Flags]
    public enum OpenFileNameFlags
    {
        OFN_ALLOWMULTISELECT = 0x00000200,
        OFN_EXPLORER = 0x00080000,
        OFN_HIDEREADONLY = 0x00000004,
        OFN_NOREADONLYRETURN = 0x00008000,
        OFN_OVERWRITEPROMPT = 0x00000002
    }

    public enum HRESULT : uint
    {
        S_FALSE = 0x0001,
        S_OK = 0x0000,
        E_INVALIDARG = 0x80070057,
        E_OUTOFMEMORY = 0x8007000E,
        E_NOTIMPL = 0x80004001,
        E_UNEXPECTED = 0x8000FFFF
    }

    public enum Icons
    {
        ICON_SMALL = 0,
        ICON_BIG = 1
    }

    public const uint SIGDN_FILESYSPATH = 0x80058000;

    [Flags]
    public enum FOS : uint
    {
        FOS_OVERWRITEPROMPT = 0x00000002,
        FOS_STRICTFILETYPES = 0x00000004,
        FOS_NOCHANGEDIR = 0x00000008,
        FOS_PICKFOLDERS = 0x00000020,
        FOS_FORCEFILESYSTEM = 0x00000040, // Ensure that items returned are filesystem items.
        FOS_ALLNONSTORAGEITEMS = 0x00000080, // Allow choosing items that have no storage.
        FOS_NOVALIDATE = 0x00000100,
        FOS_ALLOWMULTISELECT = 0x00000200,
        FOS_PATHMUSTEXIST = 0x00000800,
        FOS_FILEMUSTEXIST = 0x00001000,
        FOS_CREATEPROMPT = 0x00002000,
        FOS_SHAREAWARE = 0x00004000,
        FOS_NOREADONLYRETURN = 0x00008000,
        FOS_NOTESTFILECREATE = 0x00010000,
        FOS_HIDEMRUPLACES = 0x00020000,
        FOS_HIDEPINNEDPLACES = 0x00040000,
        FOS_NODEREFERENCELINKS = 0x00100000,
        FOS_DONTADDTORECENT = 0x02000000,
        FOS_FORCESHOWHIDDEN = 0x10000000,
        FOS_DEFAULTNOMINIMODE = 0x20000000
    }

    public static class ShellIds
    {
        public static readonly Guid OpenFileDialog = Guid.Parse("DC1C5A9C-E88A-4DDE-A5A1-60F82A20AEF7");
        public static readonly Guid SaveFileDialog = Guid.Parse("C0B4E2F3-BA21-4773-8DBA-335EC946EB8B");
        public static readonly Guid IFileDialog = Guid.Parse("42F85136-DB7E-439C-85F1-E4075D135FC8");
        public static readonly Guid IShellItem = Guid.Parse("43826D1E-E718-42EE-BC55-A1E261C37BFE");
    }

    [ComImport(), Guid("42F85136-DB7E-439C-85F1-E4075D135FC8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileDialog
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig()]
        uint Show([In, Optional] IntPtr hwndOwner); //IModalWindow

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint SetFileTypes(uint cFileTypes, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] COMDLG_FILTERSPEC[] rgFilterSpec);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint SetFileTypeIndex([In] uint iFileType);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint GetFileTypeIndex(out uint piFileType);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint Advise([In, MarshalAs(UnmanagedType.Interface)] IntPtr pfde, out uint pdwCookie);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint Unadvise([In] uint dwCookie);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint SetOptions([In] uint fos);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint GetOptions(out uint fos);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetDefaultFolder([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint SetFolder([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint GetFolder([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint GetCurrentSelection([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint SetFileName([In, MarshalAs(UnmanagedType.LPWStr)] string pszName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint GetFileName([MarshalAs(UnmanagedType.LPWStr)] out string pszName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint SetTitle([In, MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint SetOkButtonLabel([In, MarshalAs(UnmanagedType.LPWStr)] string pszText);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint SetFileNameLabel([In, MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint GetResult([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint AddPlace([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi, uint fdap);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint SetDefaultExtension([In, MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint Close([MarshalAs(UnmanagedType.Error)] uint hr);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint SetClientGuid([In] ref Guid guid);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint ClearClientData();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint SetFilter([MarshalAs(UnmanagedType.Interface)] IntPtr pFilter);
    }

    [ComImport, Guid("d57c7288-d4ad-4768-be02-9d969532d960"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileOpenDialog
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig()]
        uint Show([In, Optional] IntPtr hwndOwner); //IModalWindow

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint SetFileTypes([In] uint cFileTypes, [In, MarshalAs(UnmanagedType.LPArray)] IntPtr rgFilterSpec);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetFileTypeIndex([In] uint iFileType);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetFileTypeIndex(out uint piFileType);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint Advise([In, MarshalAs(UnmanagedType.Interface)] IntPtr pfde, out uint pdwCookie);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Unadvise([In] uint dwCookie);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint SetOptions([In] uint fos);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint GetOptions(out uint fos);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetDefaultFolder([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetFolder([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetFolder([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCurrentSelection([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetFileName([In, MarshalAs(UnmanagedType.LPWStr)] string pszName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetFileName([MarshalAs(UnmanagedType.LPWStr)] out string pszName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetTitle([In, MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetOkButtonLabel([In, MarshalAs(UnmanagedType.LPWStr)] string pszText);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetFileNameLabel([In, MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetResult([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint AddPlace([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi, uint fdap);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetDefaultExtension([In, MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Close([MarshalAs(UnmanagedType.Error)] int hr);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetClientGuid([In] ref Guid guid);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ClearClientData();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetFilter([MarshalAs(UnmanagedType.Interface)] IntPtr pFilter);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetResults([MarshalAs(UnmanagedType.Interface)] out IShellItemArray ppenum);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetSelectedItems([MarshalAs(UnmanagedType.Interface)] out IShellItemArray ppsai);
    }

    [ComImport, Guid("B63EA76D-1F85-456F-A19C-48159EFA858B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IShellItemArray
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void BindToHandler([In, MarshalAs(UnmanagedType.Interface)] IntPtr pbc, [In] ref Guid rbhid,
                     [In] ref Guid riid, out IntPtr ppvOut);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetPropertyStore([In] int Flags, [In] ref Guid riid, out IntPtr ppv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetPropertyDescriptionList([In] ref PROPERTYKEY keyType, [In] ref Guid riid, out IntPtr ppv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetAttributes([In] SIATTRIBFLAGS dwAttribFlags, [In] uint sfgaoMask, out uint psfgaoAttribs);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCount(out uint pdwNumItems);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetItemAt([In] uint dwIndex, [MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void EnumItems([MarshalAs(UnmanagedType.Interface)] out IntPtr ppenumShellItems);
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct PROPERTYKEY
    {
        public Guid fmtid;
        public uint pid;
    }

    public enum SIATTRIBFLAGS
    {
        SIATTRIBFLAGS_AND = 1,
        SIATTRIBFLAGS_APPCOMPAT = 3,
        SIATTRIBFLAGS_OR = 2
    }

    [ComImport, Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IShellItem
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint BindToHandler([In] IntPtr pbc, [In] ref Guid rbhid, [In] ref Guid riid, [Out, MarshalAs(UnmanagedType.Interface)] out IntPtr ppvOut);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint GetParent([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint GetDisplayName([In] uint sigdnName, out IntPtr ppszName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint GetAttributes([In] uint sfgaoMask, out uint psfgaoAttribs);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        uint Compare([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi, [In] uint hint, out int piOrder);
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct COMDLG_FILTERSPEC
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszName;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszSpec;
    }
}

[Flags]
internal enum NIF : uint
{
    MESSAGE = 0x00000001,
    ICON = 0x00000002,
    TIP = 0x00000004,
    STATE = 0x00000008,
    INFO = 0x00000010,
    GUID = 0x00000020,
    REALTIME = 0x00000040,
    SHOWTIP = 0x00000080
}

[Flags]
internal enum NIIF : uint
{
    NONE = 0x00000000,
    INFO = 0x00000001,
    WARNING = 0x00000002,
    ERROR = 0x00000003,
    USER = 0x00000004,
    ICON_MASK = 0x0000000F,
    NOSOUND = 0x00000010,
    LARGE_ICON = 0x00000020,
    RESPECT_QUIET_TIME = 0x00000080
}

[Flags]
internal enum DropEffect : int
{
    None = 0,
    Copy = 1,
    Move = 2,
    Link = 4,
    Scroll = -2147483648,
}

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("00000122-0000-0000-C000-000000000046")]
internal interface IDropTarget
{
    [PreserveSig]
    UnmanagedMethods.HRESULT DragEnter([MarshalAs(UnmanagedType.Interface)][In] IOleDataObject pDataObj, [MarshalAs(UnmanagedType.U4)][In] int grfKeyState, [MarshalAs(UnmanagedType.U8)][In] long pt, [In][Out] ref DropEffect pdwEffect);
    [PreserveSig]
    UnmanagedMethods.HRESULT DragOver([MarshalAs(UnmanagedType.U4)][In] int grfKeyState, [MarshalAs(UnmanagedType.U8)][In] long pt, [In][Out] ref DropEffect pdwEffect);
    [PreserveSig]
    UnmanagedMethods.HRESULT DragLeave();
    [PreserveSig]
    UnmanagedMethods.HRESULT Drop([MarshalAs(UnmanagedType.Interface)][In] IOleDataObject pDataObj, [MarshalAs(UnmanagedType.U4)][In] int grfKeyState, [MarshalAs(UnmanagedType.U8)][In] long pt, [In][Out] ref DropEffect pdwEffect);
}

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("00000121-0000-0000-C000-000000000046")]
internal interface IDropSource
{
    [PreserveSig]
    int QueryContinueDrag(int fEscapePressed, [MarshalAs(UnmanagedType.U4)][In] int grfKeyState);
    [PreserveSig]
    int GiveFeedback([MarshalAs(UnmanagedType.U4)][In] int dwEffect);
}

[ComImport]
[Guid("0000010E-0000-0000-C000-000000000046")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IOleDataObject
{
    void GetData([In] ref FORMATETC format, out STGMEDIUM medium);
    void GetDataHere([In] ref FORMATETC format, ref STGMEDIUM medium);
    [PreserveSig]
    int QueryGetData([In] ref FORMATETC format);
    [PreserveSig]
    int GetCanonicalFormatEtc([In] ref FORMATETC formatIn, out FORMATETC formatOut);
    void SetData([In] ref FORMATETC formatIn, [In] ref STGMEDIUM medium, [MarshalAs(UnmanagedType.Bool)] bool release);
    IEnumFORMATETC EnumFormatEtc(DATADIR direction);
    [PreserveSig]
    int DAdvise([In] ref FORMATETC pFormatetc, ADVF advf, IAdviseSink adviseSink, out int connection);
    void DUnadvise(int connection);
    [PreserveSig]
    int EnumDAdvise(out IEnumSTATDATA enumAdvise);
}