using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace YsA.HtmlToMarkdown.HtmlTagConverters
{
	internal interface IHtmlTagConverter
	{
		string[] TagPattern { get; }

		string Replacement(string innerHtml, IDictionary<string, string> attributes, Match tagMatche);
	}
}
