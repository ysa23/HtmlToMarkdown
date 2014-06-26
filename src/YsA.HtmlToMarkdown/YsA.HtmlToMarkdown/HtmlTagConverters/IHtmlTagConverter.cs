using System.Collections.Generic;

namespace YsA.HtmlToMarkdown.HtmlTagConverters
{
	internal interface IHtmlTagConverter
	{
		string[] TagPattern { get; }

		string Replacement(string innerHtml, IDictionary<string, string> attributes);
	}
}
