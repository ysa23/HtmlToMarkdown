using System.Collections.Generic;

namespace YsA.HtmlToMarkdown.HtmlTagConverters
{
	public class BoldTagConverter : IHtmlTagConverter
	{
		public string[] TagPattern { get { return new[] {"strong", "b"}; } }
		public string Replacement(string innerHtml, IDictionary<string, string> attributes)
		{
			return string.IsNullOrEmpty(innerHtml) ? string.Empty : "**" + innerHtml + "**";
		}
	}
}
