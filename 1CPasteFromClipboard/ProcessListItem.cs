using System.Windows.Forms;

using uom.Extensions;


#nullable enable

namespace Pasta
{
	internal class ProcessListItem
	{
		//private const string C_1C_PROCESS_NAME = "1cv8";
		private const string C_1C_PROCESS_NAME = "1c";

		private static int currentProcessID = Process.GetCurrentProcess().Id;

		public readonly Process @Process;
		private readonly string Name;
		public readonly string Title;

		public ProcessListItem(Process p)
		{
			@Process = p;
			Name = p.ProcessName;
			Title = $"{Name} ({p.MainWindowTitle})";
		}

		public override string ToString() => Title;


		public bool IsLike1CProcess =>
			(@Process.Id != currentProcessID) && Name.ToLower().StartsWith(C_1C_PROCESS_NAME.ToLower());

	}

}