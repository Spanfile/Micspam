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
			lblSelectedDevice.Text = "Selected: " + device.FriendlyName;
			groupSounds.Enabled = true;
		}

		private void btnFindWavSources_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists("sources"))
			{
				MessageBox.Show(this, "Couldn't find \"sources\" directory!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			listSounds.Items.Clear();

			int index = 0;
			string[] files = Directory.GetFiles("sources");
			foreach (string file in files)
			{
				Console.WriteLine(Path.GetExtension(file));
				if (!fileExtensions.Contains(Path.GetExtension(file)))
					return;

				string name = Path.GetFileNameWithoutExtension(file);
				int length = 0;
				string path = Path.GetFullPath(file);

				ListViewItem item = new ListViewItem(index.ToString());
				item.SubItems.Add(name);
				item.SubItems.Add(length.ToString());
				item.SubItems.Add(path);

				SoundInfo info = new SoundInfo(index, name, length, path);
				item.Tag = info;

				listSounds.Items.Add(item);

				index += 1;
			}
		}

		private void listSounds_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnPlay.Enabled = listSounds.SelectedItems.Count > 0;
		}

		private void btnPlay_Click(object sender, EventArgs e)
		{
			// failsafe if button is enabled for some reason
			if (listSounds.SelectedItems.Count < 1)
				return;

			if (soundOut.PlaybackState == PlaybackState.Stopped)
			{
				SoundInfo info = listSounds.SelectedItems[0].Tag as SoundInfo;
				Console.WriteLine("Playing sound: {0}, {1} ({2}) ({3} ms)", info.ID, info.Name, info.Path, info.Length);

				soundSource = CodecFactory.Instance.GetCodec(info.Path);
				soundOut.Device = device;
				soundOut.Initialize(soundSource);
				soundOut.Volume = (float)trackVolume.Value / 100f;
				soundOut.Play();

				btnPlay.Text = "Stop";
			}
			else if (soundOut.PlaybackState == PlaybackState.Playing)
			{
				soundOut.Stop();

				btnPlay.Text = "Play";
			}
		}

		private ISoundOut GetSoundOut()
		{
			if (WasapiOut.IsSupportedOnCurrentPlatform)
				return new WasapiOut();
			else
				return new DirectSoundOut();
		}

		private void trackVolume_Scroll(object sender, EventArgs e)
		{
			soundOut.Volume = (float)trackVolume.Value / 100f;
		}
	}

	public class SoundInfo
	{
		public int ID { get; private set; }
		public string Name { get; private set; }
		public int Length { get; private set; }
		public string Path { get; private set; }

		public SoundInfo(int id, string name, int length, string path)
		{
			ID = id;
			Name = name;
			Length = length;
			Path = path;
		}
	}
}
