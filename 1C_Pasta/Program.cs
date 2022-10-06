global using uom.Extensions;


namespace Pasta;


internal static class Program
{


	[STAThread]
	static void Main ()
	{
		ApplicationConfiguration.Initialize ();

		try
		{
			using var mtx = new uom.AppMutex (suffix: "Pasta", currentUser: false, throwAlreadyExist: true);
			Application.Run (new frmMain ());
		}

		catch (Exception ex)
		{
			ex.eLogError (true);
		}
	}


}
