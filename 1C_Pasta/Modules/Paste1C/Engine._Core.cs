using System.Data;


namespace Pasta.Modules.Paste1C;


internal partial class Engine
{


	private const string C_DICTIONARY_TOOLTIP = @"Если первый столбец элемент справочника, то после 'ввода' значения, будет 'нажата' ENTER, иначе, будет 'нажата' TAB.
! Вставляемое значение в соответствующем справочнике 1С уже должно существовать, иначе 1С не опознает ввод и вставка не получится - будут глюки!"
;

	private const string C_PASTE_BUTTONY_TOOLTIP = @"Вставить табличные данные в активный табличный документ
! В 1С в активном табличном документе ФОКУС ВВОДА ДОЛЖЕН СТОЯТЬ НА ТАБЛИЧНОЙ ЧАСТИ !
(Горячая клавиша F12)"
;

	private readonly frmMain _fm;


	private bool _foundValid1CProcess = false;
	private System.Threading.Timer? _tmrDelay;
	private EventArgs _sync = new ();
	private uom.WinAPI.Hooks.KeyboardHook _kh;
	private string lastClipboardText = string.Empty;
	private bool _isPasting = false;


	private DataGridView grd => _fm.grdTable;


	public Engine ( frmMain fm )
	{
		_fm = fm;

		InitUI ();

		InitClipboardReader ();

		Refresh1CProcessesList ();
	}


	private void InitUI ()
	{
		InitDataGrid ();

		_fm.chkTrackClipboardChanges.Text = "Отслеживать";
		_fm.chkTrackClipboardChanges.ToolTipText = "Отслеживать изменения в буфере обмена и читать из него таблицы";
		_fm.chkTrackClipboardChanges.Checked = true;
		_fm.chkTrackClipboardChanges.CheckedChanged += ( _, _ ) =>
		{
			_clipboard.MonitorClipboard = _fm.chkTrackClipboardChanges.Checked;
		};


		_fm.btnReadClipboard.Click += ( _, _ ) => ReadClipboard ();
		_fm.btnRefreshProcessList.Click += ( _, _ ) => Refresh1CProcessesList ();

		//_fm.lvwData.KeyDown += ( _, e ) => OnDeleteItem (e);

		_fm.chkSort.Text = "Сортировать 1";
		_fm.chkSort.ToolTipText = "Сортировать по 1 столбкцу";
		_fm.chkSort.Checked = true;
		_fm.chkSort.CheckedChanged += ( _, _ ) => ParseLastKnownClipboardText ();


		_fm.chkGroupByfirstColumn.Text = "Группировать 1";
		_fm.chkGroupByfirstColumn.ToolTipText = "Группировать по 1 столбцу (числовые столбцы будут просуммированы у соответствующих строк)";
		_fm.chkGroupByfirstColumn.Checked = true;
		_fm.chkGroupByfirstColumn.CheckedChanged += ( _, _ ) => ParseLastKnownClipboardText ();


		_fm.chkFirstColumnFromDictionary.Text = "1к = справочник";
		_fm.chkFirstColumnFromDictionary.Checked = true;
		_fm.chkFirstColumnFromDictionary.ToolTipText = C_DICTIONARY_TOOLTIP;

		_fm.chkSkipEmptyColumns.Text = "Пропуск пустых";
		_fm.chkSkipEmptyColumns.Checked = true;
		_fm.chkSkipEmptyColumns.ToolTipText = "Пропускать пустые столбцы при выводе в 1С";


		_fm.btnPasteTo1CTable.Text = "Передать в 1С (F12)";
		_fm.btnPasteTo1CTable.ToolTipText = C_PASTE_BUTTONY_TOOLTIP;
		_fm.btnPasteTo1CTable.Click += async ( _, _ ) => await PasteTo1CTable ();

	}


	private void Refresh1CProcessesList ()
	{
		_fm.cbo1CProcess.Items.Clear ();

		ProcessInfo[] running1CInstances = [..
			Process
			.GetProcesses()
			//.Where(p => p.MainWindowTitle.eIsNotNullOrWhiteSpace())
			.Where(p => p.IsLike1CProcess())
			.Select(p => new ProcessInfo(p))
			.OrderBy(p => p.Title)
			];

		_foundValid1CProcess = running1CInstances.Any ();
		if (_foundValid1CProcess)
		{
			_fm.cbo1CProcess.Items.AddRange (running1CInstances);
			_fm.cbo1CProcess.SelectedIndex = 0;
		}

		UpdatePasteAvailability ();

		_kh = new ();
		_kh.InstallHook (uom.WinAPI.Hooks.KeyboardHook.KeyStates.Up, Keys.F12);
		_kh.HookedKeyEvent += ( s, e ) => _fm.eRunDelayedInUIThread (async () => await PasteTo1CTable ());
	}


	private void UpdatePasteAvailability ()
	{
		//=> _fm.btnPasteTo1CTable.Enabled = lvwData.Items.Count > 0 && _foundValid1CProcess;
	}



	private void OnDeleteItem ( KeyEventArgs ea )
	{

		/*
		if (ea.KeyCode != Keys.Delete) return;
		ea.Handled = true;

		ListViewItem[] itemsToDelete = lvwData.eSelectedItemsAsIEnumerable ().ToArray ();
		if (!itemsToDelete.Any ()) return;

		foreach (ListViewItem item in itemsToDelete) lvwData.Items.Remove (item);
		DataRowListViewItem.ReEumerateItems (lvwData);
		 */
	}



}



