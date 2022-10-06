using System.Windows.Forms;

using uom.Extensions;


#nullable enable

namespace Pasta
{
	internal class DataRowListViewItem : ListViewItem
	{

		public readonly string[] DataFor1C;


		public DataRowListViewItem(string[] data) : base("@")
		{
			DataFor1C = data;
			foreach (var txt in data) SubItems.Add(txt.Trim());
		}


		public static void ReEumerateItems(ListView lvw)
		{
			DataRowListViewItem[] ii = lvw.e_ItemsAs<DataRowListViewItem>().ToArray();
			foreach (DataRowListViewItem li in ii) li.Text = (li.Index + 1).ToString();
		}
	}
}