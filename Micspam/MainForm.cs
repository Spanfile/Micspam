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

using CSCore;
using CSCore.CoreAudioAPI;
using CSCore.Codecs;
using CSCore.SoundIn;
using CSCore.SoundOut;

namespace Micspam
{
	public partial class MainForm : Form
	{
		MMDevice device;
		WasapiOut soundOut;
		IWaveSource soundSource;

		List<string> fileExtensions;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			soundOut = new WasapiOut();

			soundOut.Stopped += soundOut_Stopped;

			fileExtensions = new List<string>();
			fileExtensions.Add(".wav");
			fileExtensions.Add(".mp3");
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			soundOut.Dispose();
		}

		void soundOut_Stopped(object sender, EventArgs e)
		{
			btnPlay.Text = "Play";
			btnPlay.Enabled = listSounds.SelectedItems.Count > 0;
		}

		private void btnFindDevices_Click(object sender, EventArgs e)
		{
			listInputDevices.Clear();
			using (MMDeviceEnumerator enumerator = new MMDeviceEnumerator())
			{
				using (MMDeviceCollection devices = enumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active))
				{
					foreach (MMDevice device in devices)
					{
						Console.WriteLine("Found device: {0}", device.FriendlyName);
						listInputDevices.Items.Add(new ListViewItem(device.FriendlyName) { Tag = device });
					}
				}
			}
		}

		private void btnSelectDevice_Click(object sender, EventArgs e)
		{
			device = listInputDevices.SelectedItems[0].Tag as MMDevice;
			lblSelectedDevice.Text = "Output device: " + device.FriendlyName;
			groupSounds.Enabled = true;
		}

		private void btnFindWavSources_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists("sources"))
			{
				MessageBox.Show(this, "Couldn't find audio source directory! (sources)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			btnFindAudioSources.Text = "Finding...";

			Console.WriteLine("Finding audio sources from \"sources\"...");

			List<AudioInfo> audioInfos = new List<AudioInfo>();

			int index = 0;
			string[] files = Directory.GetFiles("sources");
			foreach (string file in files)
			{
				//Console.WriteLine(Path.GetExtension(file));
				if (!fileExtensions.Contains(Path.GetExtension(file)))
					return;

				string name = Path.GetFileNameWithoutExtension(file);
				int length = AudioLength.Get(file);
				string path = Path.GetFullPath(file);
				string friendlyPath = Path.Combine(Path.GetDirectoryName(file), Path.GetFileName(file));

				AudioInfo info = new AudioInfo(index, name, length, path, friendlyPath);
				audioInfos.Add(info);

				Console.WriteLine("Found audio. ID: {0}, name: {1}, friendly path: {2}", info.ID, info.Name, info.FriendlyPath);

				index += 1;
			}

			listSounds.Items.Clear();

			foreach (AudioInfo info in audioInfos)
			{
				ListViewItem item = new ListViewItem(new string[] {
					info.ID.ToString(),
					info.Name,
					TimeSpan.FromMilliseconds(info.Length).ToString("%m\\:ss"),
					info.FriendlyPath
				});
				item.Tag = info;
				listSounds.Items.Add(item);
			}

			btnFindAudioSources.Text = "Find audio sources";
		}

		private void listSounds_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (soundOut.PlaybackState == PlaybackState.Stopped)
				btnPlay.Enabled = listSounds.SelectedItems.Count > 0;
			else
				btnPlay.Enabled = true;
		}

		private void btnPlay_Click(object sender, EventArgs e)
		{
			// failsafe if button is enabled for some reason
			if (listSounds.SelectedItems.Count < 1)
				return;

			if (soundOut.PlaybackState == PlaybackState.Stopped)
			{
				AudioInfo info = listSounds.SelectedItems[0].Tag as AudioInfo;
				Console.WriteLine("Playing sound: {0}, {1} ({2}) ({3} ms)", info.ID, info.Name, info.Path, info.Length);

				soundSource = CodecFactory.Instance.GetCodec(info.Path);
				soundOut.Device = device;
				soundOut.Initialize(soundSource);
				soundOut.Volume = (float)trackVolume.Value / (float)trackVolume.Maximum;
				soundOut.Play();

				btnPlay.Text = "Stop";
			}
			else if (soundOut.PlaybackState == PlaybackState.Playing)
			{
				soundOut.Stop();

				btnPlay.Text = "Play";
			}
		}

		private void trackVolume_Scroll(object sender, EventArgs e)
		{
			soundOut.Volume = (float)trackVolume.Value / (float)trackVolume.Maximum;
		}
	}

	public class AudioInfo
	{
		public int ID { get; private set; }
		public string Name { get; private set; }
		public int Length { get; private set; }
		public string Path { get; private set; }
		public string FriendlyPath { get; private set; }

		public AudioInfo(int id, string name, int length, string path, string friendlyPath)
		{
			ID = id;
			Name = name;
			Length = length;
			Path = path;
			FriendlyPath = friendlyPath;
		}
	}
}
