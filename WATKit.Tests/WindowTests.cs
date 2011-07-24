using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WATKit.Tests
{
	[TestClass]
	public class WindowTests: TestBase
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
		public void WindowIsAvailableReturnsTrueAfterLaunch()
		{
			this.Aut.MainWindow.IsAvailable.Should().BeTrue();
		}

		[TestMethod]
		public void WindowIsModalReturnsFalseAfterLaunch()
		{
			this.Aut.MainWindow.IsModal.Should().BeFalse();
		}

		[TestMethod]
		public void WindowIsVisibleReturnsTrueAfterLaunch()
		{
			this.Aut.MainWindow.IsVisible.Should().BeTrue();
		}

		[TestMethod]
		public void WindowNameReturnsTitleOfTestApp()
		{
			this.Aut.MainWindow.Name.Should().Be(Utility.ApplicationTitle);
		}
	}
}
