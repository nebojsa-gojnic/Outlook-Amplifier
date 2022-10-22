using System ;
using System.ComponentModel ;
using System.Threading ;
using System.Text ;
using System.IO ;
using System.Drawing ;
using System.Windows.Forms ;
using System.Runtime.InteropServices ;
using Microsoft.Win32 ;
using Microsoft.Office ;
using Microsoft.Office.Interop ;
using Microsoft.Office.Interop.Outlook ;
using WMPLib ;
using System.Diagnostics.CodeAnalysis;
using System.Security.AccessControl ;
using System.IO.Pipes ;
using System.Diagnostics;

namespace OutlookAmplifier
{
	/// <summary>
	/// Main and only form for OutlookAmplifier program
	/// </summary>
	public partial class OutlookAmplifierForm : Form
	{


		//private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
		//private const int WM_APPCOMMAND = 0x319;
		//private const int APPCOMMAND_MICROPHONE_VOLUME_UP = 26 * 65536;
		//private const int APPCOMMAND_MICROPHONE_VOLUME_DOWN = 25 * 65536;

		

		/// <summary>
		/// Outlook(COM) application
		/// </summary>
		protected Microsoft.Office.Interop.Outlook.Application outlookApplication ;
		/// <summary>
		/// Active Outlook explorer (window)
		/// </summary>
		protected Explorer activeExplorer ;
		/// <summary>
		/// Windows Media Player(COM) application
		/// </summary>
		protected WindowsMediaPlayer player ;
		/// <summary>
		/// Receiver pipe for activation from an instance other than the current one
		/// </summary>
		protected NamedPipeServerStream receiver ;
		/// <summary>
		/// Pipe security for pipe receiver 
		/// </summary>
		protected PipeSecurity pipeSecurity ;
		/// <summary>
		/// This flag is set to false before the file dialog appears<br/>and is set to true if the user accepts the file from file dialog.
		/// </summary>
		protected bool fileAccepted ;
		/// <summary>
		/// Lower case path to folder with executable
		/// </summary>
		protected string lowCaseExecutableFolder ;
		/// <summary>
		/// Char length of the lowCaseExecutableFolder
		/// </summary>
		protected int executableFolderLength ;
		/// <summary>
		/// Lower case executable path and file name
		/// </summary>
		protected string lowCaseExecutablePath ;
		/// <summary>
		/// Creates new instacne of OutlookAmplifierForm class
		/// </summary>
		public OutlookAmplifierForm()
		{
			InitializeComponent() ;
			volumeBar.Value = 50 ;
			lowCaseExecutablePath = System.Windows.Forms.Application.ExecutablePath.ToLower() ;
			lowCaseExecutableFolder = lowCaseExecutablePath ;
			fileAccepted = false ;
			int i = lowCaseExecutableFolder.LastIndexOf ( '\\' ) ;
			if ( i != -1 ) lowCaseExecutableFolder = lowCaseExecutableFolder.Substring ( 0 , i + 1 ) ;
			executableFolderLength = lowCaseExecutableFolder.Length ;

			HandleCreated += firstTimeHandleCreated ;
			player = null ;
			readRegistrySettings () ;
			playNewMail () ;
		}
		/// <summary>
		/// Process process in Process.GetProcessesByName ( "OUTLOOK" ) 
		/// </summary>
		/// <returns>Retruns a process with "OUTLOOK" process name</returns>
		protected Process GetOutlookProcess ()
		{
			foreach ( Process process in Process.GetProcessesByName ( "OUTLOOK" ) )
				return process ;
			return null ;
		}
		/// <summary>
		/// This event handler is attached to HandleCreated event only at it fist occurance.<br/>
		/// It removes it self from invocation list on its first activation.<br/>
		/// It opens reecivier pipe, connects to Outlook application and show/hide this form.
		/// </summary>
		/// <param name="sender">(OuutlookAplifierForm)</param>
		/// <param name="e">(EventArgs)</param>
		private void firstTimeHandleCreated ( object sender , EventArgs e )
		{
			this.HandleCreated -= firstTimeHandleCreated ;
			try
			{
				pipeSecurity = new PipeSecurity() ;
				pipeSecurity.AddAccessRule ( new PipeAccessRule ( "Everyone" , PipeAccessRights.FullControl, AccessControlType.Allow ) ) ;
				receiver = NamedPipeServerStreamAcl.Create ( "OutlookAmplifier" , PipeDirection.In , 1 , PipeTransmissionMode.Byte , PipeOptions.Asynchronous , 65536 , 65536 , pipeSecurity ) ;
			}
			catch 
			{
				BeginInvoke ( new ThreadStart ( Close ) ) ;
				return ;
			}
			receiver.WaitForConnectionAsync ().ContinueWith ( onPipeConnected ) ;
			
			connectToOutlookApplication () ;
			if ( cbShowOnStart.Checked ) 
				BeginInvoke ( new ThreadStart ( beginRestoreForm ) ) ;
			else BeginInvoke ( new ThreadStart ( Hide ) ) ;
		}
		/// <summary>
		/// Reads data from pipe on incoming connection
		/// </summary>
		/// <param name="sender"></param>
		protected void onPipeConnected ( object sender )
		{
			if ( IsDisposed ) return ;
			string line = "" ;
			try
			{
				const int bSize = 65536 ;
				int nRead = bSize ;
				byte[] buffer = new byte [ bSize ] ;
				nRead = receiver.Read ( buffer , 0 , bSize ) ;
				line = Encoding.UTF8.GetString ( buffer , 0 , nRead ) ;
			}
			catch { }
			if ( line.Trim().ToLower () == "show" ) 
				BeginInvoke ( new ThreadStart ( beginRestoreForm ) ) ;
			try
			{
				receiver.Disconnect () ;
				receiver.WaitForConnectionAsync ().ContinueWith ( onPipeConnected ) ;
			}
			catch 
			{
				receiver.Dispose () ;
				receiver = NamedPipeServerStreamAcl.Create ( "SimpleHttp" , PipeDirection.In , 1 , PipeTransmissionMode.Byte , PipeOptions.Asynchronous , 65536 , 65536 , pipeSecurity ) ;
				receiver.SetAccessControl ( pipeSecurity ) ;
			}
		}
		/// <summary>
		/// Set ShowInTaskbar, Visible poprertie values to true, set Opacity to 1.0<br/>
		/// and invokes endRestoreForm() method in the next message loop
		/// </summary>
		protected void beginRestoreForm ()
		{
			ShowInTaskbar = true ;
			Visible = true ;
			Opacity = 1.0 ;
			BeginInvoke ( new ThreadStart ( endRestoreForm ) ) ;
		}
		/// <summary>
		/// Set WindowState to FormWindowState.Normal and 
		/// invokes BringToFront() method in the next message loop
		/// </summary>
		protected void endRestoreForm ()
		{
			WindowState = FormWindowState.Normal ;
			BeginInvoke ( new ThreadStart ( BringToFront ) ) ;
		}
		/// <summary>
		/// This method checks if this window is minimized before it calls base method(in order to raise Resize event).
		/// If this.WindowState is equal to FormWindowState.Minimized then totallyHide() method will be executed in the next message loop.
		/// </summary>
		/// <param name="e">(EventArgs)</param>
		protected override void OnResize ( EventArgs e )
		{
			if ( WindowState == FormWindowState.Minimized )
				BeginInvoke ( new ThreadStart ( totallyHide ) ) ;
			base.OnResize ( e ) ;
		}
		/// <summary>
		/// Hide this from both desktop and taskbar
		/// </summary>
		protected void totallyHide()
		{
			
			ShowInTaskbar = false ;
			Visible = false ;
		}
		/// <summary>
		/// Creates new instance Microsoft.Office.Interop.Outlook.Application.<br/>
		/// It either connects to exisitng or creates new external Outlook application.<br/>
		/// If new Outlook application is started then its window is not visible(it can be accessed via Outlook notification icon)
		/// </summary>
		public void connectToOutlookApplication ()
		{
			outlookApplication = new Microsoft.Office.Interop.Outlook.Application() ;
			outlookApplication.NewMail += outlookApplication_NewMail ;
			( ( Microsoft.Office.Interop.Outlook.ApplicationEvents_11_Event ) outlookApplication ).Quit += outlookAmplifierForm_Quit ;
		}
		/// <summary>
		/// When Outlook application quits this event handler disposes this form
		/// </summary>
		private void outlookAmplifierForm_Quit ()
		{
			outlookApplication = null  ;
			activeExplorer = null ;
			BeginInvoke ( new ThreadStart ( Dispose ) ) ;
		}
		/// <summary>
		/// This method try to access active Outlook explorer(window).<br/>
		/// It it successed then it invokes bringToFrontActiveExplorer() method on next message loop.
		/// </summary>
		public bool connectToOutlookExplorer ()
		{
			try
			{
				if ( outlookApplication == null ) connectToOutlookApplication () ;
				activeExplorer = outlookApplication.ActiveExplorer() ;
				if ( activeExplorer == null )
					activeExplorer = outlookApplication.Explorers.Add ( outlookApplication.GetNamespace ( "MAPI" ).GetDefaultFolder ( OlDefaultFolders.olFolderInbox ) , OlFolderDisplayMode.olFolderDisplayNormal ) ;
				if ( activeExplorer != null ) 
				{
					activeExplorer.Activate () ;
					BeginInvoke ( new ThreadStart ( bringToFrontActiveExplorer ) ) ;
				}
			}
			catch { }
			return false ;
		}


