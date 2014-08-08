using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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

		// http://stackoverflow.com/questions/5283236/remove-part-of-the-full-directory-name
		// based on that ^, edited to my needs
		public static string GetPartOfPathAfter(string path, string after)
		{
			var pathParts = path.Split(Path.DirectorySeparatorChar).ToList();
			int startAfter = pathParts.IndexOf(after);

			if (startAfter == -1)
				return null;

			pathParts.RemoveRange(0, startAfter + 1);
			return Path.Combine(pathParts.ToArray());
		}
	}
}
