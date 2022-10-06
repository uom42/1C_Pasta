using System.Net.WebSockets;
using System.Text.Json;


using uom.RU_FNS;


namespace Pasta.Modules.FNS_Check;


internal class Engine
{
	private readonly frmMain _fm;

	private System.Windows.Forms.OpenFileDialog _ofd = new()
	{
		Filter = "*.jpg|*.jpg",
		AutoUpgradeEnabled = true,
		AddExtension = true,
		CheckPathExists = true,
		CheckFileExists = true,
		DereferenceLinks = true,
		SupportMultiDottedExtensions = true,

		InitialDirectory = @"c:\",
		RestoreDirectory = false,

	};

	public Engine(frmMain fm)
	{
		_fm = fm;

		FNSCheck_Init();
	}


	private void FNSCheck_Init()
	{
		using var sm = uom.AppInfo.Assembly.eGetManifestResourceStream("29_04_2024_06_25_026015561319996628792.json");
		var r = sm.ReadFNSCheck();

		var Чек = r.Receipt;

		var OS = Чек?.TaxationType;


		_fm.pbCheck.Image = Чек.Draw();


		/*


		Span<Decimal> ddd = [1.2m, 3.5m];


		// ddd.
		//	ddd[1] = 2;







		int gggg = 9;

		 * 
		 * 
		 * 
		 * 
		 * 
		FNSCheck_InitProcessList();

		this.btnReadClipboard.Click += (_, _) => FNSCheck_ReadClipboard();
		this.btnPasteTo1CTable.Click += async (_, _) => await FNSCheck_PasteTo1CTable();
		this.btnRefreshProcessList.Click += (_, _) => FNSCheck_InitProcessList();
		this.lvwData.KeyDown += FNSCheck_OnDeleteItem;

		this.chkFirstColumnFromDictionary.Checked = true;
		this.chkFirstColumnFromDictionary.ToolTipText = @"Если значение первого столбца - это выбор элемента справочника, то после ввода значения, ""нажимаем"" ENTER, для подтверждения выбора. Иначе, нажимаем TAB для перехода к следующему столбцу.

!!!Вставляемое значение в справочнике 1С уже должно существовать, иначе встравка не получится и будут глюки!";

		FNSCheck_ReadClipboard();
		 */

	}




}
