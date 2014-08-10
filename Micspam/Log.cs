using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Micspam
{
	public static class Log
	{
		public static void WriteLine(string message, params object[] args)
		{
			Trace.WriteLine(String.Format(message, args), "Program");
		}
	}
}
