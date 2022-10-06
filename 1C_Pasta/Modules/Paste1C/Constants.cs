namespace Pasta.Modules.Paste1C;


internal static class Constants
{

	internal const char COLUMN_SEPARATOR_CHAR = '\t';
	internal static readonly Type COLUMN_DATA_TYPE_NUMERIC = typeof (decimal);
	internal static readonly Type COLUMN_DATA_TYPE_STRING = typeof (string);

	internal const string COLUMN_EXT_PROP_IS_EMPTY = "IS_EMPTY";
	internal const string COLUMN_EXT_PROP_IS_NUMERIC = "IS_NUMERIC";
	internal const string COLUMN_EXT_PROP_NUMERIC_FORMAT = "NUMERIC_FORMAT";




	private readonly static Color COLUMN_COLOR_NUMERIC = Color.PaleGreen;//'(ARGB = &HFF98FB98) (H;S;B; = 120; 0,9252337; 0,7901961;)
	private readonly static Color COLUMN_COLOR_EMPTY = SystemColors.ControlDark;

	internal readonly static Color ROW_OUTPUT_PROCESSING_COLOR_BACK = Color.Yellow;
	internal readonly static Color ROW_OUTPUT_PROCESSING_COLOR_FORE = Color.Red;

	internal readonly static DataGridViewCellStyle _cellStyle_Header = new () { Alignment = DataGridViewContentAlignment.MiddleCenter };
	internal readonly static DataGridViewCellStyle _cellStyle_Empty = new () { BackColor = COLUMN_COLOR_EMPTY };
	internal readonly static DataGridViewCellStyle _cellStyle_Numeric = new ()
	{
		Alignment = DataGridViewContentAlignment.MiddleRight,
		BackColor = COLUMN_COLOR_NUMERIC
	};




	/// <summary>
	/// Время после того, как пользователь кликнул кнопку "Вставить  в 1С", до начала активации окна 1С
	/// </summary>
	internal const int DELAY_USER_CLICK_PASTE_BUTTON = 1000;
	internal const int DELAY_WAIT_1C_WINDOW_FOCUSED = 2000;

	internal const int DELAY_CELL_PASTE_TEXT = 100;
	internal const int DELAY_CELL_PASTE_DICTIONARY = 800;

	/// <summary>Время после отправки текста в буфер обмена, до нажатия Ctrl+V в 1С. Даём время ОС на обработку буфера обмена.</summary>
	internal const int DELAY_CELL_PASTE_FROM_CLIPBOARD = 300;



	internal const string C_ERR_1C_WORKING_PROCESS_NOT_FOUND = "Не найден работающий процесс 1С!";
	internal const string C_MSG_1C_MORE_THAN_ONE_INSTANCES_RUNNING = "Найдено более одного активного процесса 1С!";
	internal const string C_MSG_1C_WINDOW_FOCUS_LOST = "1C Window focus lost!";
	internal const string C_MSG_PROGRESS = "Обработано строк: {0} из {1} ({2:P2})";
	internal const string C_KEYS_INS = "{INS}";
	internal const string C_KEYS_TAB = "{TAB}";
	internal const string C_KEYS_RETURN = "{ENTER}";
	internal const string C_KEYS_F3 = "{F3}";

	/// <summary>Ctrl+V</summary>
	internal const string C_KEYS_PASTE = "^v";


}
