using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

using CSCore;
using CSCore.CoreAudioAPI;
using CSCore.Codecs;

namespace Micspam
{
	public static class AudioTags
	{
		static string[] extensions;

		public static void UpdateAllowedExtensions(string[] ext)
		{
			extensions = ext;
		}

		public static TimeSpan GetLength(string filename)
		{
			IWaveSource source = CodecFactory.Instance.GetCodec(filename);
			TimeSpan length = source.GetLength();
			source.Dispose();

			return length;
		}

		public static string GetName(string filename)
		{
			File file = File.Create(filename);
			
			string extension = System.IO.Path.GetExtension(filename);

			if (!extensions.Contains(extension)) // if extension is not supported, return file name anyways
				return System.IO.Path.GetFileNameWithoutExtension(filename);

			if (file.Tag.Title == null)
				return System.IO.Path.GetFileNameWithoutExtension(filename);

			return file.Tag.Title;
		}
	}
}
