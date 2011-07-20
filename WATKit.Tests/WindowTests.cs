using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WATKit.Tests
{
	[TestClass]
	public class WindowTests
	{
		private static ApplicationUnderTest Aut;
		
		[ClassInitialize]
		public static void Initialise(TestContext context)
		{
			Aut = ApplicationUnderTest.Launch(Utility.GetApplicationPath(), true);
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
		public void WindowIsAvailableReturnsTrueAfterLaunch()
		{
			Aut.MainWindow.IsAvailable.Should().BeTrue();
		}

		[TestMethod]
		public void WindowIsModalReturnsFalseAfterLaunch()
		{
			Aut.MainWindow.IsModal.Should().BeFalse();
		}

		[TestMethod]
		public void WindowIsVisibleReturnsTrueAfterLaunch()
		{
			Aut.MainWindow.IsVisible.Should().BeTrue();
		}

		[TestMethod]
		public void WindowNameReturnsTitleOfTestApp()
		{
			Aut.MainWindow.Name.Should().Be(Utility.ApplicationTitle);
		}
	}
}
