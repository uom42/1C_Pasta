using WK.Libraries.SharpClipboardNS;


namespace Pasta.Modules.Paste1C;


internal partial class Engine
{


	private SharpClipboard _clipboard;


	private void InitClipboardReader ()
	{

		_clipboard = new ();
		{
			_clipboard.ObservableFormats.Texts = true;
			_clipboard.ObserveLastEntry = false;
			_clipboard.ClipboardChanged += ( _, e ) => OnClipboardChanged (e);
		}

		ReadClipboard ();
	}


	private void OnClipboardChanged ( WK.Libraries.SharpClipboardNS.SharpClipboard.ClipboardChangedEventArgs e )
	{
		if (_isPasting || e.ContentType != SharpClipboard.ContentTypes.Text) return;

		lock (_sync)
		{
			//Canceling old timer
			_tmrDelay?.Change (Timeout.Infinite, Timeout.Infinite);
			_tmrDelay?.Dispose ();

			_tmrDelay = new (OnClipboardChangedTimer, null, 1000, Timeout.Infinite);
		}
	}


	private void OnClipboardChangedTimer ( object? state )
	{
		_tmrDelay?.Change (Timeout.Infinite, Timeout.Infinite);
		_tmrDelay?.Dispose ();
		_fm.BeginInvoke (ReadClipboard);
	}


	private void ReadClipboard ()
	{
		if (_isPasting) return;

		Application.DoEvents ();

		lock (_sync)
		{
			ReadClipboard_Core ();
		}
	}


	private void ReadClipboard_Core ()
	{
		if (_isPasting) return;

		try
		{
			string clipText = Clipboard.GetText ();
			if (clipText.eIsNullOrWhiteSpace ()) return;

			lastClipboardText = clipText;

		}
		catch (Exception ex)
		{
			lastClipboardText = string.Empty;

			ex.eLogError (true);
		}
		finally
		{
			ParseLastKnownClipboardText ();
		}
	}


}



