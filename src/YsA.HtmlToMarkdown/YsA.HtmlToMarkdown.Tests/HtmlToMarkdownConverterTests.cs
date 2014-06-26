using NUnit.Framework;

namespace YsA.HtmlToMarkdown.Tests
{
	[TestFixture]
	public class HtmlToMarkdownConverterTests
	{
		private IHtmlToMarkdownConverter _target;

		[SetUp]
		public void Setup()
		{
			_target = new HtmlToMarkdownConverter();
		}

		[Test]
		public void ToMarkdown_WhenHtmlContainsParagraphTags_ReplaceParagraphWithNewLine()
		{
			const string html = "<p>Some content</p>";

			var result = _target.ToMarkdown(html);

			Assert.That(result, Is.EqualTo("\n\nSome content\n"));
		}

		[Test]
		public void ToMarkdown_WhenParagraphContainsAttribute_IgnoreAttribute()
		{
			const string html = "<p class='test'>Some content</p>";

			var result = _target.ToMarkdown(html);

			Assert.That(result, Is.EqualTo("\n\nSome content\n"));
		}
	}
}
