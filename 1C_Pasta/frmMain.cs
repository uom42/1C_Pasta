using Pasta.Properties;


using Application = System.Windows.Forms.Application;


namespace Pasta;


internal partial class frmMain : Form
{

	private Modules.Paste1C.Engine _paste1C;
	private Modules.FNS_Check.Engine _check;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	public frmMain ()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	{

		InitializeComponent ();

		uom.WinAPI.windows.DwmSetWindowAttribute_DWMWA_USE_IMMERSIVE_DARK_MODE (this.Handle, true);

		this.eAttach_PositionAndStateSaver ();

		InitUI ();

	}



	private async void InitUI ()
	{
		Icon = Resources.Pasta;

		this.eStartAutoupdateOnShown ("https://raw.githubusercontent.com/uom42/1C_Pasta/master/UpdaterXML.xml");

		ResetWindowTitle ();

		_paste1C = new (this);
		//_check = new (this);

		await Task.Delay (1);
	}



	internal void ResetWindowTitle () => Text = Application.ProductName;


}
