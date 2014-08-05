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

		List<MMDevice> devices;
		MMDevice defaultDevice;

		public MainForm()
		{
			InitializeComponent();
		}

		private void RefreshDevices()
		{
			devices.Clear();

			Console.WriteLine("Refreshing devices");
			using (MMDeviceEnumerator enumerator = new MMDeviceEnumerator())
			{
				defaultDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
				Console.WriteLine("Default device is \"{0}\"", defaultDevice.FriendlyName);

				using (MMDeviceCollection deviceCollection = enumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active))
				{
					foreach (MMDevice device in deviceCollection)
					{
						devices.Add(device);
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
				info.PopulateDevices(devices.ToArray());
				infos.Add(info);

				Console.WriteLine("Added info to list (Index: {0}, name: {1}, type: {2}, length: {3}ms)", index, name, type, length);

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
					ListViewItem infoItem = listAudios.Items.Cast<ListViewItem>().Where(i => (i.Tag as AudioInfo).Equals(info)).FirstOrDefault();
					infoItem.ImageIndex = 1;

					if (listAudios.SelectedItems.Count > 0)
						if (infoItem.Equals(listAudios.SelectedItems[0]))
							btnPlayAudio.Text = "Play";
				};

				item.Tag = info;

				listAudios.Items.Add(item);
			}

			Console.WriteLine("Done");
		}

		private void PlayAudio(AudioInfo info)
		{
			info.Play();
		}

		private float ModifyVolume(float volume)
		{
			return volume * ((float)trackGlobalVolume.Value / (float)trackGlobalVolume.Maximum);
		}

		private float UpdateGlobalVolume()
		{
			float volume = (float)trackGlobalVolume.Value / (float)trackGlobalVolume.Maximum;
			lblGlobalVolumeValue.Text = String.Format("({0:0.00})", volume);

			UpdateAudioVolume();

			return volume;
		}

		private float UpdateAudioVolume()
		{
			float volume = (float)trackAudioVolume.Value / (float)trackAudioVolume.Maximum;
			float modified = ModifyVolume(volume);
			lblAudioVolumeValue.Text = String.Format("({0:0.00}, {1:0.00})", volume, modified);

			if (listAudios.SelectedItems.Count > 0)
				(listAudios.SelectedItems[0].Tag as AudioInfo).SetVolume(modified);

			return volume;
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

			devices = new List<MMDevice>();
			RefreshDevices();
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			RefreshAudioList();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// DAT LINQ
			List<AudioInfo> playingAudios = listAudios.Items.Cast<ListViewItem>().Select(i => i.Tag as AudioInfo).Where(i => i.Playing).ToList();
			foreach (AudioInfo info in playingAudios)
				info.Stop();
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

			btnPlayAudio.Text = info.Playing ? "Stop" : "Play";
			listAudios.SelectedItems[0].ImageIndex = info.Playing ? 0 : 1;
			//Console.WriteLine((listAudios.SelectedItems[0].Tag as AudioInfo).Playing);

			listAudioOutputDevices.Items.Clear();
			foreach (MMDevice device in devices)
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
			{
				PlayAudio(info);
				btnPlayAudio.Text = "Stop";
				listAudios.SelectedItems[0].ImageIndex = 0;
			}
			else
			{
				info.Stop();
				btnPlayAudio.Text = "Play";
				listAudios.SelectedItems[0].ImageIndex = 1;
			}
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

		private void trackAudioVolume_Scroll(object sender, EventArgs e)
		{
			UpdateAudioVolume();
		}

		private void trackGlobalVolume_Scroll(object sender, EventArgs e)
		{
			UpdateGlobalVolume();
		}
	}
}
