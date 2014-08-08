using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSCore.CoreAudioAPI;

namespace Micspam
{
	public class DeviceComparer : IEqualityComparer<MMDevice>
	{
		public bool Equals(MMDevice device1, MMDevice device2)
		{
			return device1.FriendlyName == device2.FriendlyName;
		}

		public int GetHashCode(MMDevice device)
		{
			return device.GetHashCode();
		}
	}
}
