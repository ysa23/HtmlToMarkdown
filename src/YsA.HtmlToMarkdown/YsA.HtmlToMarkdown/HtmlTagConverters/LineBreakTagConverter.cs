using System.Collections.Generic;

namespace YsA.HtmlToMarkdown.HtmlTagConverters
{
	public class LineBreakTagConverter : IHtmlTagConverter, ISelfClosingTag
	{
		public string[] TagPattern { get { return new[] {"br"}; }}
		public string Replacement(string innerHtml, IDictionary<string, string> attributes)
		{
			return "\n";
		}
	}
}