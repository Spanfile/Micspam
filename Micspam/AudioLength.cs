using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Micspam
{
	public static class AudioLength
	{
		[DllImport("winmm.dll")]
		private static extern uint mciSendString(string command, StringBuilder returnValue, int returnLength, IntPtr winHandle);

		public static int Get(string fileName)
		{
			StringBuilder lengthBuffer = new StringBuilder(32);

			mciSendString(String.Format("open \"{0}\" alias audio", fileName), null, 0, IntPtr.Zero);
			mciSendString("status audio length", lengthBuffer, lengthBuffer.Capacity, IntPtr.Zero);
			mciSendString("close audio", null, 0, IntPtr.Zero);

			int length = 0;
			Int32.TryParse(lengthBuffer.ToString(), out length);

			return length;
		}
	}
}
