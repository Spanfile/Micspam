using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSCore.SoundOut;
using CSCore.CoreAudioAPI;
using CSCore;
using CSCore.Codecs;

namespace Micspam
{
	public class DeviceInfo
	{
		public MMDevice device;

		public bool enabled = true;

		public DeviceInfo(MMDevice device)
		{
			this.device = device;
		}
	}
}
