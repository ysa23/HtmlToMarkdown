using System.Collections.Generic;

namespace YsA.HtmlToMarkdown.HtmlTagConverters
{
	internal class ParagraphTagConverter : IHtmlTagConverter, IRemoveWhenEmpty
	{
		public string[] TagPattern { get { return new[] {"p"}; } }

		public string Replacement(string innerHtml, IDictionary<string, string> attributes)
		{
			return "\n\n" + innerHtml + "\n";
		}
	}
}
