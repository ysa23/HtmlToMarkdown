using System.Linq;
using System.Text.RegularExpressions;
using YsA.HtmlToMarkdown.HtmlTagConverters;

namespace YsA.HtmlToMarkdown
{
	public interface IHtmlToMarkdownConverter
	{
		string ToMarkdown(string html);
	}

	public class HtmlToMarkdownConverter : IHtmlToMarkdownConverter
	{
		private const string SourceTagPatternFormat = "<{0}\\b([^>]*)>(?<content>[\\s\\S]*?)<\\/{0}>";

		private readonly IHtmlTagConverter[] _converters;

		public HtmlToMarkdownConverter()
		{
			_converters = new IHtmlTagConverter[]
			{
				new ParagraphTagConverter()
			};
		}

		public string ToMarkdown(string html)
		{
			return _converters
				.Aggregate(html, (current1, converter) => converter
					.TagPattern
					.Select(tag => string.Format(SourceTagPatternFormat, tag))
					.Aggregate(current1, (current, sourceRegex) => 
						Regex.Replace(current, sourceRegex, x => converter.Replacement(x.Groups["content"].Value))));
		}
	}
}
