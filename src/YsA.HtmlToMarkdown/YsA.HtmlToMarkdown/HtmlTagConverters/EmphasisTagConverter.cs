using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace YsA.HtmlToMarkdown.HtmlTagConverters
{
	public class EmphasisTagConverter : IHtmlTagConverter, IRemoveWhenEmpty
	{
		public string[] TagPattern { get { return new[] {"em", "i"}; }}

		public string Replacement(string innerHtml, IDictionary<string, string> attributes, Match tagMatch)
		{
			return "_" + innerHtml + "_";
		}
	}
}
