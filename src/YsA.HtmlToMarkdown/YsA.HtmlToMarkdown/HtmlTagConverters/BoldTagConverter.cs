using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace YsA.HtmlToMarkdown.HtmlTagConverters
{
	public class BoldTagConverter : IHtmlTagConverter, IRemoveWhenEmpty
	{
		public string[] TagPattern { get { return new[] {"strong", "b"}; } }

		public string Replacement(string innerHtml, IDictionary<string, string> attributes, Match tagMatch)
		{
			return "**" + innerHtml + "**";
		}
	}
}
