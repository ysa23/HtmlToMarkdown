using System.Collections.Generic;

namespace YsA.HtmlToMarkdown.HtmlTagConverters
{
	public class EmphasisTagConverter : IHtmlTagConverter, IRemoveWhenEmpty
	{
		public string[] TagPattern { get { return new[] {"em", "i"}; }}
		public string Replacement(string innerHtml, IDictionary<string, string> attributes)
		{
			return "_" + innerHtml + "_";
		}
	}
}
