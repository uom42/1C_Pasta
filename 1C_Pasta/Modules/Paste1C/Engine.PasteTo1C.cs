using System.Data;

using static uom.Extensions.Extensions_WinForms_Controls_ProgressBar;


using static Pasta.Modules.Paste1C.Constants;
using Pasta.Modules.Paste1C.Extensions;


namespace Pasta.Modules.Paste1C;


internal partial class Engine
{


	private async Task PasteTo1CTable ()
	{
		if (_isPasting) return;

		_isPasting = true;


		try
		{

			bool firstColumnIsDictionary = _fm.chkFirstColumnFromDictionary.Checked;
			var grd = _fm.grdTable;



			_fm.pbPaste1C.Minimum = 0;
			_fm.pbPaste1C.Value = 0;
			_fm.pbPaste1C.Step = 1;
			_fm.pbPaste1C.eSetState (PBM_STATES.PBST_NORMAL);

			_fm.UseWaitCursor = true;
			_fm.tlbMain.Enabled = false;



			{
				var cols = grd.Columns.OfType<DataGridViewColumn> ().Index ();

				if (!cols.Any ()) throw new Exception ("Нет данных для для вывода!");

				var outputColumnIndexes = cols
					.Where (cc => cc.Item.IsCheckedToOutput ())
					.Select (cc => cc.Index)
					.ToArray ();

				if (!outputColumnIndexes.Any ()) throw new Exception ("Не выбрано ни одного столбца для вывода!");


				ProcessInfo process1C = ( _fm.cbo1CProcess.SelectedItem as ProcessInfo )
					?? throw new Exception (C_ERR_1C_WORKING_PROCESS_NOT_FOUND);


				await Task.Delay (DELAY_USER_CLICK_PASTE_BUTTON);
				uom.WinAPI.windows.SetForegroundWindow (process1C);
				await Task.Delay (DELAY_WAIT_1C_WINDOW_FOCUSED);
				process1C.WaitForInputIdle ();


				var allRows = grd.Rows.OfType<DataGridViewRow> ().Index ().ToArray ();
				int totalRows = allRows.Length;
				_fm.pbPaste1C.Maximum = allRows.Length;

				grd.MultiSelect = false;
				grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

				foreach (var rr in allRows)
				{
					var row = rr.Item;
					var processingRowIndex = rr.Index;
					_fm.pbPaste1C.PerformStep ();


					var OldColorF = row.DefaultCellStyle.SelectionForeColor;
					var OldColorB = row.DefaultCellStyle.SelectionBackColor;
					try
					{
						row.DefaultCellStyle.SelectionForeColor = ROW_OUTPUT_PROCESSING_COLOR_FORE;
						row.DefaultCellStyle.SelectionBackColor = ROW_OUTPUT_PROCESSING_COLOR_BACK;
						row.Selected = true;
						//li.EnsureVisible ();

						float progress = processingRowIndex / (float) totalRows;
						string progressText = C_MSG_PROGRESS.eFormat (processingRowIndex, totalRows, progress); // $"Обработано строк: {processingRowIndex} из {totalRows} ({progress:P2})";
						_fm.Text = progressText;

						await C_KEYS_INS.SendAndWait (process1C, false);

						DataRow dr = ( (DataRowView) row.DataBoundItem! ).Row!;
						object?[] rowValues = dr.ItemArray;

						foreach (var gridColumnIndex in outputColumnIndexes.Index ())
						{
							bool use1cDistionary = firstColumnIsDictionary && gridColumnIndex.Index == 0;
							string cellValue = rowValues[ gridColumnIndex.Item ]?.ToString () ?? string.Empty;

							await cellValue.SendAndWait (process1C, use1cDistionary, exchangeModeClipboard: false, doNotTrimSpecialChars: false);       // Entering cell text							

							// sk.SendKeys("{TAB}{DELAY=100}{ENTER}{DOWN}{ENTER}");

							await ( use1cDistionary                          // Press Enter if first column and checkbox=true, else send TAB
								? C_KEYS_RETURN
								: C_KEYS_TAB ).SendAndWait (process1C, false, doNotTrimSpecialChars: true);

						}
						await C_KEYS_F3.SendAndWait (process1C, false);

					}
					finally
					{
						row.DefaultCellStyle.SelectionForeColor = OldColorF;
						row.DefaultCellStyle.SelectionBackColor = OldColorB;
					}
				}
			}

		}
		catch (Exception ex)
		{
			_fm.pbPaste1C.eSetState (PBM_STATES.PBST_ERROR);
			ex.eLogError (true);

			_fm.tlbMain.Invalidate ();
		}
		finally
		{
			grd.MultiSelect = true;

			_fm.ResetWindowTitle ();

			_fm.tlbMain.Enabled = true;
			_fm.UseWaitCursor = false;

			_isPasting = false;
		}

	}


}
