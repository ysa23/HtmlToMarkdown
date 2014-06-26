using System.Collections.Generic;
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
		private const string SourceTagPatternFormat = "<{0}\\b(?<attributes>[^>]*?)>(?<content>[\\s\\S]*?)<\\/{0}>";
		private const string SelfClosingTagPatternFormat = "<{0}\\b(?<attributes>[^>]*?)>";
		private static readonly Regex AttributeRegex = new Regex("(?<name>[a-zA-Z]+?)=[\"'](?<value>[^'\"]*?)[\"']", RegexOptions.Compiled);

		private readonly IHtmlTagConverter[] _converters;

		public HtmlToMarkdownConverter()
		{
			_converters = new IHtmlTagConverter[]
			{
				new ParagraphTagConverter(),
				new LinkTagConverter(),
				new ImageTagConverter(),
				new LineBreakTagConverter()
			};
		}

		public string ToMarkdown(string html)
		{
			var markdown = html;

			foreach (var converter in _converters)
			{
				var innerConverter = converter;
				foreach (var tagRegex in converter.TagPattern.Select(x => string.Format(GetPatternFormat(innerConverter), x)))
				{
					markdown = Regex.Replace(markdown, tagRegex,
						x => innerConverter.Replacement(x.Groups["content"].Value, CreateAttributes(x.Groups["attributes"].Value)));
				}
			}

			return markdown;
		}

		private static string GetPatternFormat(IHtmlTagConverter converter)
		{
			return converter is ISelfClosingTag
				? SelfClosingTagPatternFormat
				: SourceTagPatternFormat;
		}

		private IDictionary<string, string> CreateAttributes(string attributes)
		{
			return AttributeRegex.Matches(attributes)
				.OfType<Match>()
				.ToDictionary(x => x.Groups["name"].Value, x => x.Groups["value"].Value);
		}
	}
}
