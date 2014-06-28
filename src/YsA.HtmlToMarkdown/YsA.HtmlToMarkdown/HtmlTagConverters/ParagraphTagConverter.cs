using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace YsA.HtmlToMarkdown.HtmlTagConverters
{
	internal class ParagraphTagConverter : IHtmlTagConverter, IRemoveWhenEmpty
	{
		public string[] TagPattern { get { return new[] {"p"}; } }

		public string Replacement(string innerHtml, IDictionary<string, string> attributes, Match tagMatch)
		{
			return "\n\n" + innerHtml + "\n";
		}
	}
}
