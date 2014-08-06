using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace Micspam
{
	// http://www.codeproject.com/Articles/11556/Converting-Wildcards-to-Regexes

	public class Wildcard : Regex
	{
		public Wildcard(string pattern)
			: base(WildcardToRegex(pattern), RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled)
		{
		}


		public static string WildcardToRegex(string pattern)
		{
			return "^" + Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".");
		}
	}
}
