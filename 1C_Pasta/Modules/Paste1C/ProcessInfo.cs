namespace Pasta.Modules.Paste1C;


internal class ProcessInfo ( Process p )
{


	private readonly Process _process = p;


	public string Title => $"{_process.ProcessName} ({_process.MainWindowTitle})";


	public override string ToString () => Title;


	public static implicit operator Process ( ProcessInfo p ) => p._process;
	public static implicit operator IntPtr ( ProcessInfo p ) => p._process.MainWindowHandle;


	public bool IsForeground ()
	{
		var hWndForeground = uom.WinAPI.windows.GetForegroundWindow ();
		var foregroundProcessID = uom.WinAPI.process.GetWindowThreadProcessId (hWndForeground).processid;
		var pForeground = Process.GetProcessById ((int) foregroundProcessID);
		return ( p.Id == pForeground.Id );
	}

}



internal static class ProcessExtensions
{

	//private const string C_1C_PROCESS_NAME = "1cv8";
	private const string C_1C_PROCESS_NAME = "1c";

	internal static readonly int currentProcessID = Environment.ProcessId;

	public static bool IsLike1CProcess ( this Process p ) =>
		p.Id != currentProcessID &&
			p.ProcessName.Contains (C_1C_PROCESS_NAME, StringComparison.CurrentCultureIgnoreCase);


}