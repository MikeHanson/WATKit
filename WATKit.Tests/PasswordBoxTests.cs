using System;
using FluentAssertions;
using NUnit.Framework;
using WATKit.Controls;

namespace WATKit.Tests
{
	[TestFixture]
	public class PasswordBoxTests: TestBase
	{
		private const string ExpectedText = "Some Text";
		
		[Test]
		public void SetTextUpdatesValueOfPasswordBox()
		{
			var result = this.Aut.MainWindow.FindControl().WithId(Utility.PasswordBoxWithName).IncludeDescendants().As<PasswordBox>();
			result.Should().NotBeNull();
			result.SetText(ExpectedText);
		}

		[Test]
		public void TypeTextUpdatesValueOfPasswordBox()
		{
			var result = this.Aut.MainWindow.FindControl().WithId(Utility.PasswordBoxWithName).IncludeDescendants().As<PasswordBox>();
			result.Should().NotBeNull();
			result.TypeText(ExpectedText);
		}

		[Test]
		public void TypeTextReplacesExistingText()
		{
			var result = this.Aut.MainWindow.FindControl().WithId(Utility.PasswordBoxWithName).IncludeDescendants().As<PasswordBox>();
			result.Should().NotBeNull();
			result.SetText("Some other text");
			result.TypeText(ExpectedText);
		}

		[Test]
		public void TypeTextWithTypeRateUpdatesValueOfPasswordBox()
		{
			var result = this.Aut.MainWindow.FindControl().WithId(Utility.PasswordBoxWithName).IncludeDescendants().As<PasswordBox>();
			result.Should().NotBeNull();
			result.TypeText(ExpectedText, 200);
		}
	}
}
