using System ;
using System.IO ;
using System.IO.Pipes ;
using System.Text ;
using System.Diagnostics ;

using System.Windows.Forms ;

namespace OutlookAmplifier
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//application.Quit () ;

			
			Process currentProcess = Process.GetCurrentProcess () ;
			//PipeMania.App.dummy = "" ;
			foreach ( Process process in Process.GetProcessesByName ( currentProcess.ProcessName ) )
				if ( process.Id != currentProcess.Id )
				{
					
					//API.ShowWindow ( process.MainWindowHandle , ShowWindowStyle.SW_Show ) ;
					//API.RestoreWindow ( process.MainWindowHandle ) ;
					//API.SendCopyData ( process.MainWindowHandle , "show" ) ;

					NamedPipeClientStream sender = null ;
					try
					{
						sender = new NamedPipeClientStream ( "." , "OutlookAmplifier" , PipeDirection.Out ) ;
						sender.Connect ( 1000 ) ;
						sender.Write ( Encoding.ASCII.GetBytes ( "show" ) ) ;
						sender.Flush () ;
						sender.Close () ;
						sender.Dispose () ;
						sender = null ;
					}
					catch { }
					try
					{
						if ( sender != null ) sender.Dispose () ;
					}
					catch { }

					return ;
				}


			Application.EnableVisualStyles() ;
			Application.SetCompatibleTextRenderingDefault ( false ) ;
			Application.Run(new OutlookAmplifierForm());
		}
	}
}
