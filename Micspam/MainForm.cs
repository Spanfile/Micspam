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
using System.Diagnostics;

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

		List<AudioInfo> audioInfos;
		List<Tuple<string, string>> extensions;

		List<DeviceInfo> deviceInfos;
		MMDevice defaultDevice;

		delegate void UpdateAudioProgress(AudioInfo info);
		UpdateAudioProgress updateAudioProgress;

		public MainForm()
		{
			InitializeComponent();

			updateAudioProgress = new UpdateAudioProgress((i) =>
			{
				if (listAudios.SelectedItems.Count > 0)
					if (GetAudioInfoOf(listAudios.SelectedItems[0]).Equals(i))
					{
						lblAudioPosition.Text = i.GetPosition().ToString("%m\\:ss");
						progAudioPos.Value = (int)i.GetPosition().TotalMilliseconds;
					}
			});
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

			Console.WriteLine("Found {0} devices", deviceInfos.Count);
		}

		private void RefreshAudioList()
		{
			listAudios.Items.Clear();

			lblAudioSourceDir.Text = Path.GetFullPath(audioSourceDir);

			LoadAudiosForm form = new LoadAudiosForm(audioSourceDir, searchChildren, deviceInfos, extensions);
			if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
			{
				Console.WriteLine("Audio loading cancelled by user");
				return;
			}

			audioInfos = form.Infos;
			foreach (AudioInfo info in audioInfos)
			{
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
						{
							UpdateAudioSettingsPanel(info);

							lblAudioPosition.Text = "0:00";
							progAudioPos.Value = 0;
						}
				};

				info.PositionUpdate += (s, e) =>
				{
					// best log message
					//Console.WriteLine("HEY YO! {0} JUST UPDATED! IT SAYS IT'S POSITION IS {1}!", info.name, e.Position.ToString("%m\\:ss\\.fff"));

					if (this.InvokeRequired)
						this.Invoke(updateAudioProgress, info);
					else
						updateAudioProgress(info);
				};

				listAudios.Items.Add(info.listItem);
			}

			FilterAudioList("");
		}

		private void RefreshExtensions()
		{
			var changes = new List<Tuple<string, string>>();

			if (!File.Exists("extensions.txt"))
			{
				MessageBox.Show(this, "Cannot load accepted extensions; extensions.txt is missing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
				return;
			}

			var lines = File.ReadLines("extensions.txt");
			int index = 0;
			int loaded = 0;
			foreach (string line in lines)
			{
				index += 1; // index is incremented at start to make sure it increments at every iteration

				if (line.StartsWith("#") || line.Trim() == "") // comments and blank lines are ignored
					continue;

				string[] args = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

				if (args.Length < 2)
				{
					Console.WriteLine("{0}: invalid amount of arguments", index);
					continue;
				}

				string type = args[0];
				string name = args[1];

				if (!type.StartsWith("."))
				{
					Console.WriteLine("{0}: {1} isn't a valid type", index, type);
					continue;
				}

				if (extensions.Select(t => t.Item1).Contains(type))
				{
					Console.WriteLine("{0}: {1} is already added", index, type);
					continue;
				}

				changes.Add(new Tuple<string, string>(type, name));
				Console.WriteLine("Added extension: {0} ({1})", type, name);
				loaded += 1;
			}

			if (loaded == 0)
			{
				MessageBox.Show(this, "No extensions loaded!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			extensions.Clear();
			extensions.AddRange(changes);

			Console.WriteLine("Loaded {0} extensions", loaded);
		}

		private void FilterAudioList(string filter)
		{
			// if filter is "", all items will be added

			listAudios.Items.Clear();

			Wildcard wildcard = new Wildcard(filter);
			// MOORE LINQ
			var infos = from info in audioInfos.AsEnumerable()
						where wildcard.IsMatch(info.name) || info.name.Contains(filter)
						select info;

			foreach (var info in infos)
				listAudios.Items.Add(info.listItem);
		}

		private void PlayAudio(AudioInfo info)
		{
			info.Play();
		}

		private float UpdateGlobalVolume()
		{
			float volume = (float)trackGlobalVolume.Value / (float)trackGlobalVolume.Maximum;
			lblGlobalVolumeValue.Text = String.Format("{0}%", volume * 100);

			foreach (AudioInfo info in audioInfos)
				info.SetMasterVolume(volume);

			UpdateAudioVolume();

			return volume;
		}

		private float UpdateAudioVolume()
		{
			float volume = (float)trackAudioVolume.Value / (float)trackAudioVolume.Maximum;

			if (listAudios.SelectedItems.Count > 0)
			{
				GetAudioInfoOf(listAudios.SelectedItems[0]).SetVolume(volume);
				lblAudioVolumeValue.Text = String.Format("{0}%", volume * 100);
			}

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
			btnUseDefaultDevice.Enabled = !info.Playing;
			menuSettingsRefreshAudios.Enabled = !info.Playing;

			UpdateSettings();
		}

		private void UpdateSettings()
		{
			menuSettingsChangeDir.Enabled = !GetPlayingAudios().Any();
			btnRefreshAudioList.Enabled = !GetPlayingAudios().Any();
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
			extensions = new List<Tuple<string, string>>();
			RefreshExtensions();

			audioInfos = new List<AudioInfo>();

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
			lblAudioLength.Text = info.length.ToString("%m\\:ss");

			progAudioPos.Maximum = (int)info.length.TotalMilliseconds;
			progAudioPos.Value = (int)info.GetPosition().TotalMilliseconds;
			lblAudioPosition.Text = info.GetPosition().ToString("%m\\:ss");

			listAudioOutputDevices.Items.Clear();
			foreach (MMDevice device in GetEnabledDevices())
			{
				ListViewItem item = new ListViewItem(device.FriendlyName);
				item.Tag = device;

				item.Checked = info.GetDeviceStatus(device);

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

		private void menuSettingsFindFromChildren_Click(object sender, EventArgs e)
		{
			searchChildren = menuSettingsChangeDir.Checked;
		}

		private void textAudioFilter_TextChanged(object sender, EventArgs e)
		{
			FilterAudioList(textAudioFilter.Text);
		}

		private void menuSettingsChangeDirBrowse_Click(object sender, EventArgs e)
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

		private void menuSettingsChangeDirDefault_Click(object sender, EventArgs e)
		{
			audioSourceDir = "sources";
			RefreshAudioList();
		}

		private void menuSettingsRefreshDevices_Click(object sender, EventArgs e)
		{
			RefreshDevices();
		}

		private void menuSettingsRefreshExtensions_Click(object sender, EventArgs e)
		{
			RefreshExtensions();
		}

		private void menuSettingsRefreshAudios_Click(object sender, EventArgs e)
		{
			RefreshAudioList();
		}
	}
}
