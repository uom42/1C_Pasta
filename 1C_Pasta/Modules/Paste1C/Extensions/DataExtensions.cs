using System.Data;

using Pasta.Modules.Paste1C.GridControls;

using static Pasta.Modules.Paste1C.Constants;


namespace Pasta.Modules.Paste1C.Extensions;


internal static class DataExtensions
{


	public static bool IsCheckedToOutput ( this DataGridViewColumn col )
	{
		var hdr = (CheckBoxedHeaderCell) col.HeaderCell;
		return hdr.Checked;
	}




	public static void MarkAsNumeric ( this DataColumn col, int maxFracLen )
	{
		col.ExtendedProperties.Add (COLUMN_EXT_PROP_IS_NUMERIC, true);
		col.ExtendedProperties.Add (COLUMN_EXT_PROP_NUMERIC_FORMAT, $"N{maxFracLen}");
	}

	public static void MarkAsEmpty ( this DataColumn col )
		=> col.ExtendedProperties.Add (COLUMN_EXT_PROP_IS_EMPTY, true);



	public static bool IsEmptyValuesColumn ( this DataColumn col )
	{
		bool isEmptyColumn = col.ExtendedProperties.ContainsKey (COLUMN_EXT_PROP_IS_EMPTY);
		return isEmptyColumn;
	}


	public static bool IsNumericValuesColumn ( this DataColumn col, out string format )
	{
		format = string.Empty;

		bool columnIsNumeric = !col.IsEmptyValuesColumn () && col.DataType == COLUMN_DATA_TYPE_NUMERIC;
		if (columnIsNumeric)
		{
			format = (string) col.ExtendedProperties[ COLUMN_EXT_PROP_NUMERIC_FORMAT ]!;
		}

		return columnIsNumeric;
	}




	internal static readonly CultureInfo ciUS = CultureInfo.GetCultureInfo ("En-us");
	internal static readonly CultureInfo ciRU = CultureInfo.GetCultureInfo ("RU-ru");
	internal static readonly CultureInfo ciGlobal = CultureInfo.InvariantCulture;

	public static bool IsNumericValue ( this object obj, out decimal numericValue )
	{
		numericValue = 0;

		string s = (string) obj;

		if (decimal.TryParse (s, NumberStyles.Any, null, out numericValue)) return true;
		if (decimal.TryParse (s, NumberStyles.Any, ciGlobal.NumberFormat, out numericValue)) return true;
		if (decimal.TryParse (s, NumberStyles.Any, ciRU.NumberFormat, out numericValue)) return true;
		if (decimal.TryParse (s, NumberStyles.Any, ciUS.NumberFormat, out numericValue)) return true;

		return false;
	}



}
