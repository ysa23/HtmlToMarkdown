using System.Collections.Generic;

namespace YsA.HtmlToMarkdown.HtmlTagConverters
{
	internal class ImageTagConverter : IHtmlTagConverter, ISelfClosingTag
	{
		private const string ImageMarkdownFormat = "![{0}]({1})";
		private const string ImagePlaceholderMarkdownFormat = "![{0}]";

		public string[] TagPattern { get { return new [] { "img" }; } }
		public string Replacement(string innerHtml, IDictionary<string, string> attributes)
		{
			if (attributes.ContainsKey("src") && !string.IsNullOrEmpty(attributes["src"]))
				return string.Format(ImageMarkdownFormat, attributes.ContainsKey("alt") ? attributes["alt"] : "image", attributes["src"]);

			return attributes.ContainsKey("alt") ?
				string.Format(ImagePlaceholderMarkdownFormat, attributes["alt"]) :
				string.Empty;
		}
	}
}
