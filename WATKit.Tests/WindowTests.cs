using System;
using FluentAssertions;
using NUnit.Framework;

namespace WATKit.Tests
{
	[TestFixture]
	public class WindowTests: TestBase
	{
		[Test]
		public void WindowIsAvailableReturnsTrueAfterLaunch()
		{
			this.Aut.MainWindow.IsAvailable.Should().BeTrue();
		}

		[Test]
		public void WindowIsModalReturnsFalseAfterLaunch()
		{
			this.Aut.MainWindow.IsModal.Should().BeFalse();
		}

		[Test]
		public void WindowIsVisibleReturnsTrueAfterLaunch()
		{
			this.Aut.MainWindow.IsVisible.Should().BeTrue();
		}

		[Test]
		public void WindowNameReturnsTitleOfTestApp()
		{
			this.Aut.MainWindow.Name.Should().Be(Utility.ApplicationTitle);
		}
	}
}
