using System.Data;

using CommunityToolkit.HighPerformance;

using Pasta.Modules.Paste1C.Extensions;

namespace Pasta.Modules.Paste1C;

using static Pasta.Modules.Paste1C.Constants;


internal static class ClipboardParser
{

	internal static DataTable? Parse ( string? source, bool sort, bool group, int columnToSortAndGroup = 0 )
	{
		if (null == source || source.eIsNullOrWhiteSpace ()) return null;

		string[] rowStrings = [ .. source.eReadLines (true) ];
		if (!rowStrings.Any ()) return null;

		var tabSplittedRows = rowStrings
			.Select (s => s.Split (COLUMN_SEPARATOR_CHAR, StringSplitOptions.TrimEntries)).Cast<object[]> ()
			.ToArray ();

		object[,] objects2DArray = new object[ tabSplittedRows.Length, tabSplittedRows.Select (s => s.Length).Max () ];
		Span2D<object> objects2DSpan = objects2DArray.AsSpan2D ();

		foreach (var rowString in tabSplittedRows.Index ())
		{
			var srcRow = rowString.Item.ToArray ().AsSpan ();
			var targetRow = objects2DSpan.GetRowSpan (rowString.Index);
			srcRow.CopyTo (targetRow);
		}

		DataTable dt = new ();
		var columnIndexes = Enumerable.Range (0, objects2DSpan.Width)
			.ToArray ();

		List<DataColumn> dataTableColumns = [];

		foreach (var columnIndex in columnIndexes)
		{
			//Detect numeric and empty columns

			var columnValuesRef = objects2DSpan.GetColumn (columnIndex);


			//Create Column(columnIndex)
			string columnHeader = $"Столбец {columnIndex + 1}";
			Type columnType = typeof (string);


			var isEmptyColumn = !columnValuesRef.ToArray ().Where (obj => ( (string) obj ).eIsNotNullOrWhiteSpace ()).Any ();
			int numericValuesCount = 0;

			if (!isEmptyColumn)
			{
				foreach (var columnValue in columnValuesRef.ToArray ().Index ())
				{
					if (columnValue.Item.IsNumericValue (out var parsed))
					{
						numericValuesCount++;
						columnValuesRef[ columnValue.Index ] = parsed;
					}
				}
			}

			bool columnIsNumeric = !isEmptyColumn && ( numericValuesCount == objects2DSpan.Height );
			if (columnIsNumeric)
			{
				columnType = COLUMN_DATA_TYPE_NUMERIC;
				columnHeader += "\n(число)";
			}
			else
			{
				columnHeader += isEmptyColumn
					? "\n(пустой)"
					: "\n(текст)";
			}

			columnHeader += "\n*";


			DataColumn col = new (columnHeader, columnType);
			if (columnIsNumeric)
			{
				//Detecting max decimal places lenght in all column...
				int maxFracLen = columnValuesRef
					.ToArray ()
					.Select (x =>
					{
						decimal dbl = (decimal) x;
						decimal frac = dbl % 1;
						if (frac == 0) return 0; //Integer value
						var fracLen = frac.ToString ().Length - 2;
						return fracLen;
					}
					)
					.Max ();

				//Settin up column extened properties
				col.MarkAsNumeric (maxFracLen);
			}
			else if (isEmptyColumn)
			{
				col.ExtendedProperties.Add (COLUMN_EXT_PROP_IS_EMPTY, true);
			}

			dataTableColumns.Add (col);
		}

		//AppendColumns
		dt.Columns.AddRange ([ .. dataTableColumns ]);


		List<object[]> tableRows = [];
		for (int rowIndex = 0 ; rowIndex < objects2DSpan.Height ; rowIndex++)
		{
			var rowdata = objects2DSpan.GetRowSpan (rowIndex).ToArray ();
			tableRows.Add (rowdata);
		}

		if (sort)
		{
			Func<object[], string> sortByStr = new (s => s[ columnToSortAndGroup ].ToString () ?? string.Empty);
			Func<object[], decimal> sortByNUm = new (s => (decimal) s[ columnToSortAndGroup ]);

			var colToSort = dataTableColumns[ columnToSortAndGroup ];
			var isNumCol = colToSort.IsNumericValuesColumn (out _);

			var oe = isNumCol
				? tableRows.OrderBy (rowData => sortByNUm)
				: tableRows.OrderBy (rowData => sortByStr);

			tableRows = oe.ToList ();
		}

		//AppendRows
		foreach (var row in tableRows)
		{
			dt.Rows.Add (row);
		}

		if (group) GroupByColumn (dt, columnToSortAndGroup);

		return dt;
	}


	private static void GroupByColumn ( DataTable dtSrc, int columnToSortAndGroup )
	{
		if (null == dtSrc || dtSrc.Rows.Count < 1) return;

		var dataColumns = dtSrc.Columns
			.OfType<DataColumn> ()
			.ToArray ();

		var numericColumnIndexes = dataColumns.Index ()
			.Where (cc => cc.Item.IsNumericValuesColumn (out _))
			.Select (cc => cc.Index)
			.ToArray ();

		var col = dataColumns[ columnToSortAndGroup ];

		if (col.DataType != COLUMN_DATA_TYPE_STRING) return;// throw new Exception ("Grouping must be only by string!");

		var dataRows = dtSrc.Rows
			.OfType<DataRow> ()
			.Select (row => row.ItemArray)
			.ToArray ()
			.Index ()
			.ToArray ();

		var groups = dataRows
			.GroupBy (rowRaw => ( (string) rowRaw.Item[ columnToSortAndGroup ]! ).Trim (), StringComparer.CurrentCultureIgnoreCase)
			.Where (grp => grp.Count () > 1)
			.ToArray ();


		List<int> rowsToRemove = [];
		foreach (var group in groups)
		{
			var firstGroupRow = group.First ();
			object[] firstGroupRowValues = firstGroupRow.Item!;

			var groupRows = group.ToArray ();

			foreach (var colIndex in numericColumnIndexes)
			{
				decimal columnSum = groupRows.Select (row => ( (decimal) row.Item[ colIndex ]! )).Sum ();
				firstGroupRowValues[ colIndex ] = columnSum;
			}

			//put back summarized values of first group row
			dtSrc.Rows[ firstGroupRow.Index ].ItemArray = firstGroupRowValues;

			//Remove all other group rows
			var removeIndexes = ( groupRows[ 1.. ] )
				.Select (row => row.Index)
				.ToArray ();

			rowsToRemove.AddRange (removeIndexes);
		}

		//Remove them in reverse order
		rowsToRemove.Sort ();
		rowsToRemove.Reverse ();

		foreach (var rowIndex in rowsToRemove)
		{
			dtSrc.Rows.RemoveAt (rowIndex);
		}



	}




}