		/// <summary>
		/// This method plays sound for the new mail
		/// </summary>
		public void playNewMail ()
		{
			if ( string.IsNullOrEmpty ( lbSoundPath.Text ) ) return ;
			string fullFileName =
			 ( ( lbSoundPath.Text [ 0 ] != '\\' ) && ( lbSoundPath.Text.IndexOf ( ':' ) == -1 ) ?
				( lowCaseExecutableFolder + "\\" ) : "" ) + lbSoundPath.Text ;
			if ( File.Exists ( fullFileName ) )
			{
				if ( player == null ) 
				{
					player = new WindowsMediaPlayer() ;
					player.PlayStateChange += player_PlayStateChange;
				}
				else player.controls.stop () ;
				player.URL = fullFileName ;
				player.settings.volume = volumeBar.Value ;
				if ( IsHandleCreated )
					BeginInvoke ( player.controls.play ) ;
				else player.controls.play () ;
			}

		}
		/// <summary>
		/// When user click on "Play/Stop" button this method calls playNewMail() or player.controls.stop() method 
		/// </summary>
		/// <param name="sender">cmdPlayStop(button)</param>
		/// <param name="e">(EventArgs)</param>
		private void cmdPlayStop_Click ( object sender , EventArgs e )
		{
			if ( cmdPlayStop.Text == " Play " ) 
				playNewMail () ;
			else player.controls.stop () ;
		}
		/// <summary>
		/// This event handler reacts on Windows Media Player play status change.
		/// </summary>
		/// <param name="NewState">(WMPPlayState)</param>
		private void player_PlayStateChange ( int NewState )
		{
			switch ( ( WMPPlayState ) NewState )
			{
				case WMPPlayState.wmppsStopped :
				case WMPPlayState.wmppsReady :
					cmdPlayStop.AutoSize = true ;
					cmdPlayStop.Text = " Play " ;
				break ;
				default :
					System.Drawing.Size sz = cmdPlayStop.Size ;
					cmdPlayStop.AutoSize = false ;
					cmdPlayStop.Text = "Stop" ;
					cmdPlayStop.Size = sz ;
				break ;
			}
			//System.Diagnostics.Debug.WriteLine ( ( ( WMPPlayState ) NewState ).ToString () ) ;
		}


