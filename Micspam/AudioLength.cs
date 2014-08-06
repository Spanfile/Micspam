using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSCore;
using CSCore.CoreAudioAPI;
using CSCore.Codecs;

namespace Micspam
{
	public static class AudioLength
	{
		public static TimeSpan Get(string filename)
		{
			IWaveSource source = CodecFactory.Instance.GetCodec(filename);
			TimeSpan length = source.GetLength();
			source.Dispose();

			return length;
		}
	}
}
