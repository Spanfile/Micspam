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
	public partial class DevicesForm : Form
	{
		public DevicesForm()
		{
			InitializeComponent();
		}

		public void PopulateDeviceList(List<DeviceInfo> devices)
		{
			foreach (DeviceInfo info in devices)
			{
				ListViewItem item = new ListViewItem(new string[] {
					info.device.FriendlyName,
					GetBoolFriendlyName(info.enabled)
				});
				item.Tag = info;
				listDevices.Items.Add(item);
			}
		}

		public List<DeviceInfo> GetDeviceList()
		{
			return listDevices.GetItems().Select(i => i.Tag as DeviceInfo).ToList();
		}

		private string GetBoolFriendlyName(bool value)
		{
			if (value)
				return "Yes";
			else
				return "No";
		}

		private void listDevices_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<ListViewItem> selectedItems = listDevices.GetSelectedItems();

			if (selectedItems.Count < 1)
			{
				groupDeviceSettings.Enabled = false;
				return;
			}

			groupDeviceSettings.Enabled = true;

			if (selectedItems.Select(i => i.Tag as DeviceInfo).All(d => d.enabled))
				checkDeviceEnabled.CheckState = CheckState.Checked;
			else if (selectedItems.Select(i => i.Tag as DeviceInfo).All(d => !d.enabled))
				checkDeviceEnabled.CheckState = CheckState.Unchecked;
			else
				checkDeviceEnabled.CheckState = CheckState.Indeterminate;
		}

		private void checkDeviceEnabled_CheckedChanged(object sender, EventArgs e)
		{
			List<ListViewItem> selectedItems = listDevices.GetSelectedItems();

			foreach (ListViewItem item in selectedItems)
			{
				DeviceInfo info = item.Tag as DeviceInfo;

				info.enabled = checkDeviceEnabled.Checked;
				item.SubItems[1].Text = GetBoolFriendlyName(info.enabled);

				Console.WriteLine("\"{0}\" status set to {1}", info.device.FriendlyName, info.enabled);
			}
		}
	}
}
