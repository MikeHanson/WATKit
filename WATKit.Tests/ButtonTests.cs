using System;
using FluentAssertions;
using NUnit.Framework;
using WATKit.Controls;

namespace WATKit.Tests
{
	[TestFixture]
	public class ButtonTests: TestBase
	{
		[Test]
		public void ButtonClickIsInvokedOnButtonThatChangesContent()
		{
			var result = this.Aut.MainWindow.FindControl().WithId(Utility.IChangeMyNameButtonId).IncludeDescendants().Now().As<Button>();
			result.Should().NotBeNull();
			result.Click();
			result.Name.Should().Be(Utility.IChangeMyNameButtonNewName);
		}
	}
}
