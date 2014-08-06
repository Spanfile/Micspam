using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

using CSCore;
using CSCore.CoreAudioAPI;
using CSCore.Codecs;
using CSCore.SoundOut;

namespace Micspam
{
	public partial class MainForm : Form
	{
		string audioSourceDir = "sources";

		List<string> acceptedExtensions;
		Dictionary<string, string> extensionNames;

		List<DeviceInfo> deviceInfos;
		MMDevice defaultDevice;

		public MainForm()
		{
			InitializeComponent();
		}

		private void RefreshDevices()
		{
			deviceInfos.Clear();

			Console.WriteLine("Refreshing devices");
			using (MMDeviceEnumerator enumerator = new MMDeviceEnumerator())
			{
				defaultDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
				Console.WriteLine("Default device is \"{0}\"", defaultDevice.FriendlyName);

				using (MMDeviceCollection deviceCollection = enumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active))
				{
					foreach (MMDevice device in deviceCollection)
					{
						DeviceInfo info = new DeviceInfo(device);

						if (device.FriendlyName == defaultDevice.FriendlyName)
							info.isDefault = true;

						deviceInfos.Add(info);
						Console.WriteLine("Adding \"{0}\"", device.FriendlyName);
					}
				}
			}

			Console.WriteLine("Done");
		}

		private void RefreshAudioList()
		{
			if (!Directory.Exists(audioSourceDir))
			{
				MessageBox.Show(this, "Couldn't refresh list of audios, source directory doesn't exist! (\"" + audioSourceDir + "\")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Console.WriteLine("Refreshing audio list from \"{0}\"", audioSourceDir);

			List<AudioInfo> infos = new List<AudioInfo>();
			string[] files = Directory.GetFiles(audioSourceDir);

			if (!files.Any())
			{
				Console.WriteLine("Directory is empty");
				return;
			}

			int index = 0;
			foreach (string file in files)
			{
				string extension = Path.GetExtension(file);
				if (!acceptedExtensions.Contains(extension))
				{
					Console.WriteLine("Invalid file extension ({0})", extension);
					continue;
				}

				string name = Path.GetFileNameWithoutExtension(file);
				string source = file;
				string fullPath = Path.GetFullPath(file);
				string type = extensionNames[extension];
				TimeSpan length = AudioLength.Get(fullPath);

				AudioInfo info = new AudioInfo(index, name, fullPath, source, type, length);
				info.PopulateDevices(GetDevices().ToArray());
				infos.Add(info);

				Console.WriteLine("Added info to list (Index: {0}, name: {1}, type: {2}, length: {3})", index, name, type, length.ToString("%m\\:ss"));

				index += 1;
			}

			listAudios.Items.Clear();
			foreach (AudioInfo info in infos)
			{
				ListViewItem item = new ListViewItem(new string[] {
					"",
					info.name,
					info.length.ToString("%m\\:ss"),
					info.type,
					info.source
				});

				info.Stopped += (s, e) =>
				{
					ListViewItem infoItem = GetListItemOf(info);
					infoItem.ImageIndex = 1;

					if (listAudios.SelectedItems.Count > 0)
						if (infoItem.Equals(listAudios.SelectedItems[0]))
							UpdateAudioSettingsPanel(info);
				};

				item.Tag = info;

				listAudios.Items.Add(item);
			}

			Console.WriteLine("Done");
		}

		private void PlayAudio(AudioInfo info)
		{
			info.SetMasterVolume(UpdateGlobalVolume());
			info.SetVolume(UpdateAudioVolume());
			info.Play();
		}

		private float UpdateGlobalVolume()
		{
			float volume = (float)trackGlobalVolume.Value / (float)trackGlobalVolume.Maximum;
			lblGlobalVolumeValue.Text = String.Format("({0:0.00})", volume);

			foreach (AudioInfo info in GetAudioInfos())
				info.SetMasterVolume(volume);

			UpdateAudioVolume();

			return volume;
		}

		private float UpdateAudioVolume()
		{
			float volume = (float)trackAudioVolume.Value / (float)trackAudioVolume.Maximum;
			float modified = volume * ((float)trackGlobalVolume.Value / (float)trackGlobalVolume.Maximum);
			lblAudioVolumeValue.Text = String.Format("({0:0.00}, {1:0.00})", volume, modified);

			if (listAudios.SelectedItems.Count > 0)
				(listAudios.SelectedItems[0].Tag as AudioInfo).SetVolume(volume);

			return volume;
		}

		private List<AudioInfo> GetPlayingAudios()
		{
			return GetAudioInfos().Where(i => i.Playing).ToList();
		}

		private List<AudioInfo> GetAudioInfos()
		{
			return listAudios.GetItems().Select(i => i.Tag as AudioInfo).ToList();
		}

		private ListViewItem GetListItemOf(AudioInfo info)
		{
			return listAudios.GetItems().Where(i => (i.Tag as AudioInfo).Equals(info)).FirstOrDefault();
		}

		private void StopAllAudios()
		{
			foreach (AudioInfo info in GetPlayingAudios())
				info.Stop();
		}

		private void UpdateAudioSettingsPanel(AudioInfo info)
		{
			btnPlayAudio.Text = info.Playing ? "Stop" : "Play";
			GetListItemOf(info).ImageIndex = info.Playing ? 0 : 1;
			listAudioOutputDevices.Enabled = !info.Playing;
		}

		private List<MMDevice> GetDevices()
		{
			return deviceInfos.Select(d => d.device).ToList();
		}

		private List<MMDevice> GetEnabledDevices()
		{
			return deviceInfos.Where(d => d.enabled).Select(d => d.device).ToList();
		}

		private void PrintDeviceList()
		{
			foreach (DeviceInfo info in deviceInfos)
				Console.WriteLine("\"{0}\": {1}", info.device.FriendlyName, info.enabled);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			lblAudioSourceDir.Text = Path.GetFileName(audioSourceDir);

			acceptedExtensions = new List<string>();
			acceptedExtensions.Add(".wav");
			acceptedExtensions.Add(".mp3");

			extensionNames = new Dictionary<string, string>();
			extensionNames.Add(".wav", "Waveform");
			extensionNames.Add(".mp3", "MP3");

			deviceInfos = new List<DeviceInfo>();
			RefreshDevices();
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			RefreshAudioList();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			StopAllAudios();
		}

		private void btnRefreshAudioList_Click(object sender, EventArgs e)
		{
			RefreshAudioList();
		}

		private void listAudios_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listAudios.SelectedItems.Count < 1)
			{
				groupAudioSettings.Enabled = false;
				groupAudioSettings.Text = "Audio settings";
				return;
			}

