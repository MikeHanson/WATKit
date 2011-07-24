using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WATKit.Controls;
using WATKit.Tests.Controls;

namespace WATKit.Tests
{
	[TestClass]
	public class FluentlyTests
	{
		private const string InvalidApplicationPath = @"C:\InvalidePath.exe";
		
		[TestMethod]
		public void LaunchSetsApplicationPathOfLaunchSettings()
		{
			var launchSettings = Fluently.Launch(Utility.GetApplicationPath());
			launchSettings.Should().NotBeNull();
			launchSettings.ApplicationPath.Should().Be(Utility.GetApplicationPath());
		}

		[TestMethod]
		public void WaitUntilMainWindowIsLoadedSetsWaitForWindowHandleToTrue()
		{
			var launchSettings = Fluently.Launch(Utility.GetApplicationPath()).WaitUntilMainWindowIsLoaded();
			launchSettings.Should().NotBeNull();
			launchSettings.WaitForWindowHandle.Should().BeTrue();
		}

		[TestMethod]
		public void LaunchWithValidPathLaunchesAppAndReturnsApplicationUnderTest()
		{
			var aut = Fluently.Launch(Utility.GetApplicationPath()).WaitUntilMainWindowIsLoaded().WithDefaultMainWindow();
			aut.Should()
				.NotBeNull();
			aut.Name
				.Should()
				.Be(Utility.ApplicationTitle);
			aut.IsRunning
				.Should()
				.BeTrue();
			aut.ShutDown(true);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void LaunchWithInvalidPathThrowsException()
		{
			Fluently.Launch(InvalidApplicationPath).WaitUntilMainWindowIsLoaded().WithDefaultMainWindow();
		}

		[TestMethod]
		public void ShutDownEndsApplicationProcessAndReturnsTrue()
		{
			var aut = Fluently.Launch(Utility.GetApplicationPath()).WaitUntilMainWindowIsLoaded().WithDefaultMainWindow();
			aut.ShutDown()
				.Should()
				.BeTrue();
			aut.IsRunning
				.Should()
				.BeFalse();
		}

		[TestMethod]
		public void WithDefaultMainWindowReturnsApplicationUnderTestWithMainWindowAsWindow()
		{
			var aut = Fluently.Launch(Utility.GetApplicationPath()).WaitUntilMainWindowIsLoaded().WithDefaultMainWindow();
			aut.MainWindow.Should().BeOfType<Window>();
			aut.MainWindow.AutomationElement.Current.NativeWindowHandle.Should().Be(aut.MainWindowHandle);
			aut.ShutDown(true);
		}

		[TestMethod]
		public void WithMainWindowAsReturnsApplicationUnderTestWithMainWindowOfSpecifiedType()
		{
			var aut = Fluently.Launch(Utility.GetApplicationPath()).WaitUntilMainWindowIsLoaded().WithMainWindowAs<MainWindow>();
			aut.MainWindow.Should().BeOfType<MainWindow>();
			aut.MainWindow.AutomationElement.Current.NativeWindowHandle.Should().Be(aut.MainWindowHandle);
			aut.ShutDown(true);
		}
	}
}
