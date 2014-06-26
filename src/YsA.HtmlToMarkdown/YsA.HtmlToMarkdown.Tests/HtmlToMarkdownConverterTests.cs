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

		[Test]
		public void ToMarkdown_WhenHtmlContainLinkTag_ReplaceLinkTagWithMarkdownLink()
		{
			const string html = "<a href='http://blog.house-of-code.com'>Link title</a>";

			var result = _target.ToMarkdown(html);

			Assert.That(result, Is.EqualTo("[Link title](http://blog.house-of-code.com)"));
		}

		[Test]
		public void ToMarkdown_WhenHtmlContainLinkTagAndHrefIsInQuates_ReplaceLinkTagWithMarkdownLink()
		{
			const string html = "<a href=\"http://blog.house-of-code.com\">Link title</a>";

			var result = _target.ToMarkdown(html);

			Assert.That(result, Is.EqualTo("[Link title](http://blog.house-of-code.com)"));
		}

		[Test]
		public void ToMarkdown_WhenLinkTagAsNoHrefAttribute_OnlyReturnContent()
		{
			const string html = "<a>Link title</a>";

			var result = _target.ToMarkdown(html);

			Assert.That(result, Is.EqualTo("Link title"));
		}

		[Test]
		public void ToMarkdown_WhenLinkTagContainsTargetAttribute_IgnoreTargetAttribute()
		{
			const string html = "<a href=\"http://blog.house-of-code.com\" target=\"_blank\">Link title</a>";

			var result = _target.ToMarkdown(html);

			Assert.That(result, Is.EqualTo("[Link title](http://blog.house-of-code.com)"));
		}

		[Test]
		public void ToMarkdown_WhenHtmlContainsImageTag_ReplaceImageTagWithMarkdown()
		{
			const string html = "<img src=\"http://blog.house-of-code.com/profile/profile-img.png\" alt='image title'/>";

			var result = _target.ToMarkdown(html);

			Assert.That(result, Is.EqualTo("![image title](http://blog.house-of-code.com/profile/profile-img.png)"));
		}

		[Test]
		public void ToMarkdown_WhenImageDoesNotHaveSource_ReturnImagePlaceholder()
		{
			const string html = "<img alt='image title'/>";

			var result = _target.ToMarkdown(html);

			Assert.That(result, Is.EqualTo("![image title]"));
		}

		[Test]
		public void ToMarkdown_WhenImageSourceIsEmptu_ReturnImagePlaceholder()
		{
			const string html = "<img alt='image title' src=''/>";

			var result = _target.ToMarkdown(html);

			Assert.That(result, Is.EqualTo("![image title]"));
		}

		[Test]
		public void ToMarkdown_WhenImageDoesNotHaveTitle_ReturnDefaultTitle()
		{
			const string html = "<img src=\"http://blog.house-of-code.com/profile/profile-img.png\"/>";

			var result = _target.ToMarkdown(html);

			Assert.That(result, Is.EqualTo("![image](http://blog.house-of-code.com/profile/profile-img.png)"));
		}

		[Test]
		public void ToMarkdown_WhenImageHasNoSourceOrTitle_ReturnEmptyString()
		{
			const string html = "<img/>";

			var result = _target.ToMarkdown(html);

			Assert.That(result, Is.Empty);
		}

		[Test]
		public void ToMarkdown_WhenImageIsNotClosed_ReturnMarkdown()
		{
			const string html = "<img src=\"http://blog.house-of-code.com/profile/profile-img.png\" alt='image title'>";

			var result = _target.ToMarkdown(html);

			Assert.That(result, Is.EqualTo("![image title](http://blog.house-of-code.com/profile/profile-img.png)"));
		}

		[Test]
		public void ToMarkdown_WhenHtmlContainsLineBreaks_ReplaceLineBreaksWithNewLine()
		{
			const string html = "<p>Some content<br>new line<br/>another new line</p>";

			var result = _target.ToMarkdown(html);

			Assert.That(result, Is.EqualTo("\n\nSome content\nnew line\nanother new line\n"));
		}
	}
}
