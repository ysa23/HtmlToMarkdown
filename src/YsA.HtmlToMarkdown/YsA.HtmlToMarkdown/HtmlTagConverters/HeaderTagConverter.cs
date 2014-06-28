using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace YsA.HtmlToMarkdown.HtmlTagConverters
{
	public class HeaderTagConverter : IHtmlTagConverter, IRemoveWhenEmpty
	{
		private const string HeaderMarkupFormat = "\n\n{0} {1}\n";
		public string[] TagPattern { get { return new[] {"h(?<count>[1-6]?)"}; } }

		public string Replacement(string innerHtml, IDictionary<string, string> attributes, Match tagMatch)
		{
			var count = int.Parse(tagMatch.Groups["count"].Value);

			return string.Format(HeaderMarkupFormat, Enumerable.Repeat("#", count).Aggregate((x, y) => x + y), innerHtml);
		}
	}
}