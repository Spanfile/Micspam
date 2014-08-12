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
		BackgroundWorker worker;

		List<Tuple<string, string>> extensions;

		delegate void UpdateCurrentLabel(string text);
		UpdateCurrentLabel updateCurrentLabel;

		public LoadAudiosForm(string sourcePath, bool searchChildren, List<DeviceInfo> devices, List<Tuple<string, string>> extensions)
		{
			InitializeComponent();

			Infos = new List<AudioInfo>();
			path = sourcePath;
			this.searchChildren = searchChildren;
			this.devices = devices;

			this.extensions = extensions;

			updateCurrentLabel = new UpdateCurrentLabel(s => lblCurrent.Text = s);
		}

		private bool IsAccepted(string extension)
		{
			return extensions.Select(t => t.Item1).Contains(extension);
		}

		private string GetExtensionName(string extension)
		{
			return extensions.First(t => t.Item1.Equals(extension)).Item2;
		}

		private void LoadAudiosForm_Shown(object sender, EventArgs e)
		{
			Stopwatch timer = new Stopwatch();
			timer.Start();

			worker = new BackgroundWorker();

			worker.WorkerReportsProgress = true;
			worker.WorkerSupportsCancellation = true;

			worker.DoWork += worker_DoWork;

			worker.ProgressChanged += (s, args) =>
			{
				progressLoadProg.Value = args.ProgressPercentage;
				lblTime.Text = timer.Elapsed.ToString("%m\\:ss");

				//Console.WriteLine("Progress report: {0}", args.ProgressPercentage);
			};

			worker.RunWorkerCompleted += (s, args) =>
			{
				if (args.Cancelled)
				{
					Console.WriteLine("Work cancelled");
					return;
				}

				int[] result = args.Result as int[];
				timer.Stop();
				Console.WriteLine("{0} files out of {1} added in {2}", result[0], result[1], timer.Elapsed.ToString("%m\\:ss\\.fff"));

				this.DialogResult = System.Windows.Forms.DialogResult.OK;
			};

			worker.RunWorkerAsync();
		}

		void worker_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;

			if (!Directory.Exists(path))
			{
				MessageBox.Show(this, "Couldn't refresh list of audios, source directory doesn't exist! (\"" + path + "\")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				worker.CancelAsync();
				return;
			}

			Console.WriteLine("Refreshing audio list from \"{0}\"", path);

			var files = from file in Directory.EnumerateFiles(path, "*", searchChildren ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
						where IsAccepted(Path.GetExtension(file))
						select file;

			if (!files.Any())
			{
				Console.WriteLine("Couldn't find any files");
				worker.CancelAsync();
				return;
			}

			int count = files.Count();

			int index = 0;
			foreach (string file in files)
			{
				if (worker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}

				string extension = Path.GetExtension(file);
				string fullPath = Path.GetFullPath(file);
				string name = AudioTags.GetName(fullPath);
				string source = Extensions.GetPartOfPathAfter(fullPath, Path.GetFileName(path));
				string type = GetExtensionName(extension);
				TimeSpan length = AudioTags.GetLength(fullPath);

				Log.WriteLine("Name: {0}", name);

				AudioInfo info = new AudioInfo(index, name, fullPath, type, length);
				info.PopulateDevices(devices.ToArray());

				ListViewItem item = new ListViewItem(new string[] {
					"",
					name,
					length.ToString("%m\\:ss"),
					type,
					source
				});
				info.listItem = item;
				Infos.Add(info);

				Console.WriteLine("\"{0}\" added ({1}, {2}, {3})", name, index, type, length.ToString("%m\\:ss"));

				worker.ReportProgress((int)(((double)index / (double)count) * 100d));
				if (this.InvokeRequired)
					this.Invoke(updateCurrentLabel, fullPath);
				else
					updateCurrentLabel(fullPath);

				index += 1;
			}

			Console.WriteLine("Loaded {0} audios", Infos.Count);
			e.Result = new int[] { index, count };
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			worker.CancelAsync();
		}
	}
}
