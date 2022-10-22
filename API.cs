using System ;
using Microsoft.Win32 ;
using System.Drawing ;
using System.Collections ;
using System.ComponentModel ;
using System.Windows.Forms ;
using System.Data ;
using System.Data.Common ;
using System.Text ;
using System.IO ;
using System.Threading ;
using System.Runtime.InteropServices ;





namespace OutlookAmplifier
{
    public struct WindowMessage
	{
		public const int WM_App = 0x8000 ;
		public const int WM_NCActivate = 0x86;  //Message sent to the window when it's activated or deactivated
		public const int WM_IME_Notify = 0x282 ;//Notify IME Window message
		public const int WM_NCPaint = 0x85 ;
		public const int WM_ExitSizeMove = 0x0232 ;
		public const int WM_SetRedraw = 11 ;
		public const int BM_Click = 0x00F5 ;
		public const int EM_GetSel = 0x00B0 ;
		public const int EM_SetSel = 0x00B1 ;
		public const int WM_NCMouseMove = 0x00A0 ;
        public const int WM_NCMouseLeave =  0x02A2 ;
        public const int WM_NCLButtonDown = 0x00A1 ;  
        public const int WM_NCLButtonUp = 0x00A2 ;
        public const int WM_NCLButtontDblClk = 0x00A3 ;
        public const int WM_NCHitTest = 0x0084 ;
		public const int WM_Destroy = 2 ;
		public const int WM_Move = 0x3 ;
        public const int WM_WindowPosChanged = 0x0047 ;
		public const int WM_Size = 5 ;
		public const int WM_Sizing = 0x0214 ;
		public const int WM_Activate = 0x6 ;
		public const int WM_KillFocus = 0x8 ;
		public const int WM_Paint = 0xF ;
		public const int WM_Close = 0x10 ;
		public const int WM_CopyData = 0x004A ;
		public const int WM_ActivateApp = 0x1C ;
		public const int WM_EnterSizeMove = 0x0231 ;
        public const int WM_EraseBkgnd = 0x0014 ;
        public const int WM_EraseBackground = 0x0014 ;
		public const int WM_Print = 0x317 ;
        public const int WM_PrintClient = 0x318 ;
		public const int WM_HotKey = 786 ;
		public const int WM_InitDialog = 0x0110 ;
		public const int WM_Command = 0x0111 ;
		public const int WM_SysCommand = 0x0112 ;
		public const int WM_Timer = 0x0113 ;
		public const int WM_HScroll = 0x0114 ;
		public const int WM_VScroll = 0x0115 ;
		public const int WM_InitMenu = 0x0116 ;
		public const int WM_InitMenuPopUp = 0x0117 ;
		public const int WM_MeasureItem = 0x002C ;
		public const int WM_DrawItem = 0x002B ;
		public const int WM_ContextMenu = 123 ;
		public const int WM_MenuSelect = 0x011F ;
		public const int WM_MenuChar = 0x0120 ;
		public const int WM_EnterIdle = 0x0121 ;
		public const int SC_Size = 0xF000 ;
		public const int SC_Move = 0xF010 ;
		public const int SC_Minimize = 0xF020 ;
		public const int SC_Maxmimize = 0xF030 ;
		public const int SC_NextWindow = 0xF040 ;
		public const int SC_PrevWindow = 0xF050 ;
		public const int SC_Close = 0xF060 ;
		public const int SC_VScroll = 0xF070 ;
		public const int SC_HScroll = 0xF080 ;
		public const int SC_MouseMenu = 0xF090 ; 
		public const int SC_KeyMenu = 0xF100 ;
		public const int SC_Arrange = 0xF110 ;
		public const int SC_Restore = 0xF120 ; 
		public const int SC_TaskList = 0xF130 ;
		public const int SC_ScreenSave = 0xF140 ;
		public const int SC_HotKey = 0xF150 ;
		public const int SC_Default = 0xF160 ;
		public const int SC_MonitorPower = 0xF170 ;
		public const int SC_ContextHelp = 0xF180 ;
		public const int SC_Separator = 0xF00F ;

		public const int WM_ShowWindow = 0x0018 ;
		public const int SW_ParentClosing = 1 ;
		public const int SW_OtherZoom = 2 ;
		public const int SW_ParentOpening = 3 ;
		public const int SW_OtherUnzoom = 4 ;

		public const int MA_Activate = 1 ;
		public const int MA_ActivateANDEAT = 2 ;
		public const int MA_NoActivate = 3 ;
		public const int MA_NoActivateAndEAT = 4 ;
		
		public const int WA_Inactive = 0 ;
		public const int WA_Active = 1 ;
		public const int WA_ClickActive = 2 ;

		public const int MK_LButton = 0x0001 ;
		public const int MK_RButton = 0x0002 ;
		public const int MK_Shift = 0x0004 ;
		public const int MK_CCotrol = 0x0008 ;
		public const int MK_MButton = 0x0010 ;

		public const int WM_MouseActivate = 0x21 ;
		public const int WM_MouseFirst = 0x200 ;
		public const int WM_MouseLast = 0x209 ;
		public const int WM_MouseMove = 0x200 ;
		public const int WM_RButtonUp = 0x205 ;
		public const int WM_RButtonDown = 0x204 ;
		public const int WM_MouseWheel = 0x20A ;
		public const int WM_LButtonDown = 0x201 ;
		public const int WM_LButtonUp = 0x202 ;
		public const int WM_LButtonDblClk = 0x203 ;
		public const int WM_MButtonUp = 0x208 ;
		public const int WM_MDIActivate = 0x222 ;
		public const int WM_MDICascade = 0x227 ;
		public const int WM_MDICreate = 0x220 ;
		public const int WM_MDIDestroy = 0x221 ;
		public const int WM_MDIGetActive = 0x229 ;
		public const int WM_MButtonDblClk = 0x209 ;
		public const int WM_MButtonDown = 0x207 ;
        public const int WM_NCCalcSize = 0x0083 ;
        public const int WM_USER = 0x0400 ;
        public const int WM_Reflect = WM_USER + 0x1C00 ;

		public const int SMTO_Normal = 0x0 ;
		public const int SMTO_Block = 0x1 ;
		public const int SMTO_AbortIfHung = 0x2 ;

		public const int WM_Char = 128 ;
		public const int WM_KeyDown = 0x100 ;
		public const int WM_KeyFirst = 0x100 ;
		public const int WM_KeyLast = 0x108 ;
		public const int WM_KeyUp = 0x101 ;
	}
	public enum ShowWindowStyle
	{
		SW_Hide				= 0 ,
		SW_ShowNormal       = 1 ,
		SW_Normal           = 1 ,
		SW_ShowMinimized    = 2 ,
		SW_ShowMaximized    = 3 ,
		SW_Maximize         = 3 ,
		SW_ShowNoActivate   = 4 ,
		SW_Show             = 5 ,
		SW_Minimize         = 6 ,
		SW_ShowMinNoActive  = 7 ,
		SW_ShowNA           = 8 ,
		SW_Restore          = 9 ,
		SW_ShowDefault      =10 ,
		SW_ForceMinimize    =11 ,
		SW_Max              =11 ,
	}
	public struct API
	{

		public const int MaxPath = 260 ;

