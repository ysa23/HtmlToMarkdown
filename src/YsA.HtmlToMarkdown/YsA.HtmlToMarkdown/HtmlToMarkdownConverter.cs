using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
		private const string SourceTagPatternFormat = "<{0}\\b(?<attributes>[^>]*?)>(?<content>[\\s\\S]*?)<\\/{0}>";
		private static readonly Regex AttributeRegex = new Regex("(?<name>[a-zA-Z]+?)=[\"'](?<value>[^'\"]*?)[\"']", RegexOptions.Compiled);

		private readonly IHtmlTagConverter[] _converters;

		public HtmlToMarkdownConverter()
		{
			_converters = new IHtmlTagConverter[]
			{
				new ParagraphTagConverter(),
				new LinkTagConverter()
			};
		}

		public string ToMarkdown(string html)
		{
			return _converters
				.Aggregate(html, (current1, converter) => converter
					.TagPattern
					.Select(tag => string.Format(SourceTagPatternFormat, tag))
					.Aggregate(current1, (current, sourceRegex) => 
						Regex.Replace(current, sourceRegex, x => converter.Replacement(x.Groups["content"].Value, CreateAttributes(x.Groups["attributes"].Value)))));
		}

		private IDictionary<string, string> CreateAttributes(string attributes)
		{
			return AttributeRegex.Matches(attributes)
				.OfType<Match>()
				.ToDictionary(x => x.Groups["name"].Value, x => x.Groups["value"].Value);
		}
	}
}
