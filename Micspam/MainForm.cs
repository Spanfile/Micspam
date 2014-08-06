﻿using System;
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
		bool searchChildren = true;

		List<string> acceptedExtensions;
		Dictionary<string, string> extensionNames;

		List<AudioInfo> audioInfos;

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

			lblAudioSourceDir.Text = Path.GetFullPath(audioSourceDir);

			string[] files = Directory.GetFiles(audioSourceDir, "*.*", searchChildren ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

			if (!files.Any())
			{
				Console.WriteLine("Couldn't find any files");
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

				ListViewItem item = new ListViewItem(new string[] {
					"",
					info.name,
					info.length.ToString("%m\\:ss"),
					info.type,
					info.source
				});

				info.listItem = item;
				info.Stopped += (s, e) =>
				{
					ListViewItem infoItem = info.listItem;
					if (infoItem == null)
					{
						Console.WriteLine("Something went wrong; the list item tied to the audio isn't there!");
						return;
					}

					infoItem.ImageIndex = 1;
					UpdateSettings();

					if (listAudios.SelectedItems.Count > 0)
						if (infoItem.Equals(listAudios.SelectedItems[0]))
							UpdateAudioSettingsPanel(info);
				};

				audioInfos.Add(info);

				Console.WriteLine("Added info to list (Index: {0}, name: {1}, type: {2}, length: {3})", index, name, type, length.ToString("%m\\:ss"));

				index += 1;
			}

			FilterAudioList("");

			Console.WriteLine("Done");
		}

		private void FilterAudioList(string filter)
		{
			// if filter is "", all items will be added

			listAudios.Items.Clear();

			Wildcard wildcard = new Wildcard(filter);
			foreach (AudioInfo info in audioInfos)
			{
				if (wildcard.IsMatch(info.name) || filter == "")
					listAudios.Items.Add(info.listItem);
			}
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

			foreach (AudioInfo info in audioInfos)
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
				GetAudioInfoOf(listAudios.SelectedItems[0]).SetVolume(volume);

			return volume;
		}

		private List<AudioInfo> GetPlayingAudios()
		{
			return audioInfos.Where(i => i.Playing).ToList();
		}

		private void StopAllAudios()
		{
			foreach (AudioInfo info in GetPlayingAudios())
				info.Stop();
		}

		private void UpdateAudioSettingsPanel(AudioInfo info)
		{
			btnPlayAudio.Text = info.Playing ? "Stop" : "Play";
			info.listItem.ImageIndex = info.Playing ? 0 : 1;
			listAudioOutputDevices.Enabled = !info.Playing;

			UpdateSettings();
		}

		private void UpdateSettings()
		{
			menuSettingsChangeSourceDir.Enabled = !GetPlayingAudios().Any();
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

		private AudioInfo GetAudioInfoOf(ListViewItem item)
		{
			return audioInfos.Where(i => i.listItem.Equals(item)).FirstOrDefault();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			audioInfos = new List<AudioInfo>();

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

			AudioInfo info = GetAudioInfoOf(listAudios.SelectedItems[0]);

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
			AudioInfo info = GetAudioInfoOf(listAudios.SelectedItems[0]);
			if (!info.Playing)
				PlayAudio(info);
			else
				info.Stop();

			UpdateAudioSettingsPanel(info);
		}

		private void listAudioOutputDevices_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			AudioInfo info = GetAudioInfoOf(listAudios.SelectedItems[0]);
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
			UpdateSettings();
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

		private void menuSettingsChangeSourceDir_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.Description = "Select the folder from where the program will load sounds";
			fbd.ShowNewFolderButton = true;

			if (fbd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				audioSourceDir = fbd.SelectedPath;
				RefreshAudioList();
			}
		}

		private void menuSettingsFindFromChildren_Click(object sender, EventArgs e)
		{
			searchChildren = menuSettingsChangeSourceDir.Checked;
		}

		private void textAudioFilter_TextChanged(object sender, EventArgs e)
		{
			FilterAudioList(textAudioFilter.Text);
		}
	}
}
