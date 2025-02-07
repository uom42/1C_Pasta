using System.Data;

using Pasta.Modules.Paste1C.Extensions;
using Pasta.Modules.Paste1C.GridControls;

using static Pasta.Modules.Paste1C.Constants;


namespace Pasta.Modules.Paste1C;


internal partial class Engine
{


	private void InitDataGrid ()
	{
		ClearDataGrid ();

		grd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
		grd.AllowUserToAddRows = false;
		grd.AllowDrop = false;
		grd.AllowUserToResizeColumns = false;
		grd.AllowUserToResizeRows = false;

		grd.MultiSelect = true;
		grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

		grd.RowPostPaint += grid_RowPostPaint!;


		//grd.sele
		/*
		lvwData.FullRowSelect = true;
		lvwData.GridLines = true;
		lvwData.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		lvwData.MultiSelect = true;
		 */


	}

	private void grid_RowPostPaint ( object sender, DataGridViewRowPostPaintEventArgs e )
	{
		DataGridView grd = (DataGridView) sender!;
		var rowIdx = ( e.RowIndex + 1 ).ToString ();

		var centerFormat = new StringFormat ()
		{
			// right alignment might actually make more sense for numbers
			Alignment = StringAlignment.Center,
			LineAlignment = StringAlignment.Center
		};

		var headerBounds = new Rectangle (e.RowBounds.Left, e.RowBounds.Top, grd.RowHeadersWidth, e.RowBounds.Height);
		e.Graphics.eDrawTextEx (rowIdx, grd.Font, SystemBrushes.ControlText, headerBounds, ContentAlignment.MiddleRight);
	}


	private void ClearDataGrid ()
	{
		grd.DataSource = null;
		grd.Rows.Clear ();
		grd.Columns.Clear ();

	}


	private static void UpdateDataGridColumnsFromDataSource ( DataTable dt, DataGridView grd, ToolStripCheckBox skipEmptyColumns )
	{

		if (dt.Rows.Count < 1) return;

		/*
		foreach (var row in grd.Rows.OfType<DataGridViewRow> ())
		{
			var c = row.HeaderCell;
			c.Value = $"{row.Index + 1}";
			c.ValueType = typeof (string);
			grd.InvalidateRow (row.Index);
		}
		 */


		var dataColumns = dt.Columns.OfType<DataColumn> ().ToArray ();
		foreach (var cc in grd.Columns.OfType<DataGridViewColumn> ().Index ())
		{
			DataGridViewColumn grdCol = cc.Item;
			DataColumn dtCol = dataColumns[ cc.Index ];

			grdCol.HeaderCell.Style = _cellStyle_Header;

			bool isEmptyColumn = dtCol.IsEmptyValuesColumn ();
			if (isEmptyColumn)
			{
				grdCol.DefaultCellStyle = _cellStyle_Empty;
				grdCol.ReadOnly = true;
			}
			else if (dtCol.IsNumericValuesColumn (out string fmt))
			{
				DataGridViewCellStyle cellStyle = _cellStyle_Numeric.Clone ();
				cellStyle.Format = fmt;

				grdCol.DefaultCellStyle = cellStyle;
			}

			var cellHdr = new CheckBoxedHeaderCell (grd, dtCol, grdCol, skipEmptyColumns)
			{
				Style = _cellStyle_Header
			};
			grdCol.HeaderCell = cellHdr;
			grdCol.SortMode = DataGridViewColumnSortMode.NotSortable;
		}
	}
}



