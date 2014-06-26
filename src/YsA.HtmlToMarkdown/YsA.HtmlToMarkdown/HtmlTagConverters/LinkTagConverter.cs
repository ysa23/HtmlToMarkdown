using System.Collections.Generic;

namespace YsA.HtmlToMarkdown.HtmlTagConverters
{
	internal class LinkTagConverter : IHtmlTagConverter
	{
		private const string LinkMarkdownFormat = "[{0}]({1})";

		public string[] TagPattern { get { return new[] {"a"}; } }
		public string Replacement(string innerHtml, IDictionary<string, string> attributes)
		{
			if (!attributes.ContainsKey("href"))
				return innerHtml;

			return string.Format(LinkMarkdownFormat, innerHtml, attributes["href"]);
		}
	}
}