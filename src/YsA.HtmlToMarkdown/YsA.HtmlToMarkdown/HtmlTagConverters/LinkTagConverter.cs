using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace YsA.HtmlToMarkdown.HtmlTagConverters
{
	internal class LinkTagConverter : IHtmlTagConverter
	{
		private const string LinkMarkdownFormat = "[{0}]({1})";

		public string[] TagPattern { get { return new[] {"a"}; } }

		public string Replacement(string innerHtml, IDictionary<string, string> attributes, Match tagMatch)
		{
			if (!attributes.ContainsKey("href"))
				return innerHtml;

			if (string.IsNullOrEmpty(innerHtml))
				return attributes["href"];

			return string.Format(LinkMarkdownFormat, innerHtml, attributes["href"]);
		}
	}
}