		/// <summary>
		/// Reads all registry settings and set all control property values
		/// </summary>
		public void readRegistrySettings ()
		{
			RegistryKey userKey = System.Windows.Forms.Application.UserAppDataRegistry ;
			try
			{
				foreach ( string name in userKey.GetValueNames () )
				{
					int i ;
					switch ( name )
					{
						case "NewMailSound" :
							lbSoundPath.Text = "" ;
							try
							{
								lbSoundPath.Text = ( string ) userKey.GetValue ( name , "" , RegistryValueOptions.DoNotExpandEnvironmentNames ) ;
							}
							catch { }
						break ;
						case "NewMailSoundVolume" :
							try
							{
								volumeBar.Value = ( int ) userKey.GetValue ( name , 50 , RegistryValueOptions.DoNotExpandEnvironmentNames ) ;
							}
							catch {}
						break ;
						case "NewPlaySound" :
							i = 1 ;
							try
							{
								i = ( int ) userKey.GetValue ( name , 1 , RegistryValueOptions.DoNotExpandEnvironmentNames ) ;
							}
							catch { }
							cbPlaySound.Checked = i != 0 ;
						break ;
						case "PlaySound" :
							i = 1 ;
							try
							{
								i = ( int ) userKey.GetValue ( name , 1 , RegistryValueOptions.DoNotExpandEnvironmentNames ) ;
							}
							catch { }
							cbPlaySound.Checked = i != 0 ;
						break ;
						case "ShowOutlook" :
							i = 1 ;
							try
							{
								i = ( int ) userKey.GetValue ( name , 1 , RegistryValueOptions.DoNotExpandEnvironmentNames ) ;
							}
							catch { }
							cbShowOutlook.Checked = i != 0 ;
						break ;
						case "ShowOnStart" :
							i = 1 ;
							try
							{
								i = ( int ) userKey.GetValue ( name , 1 , RegistryValueOptions.DoNotExpandEnvironmentNames ) ;
							}
							catch { }
							cbShowOnStart.Checked = i != 0 ;
						break ;
						case "CloseOutlook" :
							i = 1 ;
							try
							{
								i = ( int ) userKey.GetValue ( name , 1 , RegistryValueOptions.DoNotExpandEnvironmentNames ) ;
							}
							catch { }
							cbCloseOutlook.Checked = i != 0 ;
						break ;
						case "ConfirmClose" :
							i = 1 ;
							try
							{
								i = ( int ) userKey.GetValue ( name , 1 , RegistryValueOptions.DoNotExpandEnvironmentNames ) ;
							}
							catch { }
							cbConfirmClose.Checked = i != 0 ;
						break ;
							
					}
				}
			}
			catch { }
			try
			{
				userKey.Close () ;
			}
			catch { }
			RegistryKey rkApp = null ;
			try
			{ 
				rkApp = Registry.CurrentUser.OpenSubKey ( "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run" , true ) ;
				cbAutoStart.Checked =
				 ( rkApp.GetValue ( "OutlookAmplifier" , "" ).ToString().ToLower() == System.Windows.Forms.Application.ExecutablePath.ToLower() ) ; 
			}
			catch { }
			try
			{
				if ( rkApp != null ) rkApp .Close () ;
			}
			catch { }
		}

