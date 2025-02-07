using System.Data;
using System.Windows.Forms.VisualStyles;

using Pasta.Modules.Paste1C.Extensions;

using uom.Interfaces;

namespace Pasta.Modules.Paste1C.GridControls;



public class IndexedRowHeaderCell : DataGridViewRowHeaderCell, ICloneableT<IndexedRowHeaderCell>, ICloneable
{

	private const int PADDING = 4;

	private readonly DataGridView _grd;


	public override object Clone () => CloneT ();
	public IndexedRowHeaderCell CloneT () => new (_grd);
	public IndexedRowHeaderCell ( DataGridView grd ) : base () { _grd = grd; }





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
		graphics.Clear (Color.Red);




		return;




		//_cellBounds = cellBounds;
		if (_grd == null) return;

		base.Paint (graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

		string s = $"Строка {1}";
		graphics.eDrawTextEx (s, _grd.Font, SystemBrushes.WindowText, cellBounds, System.Drawing.ContentAlignment.MiddleRight);







		/*
		paintParts = DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground;
		base.Paint (graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

		//graphics.Clear (Color.Aqua);

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
		 */
	}





}
