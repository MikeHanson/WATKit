using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WATKit.Controls;

namespace WATKit.Tests
{
	[TestClass]
	public class ButtonTests
	{
		private static ApplicationUnderTest Aut;

		[ClassInitialize]
		public static void Initialise(TestContext context)
		{
			Aut = ApplicationUnderTest.Launch(Constants.ApplicationPath, true);
		}

		[ClassCleanup]
		public static void CleanupClass()
		{
			if(Aut != null)
			{
				Aut.ShutDown(true);
			}
		}

		[TestMethod]
		public void ButtonClickIsInvokedOnButtonThatChangesContent()
		{
			var result = Aut.MainWindow.FindControl().WithId(Constants.IChangeMyNameButtonId).IncludeDescendants().Now().As<Button>();
			result.Should().NotBeNull();
			result.Click();
			result.Name.Should().Be(Constants.IChangeMyNameButtonNewName);
		}
	}
}
