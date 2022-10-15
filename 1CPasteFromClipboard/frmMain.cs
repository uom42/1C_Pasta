using System.Data;
using System.Data.Common;
using System.Windows.Forms;

using uom.Extensions;

using Application = System.Windows.Forms.Application;


#nullable enable

namespace Pasta
{
	public partial class frmMain : Form
	{


		private const int CHANGE_APP_FOCUS_DELAY = 2000;
		private const int PASTE_CELL_DELAY = 800;


		public frmMain()
		{
			InitializeComponent();

			InitUI();			
		}

		private void InitUI()
		{

			ResetWindowText();

			this.btnReadClipboard.Click += (_, _) => ReadClipboard();
			this.btnPasteTo1CTable.Click += async (_, _) => await PasteTo1CTable();
			this.lvwData.KeyDown += OnDeleteItem;

			chkFirstColumnFromDictionary.Checked = true;

			ReadClipboard();
		}
 

		private void ResetWindowText() => Text = Application.ProductName;


		private void InitListView(bool multiselect)
		{
			lvwData.Items.Clear();
			lvwData.Columns.Clear();
			lvwData.View = View.Details;
			lvwData.FullRowSelect = true;
			lvwData.GridLines = true;
			lvwData.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			lvwData.MultiSelect = multiselect;
		}


		private void ReadClipboard()
		{

			Application.DoEvents();

			try
			{
				InitListView(true);

				var clipText = Clipboard.GetText();
				var clipboardRows = ParseTextAsTable(clipText);
				if (clipboardRows == null || !clipboardRows.Any()) return;


				int maxColumns = clipboardRows.Select(r => r.Length).Max();
				lvwData.Columns.Add("Строка");
				for (int column = 1; column <= maxColumns; column++)
					lvwData.Columns.Add($"Колонка {column}");

				DataRowListViewItem[] listRows = clipboardRows
					.Select(r => new DataRowListViewItem(r))
					.ToArray();

				//lvwData.BeginUpdate();
				try
				{
					lvwData.Items.AddRange(listRows);
					DataRowListViewItem.ReEumerateItems(lvwData);
					lvwData.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
				}
				finally
				{
					//lvwData.EndUpdate();
				}

			}
			catch (Exception ex)
			{
				tlbMain.Invalidate();
				ex.FIX_ERROR(true);
			}
			finally
			{
				btnPasteTo1CTable.Enabled = lvwData.Items.Count > 0;
			}
		}


		private async Task PasteTo1CTable()
		{

			Application.DoEvents();

			try
			{
				UseWaitCursor = true;
				tlbMain.Enabled = false;
				lvwData.MultiSelect = false;

				Process[] procList = Process.GetProcesses();
				var proc1Cs = procList.Where(p =>
					p.ProcessName.ToLower().StartsWith("1cv8".ToLower())
					&& !string.IsNullOrWhiteSpace(p.MainWindowTitle)
				).ToArray();

				if (!proc1Cs.Any()) throw new Exception("Не найден работающий процесс 1С!");
				if (proc1Cs.Length > 1) throw new Exception("Найдено более одного активного процесса 1С!");

				Process proc1C = proc1Cs.First();
				IntPtr hwnd1C = proc1C.MainWindowHandle;
				{
					SetForegroundWindow(hwnd1C);
					proc1C.WaitForInputIdle();
					await Task.Delay(CHANGE_APP_FOCUS_DELAY);

					int processingRowIndex = 0;
					int totalRows = lvwData.Items.Count;

					bool firstColumnFromDictionary = chkFirstColumnFromDictionary.Checked;


					foreach (DataRowListViewItem li in lvwData.Items)
					{
						li.Selected = true;
						li.EnsureVisible();
						lvwData.FocusedItem = li;

						processingRowIndex++;
						float progress = (float)processingRowIndex / (float)totalRows;
						string progressText = $"Обработано строк: {processingRowIndex} из {totalRows} ({progress:P2})";
						Text = progressText;


						{
							await SendAndWait("{INS}");

							int columnIndex = 0;
							foreach (string txt in li.DataFor1C)
							{
								bool firstCol = (firstColumnFromDictionary && (columnIndex == 0));

								await SendAndWait(txt.Trim(), firstCol);

								await SendAndWait(firstCol
									? "{ENTER}"
									: "{TAB}");

								columnIndex++;
							}

							await SendAndWait("{F3}");
						}
						li.Selected = false;
					}
				}


				void Check1CWindowStillActive()
				{
					var hWndActive = GetForegroundWindow();
					if (hWndActive != hwnd1C) throw new Exception("1C Window focus lost!");

					proc1C.WaitForInputIdle();
				}

				async Task SendAndWait(string txt, bool useClipboard = false)
				{

					String textToSend = useClipboard
						? "^v"
						: txt;

					Check1CWindowStillActive();

					if (useClipboard)
					{
						Clipboard.Clear();
						Clipboard.SetText(txt);
						//Delay to allow OS process clipboard text for all applications...
						await Task.Delay(200);
					}

					SendKeys.SendWait(textToSend);
					await Task.Delay(PASTE_CELL_DELAY);
				}


			}
			catch (Exception ex)
			{
				tlbMain.Invalidate();
				ex.FIX_ERROR(true);
			}
			finally
			{
				lvwData.MultiSelect = true;
				ResetWindowText();

				tlbMain.Enabled = true;
				UseWaitCursor = false;
			}
		}


		private static string[][]? ParseTextAsTable(string? source)
		{
			if (null == source || string.IsNullOrWhiteSpace(source)) return null;

			var sr = new System.IO.StringReader(source);
			string? sLine = sr.ReadLine();

			List<string[]> lTable = new();
			while (sLine != null)
			{
				string[] columns = sLine.Split('\t');
				if (columns.Any())
				{
					lTable.Add(columns);
				}
				sLine = sr.ReadLine();
			}
			return lTable.ToArray();
		}


		private void OnDeleteItem(object s, KeyEventArgs ea)
		{
			if (ea.KeyCode != Keys.Delete) return;
			ea.Handled = true;
			DeleteSelectedItems();
		}
		private void DeleteSelectedItems()
		{
			ListViewItem[] itemsToDelete = lvwData.e_SelectedItemsAsIEnumerable().ToArray();
			if (!itemsToDelete.Any()) return;

			foreach (ListViewItem item in itemsToDelete) lvwData.Items.Remove(item);
			DataRowListViewItem.ReEumerateItems(lvwData);
		}


		#region WinAPI


		[DllImport("user32.dll")]
		static extern bool SetForegroundWindow(IntPtr hWnd);

		[System.Runtime.InteropServices.DllImport("User32.dll")]
		static extern bool ShowWindow(IntPtr handle, int nCmdShow);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		static extern IntPtr GetForegroundWindow();


		#endregion



	}
}
