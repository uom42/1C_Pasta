using System.Data;
using System.Windows.Forms.VisualStyles;

using Pasta.Modules.Paste1C.Extensions;

using uom.Interfaces;

namespace Pasta.Modules.Paste1C.GridControls;



public class CheckBoxedHeaderCell : DataGridViewColumnHeaderCell, ICloneableT<CheckBoxedHeaderCell>, ICloneable
{


	private const int PADDING = 4;

	private readonly DataGridView _grd;
	private readonly DataColumn _dc;
	private readonly DataGridViewColumn _dgc;
	private readonly ToolStripCheckBox? _skipEmptyColumns;


	private bool _checked = false;


	private Rectangle _cellBounds = new ();
	private Rectangle _rcGlyph = new ();


	private bool IsEmptyValuesColumn => _dc.IsEmptyValuesColumn ();


	public override object Clone () => CloneT ();
	public CheckBoxedHeaderCell CloneT () => new (_grd, _dc, _dgc, _skipEmptyColumns);
	public CheckBoxedHeaderCell ( DataGridView grd, DataColumn dc, DataGridViewColumn dgc, ToolStripCheckBox skipEmptyColumns ) : base ()
	{
		_grd = grd;
		_dc = dc;
		_dgc = dgc;

		if (IsEmptyValuesColumn)
		{
			_skipEmptyColumns = skipEmptyColumns;
			_skipEmptyColumns.CheckedChanged += ( _, _ ) => UpdateCheckedStateFromUI ();
		}
		_grd.ColumnHeaderMouseClick += OnColumnHeaderMouseClick;


		//Checked = !( IsEmptyValuesColumn && skipEmptyColumns.Checked );
		_checked = true;

		UpdateCheckedStateFromUI ();
	}



	private void OnColumnHeaderMouseClick ( object? _, DataGridViewCellMouseEventArgs e )
	{
		if (_dgc.Index != e.ColumnIndex) return; //Other column

		//grdCol.SortMode = DataGridViewColumnSortMode.NotSortable;

		var loc = e.Location;
		loc.Offset (_cellBounds.Left, _cellBounds.Top);

		if (!_cellBounds.Contains (loc)) return;


		if (_dgc.SortMode != DataGridViewColumnSortMode.Automatic || _rcGlyph.Contains (loc))
		{
			Checked = !Checked;
		}
	}


	private void UpdateCheckedStateFromUI ()
	{
		if (!IsEmptyValuesColumn || _skipEmptyColumns == null) return;
		Checked = !_skipEmptyColumns.Checked;
	}


	public bool Checked
	{
		get => _checked;
		set
		{
			_checked = value;
			_grd?.Invalidate ();
		}
	}


	protected override void Paint (

		Graphics graphics,
		Rectangle clipBounds,
		Rectangle cellBounds,

		int rowIndex,
		DataGridViewElementStates dataGridViewElementState,
		object? value,
		object? formattedValue,
		string? errorText,
		DataGridViewCellStyle cellStyle,
		DataGridViewAdvancedBorderStyle advancedBorderStyle,
		DataGridViewPaintParts paintParts

		)
	{
		_cellBounds = cellBounds;

		if (_grd == null) return;


		//base.Paint (graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

		paintParts = DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground;
		base.Paint (graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

		//graphics.Clear (Color.Aqua);

		CheckBoxState cs = CheckBoxState.UncheckedNormal;
		if (_checked) cs = CheckBoxState.CheckedNormal;

		var szGlyph = CheckBoxRenderer.GetGlyphSize (graphics, cs);


		var rcClient = cellBounds;
		rcClient.Inflate (-PADDING, -PADDING);
		rcClient.Height -= szGlyph.Height;

		int y = rcClient.Bottom;
		int x = rcClient.Left + ( ( rcClient.Width - szGlyph.Width ) / 2 );

		var rcText = rcClient;

		var col = _grd.Columns[ this.ColumnIndex ];

		graphics.eDrawTextEx (col.HeaderText, _grd.Font, SystemBrushes.WindowText, rcText, System.Drawing.ContentAlignment.TopCenter);


		_rcGlyph = new Rectangle (x, y, szGlyph.Width, szGlyph.Height);
		CheckBoxRenderer.DrawCheckBox (graphics, _rcGlyph.Location, cs);
	}





}