		public enum NCHitTestEnum : int  
		{
			Error = -1 ,
			Transparent = -1 ,
			Nowhere = 0 ,
			Client = 1 ,
			Caption = 2 ,
			SysMenu = 3 ,
			GrowBox = 4 ,
			Size = 4 ,
			Menu = 5 ,
			HScroll = 6 ,
			VScroll = 7 ,
			Reduce = 8 ,
			MinButton = 8 ,
			MaxButton = 9 ,
			Zoom = 9 ,
			Left = 10 ,
			Right = 11 ,
			Top = 12 ,
			Bottom = 15 ,
			Border = 18 ,
			BottomLeft = 16 ,
			BottomRight = 17 ,
			TopLeft = 13 ,
			TopRight = 14 ,
			Help = 21 
		}
			


		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
			public struct FileTime
		{
			public uint dwLowDateTime ;
			public uint dwHighDateTime ;
		}
		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
			public struct Win32FindData 
		{
			public uint dwFileAttributes ;
			public FileTime ftCreationTime ;
			public FileTime ftLastAccessTime ;
			public FileTime ftLastWriteTime ;
			public uint nFileSizeHigh ;
			public uint nFileSizeLow ;
			public uint dwReserved0 ;
			public uint dwReserved1 ;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=260)]
			public string cFileName ;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=14)]
			public string cAlternateFileName ;
		}

	/*
	 		Private Declare Function PlaySound Lib "winmm.dll" Alias "PlaySoundA" _
(ByVal lpszName As String, ByVal hModule As Long, ByVal dwFlags As Long) As Long
*/
		[DllImport("winmm.dll")]
		public static extern IntPtr PlaySoundA ( 
									string lpFileName ,
									int hModule , int dwFlags ) ;
		
		[DllImport("kernel32")]
		public static extern IntPtr FindFirstFileW ( 
									string lpFileName ,
									out Win32FindData lpFindFileData ) ;
		[DllImport("kernel32", CharSet=CharSet.Unicode)] 
		public static extern IntPtr FindFirstFile ( string lpFileName , out Win32FindData lpFindFileData ) ;
		public static IntPtr FindFirstFileBefore ( string FileName , DateTime BeforeDate , out Win32FindData Data ) 
		{
			IntPtr pt = FindFirstFile ( FileName , out Data ) ;
			IntPtr p1 = new IntPtr ( -1 ) ;
			if ( pt != p1 )
			{
				if ( Win32FindDataCreated ( Data ) >= BeforeDate  )
					if ( !FindNextFileBefore ( pt , BeforeDate , out Data )  )
					{
						FindClose ( pt ) ;
						pt = p1 ;
					}
				return pt ;
			}
			return pt ;
		}
		public static bool FindNextFileBefore ( IntPtr hFindFile , DateTime BeforeDate , out Win32FindData Data ) 
		{
			if ( FindNextFile ( hFindFile , out Data ) )
			{
				while ( Win32FindDataCreated ( Data ) >= BeforeDate )
					if ( !FindNextFile ( hFindFile , out Data ) ) return false ;
				return true ;
			}
			return false ;
		}

		public static DateTime Win32FindDataCreated ( Win32FindData data )
		{
			return FileTime2Date ( 
							data.ftCreationTime.dwHighDateTime ,
							data.ftCreationTime.dwLowDateTime ) ;
		}
		public static long HiLo2Long ( uint High , uint Low )
		{
			long l = High ;
			l = l << 32 ;
			return l + Low ;
		}
		public static DateTime HiLo2Date ( uint High , uint Low )
		{
			return new DateTime ( HiLo2Long ( High , Low ) ) ;
		}
		public static DateTime FileTime2Date ( uint High , uint Low )
		{
			return DateTime.FromFileTime  ( HiLo2Long ( High , Low )  ) ;
		}
		[DllImport("kernel32.dll", CharSet=CharSet.Auto)]
		public static extern bool FindNextFile ( IntPtr hFindFile , out Win32FindData lpFindFileData) ;

		public enum FindExInfoLevels
		{
			FindExInfoStandard = 0
		}
		public enum FindExSearchOps
		{
			FindExSearchNameMatch = 0 ,
			FindExSearchLimitToDirectories = 1 ,
			FindExSearchLimitToDevices = 2 ,
			FindExSearchMaxSearchOp = 3
		} 



		[DllImport("kernel32.dll")]
		public static extern IntPtr FindFirstFileEx ( string lpFileName , 
				FindExInfoLevels fInfoLevelId , 
				IntPtr lpFindFileData , 
				FindExSearchOps fSearchOp ,
				IntPtr lpSearchFilter , uint dwAdditionalFlags ) ;

		[DllImport("kernel32.dll")]
		public static extern bool FindClose (IntPtr hFindFile ) ;


		[DllImport("kernel32")]
		public static extern IntPtr GlobalAddAtomW ( StringBuilder lpString ) ;
		public static int GlobalAddAtomW ( string lpString )
		{
			int Size = lpString.Length + 1 ;
			IntPtr ret = GlobalAddAtomW ( new StringBuilder ( lpString ) ) ;
			return ret.ToInt32 () ;
		}
		[DllImport("kernel32")]
		public static extern IntPtr GlobalDeleteAtom ( IntPtr nAtom ) ;
		public static int GlobalDeleteAtom ( int nAtom ) 
		{
			return GlobalDeleteAtom ( new IntPtr ( nAtom ) ).ToInt32 () ;
		}
		[DllImport("kernel32")]
		public static extern IntPtr GlobalGetAtomNameW ( IntPtr nAtom , StringBuilder Buffer , IntPtr Size ) ;
		public static string GlobalGetAtomNameW ( int Atom ) 
		{
			IntPtr nAtom = new IntPtr ( Atom ) ;
			StringBuilder Buffer = new StringBuilder ( 255 , 255 ) ;
			nAtom = GlobalGetAtomNameW ( nAtom , Buffer , new IntPtr ( 255 ) ) ;
			return Buffer.ToString ( 0 , nAtom.ToInt32 () ) ;

		}

		public const int MOD_ALT = 1 ;
		public const int MOD_CONTROL = 2 ;
		public const int MOD_SHIFT = 4 ;
		public const int MOD_WIN = 8 ;
		[DllImport("user32")]
		public static extern bool RegisterHotKey ( IntPtr hWnd , IntPtr id , IntPtr fsModifiers , IntPtr vk ) ;
		public static bool RegisterHotKey ( int hWnd , int id , int fsModifiers , VK vk) 
		{
			return RegisterHotKey ( new IntPtr ( hWnd ) , new IntPtr ( id ) , 
					new IntPtr ( fsModifiers ) , new IntPtr ( ( int ) vk ) ) ;
		}
		[DllImport("user32")]
		public static extern bool UnregisterHotKey ( IntPtr hWnd , IntPtr id ) ;
		public static bool UnregisterHotKey ( int hWnd , int id ) 
		{
			return UnregisterHotKey  ( new IntPtr ( hWnd ) , new IntPtr ( id ) ) ;
		}

		



		public enum WindowStyle 
		{
			OverLapped = 0x00000000 , 
			PopUp =  unchecked ( ( int ) 0x80000000 ) ,
			Child = 0x40000000 ,
			Minimize = 0x20000000 , 
			Visible = 0x10000000 , 
			Disabled = 0x08000000 , 
			ClipSibling = 0x04000000 , 
			ClipChildren = 0x02000000 , 
			Maximize = 0x01000000 , 
			Border = 0x00800000 , 
			DlgFrame = 0x00400000 , 
			Caption = Border | DlgFrame ,
			VScroll = 0x00200000 , 
			HScroll = 0x00100000 , 
			SysMenu = 0x00080000 , 
			ThickFrame = 0x00040000 , 
			Group = 0x00020000 , 
			TabStop = 0x00010000 , 
			MinimizeBox = 0x00020000 , 
			MaximizeBox = 0x00010000 , 
			Tiled = OverLapped ,
			Iconic = Minimize ,
			SizeBox = ThickFrame ,
			OverLappedWindow = OverLapped | 
				Caption | SysMenu | ThickFrame | 
				MinimizeBox | MaximizeBox ,
			TiledWindow = OverLappedWindow ,
			PopUpWindow = PopUp | Border | SysMenu ,
			ChildWindow = Child
		}
		public enum WindowExStyle
		{
			DlgModalFrame = 0x00000001 ,
			NoParentNotify = 0x00000004 ,
			TopMost = 0x00000008 ,
			AcceptFiles = 0x00000010 ,
			Transparent = 0x00000020 ,
			MDIChild = 0x00000040 ,
			ToolWindow = 0x00000080 ,
			WindowEdge = 0x00000100 ,
			ClientEdge = 0x00000200 ,
			ContextHelp = 0x00000400 ,
			Right = 0x00001000 ,
			Left = 0x00000000 ,
			RtlReading = 0x00002000 ,
			LtrReading = 0x00000000 ,
			LeftScrollbar = 0x00004000 ,
			RightScrollBar = 0x00000000 ,
			ControlParent = 0x00010000 ,
			StaticEdge = 0x00020000 ,
			AppWindow = 0x00040000 ,
			OverlapWindow = WindowEdge | ClientEdge ,
			PalleteWindow = WindowEdge | ToolWindow | TopMost
		}
        public const int ASFW_ANY = -1 ;
        [DllImport("user32.dll", SetLastError=true)]
        public static extern bool AllowSetForegroundWindow ( int dwProcessId ) ;
		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr SetForegroundWindow ( IntPtr hWnd ) ;
		public static int SetForegroundWindow ( int hWnd ) 
		{
			return SetForegroundWindow ( new IntPtr ( hWnd ) ).ToInt32 () ;
		}

		[DllImport("Kernel32.dll", SetLastError=true)]
		public static extern IntPtr GetProcessIdOfThread ( IntPtr thr ) ;

		[DllImport("user32.dll", SetLastError=true)]
		public static extern bool AttachThreadInput ( 
			uint idAttach , uint idAttachTo , bool fAttach ) ;

		[DllImport("user32",EntryPoint="GetForegroundWindow",SetLastError=true)]
		public static extern IntPtr GetForegroundWindowProc ( ) ;
		public static int GetForegroundWindow ( ) 
		{
			return GetForegroundWindowProc ().ToInt32 () ;
		}
		[DllImport("user32",EntryPoint="BringWindowToTop",SetLastError=true)]
		public static extern bool BringWindowToTop ( IntPtr hWnd ) ;
		[DllImport("user32",EntryPoint="BringWindowToTop",SetLastError=true)]
		public static extern bool BringWindowToTop ( int hWnd ) ;

		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr SetActiveWindow ( IntPtr hWnd ) ;
		public static int SetActiveWindow ( int hWnd ) 
		{
			return SetActiveWindow ( new IntPtr ( hWnd ) ).ToInt32 () ;
		}
		[DllImport("user32",EntryPoint="GetActiveWindow")]
		public static extern IntPtr GetActiveWindowProc ( ) ;
		public static int GetActiveWindow ( ) 
		{
			IntPtr p = GetActiveWindowProc ( ) ;
			return p.ToInt32 () ;
		}
		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr SetFocus ( IntPtr hWnd ) ;
		public static int SetFocus ( int hWnd ) 
		{
			return SetFocus ( new IntPtr ( hWnd ) ).ToInt32 () ;
		}
		[DllImport("user32",EntryPoint="GetFocus")]
		public static extern IntPtr GetFocusProc ( ) ;
		public static int GetFocus ( ) 
		{
			return GetFocusProc ( ).ToInt32 () ;
		}
		[DllImport("user32",EntryPoint="GetDesktopWindow")]
		public static extern IntPtr GetDesktopWindowProc ( ) ;
		public static int GetDesktopWindow ( ) 
		{
			IntPtr p = GetDesktopWindowProc ( ) ;
			return p.ToInt32 () ;
		}
		[DllImport("user32.dll")]
		public static extern IntPtr WindowFromPoint ( APIPoint Point ) ;
		[DllImport("user32")]
		public static extern IntPtr GetWindowDC ( IntPtr hWnd ) ;
		public static int GetWindowDC ( int hWnd ) 
		{
			IntPtr p = new IntPtr ( hWnd ) ;
			p = GetWindowDC ( p ) ;
			return p.ToInt32 () ;
		}
        [DllImport("GDI32.dll")]
        public static extern int GetDeviceCaps ( int hdc , int nIndex ) ;

		[DllImport("user32.dll")]
		public static extern bool LockWindowUpdate ( IntPtr hWndLock ) ;
		[DllImport("user32.dll")]
		public static extern bool InvalidateRect ( IntPtr hWnd , API.APIRect lpRect , bool bErase ) ;
		[DllImport("user32.dll")]
		public static extern bool InvalidateRect ( IntPtr hWnd , ref API.APIRect lpRect , bool bErase ) ;
		[DllImport("user32.dll")]
		public static extern bool InvalidateRect ( int hWnd , ref API.APIRect lpRect , bool bErase ) ;
		[DllImport("user32.dll")]
		public static extern bool InvalidateRect ( IntPtr hWnd , IntPtr lpRect , bool bErase ) ;
		[DllImport("user32.dll")]
		public static extern bool InvalidateRect ( int hWnd , IntPtr lpRect , bool bErase ) ;

		//BOOL GetTextExtentPoint32(
		[DllImport("gdi32", EntryPoint="GetTextExtentPoint32W", CharSet=CharSet.Unicode, SetLastError=true)]
		public static extern bool GetTextExtentPoint32 ( IntPtr hDC , string Str , 
											IntPtr CharSize , ref APIPoint SizePtr ) ;
		/*
		public static bool GetTextExtentPoint32 ( IntPtr hDC , String Str , 
			IntPtr CharSize , ref APIPoint Size ) 
		{
			unsafe
			{
				byte [] w = new byte [8] ;
				IntPtr SizePtr = new IntPtr ( w ) ;
				bool b = GetTextExtentPoint32 ( hDC , Str , CharSize , ref SizePtr ) ;
				byte w0 = w[0] ;
				byte w1 = w[1] ;
				byte w2 = w[2] ;
				byte w3 = w[3] ;
				byte w4 = w[4] ;
				byte w5 = w[5] ;
				byte w6 = w[6] ;
				byte w7 = w[7] ;
				return b ;
			}
		}*/
 
		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr GetDC ( IntPtr hWnd ) ;
		public static int GetDC ( int hWnd ) 
		{
			return GetDC ( new IntPtr ( hWnd ) ).ToInt32 () ;
		}

		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr ReleaseDC ( IntPtr hWnd , IntPtr hDC ) ;
		public static int ReleaseDC ( int hWnd , int hDC ) 
		{
			return ReleaseDC ( new IntPtr ( hWnd ) , new IntPtr ( hDC ) ).ToInt32 () ;
		}


		[DllImport("gdi32", SetLastError=true)]
		public static extern IntPtr SelectObject ( IntPtr hDC , IntPtr hgdiobj ) ;
		public static int SelectObject ( int hDC , int hgdiobj ) 
		{
			return SelectObject ( new IntPtr ( hDC ) , new IntPtr ( hgdiobj ) ).ToInt32 () ;
		}

		public enum StockObjects
		{
			WhiteBrush = 0 ,
			LightGrayBrush = 1 ,
			GrayBrush = 2 ,
			DarkGrayBrush = 3 ,
			BlackBrush = 4 ,
			BullBrushh = 5 ,
			HollowBrush = 5 ,
			BlackPen = 7 ,
			Whiteness = 0xFF0062 ,
			OEMFixedFont = 10 ,
			AnsiFIxedFont = 11 ,
			ANSIVarFont = 12 ,
			SystemFont = 13 ,
			DeviceDefaultFont = 14 ,
			DefaultPallete = 15 ,
			SystemFixedFont = 16 ,
			DefaultGUIFont = 17 
		}

		[ StructLayout  ( LayoutKind.Sequential , CharSet=CharSet.Auto ) ] 
		public class LogFon
		{
        
            public int lfHeight = 0 ;
            public int lfWidth = 0 ;
            public int lfEscapement = 0 ;
            public int lfOrientation = 0 ;
            public int lfWeight = 0 ;
            public byte lfItalic = 0 ;
            public byte lfUnderline = 0 ;
            public byte lfStrikeOut = 0 ;
            public byte lfCharSet = 0 ;
            public byte lfOutPrecision = 0 ;
            public byte lfClipPrecision = 0 ;
            public byte lfQuality = 0 ;
            public byte lfPitchAndFamily = 0 ;
            [ MarshalAs  (  UnmanagedType.ByValTStr , SizeConst=32 ) ] 
			public string lfFaceName = null ;
         }


		[DllImport("gdi32")]
		public static extern IntPtr FillRect ( IntPtr hDC , ref APIRect Rect , IntPtr Brush) ;
		public static int FillRect ( int hDC , ref APIRect Rect , int Brush ) 
		{
			return FillRect ( new IntPtr (  hDC ) , ref Rect , new  IntPtr ( Brush ) ) .ToInt32 () ;
		}
		[DllImport("gdi32")]
		public static extern IntPtr GetStockObjectProc( IntPtr StockObjectConst ) ;
		public static IntPtr GetStockObject ( StockObjects StockObjectConst ) 
		{
			return GetStockObjectProc ( new IntPtr ( ( int ) StockObjectConst) ) ;
		}
		public static int GetStockObjectI ( StockObjects StockObjectConst ) 
		{
			return GetStockObjectProc ( new IntPtr ( ( int ) StockObjectConst ) ).ToInt32 () ;
		}
 
		[DllImport("gdi32")]
		public static extern IntPtr DeleteDC ( IntPtr hDC ) ;
		public static int DeleteDC ( int hDC ) 
		{
			IntPtr p = new IntPtr ( hDC ) ;
			p = DeleteDC ( p ) ;
			return p.ToInt32 () ;
		}
		[DllImport("gdi32")]
		public static extern IntPtr ReleaseDC ( IntPtr hDC ) ;
		public static int ReleaseDC ( int hDC ) 
		{
			IntPtr p = new IntPtr ( hDC ) ;
			p = ReleaseDC ( p ) ;
			return p.ToInt32 () ;
		}

		[DllImport("gdi32",EntryPoint="CreateCompatibleDC")]
		public static extern IntPtr CreateCompatibleDC ( IntPtr hDC ) ;
		public static int CreateCompatibleDC ( int hDC ) 
		{
			IntPtr p = new IntPtr ( hDC ) ;
			p = CreateCompatibleDC ( p ) ;
			return p.ToInt32 () ;
		}
		[DllImport("gdi32",EntryPoint="CreateCompatibleBitmap")]
		public static extern IntPtr CreateCompatibleBitMap 
						( IntPtr hDC , IntPtr nWidth , IntPtr nHeight ) ;
		public static int CreateCompatibleBitMap 
						( int hDC , int nWidth , int nHeight ) 
		{
			IntPtr p = new IntPtr ( hDC ) ;
			IntPtr w = new IntPtr ( nWidth ) ;
			IntPtr h = new IntPtr ( nHeight ) ;
			p = CreateCompatibleBitMap ( p , w , h ) ;
			return p.ToInt32 () ;
		}
		public enum RasterOpConstants
		{
			vbDstInvert = 5570569 ,
			vbMergeCopy = 12583114 ,
			vbMergePaint = 12255782 ,
			vbNotSrcCopy = 3342344 ,
			vbNotSrcErase = 1114278 ,
			vbPatCopy = 15728673 ,
			vbPatInvert = 5898313 ,
			vbPatPaint = 16452105 ,
			vbSrcAnd = 8913094 ,
			vbSrcCopy = 13369376 ,
			vbSrcErase = 4457256 ,
			vbSrcInvert = 6684742 ,
			vbSrcPaint = 15597702 
		}
		[DllImport("gdi32")]
		public static extern IntPtr BitBlt ( IntPtr hDCDest , IntPtr XDest , IntPtr YDest , 
											IntPtr nWidth , IntPtr nHeight , IntPtr SourceDC , 
											IntPtr XSrc , IntPtr YSrc , IntPtr dwRop ) ;
		public static int BitBlt ( int hDCDest , int XDest , int YDest , 
											int nWidth , int nHeight , int SourceDC , 
											int XSrc , int YSrc , RasterOpConstants dwRop ) 
		{
			IntPtr p = new IntPtr ( hDCDest ) ;
			IntPtr xd = new IntPtr ( XDest ) ;
			IntPtr xy = new IntPtr ( YDest ) ;
			IntPtr w = new IntPtr ( nWidth ) ;
			IntPtr h = new IntPtr ( nHeight ) ;
			IntPtr d = new IntPtr ( SourceDC ) ;
			IntPtr xs = new IntPtr ( XSrc ) ;
			IntPtr ys = new IntPtr ( YSrc ) ;
			IntPtr r = new IntPtr ( (int) dwRop ) ;
			return BitBlt  ( p , xd, xy , w , h , d , xs , ys , r ).ToInt32 () ;
		}
		public static int BitBlt ( int hDCDest , int XDest , int YDest , 
									int nWidth , int nHeight , int SourceDC , 
									int XSrc , int YSrc ) 
		{
			return BitBlt ( hDCDest , XDest , YDest , nWidth , nHeight , 
							SourceDC , XSrc , YSrc , RasterOpConstants.vbSrcCopy ) ;
		}
		public static int BitBlt ( int hDCDest , int XDest , int YDest , 
								int nWidth , int nHeight , int SourceDC )
		{
			return BitBlt ( hDCDest , XDest , YDest , nWidth , nHeight , 
							SourceDC , 0 , 0 , RasterOpConstants.vbSrcCopy ) ;
		}
		public static int BitBlt ( int hDCDest , int nWidth , int nHeight , int SourceDC )
		{
			return BitBlt ( hDCDest , 0 , 0 , nWidth , nHeight , 
								SourceDC , 0 , 0 , RasterOpConstants.vbSrcCopy ) ;
		}

		public enum DCObject
		{
			Pen = 1 ,
			Brush = 2 ,
			Pallete = 5 ,
			Font = 6 ,
			BitMap = 7 ,
		}
		[DllImport("gdi32")]
		public static extern IntPtr GetCurrentObject ( IntPtr hWnd , IntPtr ObjectType ) ;
		public static IntPtr GetCurrentObject ( IntPtr hWnd , DCObject ObjectType ) 
		{
			return GetCurrentObject ( hWnd , new IntPtr ( ( int ) ObjectType ) ) ;
		}
		public static int GetCurrentObject ( int hWnd , DCObject ObjectType ) 
		{
			return GetCurrentObject ( new IntPtr ( hWnd ) , 
				new IntPtr ( ( int ) ObjectType ) ).ToInt32 () ;
		}
		
		[DllImport("user32")]
		public static extern IntPtr SetCapture ( IntPtr hWnd ) ;
		public static int SetCapture ( int hWnd ) 
		{
			return SetCapture ( new IntPtr ( hWnd ) ).ToInt32 () ;
		}
		[DllImport("user32",EntryPoint="GetCapture")]
		public static extern IntPtr GetCaptureProc ( ) ;
		public static int GetCapture ( ) 
		{
			return GetCaptureProc ().ToInt32 () ;
		}
		[DllImport("user32")]
		public static extern bool ReleaseCapture ( ) ;
		[DllImport("user32")]
		private static extern int CreateWindowExA ( int dwExStyle ,  
						StringBuilder lpClassName , StringBuilder lpWindowName , 
						int dwStyle , int x , int y , int nWidth , int nHeight , 
						int hWndParent , int hMenu , int hInstance , int lpParam ) ;

		public static int CreateWindowExA ( WindowExStyle dwExStyle ,  
			string lpClassName , string lpWindowName , 
			WindowStyle dwStyle , int x , int y , int nWidth , int nHeight , 
			int hWndParent , int hMenu , int hInstance , int lpParam ) 
		{
			try
			{
				StringBuilder ClassName ;
				StringBuilder WindowName ;
				int Size ;
				if ( lpClassName == null )
					ClassName = null ;
				else
				{
					Size = lpClassName.Length + 1 ;
					ClassName = new StringBuilder ( Size , Size ) ;
				}
				if ( lpWindowName == null )
					WindowName = null ;
				else
				{
					Size = lpWindowName.Length + 1 ;
					WindowName = new StringBuilder ( Size , Size ) ;
				}
				return CreateWindowExA ( unchecked ( ( int ) dwExStyle ) ,  
										ClassName , WindowName , 
										unchecked ( ( int ) dwStyle ) ,  
										x , y , nWidth , nHeight ,
										hWndParent , hMenu , hInstance , lpParam ) ;

			}
			catch {}
			return 0 ;
		}

		[DllImport("gdi32")]
		public static extern IntPtr CreateRoundRectRgn 
					( IntPtr LeftCo , IntPtr TopCo , 
						IntPtr RightCo , IntPtr BottomCo , 
						IntPtr rWidth , IntPtr rHeight ) ;
		public static int CreateRoundRectRgn 
					( int LeftCo , int TopCo , 
						int RightCo , int BottomCo , 
						int rWidth , int rHeight ) 
		{
			return CreateRoundRectRgn ( 
					new IntPtr ( LeftCo ) ,
					new IntPtr ( TopCo ) ,
					new IntPtr ( RightCo ) ,
					new IntPtr ( BottomCo ) ,
					new IntPtr ( rWidth ) ,
					new IntPtr ( rHeight ) ).ToInt32 () ;
		}
		public const int DFC_BUTTON = 4 ;
		public const int DFC_CAPTION = 1 ;
		public const int DFC_MENU = 2 ;
		public const int DFC_SCROLL = 3 ;
		public const int DFCS_ADJUSTRECT = 0x2000 ;
		public const int DFCS_BUTTON3STATE = 0x8 ;
		public const int DFCS_BUTTONCHECK = 0x0 ;
		public const int DFCS_BUTTONPUSH = 0x10 ;
		public const int DFCS_BUTTONRADIO = 0x4 ;
		public const int DFCS_BUTTONRADIOIMAGE = 0x1 ;
		public const int DFCS_BUTTONRADIOMASK = 0x2 ;
		public const int DFCS_CAPTIONCLOSE = 0x0 ;
		public const int DFCS_CAPTIONHELP = 0x4 ;
		public const int DFCS_CAPTIONMAX = 0x2 ;
		public const int DFCS_CAPTIONMIN = 0x1 ;
		public const int DFCS_CAPTIONRESTORE = 0x3 ;
		public const int DFCS_CHECKED = 0x400 ;
		public const int DFCS_FLAT = 0x4000 ;
		public const int DFCS_INACTIVE = 0x100 ;
		public const int DFCS_MENUARROW = 0x0 ;
		public const int DFCS_MENUARROWRIGHT = 0x4 ;
		public const int DFCS_MENUBULLET = 0x2 ;
		public const int DFCS_MENUCHECK = 0x1 ;
		public const int DFCS_MONO = 0x8000 ;
		public const int DFCS_PUSHED = 0x200 ;
		public const int DFCS_SCROLLCOMBOBOX = 0x5 ;
		public const int DFCS_SCROLLDOWN = 0x1 ;
		public const int DFCS_SCROLLLEFT = 0x2 ;
		public const int DFCS_SCROLLRIGHT = 0x3 ;
		public const int DFCS_SCROLLSIZEGRIP = 0x8 ;
		public const int DFCS_SCROLLSIZEGRIPRIGHT = 0x10 ;
		public const int DFCS_SCROLLUP = 0x0 ;		
		[DllImport("user32.dll")]
		public static extern IntPtr DrawFrameControl ( IntPtr hdc ,
			ref APIRect Rect , IntPtr un1 , IntPtr un2 ) ;
		public static IntPtr DrawFrameControl ( IntPtr hdc ,
			APIRect Rect , int un1 , int un2 ) 
		{
			IntPtr p1 = new IntPtr ( un1 ) ;
			IntPtr p2 = new IntPtr ( un2 ) ;
			return DrawFrameControl ( hdc , ref Rect , p1 , p2 ) ;
		}

        //[DllImport("user32.dll")]
        //static extern bool RedrawWindow ( IntPtr hWnd, [In] ref APIRect lprcUpdate, IntPtr hrgnUpdate , RedrawWindowFlags flags ) ;

        //[DllImport("user32.dll")]
        //static extern bool RedrawWindow ( IntPtr hWnd , IntPtr lprcUpdate , IntPtr hrgnUpdate , RedrawWindowFlags flags ) ; 


        [DllImport("user32")]
		public static extern IntPtr SetWindowRgn ( IntPtr hWnd , IntPtr hRgn , bool bRedraw ) ;
		public static int SetWindowRgn ( int hWnd , int hRgn , bool bRedraw ) 
		{
			return SetWindowRgn ( new IntPtr ( hWnd ) , new IntPtr ( hRgn ) , bRedraw ).ToInt32 ()  ;
		}
		public static int SetWindowRgn ( IntPtr hWnd , int hRgn , bool bRedraw ) 
		{
			return SetWindowRgn ( hWnd , new IntPtr ( hRgn ) , bRedraw ).ToInt32 ()  ;
		}




		[DllImport("gdi32")]
		public static extern IntPtr DeleteObject ( IntPtr hWnd ) ;
		public static int DeleteObject ( int hWnd ) 
		{
			return DeleteObject ( new IntPtr ( hWnd ) ).ToInt32 () ;
		}

		public enum GWL
		{
			WndProc = (-4) ,
			HInstance = (-6) ,
			HWndParent = (-8) ,
			Style = (-16) ,
			ExStyle = (-20) ,
			UserData = (-21) ,
			ID = -12 
		}

		public enum ScrollBarDirection
		{
			SB_HORZ = 0x0 ,
			SB_VERT = 0x1
		}

		[DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		public static extern int GetScrollPos ( int hWnd , int nBar ) ;
		[DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		public static extern IntPtr GetScrollPos ( IntPtr hWnd , IntPtr nBar ) ;
		public static IntPtr GetScrollPos ( IntPtr hWnd , ScrollBarDirection sb ) 
		{
			return GetScrollPos ( hWnd , new IntPtr ( ( int ) sb ) ) ;
		}
		public static int GetScrollPos ( int hWnd , ScrollBarDirection sb ) 
		{
			return GetScrollPos ( hWnd , ( int ) sb ) ;
		}

		[DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		public static extern int SetScrollPos ( int hWnd , int nBar , int Pos , bool redraw ) ;
		[DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		public static extern IntPtr SetScrollPos ( IntPtr hWnd , IntPtr nBar , IntPtr Pos , bool redraw ) ;
		public static IntPtr SetScrollPos ( IntPtr hWnd , ScrollBarDirection sb , int Pos , bool redraw ) 
		{
			return SetScrollPos ( hWnd , new IntPtr ( ( int ) sb ) , new IntPtr ( Pos ) , redraw ) ;
		}


		[DllImport("user32")]
		private static extern IntPtr GetWindowLong ( IntPtr hWnd , IntPtr nIndex ) ;
		public static int GetWindowLong ( int hWnd , GWL nIndex ) 
		{
			return GetWindowLong ( new IntPtr ( hWnd ) , new IntPtr ( ( int ) nIndex ) ).ToInt32 () ;
		}
		public static int GetWindowLong ( IntPtr hWnd , GWL nIndex ) 
		{
			return GetWindowLong ( hWnd , new IntPtr ( ( int ) nIndex ) ).ToInt32 () ;
		}
		[DllImport("user32")]
		private static extern IntPtr SetWindowLong ( IntPtr hWnd , IntPtr nIndex , IntPtr NewValue ) ;
		public static IntPtr SetWindowLong ( IntPtr hWnd , GWL nIndex , IntPtr NewValue ) 
		{
			return SetWindowLong ( hWnd , new IntPtr ( ( int ) nIndex ) , NewValue ) ;
		}
		public static IntPtr SetWindowLong ( IntPtr hWnd , GWL nIndex , int NewValue ) 
		{
			return SetWindowLong ( hWnd , new IntPtr ( ( int ) nIndex ) , new IntPtr ( NewValue ) ) ;
		}
		public static int SetWindowLong ( int hWnd , GWL nIndex , int NewValue ) 
		{
			return SetWindowLong ( new IntPtr ( hWnd ) , new IntPtr ( ( int ) nIndex ) , new IntPtr ( NewValue ) ).ToInt32 () ;
		}
		[DllImport("user32")]
		public static extern IntPtr SetLayeredWindowAttributes ( IntPtr hWnd , IntPtr crKey , byte Alpha , IntPtr dwFlags ) ;
		public static int SetLayeredWindowAttributes ( IntPtr hWnd , int crKey , byte Alpha , int dwFlags ) 
		{
			return SetLayeredWindowAttributes ( hWnd , new IntPtr ( crKey ) , Alpha , new IntPtr ( dwFlags ) ).ToInt32 () ;
		}

		public static RegistryKey OpenNextKey ( RegistryKey Key , string SubKeyName )
		{
			RegistryKey Ret = Key.OpenSubKey ( SubKeyName ) ;
			Key.Close () ;
			return Ret ;
		}

		public enum ShowCommand
		{
			Hide = 0 ,
			ShowNormal = 1 ,
			ShowMinimized = 2,
			Maximize = 3 ,
			ShowMaximized = 3,
			ShowNoActivate = 4 ,
			Show = 5 ,
			Minimize = 6 ,
			ShowMinNoActivate = 7 ,
			ShowNA = 8 ,
			Restore = 9 
		}
		public enum ShowFlags
		{
			None = 0 ,
			SetMinPosition = 1 ,
			RestoreMaximized = 2 ,
			SetMinPosAndResMax = 3
		}
		public struct APIRect
		{
			public int Left ;
			public int Top ;
			public int Right ;
			public int Bottom ;
		}
		public struct APIPoint
		{
			public int x ;
			public int y ;
		}
        [StructLayout(LayoutKind.Sequential)]
		public struct WindowPos
		{
            public IntPtr hwnd ;
            public IntPtr hWndInsertAfter ;
            public int x ;
            public int y ;
            public int cx ;
            public int cy ;
            public int flags ;
		}
		public struct WindowPlacement
		{
			public int Length ;		// allways  44
			public ShowFlags Flags ;
			public ShowCommand Command ;
			public APIPoint MinPosition ;
			public APIPoint MaxPosition ;
			public APIRect NormalPosition ;
		}
		public enum WindowRelation
		{
			First = 0 ,
			Last = 0 ,
			Next = 2 ,
			Prev = 3 ,
			Owner = 4 ,
			Child = 5 
		}

		[DllImport("user32", SetLastError=true )]
		public static extern int GetDoubleClickTime ( ) ;

		[DllImport("kernel32", SetLastError=true )]
		public static extern int GetTickCount ( ) ;

		[DllImport("user32", SetLastError=true, CharSet=CharSet.Ansi )]
		public static extern int GetWindowTextA ( int hWnd , StringBuilder WindowText , int Size ) ;
		[DllImport("user32", SetLastError=true, CharSet=CharSet.Ansi )]
		public static extern int GetWindowTextA ( IntPtr hWnd , StringBuilder WindowText , int Size ) ;

		[DllImport("user32", SetLastError=true, CharSet=CharSet.Unicode )]
		public static extern int GetWindowTextW ( int hWnd , StringBuilder WindowText , int Size ) ;
		[DllImport("user32", SetLastError=true, CharSet=CharSet.Unicode )]
		public static extern int GetWindowTextW ( IntPtr hWnd , StringBuilder WindowText , int Size ) ;

		public static string GetWindowTextW ( int hWnd , int Size ) 
		{
			string s = "" ;
			try
			{
				StringBuilder Buffer ;
				Buffer = new StringBuilder ( Size + 1 , Size + 1) ;
				int i = GetWindowTextW ( hWnd , Buffer , Size ) ;
				s = Buffer.ToString () ;
			}
			catch {}
			return s ;
		}
		public static string GetWindowTextW ( IntPtr hWnd ) 
		{
			string s = "" ;
            int Size = 1023 ;
			try
			{
				StringBuilder Buffer ;
				Buffer = new StringBuilder ( Size + 1 , Size + 1) ;
				int i = GetWindowTextW ( hWnd , Buffer , Size ) ;
				s = Buffer.ToString () ;
			}
			catch {}
			return s ;
		}

		public delegate bool EnumWindowsCallBack ( IntPtr hwnd , IntPtr lParam ) ;

		[DllImport("user32")]
		public static extern int EnumWindows ( EnumWindowsCallBack Proc , int Param ); 

		[DllImport("user32", SetLastError=true, CharSet=CharSet.Ansi )]
		public static extern IntPtr SendMessageA ( IntPtr hWnd , IntPtr wMsg , IntPtr wParam , ref APIRect rect ) ;
		public static IntPtr SendMessageA ( IntPtr hWnd , int wMsg , IntPtr wParam , ref APIRect rect )
		{
			return SendMessageA ( hWnd , new IntPtr ( wMsg ) , wParam , ref rect ) ;
		}
		public static IntPtr SendMessageA ( IntPtr hWnd , int wMsg , int wParam , ref APIRect rect )
		{
			return SendMessageA ( hWnd , new IntPtr ( wMsg ) , new IntPtr ( wParam ) , ref rect ) ;
		}
		public static int SendMessageA ( int hWnd , int wMsg , int wParam , ref APIRect rect )
		{
			return SendMessageA ( new IntPtr ( hWnd ) , new IntPtr ( wMsg ) , new IntPtr ( wParam ) , ref rect ).ToInt32 () ;
		}

		[DllImport("user32", SetLastError=true, CharSet=CharSet.Ansi )]
		public static extern IntPtr SendMessageA ( IntPtr hWnd , IntPtr wMsg , IntPtr wParam , IntPtr lParam ) ;
		public static int SendMessageA ( int hWnd , int wMsg , int wParam , int lParam ) 
		{
			return SendMessageA ( new IntPtr ( hWnd ) , new IntPtr ( wMsg ) , new IntPtr ( wParam ) , new IntPtr ( lParam ) ).ToInt32 () ;
		}
		public static int SendMessageA ( IntPtr hWnd , int wMsg , IntPtr wParam , IntPtr lParam ) 
		{
			return SendMessageA ( hWnd , new IntPtr ( wMsg ) , wParam , lParam ).ToInt32 () ;
		}

		[DllImport("user32", SetLastError=true, CharSet=CharSet.Unicode )]
		public static extern IntPtr SendMessageW ( IntPtr hWnd , IntPtr wMsg , IntPtr wParam , IntPtr lParam ) ;
		public static int SendMessageW ( int hWnd , int wMsg , int wParam , int lParam ) 
		{
			return SendMessageW ( new IntPtr ( hWnd ) , new IntPtr ( wMsg ) , new IntPtr ( wParam ) , new IntPtr ( lParam ) ).ToInt32 () ;
		}
		public static int SendMessageW ( IntPtr hWnd , int wMsg , IntPtr wParam , IntPtr lParam ) 
		{
			return SendMessageW ( hWnd , new IntPtr ( wMsg ) , wParam , lParam ).ToInt32 () ;
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage ( IntPtr hWnd , UInt32 Msg , IntPtr wParam, IntPtr lParam ) ;
		public static int SendMessage ( int hWnd , int wMsg , int wParam , int lParam ) 
		{
			return SendMessage ( new IntPtr ( hWnd ) , ( UInt32 ) wMsg , new IntPtr ( wParam ) , new IntPtr ( lParam ) ).ToInt32 () ;
		}
		public static int SendMessage ( IntPtr hWnd , int wMsg , IntPtr wParam , IntPtr lParam ) 
		{
			return SendMessage ( hWnd , ( UInt32 ) wMsg , wParam , lParam ).ToInt32 () ;
		}
		
		[DllImport("user32", SetLastError=true, CharSet=CharSet.Unicode )]
		public static extern int PostMessageW ( int hWnd , int wMsg , int wParam , int lParam ) ;

		[DllImport("user32", SetLastError=true, CharSet=CharSet.Ansi )]
		public static extern int PostMessageA ( int hWnd , int wMsg , int wParam , int lParam ) ;

		[DllImport("user32", SetLastError=true, CharSet=CharSet.Ansi )]
		public static extern int PostMessageA ( IntPtr hWnd , int wMsg , IntPtr wParam , IntPtr lParam ) ;

		public static string GetWindowTextMsA ( int hWnd , int MaxLength )
		{

			try
			{
				byte [] b = new byte [MaxLength + 1] ;
				System.Runtime.InteropServices.GCHandle GC =
					System.Runtime.InteropServices.GCHandle.Alloc 
					( b , System.Runtime.InteropServices.GCHandleType.Pinned ) ;
				int h = API.SendMessageA ( hWnd , 0x000D , MaxLength , 
										GC.AddrOfPinnedObject ().ToInt32 ()  ) ;
				string s = "" ;
				if ( h != 0 ) 
					s = System.Runtime.InteropServices.Marshal.PtrToStringAnsi ( GC.AddrOfPinnedObject () ) ;
				return s ;
			}
			catch 
			{
				return null ;
			}
		}
		public static string GetWindowTextMsW ( int hWnd , int MaxLength )
		{

			try
			{
				byte [] b = new byte [MaxLength + 1] ;
				System.Runtime.InteropServices.GCHandle GC =
					System.Runtime.InteropServices.GCHandle.Alloc 
					( b , System.Runtime.InteropServices.GCHandleType.Pinned ) ;
				int h = API.SendMessageW ( hWnd , 0x000D , MaxLength , 
					GC.AddrOfPinnedObject ().ToInt32 ()  ) ;
				string s = "" ;
				if ( h != 0 ) 
					s = System.Runtime.InteropServices.Marshal.PtrToStringUni
										( GC.AddrOfPinnedObject () ) ;
				return s ;
			}
			catch 
			{
				return null ;
			}
		}
        public static string GetWindowTextMsW ( IntPtr hWnd , int MaxLength )
		{

			return GetWindowTextMsW ( hWnd.ToInt32 () , MaxLength ) ;
		}
		[DllImport("user32", SetLastError=true) ]
		public static extern int SetWindowTextW ( IntPtr handle , StringBuilder newText ) ;
		public static int SetWindowTextW ( IntPtr handle , string newText ) 
		{
			StringBuilder b = new StringBuilder ( newText ) ;
			return SetWindowTextW ( handle , b ) ;
		}
		public static int SetWindowTextW ( int handle , string newText ) 
		{
			return SetWindowTextW ( new IntPtr ( handle ) , newText ) ;
		}


		public static int SetWindowTextMsA ( int hWnd , string value )
		{

			try
			{
				int l = value.Length ;
				char [] ch = value.ToCharArray () ;
				byte [] b = new byte [ l + 1 ] ;
				for ( int i = 0 ; i < l ; i = i + 1 )
					b[i] = ( byte ) ch[i] ;
				b[l] = 0 ;
				System.Runtime.InteropServices.GCHandle GC =
					System.Runtime.InteropServices.GCHandle.Alloc 
					( b , System.Runtime.InteropServices.GCHandleType.Pinned ) ;
				return API.SendMessageW ( hWnd , 0x000C , 0 , 
										GC.AddrOfPinnedObject ().ToInt32 () ) ;
			}
			catch 
			{
				return 0 ;
			}

		}
		public static int SetWindowTextMsW ( IntPtr hWnd , string value )
		{
			return SetWindowTextMsW ( hWnd.ToInt32 () , value , 0 ) ;
		}
		public static int SetWindowTextMsW ( int hWnd , string value )
		{
			return SetWindowTextMsW ( hWnd , value , 0 ) ;
		}
		public static int SetWindowTextMsW ( int hWnd , string value , int Style )
		{

			try
			{
				int l = value.Length ;
				char [] ch = value.ToCharArray () ;
				System.Runtime.InteropServices.GCHandle GC =
					System.Runtime.InteropServices.GCHandle.Alloc 
					( ch , System.Runtime.InteropServices.GCHandleType.Pinned ) ;
				return API.SendMessageW ( hWnd , 0x000C , Style , 
					GC.AddrOfPinnedObject ().ToInt32 ()  ) ;
			}
			catch 
			{
				return 0 ;
			}
		}
		
		
		public static int PostWindowTextMsW ( int hWnd , string value )
		{
			return PostWindowTextMsW ( hWnd , value , 0 ) ;
		}
		public static int PostWindowTextMsW ( int hWnd , string value , int Style )
		{

			try
			{
				int l = value.Length ;
				char [] ch = value.ToCharArray () ;
				System.Runtime.InteropServices.GCHandle GC =
					System.Runtime.InteropServices.GCHandle.Alloc 
					( ch , System.Runtime.InteropServices.GCHandleType.Pinned ) ;
				return API.PostMessageW ( hWnd , 0x000C , Style , 
					GC.AddrOfPinnedObject ().ToInt32 ()  ) ;
			}
			catch 
			{
				return 0 ;
			}
		}
		
		[DllImport("user32", SetLastError=true)]
		public static extern bool IsWindowVisible ( IntPtr hWnd ) ;
		public static bool IsWindowVisible ( int hWnd ) 
		{
			return IsWindowVisible ( new IntPtr ( hWnd ) ) ;
		}
		
		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr IsZoomed ( IntPtr hWnd ) ;
		public static int IsZoomed ( int hWnd ) 
		{
			return IsZoomed ( new IntPtr ( hWnd ) ).ToInt32 () ;
		}

		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr GetWindow ( IntPtr hWnd , IntPtr Relation ) ;
		public static int GetWindow ( int hWnd , WindowRelation Relation ) 
		{
			return GetWindow ( new IntPtr ( hWnd ) , new IntPtr ( ( int ) Relation ) ).ToInt32 () ;
		}
        public static IntPtr GetWindow ( IntPtr hWnd , WindowRelation Relation ) 
		{
			return GetWindow ( hWnd , new IntPtr ( ( int ) Relation ) ) ;
		}




		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr SetWindowPlacement ( IntPtr hWnd , ref WindowPlacement WP ) ;
		public static int SetWindowPlacement ( int hWnd , ref WindowPlacement WP )  
		{
			return SetWindowPlacement ( new IntPtr ( hWnd ) , ref WP ).ToInt32 () ;
		}
		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr GetWindowPlacement ( IntPtr hWnd , ref WindowPlacement WP) ;
		public static int GetWindowPlacement ( int hWnd , ref WindowPlacement WP )  
		{
			return  GetWindowPlacement ( new IntPtr ( hWnd ) , ref WP ).ToInt32 () ;
		}

		
		/// <summary>
		/// Radi smart-restore iz minimiziranog stanja
		/// </summary>
		/// <param name="Handle">Handle od prozora</param>
		/// <returns>nemam pojma</returns>
		public static IntPtr RestoreWindow ( IntPtr Handle )
		{
			IntPtr ret = IntPtr.Zero ;
			WindowPlacement wp = new WindowPlacement () ;
			ret = GetWindowPlacement ( Handle , ref wp ) ;
			if ( ret != IntPtr.Zero )
			{
				if ( wp.Flags == ShowFlags.RestoreMaximized )
                    if ( wp.Command == ShowCommand.Maximize )
                        wp.Command = ShowCommand.Restore ;
                    else wp.Command = ShowCommand.Maximize ;
				else wp.Command = ShowCommand.Restore ;
				ret = SetWindowPlacement ( Handle , ref wp ) ;
			}
			return ret ;
		}

		public const int HWND_TOP = 0 ;
		public const int HWND_BOTTOM = 1 ;
		public const int HWND_TOPMOST = -1 ;
		public const int HWND_NOTOPMOST = -2 ;
		public enum ZOrder
		{	
			Top = 0 ,
			Bottom = 1 ,
			TopMost = -1 ,
			NoTopMost = -2 
		}
		public const int SWP_NOSIZE = 1 ;
		public const int SWP_NOMOVE = 2 ;
		public const int SWP_NOZORDER = 4 ;
		public const int SWP_NOREDRAW = 8 ;
		public const int SWP_NOACTIVATE = 16 ;
		public const int SWP_FRAMECHANGED = 32 ;
		public const int SWP_SHOWWINDOW = 64 ;
		public const int SWP_HIDEWINDOW = 128 ;
		public const int SWP_NOCOPYBITS = 256 ;
		public const int SWP_NOOWNERZORDER = 512 ;
		public const int SWP_NOSENDCHANGING = 1024 ;
		public const int SWP_DRAWFRAME = SWP_FRAMECHANGED ;
		public const int SWP_NOREPOSITION = SWP_NOOWNERZORDER ;
		public const int SWP_DEFERERASE = 8192 ;
		public const int SWP_ASYNCWINDOWPOS = 16384 ;
		[Flags]
		public enum WindowPosFlags
		{
			NoSize = 1 ,
			NoMove = 2 ,
			NoZOrder = 4 ,
			NoRedraw = 8 ,
			NoActivate = 16 ,
			FramChenged = 32 ,
			ShowWindow = 64 ,
			HideWindow = 128 ,
			NoCopyBits = 256 ,
			NoOwnerZOrder = 512 ,
			NoSendChanging= 1024 ,
			DrawFrame = 32 ,
			NoReposition = 512 ,
			DefErase = 8192 ,
			AsyncWindowPos = 16384 
		}
		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr SetWindowPos ( IntPtr hWnd , IntPtr hWndInsertAfter , 
						IntPtr x , IntPtr y , IntPtr width , IntPtr height , IntPtr Flags ) ;
		public static int SetWindowPos ( int hWnd , int hWndInsertAfter , 
						int x , int y , int width , int height , int Flags ) 
		{
			return SetWindowPos ( new IntPtr ( hWnd ) , new IntPtr ( hWndInsertAfter ) ,
					new IntPtr ( x ) , new IntPtr ( y ) ,
					new IntPtr ( width ) , new IntPtr ( height ) ,
					 new IntPtr ( Flags ) ).ToInt32 () ;
		}
		public static int SetWindowPos ( int hWnd , ZOrder zOrder , 
			int x , int y , int width , int height , int Flags ) 
		{
			return SetWindowPos ( new IntPtr ( hWnd ) , new IntPtr ( ( int ) zOrder ) ,
				new IntPtr ( x ) , new IntPtr ( y ) ,
				new IntPtr ( width ) , new IntPtr ( height ) ,
				new IntPtr ( Flags ) ).ToInt32 () ;
		}
		public static int SetWindowPos ( IntPtr hWnd , ZOrder zOrder , 
			int x , int y , int width , int height , int Flags ) 
		{
			return SetWindowPos ( hWnd , new IntPtr ( ( int ) zOrder ) ,
				new IntPtr ( x ) , new IntPtr ( y ) ,
				new IntPtr ( width ) , new IntPtr ( height ) ,
				new IntPtr ( Flags ) ).ToInt32 () ;
		}
		public static int SetWindowPos ( int hWnd , ZOrder zOrder , 
			int x , int y , int width , int height , WindowPosFlags Flags ) 
		{
			return SetWindowPos ( new IntPtr ( hWnd ) , new IntPtr ( ( int ) zOrder ) ,
				new IntPtr ( x ) , new IntPtr ( y ) ,
				new IntPtr ( width ) , new IntPtr ( height ) ,
				new IntPtr ( ( int ) Flags ) ).ToInt32 () ;
		}
		public static int SetWindowPos ( IntPtr hWnd , ZOrder zOrder , 
			int x , int y , int width , int height , WindowPosFlags Flags ) 
		{
			return SetWindowPos ( hWnd , new IntPtr ( ( int ) zOrder ) ,
				new IntPtr ( x ) , new IntPtr ( y ) ,
				new IntPtr ( width ) , new IntPtr ( height ) ,
				new IntPtr ( ( int ) Flags ) ).ToInt32 () ;
		}
		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr GetParent ( IntPtr hWnd ) ;
		public static int GetParent ( int hWnd ) 
		{
			return GetParent ( new IntPtr ( hWnd ) ).ToInt32 () ;
		}

        
		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr SetParent ( IntPtr hWndChild , IntPtr hWndNewParent ) ;
		public static int SetParent ( int hWndChild , int hWndNewParent ) 
		{
			return SetParent ( new IntPtr ( hWndChild ) , new IntPtr ( hWndNewParent ) ).ToInt32 () ;
		}

		
		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr FindWindowA ( StringBuilder lpClassName , StringBuilder pWindowName ) ;
		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr FindWindow ( StringBuilder lpClassName , StringBuilder pWindowName ) ;
		[DllImport("user32", SetLastError=true)]
		public static extern int FindWindowExA ( int ParentHandle , int ChildHandle , 
								StringBuilder lpClassName , StringBuilder pWindowName ) ;


		public static IntPtr FindWindow ( string WindowCaption )
		{
			StringBuilder Buffer ;
			int Size ;
			Size = WindowCaption.Length + 1  ;
			Buffer = new StringBuilder ( Size , Size ) ;
			Buffer.Append ( WindowCaption ) ;
			return FindWindowA ( null , Buffer ) ;
		}

		public static int FindWindowEx ( IntPtr ParentHandle , IntPtr ChildHandle , string WindowCaption )
		{
			return FindWindowEx ( ParentHandle.ToInt32 () , ChildHandle.ToInt32 () , WindowCaption ) ;
		}
		public static int FindWindowEx ( int ParentHandle , int ChildHandle , string WindowCaption )
		{
			StringBuilder Buffer ;
			int Size ;
			Size = WindowCaption.Length + 1  ;
			Buffer = new StringBuilder ( Size , Size ) ;
			Buffer.Append ( WindowCaption ) ;
			return FindWindowExA ( ParentHandle , ChildHandle , null , Buffer ) ;
		}
		public static int FindWindowEx ( int ParentHandle , int ChildHandle , 
					string ClassName , string WindowCaption )
		{
			StringBuilder WindowCaptionBuffer = null ;
			StringBuilder ClassNameBuffer = null ;
			int Size ;
			if ( WindowCaption != null )
			{
				Size = WindowCaption.Length + 1  ;
				WindowCaptionBuffer = new StringBuilder ( Size , Size ) ;
				WindowCaptionBuffer.Append ( WindowCaption ) ;
			}
			if ( ClassName != null )
			{
				Size = ClassName.Length + 1  ;
				ClassNameBuffer = new StringBuilder ( Size , Size ) ;
				ClassNameBuffer.Append ( ClassName ) ;
			}
			return FindWindowExA ( ParentHandle , ChildHandle , 
						ClassNameBuffer , WindowCaptionBuffer ) ;
		}
		[DllImport ("user32.dll", SetLastError = true, CharSet = CharSet.Auto) ]
		public static extern int GetClassName ( IntPtr hWnd , StringBuilder lpClassName , int nMaxCount );
		public static string GetClassName ( IntPtr hWnd )
		{
			try
			{
				StringBuilder lpClassName = new StringBuilder ( 2000 ) ;
				int r = GetClassName ( hWnd , lpClassName , 2000 ) ;
				if ( r != 0 )
					return lpClassName.ToString ( 0 , r ) ;
			}
			catch {}
			return null ;
		}
		public static string GetClassName ( int hWnd )
		{
			return GetClassName ( new IntPtr ( hWnd ) ) ;
		}
		//
		[DllImport("user32", SetLastError=true)]
		public static extern int CloseWindow ( int hWnd ) ;
		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr CloseWindow ( IntPtr hWnd ) ;

		[DllImport("user32", EntryPoint="CloseWindow", SetLastError=true)]
		public static extern int CloseWindowProc ( IntPtr hWnd ) ;

		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr DestroyWindow ( IntPtr hWnd ) ;

		[DllImport("user32", SetLastError=true)]
		public static extern int GetWindowRect ( int hWnd , ref APIRect Rect ) ;

		[DllImport("user32", SetLastError=true)]
		public static extern int GetWindowRect ( IntPtr hWnd , ref APIRect Rect ) ;







		/// <summary>
		/// The MoveWindow function changes the position and dimensions of the specified window. For a top-level window, the position and dimensions are relative to the upper-left corner of the screen. For a child window, they are relative to the upper-left corner of the parent window's client area.
		/// </summary>
		/// <param name="hWnd">Handle to the window.</param>
		/// <param name="X">Specifies the new position of the left side of the window.</param>
		/// <param name="Y">Specifies the new position of the top of the window.</param>
		/// <param name="nWidth">Specifies the new width of the window.</param>
		/// <param name="nHeight">Specifies the new height of the window.</param>
		/// <param name="bRepaint">Specifies whether the window is to be repainted. If this parameter is TRUE, the window receives a message. If the parameter is FALSE, no repainting of any kind occurs. This applies to the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent window uncovered as a result of moving a child window.</param>
		/// <returns>If the function succeeds, the return value is nonzero.
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para></returns>
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool MoveWindow ( IntPtr hWnd , int X , int Y , int nWidth , int nHeight , bool bRepaint ) ;

	
		
		public static APIRect FindWindowSize ( string WindowCaption )
		{
			IntPtr h = FindWindow ( WindowCaption ) ;
			APIRect Rect = new APIRect () ;
			if ( h != IntPtr.Zero ) GetWindowRect ( h , ref Rect ) ;
			return Rect ;
		}

		[DllImport("user32",EntryPoint="CreatePopupMenu", SetLastError=true)]
		public static extern IntPtr CreatePopupMenuProc () ;
		public static int CreatePopupMenu () 
		{
			return CreatePopupMenuProc ().ToInt32 () ;
		}
		[DllImport("user32", SetLastError=true)]
		public static extern bool DestroyMenu ( IntPtr hMenu ) ;
		public static bool DestroyMenu ( int hMenu ) 
		{
			return DestroyMenu ( new IntPtr ( hMenu ) ) ;
		}
		public struct TrackPopupMenuParams
		{
			public uint cbSize ; 
			public APIRect rcExclude ;
		}		

		public struct MenuInfoSet
		{
			public const int State = 0x00000001 ;
			public const int ID = 0x00000002 ;
			public const int SubMenu = 0x00000004 ;
			public const int CheckMarks = 0x00000008 ;
			public const int Type = 0x00000010 ;
			public const int Data = 0x00000020 ;
			public const int String = 0x00000040 ;
			public const int BitMap = 0x00000080 ;
			public const int FType = 0x00000100 ; 	
			public const int All = 0x000001FF ;
		}

		public enum MenuItemType
		{
			BitMap = 0x00000004 ,
			MenuBarBreak = 0x00000020 ,
			MenuBreak = 0x00000040 ,
			OwnerDraw = 0x00000100 ,
			RadioCheck = 0x00000200 ,
			RightJustify = 0x00004000 ,
			RightOrder = 0x00002000 ,
			Separator = 0x00000800 ,
			String = 0x00000000 
		}

		public enum MenuItemState
		{
			UnHilite = 0x00000000 ,
			Hilite = 0x00000080 ,
			Checked = 0x00000008 ,
			UnChecked = 0x00000000 ,
			Default = 0x00001000 ,
			Enabled = 0x00000000 ,
			Grayed =  0x00000001 ,
			Disabled = 0x00000002 
		}
		public enum MenuEnabledItemState
		{
			Enabled = 0x00000000 ,
			Grayed =  0x00000001 ,
			Disabled = 0x00000002 ,
		}
		public struct MenuItemSelect
		{
			public const int BitMap = 0x00000004 ;
			public const int Checked = 0x00000008 ;
			public const int Disabled = 0x00000002 ;
			public const int Grayed =  0x00000001 ;
			public const int Hilite = 0x00000080 ;
			public const int MouseSelect = 0x00008000 ;
			public const int OwnerDraw = 0x00000100 ;
			public const int PopUp = 0x00000010 ;
			public const int SysMenu = 0x00002000 ;
		}
		public struct MenuItemInfo
		{
			public uint Size ;			// 4
			public uint InfoSet ;		// 8
			public uint Type ;			// 12
			public uint State;			// 16
			public uint ID ;			// 20
			public int hSubMenu ;		// 24
			public int hBMPChecked ;	// 28
			public int hBMPUnchecked ;  // 32
			public uint dwItemData ;	// 36
			public IntPtr dwTypeData;	// 40
			public int cch ;			// 44
		} 
 
		public enum MeasureControlType
		{
			Menu = 1 ,
			ListBox = 2 ,
			ComboBox = 3 ,
			Button = 4 ,
			Static = 5
		}

		public struct MeasureItemStruct
		{   
			public MeasureControlType CtlType ;  
			public int CtlID ;    
			public int itemID ;   
			public int Width ;    
			public int Height ;   
			public IntPtr itemData ; 
		} 
		public struct OwnerDrawMenuStruct
		{   
			public int hfont ; 
			public int cchItemText ; 
			public string Caption ; 
		} 

		public class MeasureItemObject
		{   
			public int CtlType ;		//4,0
			public int CtlID ;			//8,1
			public int itemID ;			//12,2
			public int Width ;			//16,3
			public int Height ;			//20,4
			public IntPtr itemData ;	//24,5
		} 
		public enum DrawControlType
		{
			Menu = 1 ,
			ListBox = 2 ,
			ComboBox = 3 ,
			Button = 4 ,
			Static = 5
		}
		public struct DrawItemStruct
		{   
			public DrawControlType CtlType ;  
			public int CtlID ;    
			public int itemID ;   
			public uint itemAction ;  
			public uint itemState ;  
			public int hWndItem ; 
			public int hDC ; 
			public APIRect rcItem ; 
			public IntPtr itemData ; 
		} 
		public struct DrawItemAction
		{
			public const int DrawEntire = 1 ;
			public const int Focus = 4 ;
            public const int Select = 2 ;
		}
		public struct OwnerDrawState
		{
			public const int Selected = 0x0001 ;
			public const int Grayed = 0x0002 ;
			public const int Disabled = 0x0004 ;
			public const int Checked = 0x0008 ;
			public const int Focus = 0x0010 ;
			public const int Default = 0x0020 ;
			public const int ComboBoxEdit = 0x1000 ;
			public const int HotLight = 0x0040 ;
			public const int Inactive = 0x0080 ;
			public const int NoAccelerator  = 0x0100 ;
			public const int NoFocusRect = 0x0200 ;
		}

		[DllImport("user32", EntryPoint="InsertMenuItemW" ,  SetLastError=true)]
		public static extern bool InsertMenuItem ( IntPtr hMenu , IntPtr uItem , 
										bool ByPosition , ref MenuItemInfo lpmii ) ;
		public static bool InsertMenuItem ( int hMenu , int uItem , 
										bool ByPosition , ref MenuItemInfo lpmii ) 
		{
			return InsertMenuItem ( new IntPtr ( hMenu ) , new IntPtr ( uItem ) , 
										ByPosition , ref lpmii ) ;
		}
		public static bool InsertMenuItem ( int hMenu , uint ID , int Position , string Caption , bool OnwerDraw ) 
		{
			unchecked 
			{
				MenuItemInfo MI = new MenuItemInfo () ;
				MI.Size = ( uint ) 44 ;
				MI.State = ( int ) MenuItemState.UnHilite ;
				MI.ID = ID ;
				MI.hSubMenu = 0 ;
				MI.hBMPChecked = 0 ;
				MI.hBMPUnchecked = 0 ;
				uint o ;
				if ( OnwerDraw ) 
				{
					MI.InfoSet =	
						( int ) MenuInfoSet.ID |
						( int ) MenuInfoSet.Type ;

					o = ( uint ) MenuItemType.OwnerDraw ;
				}
				else 
				{
					o = 0 ;
					MI.InfoSet = ( int ) MenuInfoSet.String | ( int ) MenuInfoSet.ID ;
				}
				if ( Caption == "-" )
				{
					MI.Type = ( int ) MenuItemType.Separator | o ;
					MI.dwTypeData = IntPtr.Zero ;
					return InsertMenuItem ( hMenu , Position , true , ref MI ) ;
				}
				else
				{
					MI.Type = ( int ) MenuItemType.String | o ;
					Caption = Caption + ( char ) 0 ;
					int l = Caption.Length ;
					IntPtr pMem = Marshal.AllocCoTaskMem ( l ) ; 
					Marshal.Copy ( Caption.ToCharArray() , 0 , pMem , l ) ;
					MI.dwTypeData = pMem ;
					MI.cch = l ;
					bool b = InsertMenuItem ( hMenu , Position , true , ref MI ) ;
					Marshal.FreeCoTaskMem ( pMem ) ; 
					return b ;
				}
			}
		}
		public static bool InsertMenuItem ( int hMenu , uint ID , int Position , string Caption ) 
		{
			return InsertMenuItem ( hMenu , ID , Position , Caption , false ) ;
		}
		
		[DllImport("user32", EntryPoint="GetMenuItemInfoW" ,  SetLastError=true)]
		public static extern bool GetMenuItemInfo ( IntPtr hMenu , IntPtr uItem , 
								bool ByPosition , ref MenuItemInfo lpmii ) ;

		[DllImport("user32", EntryPoint="SetMenuItemInfoW" ,  SetLastError=true)]
		public static extern bool SetMenuItemInfo ( IntPtr hMenu , IntPtr uItem , 
									bool ByPosition , ref MenuItemInfo lpmii ) ;

		public static bool SetMenuItemState ( IntPtr hMenu , IntPtr uItem , 
							bool ByPosition , MenuItemState State ) 
		{
			MenuItemInfo MI = new MenuItemInfo () ;
			MI.Size = ( uint ) 44 ;
			MI.InfoSet = ( int ) MenuInfoSet.String ;
			MI.State = ( uint ) State ;
			return SetMenuItemInfo ( hMenu , uItem , ByPosition , ref MI ) ;
		}
		public static bool SetMenuItemState ( int hMenu , int uItem , 
						bool ByPosition , MenuItemState State ) 
		{
			MenuItemInfo MI = new MenuItemInfo () ;
			MI.Size = ( uint ) 44 ;
			MI.InfoSet = ( int ) MenuInfoSet.State ;
			MI.State = ( uint ) State ;
			return SetMenuItemInfo ( new IntPtr ( hMenu ) , new IntPtr ( uItem ) , ByPosition , ref MI ) ;
		}

		public enum MenuPosition
		{
			ByCommand = 0x00000000 ,
			ByPosition = 0x00000400
		}

		[DllImport("user32", EntryPoint="EnableMenuItem" ,  SetLastError=true)]
		public static extern IntPtr EnableMenuItem ( IntPtr hMenu , IntPtr uIDEnableItem , IntPtr uEnable ) ;
		public static IntPtr EnableMenuItem ( IntPtr hMenu , IntPtr uIDEnableItem , 
									MenuPosition uPosition , MenuEnabledItemState uState )
		{
			return EnableMenuItem ( hMenu , uIDEnableItem , 
									new IntPtr ( ( int ) uPosition + ( int ) uState ) ) ;
		}
		public static IntPtr EnableMenuItem ( IntPtr hMenu , IntPtr uIDEnableItem , 
									bool ByPosition , bool State )
		{
			MenuPosition uPosition ;
			if ( ByPosition )
				uPosition = MenuPosition.ByPosition ;
			else uPosition = MenuPosition.ByCommand ;
			MenuEnabledItemState uState ;
			if ( State )
				uState = MenuEnabledItemState.Enabled ;
			else uState = MenuEnabledItemState.Grayed ;
			return EnableMenuItem ( hMenu , uIDEnableItem , 
				new IntPtr ( ( int ) uPosition + ( int ) uState ) ) ;
		}
		public static int EnableMenuItem ( int hMenu , int uIDEnableItem , 
											bool ByPosition , bool State )
		{
			return EnableMenuItem ( new IntPtr ( hMenu ) , new IntPtr ( uIDEnableItem ) , 
										ByPosition , State ).ToInt32() ;
		}
						
		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr GetMenuItemCount ( IntPtr hMenu ) ;
		public static int GetMenuItemCount ( int hMenu ) 
		{
			return GetMenuItemCount ( new IntPtr ( hMenu ) ).ToInt32 () ;
		}
 

		[DllImport("user32", SetLastError=true)]
		public static extern bool RemoveMenu ( IntPtr hMenu , IntPtr uPosition , IntPtr Flags ) ;
		public static bool RemoveMenu ( IntPtr hMenu , IntPtr uPosition , MenuPosition ByPostion ) 
		{
			return RemoveMenu ( hMenu , uPosition , new IntPtr ( ( int ) ByPostion ) ) ;
			}
		public static bool RemoveMenu ( IntPtr hMenu , IntPtr uPosition , bool ByPosition ) 
		{
			IntPtr p ;
			if ( ByPosition )
				p = new IntPtr ( ( int ) MenuPosition.ByPosition ) ;
			else p = new IntPtr ( ( int ) MenuPosition.ByCommand ) ;
			return RemoveMenu ( hMenu , uPosition , p ) ;
		}
 

		[DllImport("user32", SetLastError=true)]
		public static extern bool DeleteMenu ( IntPtr hMenu , IntPtr uPosition , IntPtr Flags ) ;
		public static bool DeleteMenu ( IntPtr hMenu , IntPtr uPosition , MenuPosition ByPostion ) 
		{
			return DeleteMenu ( hMenu , uPosition , new IntPtr ( ( int ) ByPostion ) ) ;
		}
		public static bool DeleteMenu ( IntPtr hMenu , IntPtr uPosition , bool ByPosition ) 
		{
			IntPtr p ;
			if ( ByPosition )
				p = new IntPtr ( ( int ) MenuPosition.ByPosition ) ;
			else p = new IntPtr ( ( int ) MenuPosition.ByCommand ) ;
			return DeleteMenu ( hMenu , uPosition , p ) ;
		}
		public struct TrackPopupMenuFlags
		{
			public const int LegtButton = 0x0000 ; 
			public const int RightButton = 0x0002;
			public const int LeftAlign = 0x0000 ;
			public const int CenterAlign = 0x0004 ;
			public const int RightAlign = 0x0008 ;
			public const int TopAlign = 0x0000 ;
			public const int VCenterAlign = 0x0010 ;
			public const int BottomALign = 0x0020 ;
			public const int Horizontal = 0x0000 ;		/* Horz alignment matters more */
			public const int Vertical = 0x0040 ;			/* Vert alignment matters more */
			public const int NoNotify = 0x0080;			/* Don't send any notification msgs */
			public const int ReturnCmd = 0x0100 ;
			public const int Recurse = 0x0001 ;
			public const int HorPosAnimation = 0x0400 ; 
			public const int HorNegAnimation = 0x0800 ;
			public const int VerPosAanimation = 0x1000 ;
			public const int VerNegAnimation = 0x2000 ;
			public const int NoAnimation = 0x4000 ;
			public const int LayoutRtl = 0x8000 ;
		}
		[DllImport("user32",EntryPoint="TrackPopupMenu",SetLastError=true)]
		private static extern IntPtr TrackPopupMenu ( IntPtr hMenu , IntPtr fuFlags ,
						IntPtr x , IntPtr y , 
						IntPtr nReserved , 
						IntPtr hwnd , 
						IntPtr nIngpored ) ;
		public static int TrackPopupMenu ( int hMenu , int fuFlags ,
						int x , int y , int hwnd ) 
		{
			return TrackPopupMenu ( new IntPtr ( hMenu ) , new IntPtr ( fuFlags ) ,
				new IntPtr ( x ) , new IntPtr ( y ) , IntPtr.Zero ,
				new IntPtr ( hwnd ) , IntPtr.Zero ).ToInt32 ()  ;
		}
 
		[DllImport("user32",EntryPoint="TrackPopupMenuEx",SetLastError=true)]
		private static extern IntPtr TrackPopupMenuExNo ( IntPtr hMenu , IntPtr fuFlags ,
								IntPtr x , IntPtr y , IntPtr hwnd , IntPtr Nolptpm ) ;
		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr TrackPopupMenuEx ( IntPtr hMenu , IntPtr fuFlags ,
					IntPtr x , IntPtr y , IntPtr hwnd , ref TrackPopupMenuParams lptpm ) ;
		public static int TrackPopupMenuEx ( int hMenu , int fuFlags ,
						int x , int y , int hwnd , ref TrackPopupMenuParams lptpm ) 
		{
			return TrackPopupMenuEx ( new IntPtr ( hMenu ) , new IntPtr ( fuFlags ) ,
					new IntPtr ( x ) , new IntPtr ( y ) , 
					new IntPtr ( hwnd ) , ref lptpm ).ToInt32 ()  ;
		}
		public static int TrackPopupMenuEx ( int hMenu , int fuFlags ,
											int x , int y , int hwnd ) 
		{
			return TrackPopupMenuExNo ( new IntPtr ( hMenu ) , new IntPtr ( fuFlags ) ,
				new IntPtr ( x ) , new IntPtr ( y ) , 
				new IntPtr ( hwnd ) , new IntPtr ( 0 ) ).ToInt32 ()  ;
		}
 

		[DllImport("user32", SetLastError=true)]
		public static extern bool GetCursorPos ( ref APIPoint Point ) ;
		[DllImport("user32", SetLastError=true)]
		public static extern bool SetCursorPos ( int x , int y ) ;


		[DllImport("kernel32.dll", SetLastError=true)]
		public static extern uint GetCurrentThreadId() ;

		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr GetWindowThreadProcessId ( IntPtr hWnd , ref IntPtr ProcessID ) ;
		public static int GetWindowThreadProcessId ( int hWnd , ref int ProcessID ) 
		{
			IntPtr p = new IntPtr ( ProcessID ) ;
			int r = GetWindowThreadProcessId ( new IntPtr ( hWnd ) , ref p ).ToInt32 () ;
			ProcessID = p.ToInt32 () ;
			return r ;
		}

		[DllImport("kernel32", SetLastError=true)]
		public static extern bool TerminateProcess ( IntPtr hProcess , IntPtr ExitCode ) ;
		public static bool TerminateProcess ( int hProcess , int ExitCode )
		{
			return TerminateProcess ( new IntPtr ( hProcess ) , new IntPtr ( ExitCode ) );
		}
		
		[DllImport("kernel32", SetLastError=true)]
		public static extern void ExitProcess ( IntPtr hProcess ) ;
		public static void ExitProcess ( int hProcess )
		{
			ExitProcess ( new IntPtr ( hProcess ) ) ;
		}
		

		
/*
 * 
 * DWORD GetWindowThreadProcessId(
  HWND hWnd,             // handle to window
  LPDWORD lpdwProcessId  // address of variable for process identifier
);
 */
		[DllImport("kernel32", SetLastError=true)]
		private static extern int GetTempPathA ( ref int BufferSize , StringBuilder Buffer ) ;
		public static string GetTempPath ( ) 
		{
			try
			{
				StringBuilder Buffer ;
				int Size ;
				Size = 500 ;
				Buffer = new StringBuilder ( Size , Size ) ;
				Size = GetTempPathA ( ref Size , Buffer ) ;
				return Buffer.ToString ( 0 , Size ) ;
			}
			catch {}
			return "" ;
		}
		[DllImport("kernel32", SetLastError=true)]
		private static extern bool GetComputerName ( StringBuilder Buffer , ref int Size );
		public static string GetComputerName () 
		{
			StringBuilder Buffer ;
			int Size ;
			Size = 300 ;
			Buffer = new StringBuilder ( Size , Size ) ;
			GetComputerName ( Buffer , ref Size ) ;
			return  Buffer.ToString ( 0 , Size ) ;
		}
		

        [DllImport("user32.dll", SetLastError=true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ClientToScreen ( IntPtr hWnd , ref APIPoint point ) ;
        
        [DllImport("user32.dll", SetLastError=true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowWindow ( IntPtr hWnd , IntPtr CmdShow ) ;
		public static bool ShowWindow ( IntPtr hWnd , ShowWindowStyle ShowCmd ) 
		{
			return ShowWindow ( hWnd ,  new IntPtr ( ( int ) ShowCmd ) ) ;
		}
		public static bool ShowWindow ( int hWnd , ShowWindowStyle ShowCmd ) 
		{
			return ShowWindow ( new IntPtr ( hWnd ) ,  new IntPtr ( ( int ) ShowCmd ) ) ;
		}

		[DllImport("shell32", SetLastError=true)]
		private static extern int ShellExecute ( int hWnd , string lpOperation , 
			string lpFile , string lpParameters , string lpDirectory , int nShowCmd ) ;
		public static int ShellExecute ( IntPtr Handle , string Operation , 
			string File , string Parameters , string Directory , ShowWindowStyle ShowCmd ) 
		{
			return ShellExecute (	Handle.ToInt32 () , 
				Operation , File , 
				Parameters , Directory ,
				System.Convert.ToInt32 ( ShowCmd ) ) ;
		}
		public static int ShellExecute ( string Operation , string File , 
			string Parameters , string Directory , 
			ShowWindowStyle ShowCmd ) 
		{
			return ShellExecute ( 0 , 
				Operation , File , 
				Parameters , Directory ,
				System.Convert.ToInt32 ( ShowCmd ) ) ;
		}
		public static int ShellExecute ( string Operation , string File , 
			string Parameters , string Directory )
		{
			return ShellExecute ( 0 , Operation , File , Parameters , Directory , 1 ) ;
		}
		public static int ShellExecute ( IntPtr Handle , 
			string Operation , string File , 
			string Parameters , string Directory )
		{
			return ShellExecute ( Handle.ToInt32 () , Operation , File , Parameters , Directory , 1 ) ;
		}


		
		[DllImport("User32", SetLastError=true)]
		private static extern int GetSystemMetrics ( int nIndex ) ;
		public enum SystemMetrics 
		{
			CXSCREEN             = 0 ,
			CYSCREEN             = 1 ,
			CXVSCROLL            = 2 ,
			CYHSCROLL            = 3 ,
			CYCAPTION            = 4 ,
			CXBORDER             = 5 ,
			CYBORDER             = 6 ,
			CXDLGFRAME           = 7 ,
			CYDLGFRAME           = 8 ,
			CYVTHUMB             = 9 ,
			CXHTHUMB             = 10 ,
			CXICON               = 11 ,
			CYICON               = 12 ,
			CXCURSOR             = 13 ,
			CYCURSOR             = 14 ,
			CYMENU               = 15 ,
			CXFULLSCREEN         = 16 ,
			CYFULLSCREEN         = 17 ,
			CYKANJIWINDOW        = 18 ,
			MOUSEPRESENT         = 19 ,
			CYVSCROLL            = 20 ,
			CXHSCROLL            = 21 ,
			DEBUG                = 22 ,
			SWAPBUTTON           = 23 ,
			RESERVED1            = 24 ,
			RESERVED2            = 25 , 
			RESERVED3            = 26 ,
			RESERVED4            = 27 ,
			CXMIN                = 28 ,
			CYMIN                = 29 ,
			CXSIZE               = 30 ,
			CYSIZE               = 31 ,
			CXFRAME              = 32 ,
			CYFRAME              = 33 ,
			CXMINTRACK           = 34 ,
			CYMINTRACK           = 35 ,
			CXDOUBLECLK          = 36 ,
			CYDOUBLECLK          = 37 ,
			CXICONSPACING        = 38 ,
			CYICONSPACING        = 39 ,
			MENUDROPALIGNMENT    = 40 ,
			PENWINDOWS           = 41 ,
			DBCSENABLED          = 42 ,
			CMOUSEBUTTONS        = 43 ,

			CXFIXEDFRAME         = CXDLGFRAME ,
			CYFIXEDFRAME         =  CYDLGFRAME ,
			CXSIZEFRAME          = CXFRAME ,
			CYSIZEFRAME          = CYFRAME ,

			SECURE               = 44 ,
			CXEDGE               = 45 ,
			CYEDGE               = 46 ,
			CXMINSPACING         = 47 ,
			CYMINSPACING         = 48 ,
			CXSMICON             = 49 ,
			CYSMICON             = 50 ,
			CYSMCAPTION          = 51 ,
			CXSMSIZE             = 52 ,
			CYSMSIZE             = 53 ,
			CXMENUSIZE           = 54 ,
			CYMENUSIZE           = 55 ,
			ARRANGE              = 56 ,
			CXMINIMIZED          = 57 ,
			CYMINIMIZED          = 58 ,
			CXMAXTRACK           = 59 ,
			CYMAXTRACK           = 60 ,
			CXMAXIMIZED          = 61 ,
			CYMAXIMIZED          = 62 ,
			NETWORK              = 63 ,
			CLEANBOOT            = 67 ,
			CXDRAG               = 68 ,
			CYDRAG               = 69 ,
			SHOWSOUNDS           = 70 ,
			CXMENUCHECK          = 71 , /* Use instead of GetMenuCheckMarkDimensions()! */
			CYMENUCHECK          = 72 ,
			SLOWMACHINE          = 73 ,
			MIDEASTENABLED       = 74 ,
			MOUSEWHEELPRESENT    = 75 ,
			XVIRTUALSCREEN       = 76 ,
			YVIRTUALSCREEN       = 77 ,
			CXVIRTUALSCREEN      = 78 ,
			CYVIRTUALSCREEN      = 79 ,
			CMONITORS            = 80 ,
			SAMEDISPLAYFORMAT    = 81 ,
			IMMENABLED           = 82 ,
			CXFOCUSBORDER        = 83 ,
			CYFOCUSBORDER        = 84 ,
			TABLETPC             = 86 ,
			MEDIACENTER          = 87 ,
			CMETRICS             = 44 ,
			REMOTESESSION        = 0x1000 ,
			SHUTTINGDOWN         = 0x2000 ,
			REMOTECONTROL        = 0x2001
		}


		
		public static int GetSystemMetrics ( SystemMetrics Index )
		{
			return GetSystemMetrics ( (int) Index ) ;
		}


		[DllImport("user32", SetLastError=true )]
		public static extern bool ExitWindowsEx ( uint uFlags , uint dwReason ) ;

		public enum ExitWindowsAction :uint
		{
			LogOff = 0 ,
			ShutDown = 0x00000001 ,
			Reboot = 0x00000002 ,
			PowerOff = 0x00000008 ,
            RestartApps = 0x00000040 
		}
		public enum ExitWindowsMode :uint
		{
			Wait = 0x00000000 ,
			Force = 0x00000004 ,
			ForceIfHang = 0x00000010 ,
			ForceAll= 0xFFFFFFFF
		}
        [Flags]
		public enum MajorShutDownReason : uint 
		{
            Application = 0x00040000 ,
            Hardware = 0x00010000 ,
            LegacyAPI = 0x00070000 ,
            OperatingSystem = 0x00020000 ,
            Other = 0x00000000 ,
            Power = 0x00060000 ,
            Software = 0x00030000 ,
            System = 0x00050000 
		}
		public enum MinorShutDownReason : uint 
		{
            BlueScreen = 0x0000000F ,
            CordUnplugged = 0x0000000b ,
            Disk = 0x00000007 ,
            Environment = 0x0000000c ,
            HardwareDriver = 0x0000000d ,
            HotFix = 0x00000011 ,
            HotFixUninstall = 0x00000017 ,
            Hung = 0x00000005 ,
            Installation = 0x00000002 ,
            Maintenance = 0x00000001 ,
            MMC = 0x00000019 ,
            NetworkConnectivity = 0x00000014 ,
            NetworkCard = 0x00000009 ,
            Other= 0x00000000 ,
            OhterDriver = 0x0000000e ,
            PowerSupply = 0x0000000a ,
            Processor = 0x00000008 ,
            Reconfig = 0x00000004 ,
            Security = 0x00000013 ,
            SecurityFix = 0x00000012 ,
            SecurityFixUninstall = 0x00000018 ,
            ServicePack = 0x00000010 ,
            ServicePackUninstall = 0x00000016 ,
            TermSrv = 0x00000020 ,
            TerminalServices = 0x00000020 ,
            Unstable = 0x00000006 ,
            Upgrade = 0x00000003 ,
            WMI = 0x00000015 
        }
		public enum FlagShutDownReason : uint 
		{
            UserDefined = 0x40000000 ,
            Planned = 0x80000000 ,
			None = 0x0000000 
		}



		public static bool ExitWindows ( ExitWindowsAction Action , ExitWindowsMode Mode , MajorShutDownReason MajorReason , MinorShutDownReason MinorReason , FlagShutDownReason FlagReason ) 
		{
			return ExitWindowsEx ( ( uint ) Action | ( uint ) Mode , ( uint ) MajorReason | ( uint ) MinorReason | ( uint ) FlagReason ) ;
		}
		public static bool ExitWindows ( ExitWindowsAction Action , ExitWindowsMode Mode , MajorShutDownReason MajorReason , MinorShutDownReason MinorReason ) 
		{
			return ExitWindowsEx ( ( uint ) Action | ( uint ) Mode , ( uint ) MajorReason | ( uint ) MinorReason ) ;
		}

        [Flags]
        public enum AccessToken : uint
        {

            AssignPrimary = 0x1 ,
            Duplicate = 0x2 ,
            Impersonate = 0x4 ,
            Query = 0x8 ,
            QuerySource = 0x10 ,
            AdjustPrivileges = 0x20 ,
            AdjustGroups = 0x40 ,
            AdjustDefault = 0x80 ,
            AllAccess = AssignPrimary | Duplicate | Duplicate | Query | QuerySource | AdjustPrivileges | AdjustGroups | AdjustDefault 
        }
        [ DllImport ( "kernel32.dll" , SetLastError=true ) ]
        public static extern IntPtr GetCurrentProcess ( ) ;
        

        [ DllImport ( "advapi32.dll" , SetLastError=true ) ]
        [ return: MarshalAs ( UnmanagedType.Bool ) ]
        public static extern bool OpenProcessToken ( IntPtr ProcessHandle , uint DesiredAccess , out IntPtr TokenHandle ) ;
        public static bool OpenProcessToken ( IntPtr ProcessHandle , AccessToken DesiredAccess , out IntPtr TokenHandle ) 
        {
            return OpenProcessToken (  ProcessHandle , ( uint ) DesiredAccess , out TokenHandle ) ;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LUID
        {
            public uint LowPart ;
            public int HighPart ;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct LUIDWithAttributes
        {
            public LUID Luid;
            public UInt32 Attributes;
        }

        public struct TokenPrivileges
        {
            public uint PrivilegeCount ;
            [ MarshalAs ( UnmanagedType.ByValArray , SizeConst = 1)]
            public LUIDWithAttributes[] Privileges ;
        }

        [DllImport("advapi32.dll", SetLastError=true, CharSet=CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LookupPrivilegeValue ( StringBuilder lpSystemName , StringBuilder lpName , out LUID lpLuid ) ;
        public static bool LookupPrivilegeValue ( string SystemName , string Name , out LUID Luid ) 
        {
            return LookupPrivilegeValue ( new StringBuilder ( SystemName ) , new StringBuilder ( Name ) , out Luid ) ;
        }



        [DllImport("advapi32.dll", SetLastError = true, EntryPoint="AdjustTokenPrivileges")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AdjustTokenPrivileges ( IntPtr TokenHandle ,
            [MarshalAs(UnmanagedType.Bool)] bool DisableAllPrivileges ,
            ref TokenPrivileges NewState , uint BufferLengthInBytes , 
            ref TokenPrivileges PreviousState , out uint ReturnLengthInBytes ) ;
        [DllImport("advapi32.dll", SetLastError = true, EntryPoint="AdjustTokenPrivileges")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AdjustTokenPrivilegesNull ( IntPtr TokenHandle ,
            [MarshalAs(UnmanagedType.Bool)] bool DisableAllPrivileges ,
            ref TokenPrivileges NewState , uint Zero , IntPtr Null1 , IntPtr Null2 ) ;

		[DllImport("User32", SetLastError=true)]
		private static extern void keybd_event ( byte bV , byte bScan , int dwFlags , int dwExtraInfo ) ;

		[DllImport("User32", SetLastError=true)]
		private static extern int MapVirtualKey ( int uCode , int uMapType ) ;
		public enum KeyEventFlags
		{
			KeyDown = 0 ,
			ExtendedKey = 1 ,
			KeyUp = 2 ,
			ExtendedKeyUp = 3
		}

		public enum VK
		{
			LBUTTON = 1 ,
			RBUTTON = 2 ,
			CANCEL = 3 ,
			MBUTTON = 4 ,  
			BACK = 8 ,
			Tab = 9 ,
			CLEAR = 12 ,
			Return = 13 ,
			Enter = 13 ,
			Shift = 16 ,
			Control = 17 ,
			Menu = 18 ,
			PAUSE = 19 ,
			CAPITAL = 20 ,
			KANA = 21 ,
			HANGUL = 21 ,
			JUNJA = 23 ,
			FINAL = 24 ,
			HANJA = 25 ,
			KANJI = 25 ,
			CONVERT = 28 ,
			NONCONVERT = 29 ,
			ACCEPT = 30 ,
			MODECHANGE = 31 ,
			ESCAPE = 27 ,
			Escape = 27 ,
			SPACE = 32 ,
			Space= 32 ,
			PRIOR = 33 ,
			NEXT = 34 ,
			END = 35 ,
			HOME = 36 ,
			LEFT = 37 ,
			UP = 38 ,
			RIGHT = 39 ,
			DOWN = 40 ,
			SELECT = 41 ,
			PRINT = 42 ,
			EXECUTE = 43 ,
			SNAPSHOT = 44 ,
			INSERT = 45 ,
			DELETE = 46 ,
			HELP = 47 ,
			A = 65 ,
			B = 66 ,
			C = 67 ,
			D = 68 ,
			E = 69 ,
			F = 70 ,
			G = 71 ,
			H = 72 ,
			I = 73 ,
			J = 74 ,
			K = 75 ,
			L = 76 ,
			M = 77 ,
			N = 78 ,
			O = 79 ,
			P = 80 ,
			Q = 81 ,
			R = 82 ,
			S = 83 ,
			T = 84 ,
			U = 85 ,
			V = 86 ,
			W = 87 ,
			X = 88 ,
			Z = 89 ,
			Y = 90 ,

			LWIN = 91 ,
			RWIN = 92 ,
			APPS = 93 ,
			NUMPAD0 = 96 ,
			NUMPAD1 = 97 ,
			NUMPAD2 = 98 ,
			NUMPAD3 = 99 ,
			NUMPAD4 = 100 ,
			NUMPAD5 = 101 ,
			NUMPAD6 = 102 ,
			NUMPAD7 = 103 ,
			NUMPAD8 = 104 ,
			NUMPAD9 = 105 ,
			MULTIPLY = 106 ,
			ADD = 107 ,
			SEPARATOR = 108 ,
			Subtract = 109 ,
			DECIMAL = 110 ,
			DIVIDE = 111 ,
			F1 = 112 ,
			F2 = 113 ,
			F3 = 114 ,
			F4 = 115 ,
			F5 = 116 ,
			F6 = 117 ,
			F7 = 118 ,
			F8 = 119 ,
			F9 = 120 ,
			F10 = 121 ,
			F11 = 122 ,
			F12 = 123 ,
			F13 = 124 ,
			F14 = 125 ,
			F15 = 126 ,
			F16 = 127 ,
			F17 = 128 ,
			F18 = 129 ,
			F19 = 130 ,
			F20 = 131 ,
			F21 = 132 ,
			F22 = 133 ,
			F23 = 134 ,
			F24 = 135 ,
			NumLock = 144 ,
			SCROLL = 145 ,
			LSHIFT = 160 ,
			RSHIFT = 161 ,
			LCONTROL = 162 ,
			RCONTROL = 163 ,
			LMENU = 164 ,
			RMENU = 165 ,
			PROCESSKEY = 229 ,
			ATTN = 246 ,
			CRSEL = 247 ,
			EXSEL = 248 ,
			EREOF = 249 ,
			PLAY = 250 ,
			ZOOM = 251 ,
			NONAME = 252 ,
			PA1 = 253 ,
			OEM_CLEAR = 254 
		}
			/*
		VK_0 thru VK_9 are the same as ASCII '0' thru '9' ($30 - $39) 
		VK_A thru VK_Z are the same as ASCII 'A' thru 'Z' ($41 - $5A) 
				VK_L & VK_R - left and right Alt, Ctrl and Shift virtual keys.
		Used only as parameters to GetAsyncKeyState() and GetKeyState().
		No other API or message will distinguish left and right keys in this way. 
		*/

		public enum VirtualKeyMapType
		{
			VirtualKey2ScanCode = 0 ,
			ScanCode2VirtualKey = 1 ,
			VirtualKey2UnshiftedScanCode = 2 ,
			VirtualKey2LeftRightScanCode = 3
		}
		[DllImport("user32", SetLastError=true)]
		private static extern int GetKeyState ( int vKey ) ;
		public static int GetKeyState ( VK VKCode ) 
		{
			return GetKeyState ( (int) VKCode ) ;
		}
        /// <summary>
        /// Direktan API na GetAsyncKeyState, vidi MSDN
        /// </summary>
        /// <param name="vKey"></param>
        /// <returns></returns>
		[DllImport("user32", SetLastError=true)]
		private static extern int GetAsyncKeyState ( int vKey ) ;
        /// <summary>
        /// Maskira sa &amp;0xFFFF
        /// </summary>
        /// <param name="VKCode"></param>
        /// <returns></returns>
		public static int GetAsyncKeyState ( VK VKCode ) 
		{
			return GetAsyncKeyState ( (int) VKCode ) & 1 ;
		}
		public static void SetNumLock ( bool State )
		{
			bool b = false ;
			int i = -1 ;
			if ( State )
			{
				i = GetKeyState ( VK.NumLock ) ;
				if ( i == 0 )
				{ 
					b = true ;
				}
			}
			else if ( i != 0 )
				b = true ;
			if ( b )
			{
				keybd_event ( VK.NumLock , KeyEventFlags.KeyDown , 0 ) ;
				keybd_event ( VK.NumLock , KeyEventFlags.ExtendedKeyUp , 0 ) ;
			}
		}
		public static byte MapVirtualKey ( VK VKCode , VirtualKeyMapType MapType ) 
		{
			return ( byte ) MapVirtualKey ( ( int ) VKCode , ( int ) MapType ) ;
		}
		public static void keybd_event ( VK VKCode , KeyEventFlags Flags , int dwExtraInfo ) 
		{
			keybd_event ( ( byte ) VKCode , MapVirtualKey ( VKCode , VirtualKeyMapType.ScanCode2VirtualKey  ) , ( int ) Flags , dwExtraInfo ) ;
		}
		public static void SendSingleKey ( VK VKCode ) 
		{
			keybd_event ( ( byte ) VKCode , MapVirtualKey ( VKCode , VirtualKeyMapType.ScanCode2VirtualKey  ) , 0 , 0 ) ;
			keybd_event ( ( byte ) VKCode , MapVirtualKey ( VKCode , VirtualKeyMapType.ScanCode2VirtualKey  ) , 2 , 0 ) ;

		}
		public struct DrawCaptionFlags
		{
			public const int Active = 0x0001 ;
			public const int SmallCap = 0x0002 ;
			public const int Icon = 0x0004 ;
			public const int Text = 0x0008 ;
			public const int InButton = 0x0010 ;
			public const int Gradient = 0x0020 ;
		}

		[DllImport("user32", SetLastError=true)]
		public static extern IntPtr DrawCaption ( IntPtr hWnd , IntPtr hDC , ref APIRect pcRect , IntPtr un ) ;
		public static int DrawCaption ( int hWnd , int hDC , ref APIRect pcRect , int un ) 
		{
			return DrawCaption ( new IntPtr ( hWnd ) , new IntPtr ( hDC ) , 
								ref pcRect , new IntPtr ( un ) ).ToInt32 () ;
		}

		public struct DrawTextFlags
		{
			public const int Top = 0x00000000 ;
			public const int Left = 0x00000000 ;
			public const int Center = 0x00000001 ;
			public const int Right = 0x00000002 ;
			public const int VCenter = 0x00000004 ;
			public const int Bottom = 0x00000008 ;
			public const int WordBreak = 0x00000010 ;
			public const int SingleLine = 0x00000020 ;
			public const int ExpandTabs = 0x00000040 ;
			public const int TabsStop = 0x00000080 ;
			public const int NoClick = 0x00000100 ;
			public const int ExternalLeading = 0x00000200 ;
			public const int CalcRect = 0x00000400 ;
			public const int NoPrefix = 0x00000800 ;
			public const int Internal = 0x00001000 ;
			public const int EditControl = 0x00002000 ;
			public const int PathEllipsis = 0x00004000 ;
			public const int EndEllipsis = 0x00008000 ;
			public const int ModifyString = 0x00010000 ;
			public const int RTLReading = 0x00020000 ;
			public const int WordEllipsis = 0x00040000 ;
			public const int NoFullWidthCharBreak = 0x00080000 ;
			public const int HidePrefix = 0x00100000 ;
			public const int PrefixOnlty = 0x00200000 ;
		}
		[DllImport("user32", EntryPoint="DrawTextW",SetLastError=true,CharSet=CharSet.Unicode)]
		public static extern IntPtr DrawText ( IntPtr hDC , string Str ,
											IntPtr CharCount , ref APIRect lpRect , IntPtr wFormat ) ;
		

		public struct DrawTextParams
		{ 
			public uint Size ; 
			public int TabLength ; 
			public int LeftMargin ; 
			public int RightMargin ; 
			public uint uiLengthDrawn ; 
		} 

		[DllImport("user32", EntryPoint="DrawTextExW",SetLastError=true,CharSet=CharSet.Unicode)]
		public static extern IntPtr DrawTextEx ( IntPtr hDC , ref StringBuilder Str ,
												IntPtr CharCount , 
												ref APIRect lpRect , 
												ref DrawTextParams lpParams ) ;
		public struct TextMetric
		{ 
			public int Height ; 
			public int Ascent ; 
			public int Descent ; 
			public int InternalLeading ; 
			public int ExternalLeading ; 
			public int AveCharWidth ; 
			public int MaxCharWidth ; 
			public int Weight ; 
			public int Overhang ; 
			public int DigitizedAspectX ; 
			public int DigitizedAspectY ; 
			public char FirstChar ; 
			public char LastChar ; 
			public char DefaultChar ; 
			public char BreakChar ; 
			public byte Italic ; 
			public byte Underlined ; 
			public byte StruckOut ; 
			public byte PitchAndFamily ; 
			public byte CharSet ; 
		} 
 
		[DllImport("user32", SetLastError=true)]
		public static extern bool GetTextMetrics ( IntPtr hDC , ref TextMetric lptm ) ;
		public static bool GetTextMetrics ( int hDC , ref TextMetric lptm ) 
		{
			return GetTextMetrics ( new IntPtr ( hDC ) , ref lptm ) ;
		}
 
		[ DllImport("uxTheme.dll", CharSet=System.Runtime.InteropServices.CharSet.Unicode ) ]
		public static extern bool IsAppThemed();
		
		[ DllImport("uxTheme.dll", CharSet=System.Runtime.InteropServices.CharSet.Unicode ) ]
		public static extern bool DrawBackground(string name, string part, string state, System.IntPtr hdc, int ox, int oy, int dx, int dy, int clip_ox, int clip_oy, int clip_dx, int clip_dy);
		
		[ DllImport("uxTheme.dll", CharSet=System.Runtime.InteropServices.CharSet.Unicode) ]
		public static extern bool DrawTabPageBackground(System.IntPtr hdc, int ox, int oy, int dx, int dy, int clip_ox, int clip_oy, int clip_dx, int clip_dy);
		
		[ DllImport("uxTheme.dll", CharSet=System.Runtime.InteropServices.CharSet.Unicode) ]
		public static extern bool DrawGroupBoxBackground(System.IntPtr hdc, int ox, int oy, int dx, int dy, int clip_ox, int clip_oy, int clip_dx, int clip_dy);
		
		[ DllImport("uxTheme.dll", CharSet=System.Runtime.InteropServices.CharSet.Unicode) ]
		public static extern bool DrawThemeParentBackground(System.IntPtr hwnd, System.IntPtr hdc);
		
		[ DllImport("uxTheme.dll", CharSet=System.Runtime.InteropServices.CharSet.Unicode )]
		public static extern bool DrawThemeParentBackground(System.IntPtr hwnd, System.IntPtr hdc, int ox, int oy, int dx, int dy);
		
		[ DllImport("uxTheme.dll", CharSet=System.Runtime.InteropServices.CharSet.Unicode)  ]
		public static extern bool GetTextColor(string name, string part, string state, out int r, out int g, out int b);

		[DllImport("UxTheme")]
		private static extern int SetWindowTheme ( int hWnd  , StringBuilder pszSubAppName , StringBuilder pszSubIdList ) ;
		public static int NoXPStyle ( int hWnd  ) 
		{

			try 
			{
				return SetWindowTheme ( hWnd , null , null ) ;
			}
			catch ( Exception x )
			{
				string s = x.Message ;
				return -1 ;
			}
		}
        [DllImport ( "uxtheme.dll" , ExactSpelling=true, CharSet=CharSet.Unicode ) ]
        public static extern IntPtr OpenThemeData ( IntPtr hWnd , String classList ) ;
        
        /// <summary>
        /// Data structure for WM_CopyData message. It is used in SendCopyData() method.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct CopyDataStructure
        {
            public IntPtr dwData ;
            public int cbData ;
            public IntPtr lpData ;
        }
        /// <summary>
        /// Send WM_CopyData message to desired window.
        /// </summary>
        /// <param name="hWnd">Target window handle.</param>
        /// <param name="value">String to send</param>
        /// <returns>Returns true if SendMessage() method returns something other then 0.</returns>
		public static bool SendCopyData ( IntPtr hWnd, string value )
		{
			return SendCopyData ( hWnd , value, IntPtr.Zero ) ;
		}
        /// <summary>
        /// Send WM_CopyData message to desired window.
        /// </summary>
        /// <param name="hWnd">Target window handle.</param>
        /// <param name="value">String to send</param>
        /// <param name="wParam">I don't have a clue, always use IntPtr.Zero(it counts as null?).</param>
        /// <returns>Returns true if SendMessage() method returns something other then 0.</returns>
		public static bool SendCopyData ( IntPtr hWnd , string value , IntPtr wParam )
		{
			IntPtr memPtr = IntPtr.Zero ;
            bool ret = false ;
			try
			{
				if ( hWnd != IntPtr.Zero )
				{
					CopyDataStructure data = new CopyDataStructure() ;
					value = string.Concat ( value , '\0' ) ;
					data.dwData = IntPtr.Zero ;
					data.cbData = value.Length << 1 ;
					data.lpData = Marshal.StringToHGlobalAuto ( value ) ;
					memPtr = Marshal.AllocHGlobal ( Marshal.SizeOf ( data ) ) ;
					Marshal.StructureToPtr ( data , memPtr , true ) ;
					ret = ( API.SendMessage ( hWnd , WindowMessage.WM_CopyData , wParam , memPtr ) != 0 ) ;
				}
			}
			catch { }
			try
			{
				if ( memPtr != IntPtr.Zero ) Marshal.FreeHGlobal ( memPtr ) ;
			}
			catch {}
            return ret ;
		}

		
        [StructLayout(LayoutKind.Sequential)]
        public class NCCalcSizeParams
        {
            public API.APIRect rcNewWindow ;
            public API.APIRect rcOldWindow ;
            public API.APIRect rcClient ;
            public IntPtr lppos ;
        }
        public struct IconInfo
	    {
	      public bool fIcon ;
	      public int xHotspot ;
	      public int yHotspot ;
	      public IntPtr hbmMask ;
	      public IntPtr hbmColor ;
	    }
        [DllImport("user32.dll")]
		[return:MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetIconInfo ( IntPtr hIcon , ref IconInfo pIconInfo ) ;

        [DllImport("user32.dll")]
		public static extern IntPtr CreateIconIndirect ( ref IconInfo icon ) ;

        public static Cursor CreateCursor ( Bitmap bmp , Point hotSpot )
		{
			return CreateCursor ( bmp , hotSpot.X , hotSpot.Y ) ; 
		}
		public static Cursor CreateCursor ( Bitmap bmp , int xHotSpot , int yHotSpot )
		{
			IntPtr ptr = bmp.GetHicon() ;
			API.IconInfo tmp = new API.IconInfo() ;
			API.GetIconInfo ( ptr, ref tmp ) ;
			tmp.xHotspot = xHotSpot ;
			tmp.yHotspot = yHotSpot ;
			tmp.fIcon = false ;
			ptr = API.CreateIconIndirect ( ref tmp ) ;
			return new Cursor ( ptr ) ;
		}

	}
}
