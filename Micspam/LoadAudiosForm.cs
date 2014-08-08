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
using System.Diagnostics;

namespace Micspam
{
	public partial class LoadAudiosForm : Form
	{
		public List<AudioInfo> Infos { get; set; }

		string path;
		bool searchChildren;
		List<DeviceInfo> devices;
		bool shouldCancel = false;

		List<Tuple<string, string>> extensions;

		delegate void SetStatus(string text, int progress, TimeSpan elapsed);
		delegate void SetProgressMax(int max);
		SetStatus setStatus;
		SetProgressMax setProgressMax;

		public LoadAudiosForm(string sourcePath, bool searchChildren, List<DeviceInfo> devices, List<Tuple<string, string>> extensions)
		{
			InitializeComponent();

			Infos = new List<AudioInfo>();
			path = sourcePath;
			this.searchChildren = searchChildren;
			this.devices = devices;

			this.extensions = extensions;

			setStatus = new SetStatus((s, p, e) =>
			{
				if (shouldCancel)
					return;

				lblCurrent.Text = String.Format("({0}/{1}) {2}", p, progressLoadProg.Maximum, s); // descriptive variable names ftw
				lblTime.Text = e.ToString("%m\\:ss");
				progressLoadProg.Value = p;
			});

			setProgressMax = new SetProgressMax(m => progressLoadProg.Maximum = m);
		}

		private Task<int[]> GetLoadTask(Func<TimeSpan> getTimeFunc)
		{
			return Task.Run<int[]>(() =>
			{
				if (!Directory.Exists(path))
				{
					MessageBox.Show(this, "Couldn't refresh list of audios, source directory doesn't exist! (\"" + path + "\")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return new int[] { -1, -1 };
				}

				Console.WriteLine("Refreshing audio list from \"{0}\"", path);

				var files = from file in Directory.EnumerateFiles(path, "*", searchChildren ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
							where IsAccepted(Path.GetExtension(file))
							select file;

				if (!files.Any())
				{
					Console.WriteLine("Couldn't find any files");
					return new int[] { -1, -1 };
				}

				int count = files.Count();

				if (this.InvokeRequired)
					this.Invoke(setProgressMax, count);
				else
					setProgressMax(count);

				int index = 0;
				foreach (string file in files)
				{
					string extension = Path.GetExtension(file);
					string name = Path.GetFileNameWithoutExtension(file);
					string source = file;
					string fullPath = Path.GetFullPath(file);
					string type = GetExtensionName(extension);
					TimeSpan length = AudioLength.Get(fullPath);

					AudioInfo info = new AudioInfo(index, name, fullPath, source, type, length);
					info.PopulateDevices(devices.ToArray());

					ListViewItem item = new ListViewItem(new string[] {
						"",
						info.name,
						info.length.ToString("%m\\:ss"),
						info.type,
						info.source
					});
					info.listItem = item;

					Infos.Add(info);

					Console.WriteLine("\"{0}\" added ({1}, {2}, {3})", name, index, type, length.ToString("%m\\:ss"));

					if (shouldCancel)
						break;

					if (this.InvokeRequired)
						this.Invoke(setStatus, fullPath, index, getTimeFunc()); // what an odd workaround
					else
						setStatus(fullPath, index, getTimeFunc()); // ^ you can't use refs in lambda expressions

					index += 1;
				}

				Console.WriteLine("Loaded {0} audios", Infos.Count);

				return new int[] { index, count };
			});
		}

		private bool IsAccepted(string extension)
		{
			return extensions.Select(t => t.Item1).Contains(extension);
		}

		private string GetExtensionName(string extension)
		{
			return extensions.First(t => t.Item1.Equals(extension)).Item2;
		}

		private async void LoadAudiosForm_Shown(object sender, EventArgs e)
		{
			Stopwatch timer = new Stopwatch();
			timer.Start();

			int[] result = await GetLoadTask(() => timer.Elapsed);

			timer.Stop();
			Console.WriteLine("{0} files out of {1} added in {2} ms", result[0], result[1], timer.Elapsed.ToString("%m\\:ss\\.fff"));

			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void LoadAudiosForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			shouldCancel = true;
		}
	}
}
