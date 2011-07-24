using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WATKit.Controls;

namespace WATKit.Tests
{
	[TestClass]
	public class ButtonTests: TestBase
	{
		[TestInitialize]
		public void Initialise()
		{
			base.Initialise();
		}

		[TestCleanup]
		public void Cleanup()
		{
			base.Cleanup();
		}

		[TestMethod]
		public void ButtonClickIsInvokedOnButtonThatChangesContent()
		{
			var result = this.Aut.MainWindow.FindControl().WithId(Utility.IChangeMyNameButtonId).IncludeDescendants().Now().As<Button>();
			result.Should().NotBeNull();
			result.Click();
			result.Name.Should().Be(Utility.IChangeMyNameButtonNewName);
		}
	}
}