		/// <summary>
		/// This event handler reacts on new mail.
		/// It always read all registry settins and then acts.
		/// </summary>
		private void outlookApplication_NewMail ()
		{
			readRegistrySettings () ;
			if ( cbPlaySound.Checked ) playNewMail () ;
			if ( cbShowOutlook.Checked )
					connectToOutlookExplorer () ;
		}
		/// <summary>
		/// This method brings Outlook main window up and set it into maximized state.<br/>
		/// After that it invokes setActiveExplorerMaximized() method.
		/// </summary>
		protected void bringToFrontActiveExplorer ( )
		{
			IntPtr handle = GetOutlookProcess().MainWindowHandle ;
			if ( API.BringWindowToTop ( handle ) )
			{
				API.WindowPlacement windowPlacement = new API.WindowPlacement () ;
				API.GetWindowPlacement ( handle , ref windowPlacement ) ;
				Screen currentScreen = Screen.FromHandle ( handle ) ;
				windowPlacement.Command = API.ShowCommand.ShowMinimized ;
				API.SetWindowPlacement ( handle , ref windowPlacement ) ;
			}
			BeginInvoke ( new ThreadStart ( setActiveExplorerMaximized ) ) ;
		}
		/// <summary>
		/// Just set activeExplorer.WindowState to OlWindowState.olMaximized .
		/// </summary>
		protected void setActiveExplorerMaximized ()
		{
			//object o = outlookApplication.ActiveWindow() ;
			if ( IsDisposed ) return ;
			try
			{
				if ( activeExplorer != null )
					if ( activeExplorer.WindowState != OlWindowState.olMaximized ) 
					activeExplorer.WindowState = OlWindowState.olMaximized ;
			}
			catch { }

		}
		/// <summary>
		/// When "Play sound" check box value changes this event handler writes its value in the registry
		/// </summary>
		/// <param name="sender">cbPlaySound(CheckBox)</param>
		/// <param name="e">(EventArgs)</param>
        private void cbPlaySound_CheckedChanged ( object sender, EventArgs e )
        {
			if ( !IsHandleCreated ) return ;
			RegistryKey userKey = System.Windows.Forms.Application.UserAppDataRegistry ;
			try
			{
				userKey.SetValue ( "NewMailPlaySound" , cbPlaySound.Checked ? 1 : 0 , RegistryValueKind.DWord ) ;
			}
			catch { }
			try
			{
				userKey.Close () ;
			}
			catch { }
        }
		/// <summary>
		/// When "Show outlook" check box value changes this event handler writes its value in the registry
		/// </summary>
		/// <param name="sender">cbShowOutlook(CheckBox)</param>
		/// <param name="e">(EventArgs)</param>
		private void cbShowOutlook_CheckedChanged ( object sender , EventArgs e )
		{
			if ( !IsHandleCreated ) return ;
			RegistryKey userKey = System.Windows.Forms.Application.UserAppDataRegistry ;
			try
			{
				userKey.SetValue ( "ShowOutlook" , cbShowOutlook.Checked ? 1 : 0 , RegistryValueKind.DWord ) ;
			}
			catch { }
			try
			{
				userKey.Close () ;
			}
			catch { }
		}
		/// <summary>
		/// When "Auto start at login" check box value changes this event handler writes its value in the registry
		/// </summary>
		/// <param name="sender">cbAutoStart(CheckBox)</param>
		/// <param name="e">(EventArgs)</param>
		private void cbAutoStart_CheckedChanged ( object sender , EventArgs e )
		{
			if ( !IsHandleCreated ) return ;
			RegistryKey rkApp = null ;
			try
			{
				rkApp = Registry.CurrentUser.OpenSubKey ( "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run" , true ) ;
				if ( cbAutoStart.Checked )
					rkApp.SetValue ( "OutlookAmplifier" , System.Windows.Forms.Application.ExecutablePath ) ;
				else
					rkApp.DeleteValue ( "OutlookAmplifier" ) ;
			}
			catch { }
			try
			{
				if ( rkApp != null ) rkApp.Close () ;
			}
			catch { }
		}

