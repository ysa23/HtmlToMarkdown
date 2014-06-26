namespace YsA.HtmlToMarkdown.HtmlTagConverters
{
	internal class ParagraphTagConverter : IHtmlTagConverter
	{
		public string[] TagPattern { get { return new[] {"p"}; } }

		public string Replacement(string innerHtml)
		{
			return "\n\n" + innerHtml + "\n";
		}
	}
}
