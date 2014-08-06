using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Micspam
{
	public static class Extensions
	{
		public static List<ListViewItem> GetItems(this ListView list)
		{
			return list.Items.Cast<ListViewItem>().ToList();
		}

		public static List<ListViewItem> GetSelectedItems(this ListView list)
		{
			return list.SelectedItems.Cast<ListViewItem>().ToList();
		}
	}
}