			AudioInfo info = listAudios.SelectedItems[0].Tag as AudioInfo;

			groupAudioSettings.Enabled = true;
			groupAudioSettings.Text = info.name;

			UpdateAudioSettingsPanel(info);
			//Console.WriteLine((listAudios.SelectedItems[0].Tag as AudioInfo).Playing);

			trackAudioVolume.Value = (int)(info.volume * 100);

			listAudioOutputDevices.Items.Clear();
			foreach (MMDevice device in GetEnabledDevices())
			{
				ListViewItem item = new ListViewItem(device.FriendlyName);
				item.Tag = device;

				if (device.FriendlyName == defaultDevice.FriendlyName) // may not be best implementation
					item.Checked = true;

				listAudioOutputDevices.Items.Add(item);
			}
		}

		private void btnUseDefaultDevice_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in listAudioOutputDevices.Items)
			{
				MMDevice device = item.Tag as MMDevice;
				item.Checked = device.FriendlyName == defaultDevice.FriendlyName;
			}
		}

		private void menuViewAudioDir_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(audioSourceDir);
		}

		private void btnPlayAudio_Click(object sender, EventArgs e)
		{
			AudioInfo info = listAudios.SelectedItems[0].Tag as AudioInfo;
			if (!info.Playing)
				PlayAudio(info);
			else
				info.Stop();

			UpdateAudioSettingsPanel(info);
		}

		private void listAudioOutputDevices_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			AudioInfo info = listAudios.SelectedItems[0].Tag as AudioInfo;
			foreach (ListViewItem item in listAudioOutputDevices.Items)
			{
				MMDevice device = item.Tag as MMDevice;
				info.SetDeviceStatus(device, item.Checked);
			}
		}

		private void trackAudioVolume_ValueChanged(object sender, EventArgs e)
		{
			UpdateAudioVolume();
		}

		private void trackGlobalVolume_ValueChanged(object sender, EventArgs e)
		{
			UpdateGlobalVolume();
		}

		private void btnStopAllAudios_Click(object sender, EventArgs e)
		{
			StopAllAudios();
		}

		private void menuViewOutputDevices_Click(object sender, EventArgs e)
		{
			DevicesForm form = new DevicesForm();
			form.PopulateDeviceList(deviceInfos);

			if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				deviceInfos = form.GetDeviceList();
				Console.WriteLine("Device list updated");
				PrintDeviceList();
			}
		}
	}
}
