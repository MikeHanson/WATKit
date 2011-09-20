using System;
using FluentAssertions;
using NUnit.Framework;
using WATKit.Controls;
using WATKit.Tests.Controls;

namespace WATKit.Tests
{
	[TestFixture]
	public class DesktopTests: TestBase
	{
		[Test]
		public void FindWindowByTitleFindsChildWindowAsWindow()
		{
			this.Aut.MainWindow.OpenChildWindowButton.Click();
			var childWindow = this.Aut.Desktop.FindWindowByTitle<Window>(Utility.ChildWindowTitle, 20);
			childWindow.Should().NotBeNull();
			childWindow.AutomationElement.Should().NotBeNull();
			childWindow.Close();
		}

		[Test]
		public void FindWindowByTitleFindsChildWindowAsChildWindow()
		{
			this.Aut.MainWindow.OpenChildWindowButton.Click();
			var childWindow = this.Aut.Desktop.FindWindowByTitle<ChildWindow>(Utility.ChildWindowTitle, 20);
			childWindow.Should().NotBeNull();
			childWindow.AutomationElement.Should().NotBeNull();
			childWindow.Close();
		}
	}
}
