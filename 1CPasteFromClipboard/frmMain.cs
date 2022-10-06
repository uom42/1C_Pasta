using System.Data;

using Pasta.Properties;

using Application = System.Windows.Forms.Application;


#nullable enable

namespace Pasta
{
	public partial class frmMain : Form
	{


		private const int DELAY_1C_FOCUS = 2000;
		private const int DELAY_CELL_PASTE = 800;

		private const string C_ERR_1C_WORKING_PROCESS_NOT_FOUND = "Не найден работающий процесс 1С!";
		private const string C_MSG_1C_MORE_THAN_ONE_INSTANCES_RUNNING = "Найдено более одного активного процесса 1С!";
		private const string C_MSG_1C_WINDOW_FOCUS_LOST = "1C Window focus lost!";
		private const string C_MSG_PROGRESS = "Обработано строк: {0} из {1} ({2:P2})";

		private const string C_KEYS_INS = "{INS}";
		private const string C_KEYS_TAB = "{TAB}";
		private const string C_KEYS_RETURN = "{ENTER}";
		private const string C_KEYS_F3 = "{F3}";
		private const string C_KEYS_PASTE = "^v";


		public frmMain()
		{
			InitializeComponent();

			this.e_StartAutoupdateOnShown("https://raw.githubusercontent.com/uom42/1C_Pasta/master/UpdaterXML.xml");

			InitUI();
		}

		private void InitUI()
		{
			Icon = Resources.Pasta;

			ResetWindowText();
			InitProcessList();

			this.btnReadClipboard.Click += (_, _) => ReadClipboard();
			this.btnPasteTo1CTable.Click += async (_, _) => await PasteTo1CTable();
			this.btnRefreshProcessList.Click += (_, _) => InitProcessList();
			this.lvwData.KeyDown += OnDeleteItem;

			this.chkFirstColumnFromDictionary.Checked = true;
			this.chkFirstColumnFromDictionary.ToolTipText = @"Если значение первого столбца - это выбор элемента справочника, то после ввода значения, ""нажимаем"" ENTER, для подтверждения выбора. Иначе, нажимаем TAB для перехода к следующему столбцу.

!!!Вставляемое значение в справочнике 1С уже должно существовать, иначе встравка не получится и будут глюки!";

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
				ex.e_LogError(true);
			}
			finally
			{
				UpdatePasteAvailability();
			}
		}

		private bool foundValid1CProcess = false;

		private void UpdatePasteAvailability()
		{
			btnPasteTo1CTable.Enabled = (lvwData.Items.Count > 0) && foundValid1CProcess;
		}


		private void InitProcessList()
		{
			cbo1CProcess.Items.Clear();

			ProcessListItem[] runningProcess = Process
				.GetProcesses()
				.Where(p => !string.IsNullOrWhiteSpace(p.MainWindowTitle))
				.Select(p => new ProcessListItem(p))
				.Where(p => p.IsLike1CProcess)
				.OrderBy(p => p.Title)
				.ToArray();

			foundValid1CProcess = runningProcess.Any();

			if (foundValid1CProcess)
			{
				cbo1CProcess.Items.AddRange(runningProcess);
				cbo1CProcess.SelectedIndex = 0;
			}

			UpdatePasteAvailability();
		}

		private async Task PasteTo1CTable()
		{

			Application.DoEvents();

			try
			{
				UseWaitCursor = true;
				tlbMain.Enabled = false;
				lvwData.MultiSelect = false;

				{
					ProcessListItem? prc1C = cbo1CProcess.SelectedItem as ProcessListItem;
					if (prc1C == null) throw new Exception(C_ERR_1C_WORKING_PROCESS_NOT_FOUND);

					Process proc1C = prc1C!.Process;
					IntPtr hwnd1C = proc1C.MainWindowHandle;

					{
						uom.WinAPI.Windows.SetForegroundWindow(hwnd1C);
						proc1C.WaitForInputIdle();
						await Task.Delay(DELAY_1C_FOCUS);

						int processingRowIndex = 0;
						int totalRows = lvwData.Items.Count;

						bool isFirstColumnFromDictionary = chkFirstColumnFromDictionary.Checked;

						foreach (DataRowListViewItem li in lvwData.Items)
						{
							li.Selected = true;
							li.EnsureVisible();
							lvwData.FocusedItem = li;

							processingRowIndex++;
							float progress = (float)processingRowIndex / (float)totalRows;
							string progressText = C_MSG_PROGRESS.e_Format(processingRowIndex, totalRows, progress); // $"Обработано строк: {processingRowIndex} из {totalRows} ({progress:P2})";
							Text = progressText;


							{
								await SendAndWait(C_KEYS_INS);

								int columnIndex = 0;
								foreach (string txt in li.DataFor1C)
								{
									bool firstCol = (isFirstColumnFromDictionary && (columnIndex == 0));

									await SendAndWait(txt, pasteFromClipboard: false, specialChars: false);       // Entering cell text

									await SendAndWait(firstCol                          // Pressing Enter if first column and checkbox=true, else send TAB
										? C_KEYS_RETURN
										: C_KEYS_TAB, specialChars: true);

									columnIndex++;
								}

								await SendAndWait(C_KEYS_F3);
							}
							li.Selected = false;
						}
					}


					void Check1CWindowStillActive()
					{
						var hWndActive = uom.WinAPI.Windows.GetForegroundWindow();
						if (hWndActive != hwnd1C) throw new Exception(C_MSG_1C_WINDOW_FOCUS_LOST);

						proc1C.WaitForInputIdle();
					}

					async Task SendAndWait(string txt, bool pasteFromClipboard = false, bool specialChars = false)
					{

						Check1CWindowStillActive();

						String textToSend = txt;
						if (!specialChars) textToSend = textToSend.Trim().TrimEnd('\t', '\r', '\n', ' ');


						if (pasteFromClipboard)
						{
							Clipboard.Clear();
							Clipboard.SetText(textToSend);

							//Delay to allow OS process clipboard text for all applications...
							await Task.Delay(300);
							textToSend = C_KEYS_PASTE;
						}
						else
						{
							/*
							The plus sign (+), caret (^), percent sign (%), tilde (~), and parentheses () have special meanings to SendKeys.
							To specify one of these characters, enclose it within braces ({}). 
							For example, to specify the plus sign, use "{+}". To specify brace characters, use "{{}" and "{}}". 
							Brackets ([ ]) have no special meaning to SendKeys, but you must enclose them in braces. 
							In other applications, brackets do have a special meaning that might be significant when dynamic data exchange (DDE) occurs.
							*/
							char[] invalidChars = { '+', '^', '%', '~', '(', ')' };
							textToSend = textToSend.e_ReplaceCharsWithString(invalidChars, x => ('{' + x.ToString() + '}'));
						}

						SendKeys.SendWait(textToSend);
						await Task.Delay(DELAY_CELL_PASTE);
					}
				}

			}
			catch (Exception ex)
			{
				tlbMain.Invalidate();
				ex.e_LogError(true);
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
	}
}
