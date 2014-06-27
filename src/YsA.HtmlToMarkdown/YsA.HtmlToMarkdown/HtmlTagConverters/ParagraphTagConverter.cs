using System.Collections.Generic;

namespace YsA.HtmlToMarkdown.HtmlTagConverters
{
	internal class ParagraphTagConverter : IHtmlTagConverter
	{
		public string[] TagPattern { get { return new[] {"p"}; } }

		public string Replacement(string innerHtml, IDictionary<string, string> attributes)
		{
			return string.IsNullOrEmpty(innerHtml) ? string.Empty : "\n\n" + innerHtml + "\n";
		}
	}
}
