using static Pasta.Modules.Paste1C.Constants;


namespace Pasta.Modules.Paste1C.Extensions;


internal static class PasteExtensions
{


	internal async static Task SendAndWait ( this string textToSend, ProcessInfo process1C, bool dictionaryValue, bool exchangeModeClipboard = false, bool doNotTrimSpecialChars = false )
	{
		if (!process1C.IsForeground ()) throw new Exception (C_MSG_1C_WINDOW_FOCUS_LOST);

		if (!doNotTrimSpecialChars) textToSend = textToSend.Trim ().TrimEnd ('\t', '\r', '\n', ' ');

		process1C.WaitForInputIdle ();

		if (exchangeModeClipboard)
		{
			textToSend.eSetClipboardSafe ();
			await Task.Delay (DELAY_CELL_PASTE_FROM_CLIPBOARD);
			textToSend = C_KEYS_PASTE;
		}
		else
		{

			//The plus sign (+), caret (^), percent sign (%), tilde (~), and parentheses () have special meanings to SendKeys.
			//To specify one of these characters, enclose it within braces ({}). 
			//For example, to specify the plus sign, use "{+}". To specify brace characters, use "{{}" and "{}}". 
			//Brackets ([ ]) have no special meaning to SendKeys, but you must enclose them in braces. 
			//In other applications, brackets do have a special meaning that might be significant when dynamic data exchange (DDE) occurs.

			char[] invalidChars = { '+', '^', '%', '~', '(', ')' };
			textToSend = textToSend.eReplaceCharsWithString (invalidChars, x => '{' + x.ToString () + '}');
		}

		SendKeys.SendWait (textToSend);
		await Task.Delay (dictionaryValue
			? DELAY_CELL_PASTE_DICTIONARY
			: DELAY_CELL_PASTE_TEXT);

	}



	internal static void WaitForInputIdle ( this ProcessInfo process1C ) => ( (Process) process1C ).WaitForInputIdle ();


}