		/// <summary>
		/// When "Show this dialog on startup" check box value changes this event handler writes its value in the registry
		/// </summary>
		/// <param name="sender">cbShowOnStart(CheckBox)</param>
		/// <param name="e">(EventArgs)</param>
		private void cbShowOnStart_CheckedChanged ( object sender , EventArgs e )
		{
			if ( !IsHandleCreated ) return ;
			RegistryKey userKey = System.Windows.Forms.Application.UserAppDataRegistry ;
			try
			{
				userKey.SetValue ( "ShowOnStart" , cbShowOnStart.Checked ? 1 : 0 , RegistryValueKind.DWord ) ;
			}
			catch { }
			try
			{
				userKey.Close () ;
			}
			catch { }
		}
		/// <summary>
		/// When "Close outlook when close this program" check box value changes this event handler writes its value in the registry
		/// </summary>
		/// <param name="sender">cbCloseOutlook(CheckBox)</param>
		/// <param name="e">(EventArgs)</param>
		private void cbCloseOutlook_CheckedChanged ( object sender , EventArgs e )
		{
			if ( !IsHandleCreated ) return ;
			RegistryKey userKey = System.Windows.Forms.Application.UserAppDataRegistry ;
			try
			{
				userKey.SetValue ( "CloseOutlook" , cbCloseOutlook.Checked ? 1 : 0 , RegistryValueKind.DWord ) ;
			}
			catch { }
			try
			{
				userKey.Close () ;
			}
			catch { }
		}
		/// <summary>
		/// When "Confirm on close" check box value changes this event handler writes its value in the registry
		/// </summary>
		/// <param name="sender">cbConfirmClose(CheckBox)</param>
		/// <param name="e">(EventArgs)</param>
		private void cbConfirmClose_CheckedChanged ( object sender , EventArgs e )
		{
			if ( !IsHandleCreated ) return ;
			RegistryKey userKey = System.Windows.Forms.Application.UserAppDataRegistry ;
			try
			{
				userKey.SetValue ( "ConfirmClose" , cbConfirmClose.Checked ? 1 : 0 , RegistryValueKind.DWord ) ;
			}
			catch { }
			try
			{
				userKey.Close () ;
			}
			catch { }
			
		}
		/// <summary>
		/// When user click on notify icon this method call beginRestoreForm() in order bring up this form
		/// </summary>
		/// <param name="sender">notifyIcon(NotifyIcon)</param>
		/// <param name="e">(EventArgs)</param>
        private void notifyIcon_Click ( object sender , EventArgs e )
        {
			beginRestoreForm () ;
        }
		/// <summary>
		/// This method may change Cancel property value of the args parameter(FormClosingEventArgs)
		/// before it calls its base method in order to raise FormClosing event.
		/// </summary>
		/// <param name="args">(FormClosingEventArgs)</param>
		protected override void OnFormClosing ( FormClosingEventArgs args )
		{
			args.Cancel = false ;
			if ( args.CloseReason == CloseReason.UserClosing )
				if ( cbConfirmClose.Checked )
					args.Cancel = MessageBox.Show ( this , 
						cbCloseOutlook.Checked ? "Do you want to close Outlook?" : "Do you want to close Outlook Amplifier?" ,
						cbCloseOutlook.Checked ? "Close Outlook" : "Close Outlook Amplifer" , MessageBoxButtons.YesNo , 
						cbCloseOutlook.Checked ? MessageBoxIcon.Warning : MessageBoxIcon.Question , 
						MessageBoxDefaultButton.Button1 ) != DialogResult.Yes ;
			base.OnFormClosing ( args ) ;
		}
		/// <summary>
		/// This method close Outlook application(if "Close Outlook ..."  box is checked)<br/>
		/// and close its base method in order to activate FormClosed event
		/// </summary>
		/// <param name="e">(FormClosedEventArgs)</param>
		protected override void OnFormClosed ( FormClosedEventArgs e )
		{
			if ( cbCloseOutlook.Checked )
			try
			{
				if ( outlookApplication != null ) outlookApplication.Quit () ;
			}
			catch { }
			base.OnFormClosed ( e ) ;
			try
			{
				player.close () ;
			}
			catch { }
		}



