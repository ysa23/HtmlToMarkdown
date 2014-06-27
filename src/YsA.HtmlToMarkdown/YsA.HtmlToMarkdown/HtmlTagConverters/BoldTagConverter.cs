﻿using System.Collections.Generic;

namespace YsA.HtmlToMarkdown.HtmlTagConverters
{
	public class BoldTagConverter : IHtmlTagConverter, IRemoveWhenEmpty
	{
		public string[] TagPattern { get { return new[] {"strong", "b"}; } }
		public string Replacement(string innerHtml, IDictionary<string, string> attributes)
		{
			return "**" + innerHtml + "**";
		}
	}
}
