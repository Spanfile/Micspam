using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using CSCore.SoundOut;
using CSCore.CoreAudioAPI;
using CSCore;
using CSCore.Codecs;

namespace Micspam
{
	public class AudioInfo
	{
		public int index;
		public string name;
		public string source;
		public string friendlySource;
		public string type;
		public int length;
		public float volume;

		List<Tuple<WasapiOut, IWaveSource>> audioOuts;
		Dictionary<MMDevice, bool> devices;

		public event EventHandler Stopped;

		public bool Playing
		{
			get
			{
				return audioOuts.Any(s => s.Item1.PlaybackState == PlaybackState.Playing);
			}
		}

		public AudioInfo(int index, string name, string source, string friendlySource, string type, int length)
		{
			this.index = index;
			this.name = name;
			this.source = source;
			this.friendlySource = friendlySource;
			this.type = type;
			this.length = length;

			this.volume = 1;

			audioOuts = new List<Tuple<WasapiOut, IWaveSource>>();
		}

		public void PopulateDevices(MMDevice[] deviceList)
		{
			devices = new Dictionary<MMDevice, bool>();

			foreach (MMDevice device in deviceList)
				devices.Add(device, false);
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

		public async void Play()
		{
			MMDevice[] playDevices = GetEnabledDevices();
			Console.WriteLine("Playing \"{0}\" on devices: {1}", name, String.Join<string>(", ", playDevices.Select(d => d.FriendlyName)));

			List<ManualResetEvent> mres = new List<ManualResetEvent>();

			foreach (MMDevice device in playDevices)
			{
				WasapiOut audioOut = new WasapiOut();
				IWaveSource source = CodecFactory.Instance.GetCodec(this.source);

				audioOut.Device = device;
				audioOut.Initialize(source);
				audioOut.Volume = volume;

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

			await Task.Run(() => WaitHandle.WaitAll(mres.ToArray()));

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

		public void SetVolume(float volume)
		{
			this.volume = volume;

			if (Playing)
				foreach (var audioOut in audioOuts)
					audioOut.Item1.Volume = volume;
		}
	}
}
