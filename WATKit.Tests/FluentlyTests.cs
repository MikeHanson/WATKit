using System;
using FluentAssertions;
using NUnit.Framework;
using WATKit.Controls;
using WATKit.Tests.Controls;

namespace WATKit.Tests
{
	[TestFixture]
	public class FluentlyTests
	{
		private const string InvalidApplicationPath = @"C:\InvalidePath.exe";
		
		[Test]
		public void LaunchSetsApplicationPathOfLaunchSettings()
		{
			var launchSettings = Fluently.Launch(Utility.GetApplicationPath());
			launchSettings.Should().NotBeNull();
			launchSettings.ApplicationPath.Should().Be(Utility.GetApplicationPath());
		}

		[Test]
		public void WaitUntilMainWindowIsLoadedSetsWaitForWindowHandleToTrue()
		{
			var launchSettings = Fluently.Launch(Utility.GetApplicationPath()).WaitUntilMainWindowIsLoaded();
			launchSettings.Should().NotBeNull();
			launchSettings.WaitForWindowHandle.Should().BeTrue();
		}

		[Test]
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

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void LaunchWithInvalidPathThrowsException()
		{
			Fluently.Launch(InvalidApplicationPath).WaitUntilMainWindowIsLoaded().WithDefaultMainWindow();
		}

		[Test]
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

		[Test]
		public void WithDefaultMainWindowReturnsApplicationUnderTestWithMainWindowAsWindow()
		{
			var aut = Fluently.Launch(Utility.GetApplicationPath()).WaitUntilMainWindowIsLoaded().WithDefaultMainWindow();
			aut.MainWindow.Should().BeOfType<Window>();
			aut.MainWindow.AutomationElement.Current.NativeWindowHandle.Should().Be(aut.MainWindowHandle);
			aut.ShutDown(true);
		}

		[Test]
		public void WithMainWindowAsReturnsApplicationUnderTestWithMainWindowOfSpecifiedType()
		{
			var aut = Fluently.Launch(Utility.GetApplicationPath()).WaitUntilMainWindowIsLoaded().WithMainWindowAs<MainWindow>();
			aut.MainWindow.Should().BeOfType<MainWindow>();
			aut.MainWindow.AutomationElement.Current.NativeWindowHandle.Should().Be(aut.MainWindowHandle);
			aut.ShutDown(true);
		}
	}
}
