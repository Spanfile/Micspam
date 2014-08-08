using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Micspam
{
	public partial class AcceptedExtensionsForm : Form
	{
		public AcceptedExtensionsForm()
		{
			InitializeComponent();
		}

		public void PopulateExtensionList(Tuple<string, string>[] extensions)
		{
			foreach (var ext in extensions)
				listExtensions.Items.Add(new ListViewItem(new string[] {
					ext.Item2,
					ext.Item1
				}));
		}
	}
}
