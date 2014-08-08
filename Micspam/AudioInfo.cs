using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

using CSCore.SoundOut;
using CSCore.CoreAudioAPI;
using CSCore;
using CSCore.Codecs;

namespace Micspam
{
	public class PositionUpdateEventArgs : EventArgs
	{
		public TimeSpan Position { get; set; }

		public PositionUpdateEventArgs(TimeSpan position)
		{
			Position = position;
		}
	}

	public class AudioInfo
	{
		public ListViewItem listItem;

		public int index;
		public string name;
		public string source;
		public string friendlySource;
		public string type;
		public TimeSpan length;
		public float volume;
		public float masterVolume;

		public int positionUpdateFreq = 500;

		List<Tuple<WasapiOut, IWaveSource>> audioOuts;
		Dictionary<MMDevice, bool> devices;

		public event EventHandler Stopped;
		public event EventHandler<PositionUpdateEventArgs> PositionUpdate;

		public bool Playing
		{
			get
			{
				return audioOuts.Any(s => s.Item1.PlaybackState == PlaybackState.Playing);
			}
		}

		public AudioInfo(int index, string name, string source, string type, TimeSpan length)
		{
			this.index = index;
			this.name = name;
			this.source = source;
			this.type = type;
			this.length = length;

			this.volume = 1;
			this.masterVolume = 1;

			audioOuts = new List<Tuple<WasapiOut, IWaveSource>>();
		}

		public void PopulateDevices(DeviceInfo[] deviceList)
		{
			devices = new Dictionary<MMDevice, bool>();

			foreach (DeviceInfo info in deviceList)
				devices.Add(info.device, info.isDefault);
		}

		public void UpdateDeviceList(DeviceInfo[] deviceList)
		{
			Console.WriteLine("Updating device list for \"{0}\"", name);

			var updated = new Dictionary<MMDevice, bool>();
			List<MMDevice> devices = this.devices.Select(d => d.Key).ToList();

			DeviceComparer comparer = new DeviceComparer();

			foreach (DeviceInfo info in deviceList)
			{
				MMDevice existing = this.devices.Keys.First(d => comparer.Equals(d, info.device));
				if (existing != null)
				{
					//Console.WriteLine("Existing device found (\"{0}\"), replacing and setting status to {1}", info.device.FriendlyName, GetDeviceStatus(existing));
					updated.Add(info.device, GetDeviceStatus(existing));
				}
				else
				{
					//Console.WriteLine("New device (\"{0}\"), adding with status {1}", info.device.FriendlyName, info.isDefault);
					updated.Add(info.device, info.isDefault);
				}
			}

			Console.WriteLine("Updated from {0} devices to {1} devices", this.devices.Count, updated.Count);
			this.devices = updated;
		}

		public MMDevice[] GetEnabledDevices()
		{
			return devices.Where(kvp => kvp.Value).Select(kvp => kvp.Key).ToArray(); // dat linq
		}

		public void SetDeviceStatus(MMDevice device, bool status)
		{
			devices[device] = status;
			//Console.WriteLine("Audio \"{0}\" device \"{1}\" status: {2}", name, device.FriendlyName, status);
		}

		public bool GetDeviceStatus(MMDevice device)
		{
			return devices[device];
		}

		public async void Play()
		{
			MMDevice[] playDevices = GetEnabledDevices();
			Console.WriteLine("Playing \"{0}\" with volume {1:0.00} on devices: {2}", name, GetVolume(), String.Join<string>(", ", playDevices.Select(d => d.FriendlyName)));

			List<ManualResetEvent> mres = new List<ManualResetEvent>();

			foreach (MMDevice device in playDevices)
			{
				WasapiOut audioOut = new WasapiOut();
				IWaveSource source = CodecFactory.Instance.GetCodec(this.source);
				Console.WriteLine("Source format: {0}", source.WaveFormat.ToString());

				audioOut.Device = device;
				audioOut.Initialize(source);
				audioOut.Volume = GetVolume();

				ManualResetEvent mre = new ManualResetEvent(false);
				mres.Add(mre);
				audioOut.Stopped += (s, e) =>
				{
					audioOut.Dispose();
					source.Dispose();

					mre.Set();
					Console.WriteLine("\"{0}\" stopped on device \"{1}\"", name, device.FriendlyName);
				};

				audioOuts.Add(new Tuple<WasapiOut, IWaveSource>(audioOut, source));

				audioOut.Play();
			}

			Console.WriteLine("Waiting for all ({0}) events to trigger", mres.Count);

			await Task.Run(() =>
			{
				while (true)
				{
					if (WaitHandle.WaitAll(mres.ToArray(), positionUpdateFreq))
						return;

					PositionUpdate(this, new PositionUpdateEventArgs(GetPosition()));
				}
			});

			Console.WriteLine("\"{0}\" stopped", name);
			audioOuts.Clear();
			if (Stopped != null)
				Stopped(this, EventArgs.Empty);
		}

		public void Stop()
		{
			foreach (var audioOut in audioOuts)
				audioOut.Item1.Stop();

			audioOuts.Clear();

			Console.WriteLine("\"{0}\" forcefully stopped", name);
		}

		public TimeSpan GetPosition()
		{
			if (!Playing)
				return TimeSpan.FromSeconds(0);

			return audioOuts[0].Item1.WaveSource.GetPosition();
		}

		public void SetVolume(float volume)
		{
			Console.WriteLine("Volume set to {0:0.00} (before: {1:0.00}) for \"{2}\"", volume, this.volume, name);
			this.volume = volume;
			UpdateVolume();
		}

		public void SetMasterVolume(float volume)
		{
			Console.WriteLine("Master volume set to {0} (before: {1}) for \"{2}\"", volume, this.masterVolume, name);
			this.masterVolume = volume;
			UpdateVolume();
		}

		public void UpdateVolume()
		{
			if (Playing)
				foreach (var audioOut in audioOuts)
				{
					Console.WriteLine("Setting audio volume from {0:0.00} to {1:0.00} (\"{2}\")", audioOut.Item1.Volume, GetVolume(), name);
					audioOut.Item1.Volume = GetVolume();
				}
		}

		private float GetVolume()
		{
			return volume * masterVolume;
		}
	}
}
