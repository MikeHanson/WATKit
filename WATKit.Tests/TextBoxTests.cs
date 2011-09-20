using System;
using FluentAssertions;
using NUnit.Framework;
using WATKit.Controls;

namespace WATKit.Tests
{
	[TestFixture]
	public class TextBoxTests: TestBase
	{
		private const string ExpectedText = "Some Text";
		
		[Test]
		public void SetTextUpdatesValueOfTextBox()
		{
			var result = this.Aut.MainWindow.FindControl().WithId(Utility.TextBoxWithName).IncludeDescendants().As<TextBox>();
			result.Should().NotBeNull();
			result.SetText(ExpectedText);
			result.Text.Should().Be(ExpectedText);
		}

		[Test]
		public void TypeTextUpdatesValueOfTextBox()
		{
			var result = this.Aut.MainWindow.FindControl().WithId(Utility.TextBoxWithName).IncludeDescendants().As<TextBox>();
			result.Should().NotBeNull();
			result.TypeText(ExpectedText);
			result.Text.Should().Be(ExpectedText);
		}

		[Test]
		public void TypeTextReplacesExistingText()
		{
			var result = this.Aut.MainWindow.FindControl().WithId(Utility.TextBoxWithName).IncludeDescendants().As<TextBox>();
			result.Should().NotBeNull();
			result.SetText("Some other text");
			result.TypeText(ExpectedText);
			result.Text.Should().Be(ExpectedText);
		}

		[Test]
		public void TypeTextWithTypeRateUpdatesValueOfTextBox()
		{
			var result = this.Aut.MainWindow.FindControl().WithId(Utility.TextBoxWithName).IncludeDescendants().As<TextBox>();
			result.Should().NotBeNull();
			result.TypeText(ExpectedText, 200);
			result.Text.Should().Be(ExpectedText);
		}
	}
}
