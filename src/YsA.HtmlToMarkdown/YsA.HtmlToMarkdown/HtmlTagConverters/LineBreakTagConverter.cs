using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace YsA.HtmlToMarkdown.HtmlTagConverters
{
	public class LineBreakTagConverter : IHtmlTagConverter, ISelfClosingTag
	{
		public string[] TagPattern { get { return new[] {"br"}; }}

		public string Replacement(string innerHtml, IDictionary<string, string> attributes, Match tagMatch)
		{
			return "\n";
		}
	}
}