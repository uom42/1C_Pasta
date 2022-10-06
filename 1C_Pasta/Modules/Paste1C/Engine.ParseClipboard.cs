namespace Pasta.Modules.Paste1C;


internal partial class Engine
{


	private void ParseLastKnownClipboardText ()
	{
		if (_isPasting) return;

		try
		{
			ClearDataGrid ();

			var dt = ClipboardParser.Parse (
				lastClipboardText,
				_fm.chkSort.Checked,
				_fm.chkGroupByfirstColumn.Checked
				);

			if (dt == null || dt.Rows.Count < 1) return;

			grd.DataSource = dt;
			UpdateDataGridColumnsFromDataSource (dt, grd, _fm.chkSkipEmptyColumns);

		}
		catch (Exception ex)
		{
			ex.eLogError (true);
		}
		finally
		{
			UpdatePasteAvailability ();
		}
	}




}