		/// <summary>
		/// When user clicks on "Browse" button this event handler set fileAccepted flag to false,<br/>
		/// shows modal openFileDialog and if fileAccepted flag is true calls setNewMailSound() method afterward.
		/// </summary>
		/// <param name="sender">cmdLoadSound(Button)</param>
		/// <param name="e">(EventArgs)</param>
		private void cmdLoadSound_Click ( object sender , EventArgs e )
		{
			fileAccepted = false ;
			openFileDialog.ShowDialog ( this ) ;
			if ( fileAccepted ) setNewMailSound ( openFileDialog.FileName ) ;
		}
		/// <summary>
		/// This method set give fileName parametr as new mail sound file name.<br/>
		/// It may change fileName to relative path if the given path is under the current executable path.
		/// </summary>
		/// <param name="fileName">File name with full or not full path.<br/>
		/// If realative path is given the the current executable path is considered.</param>
		protected void setNewMailSound ( string fileName )
		{
			lbSoundPath.Text = fileName ;
			if ( lbSoundPath.Text.ToLower ().IndexOf ( lowCaseExecutableFolder ) == 0 ) 
				lbSoundPath.Text = lbSoundPath.Text.Substring ( executableFolderLength ) ;
			RegistryKey userKey = System.Windows.Forms.Application.UserAppDataRegistry ;
			try
			{
				userKey.SetValue ( "NewMailSound" , lbSoundPath.Text , RegistryValueKind.String ) ;
			}
			catch { }
			try
			{
				userKey.Close () ;
			}
			catch { }
		}
		/// <summary>
		/// When user accepts file in file dialog this event handler set fileAccepted flag to true
		/// </summary>
		/// <param name="sender">openFileDialog(OpenFileDialog)</param>
		/// <param name="e">(CancelEventArgs)</param>
		private void openFileDialog_FileOk ( object sender , CancelEventArgs e )
		{
			fileAccepted = true ;
		}
		private void gbOptions_Layout ( object sender , LayoutEventArgs e )
		{
			testLabel1_SizeChanged ( testLabel1 , e ) ;
		}
		private void gbProgramOptions_Layout ( object sender , LayoutEventArgs e )
		{
			testLabel2_SizeChanged ( testLabel2 , e ) ;
		}
		private void lbSoundPath_Resize(object sender, EventArgs e)
		{
			lbSoundPath.Left = lbSoundPath.Width <= paSoundPath.Width ? 0 : paSoundPath.Width - lbSoundPath.Width ;
		}
		private void testLabel1_SizeChanged ( object sender , EventArgs e )
		{
			testLabel1.Location = cbPlaySound.Location ;
			paSoundPath.Size = testLabel1.Size ;
			lbSoundPath_Resize ( lbSoundPath , e ) ;
		}
		private void testLabel2_SizeChanged ( object sender, EventArgs e )
		{
			testLabel2.Location = cbAutoStart.Location ;
		}
		/// <summary>
		/// When user moves position on volumeBar(TrackBar) this event handler changes player volume,
		/// </summary>
		/// <param name="sender">volumeBar(TrackBar)</param>
		/// <param name="e">(EventArgs)</param>
		private void volumeBar_ValueChanged ( object sender , EventArgs e )
		{
			if ( player != null ) player.settings.volume = volumeBar.Value ;
		}
		/// <summary>
		/// When user release mouse button this event handler saves volume level in registry
		/// </summary>
		/// <param name="sender">volumeBar(TrackBar)</param>
		/// <param name="e">(MouseEventArgs)</param>
		private void volumeBar_MouseUp ( object sender, MouseEventArgs e )
		{
			RegistryKey userKey = System.Windows.Forms.Application.UserAppDataRegistry ;
			try
			{
				userKey.SetValue ( "NewMailSoundVolume" , volumeBar.Value , RegistryValueKind.DWord ) ;
			}
			catch { }
			try
			{
				userKey.Close () ;
			}
			catch { }
		}
		/// <summary>
		/// When user release key this event handler saves volume level in registry
		/// </summary>
		/// <param name="sender">volumeBar(TrackBar)</param>
		/// <param name="e">(KeyEventArgs)</param>
		private void volumeBar_KeyUp ( object sender , KeyEventArgs e )
		{
			RegistryKey userKey = System.Windows.Forms.Application.UserAppDataRegistry ;
			try
			{
				userKey.SetValue ( "NewMailSoundVolume" , volumeBar.Value , RegistryValueKind.DWord ) ;
			}
			catch { }
			try
			{
				userKey.Close () ;
			}
			catch { }
		}
		/// <summary>
		/// When user clicks on cmdShowOutlook button this event handler calls connectToOutlookExplorer() methid
		/// </summary>
		/// <param name="sender">cmdShowOutlook(Button)</param>
		/// <param name="e">(EventArgs)</param>
		private void cmdShowOutlook_Click ( object sender , EventArgs e )
		{
			connectToOutlookExplorer () ;
		}


	}		
}
