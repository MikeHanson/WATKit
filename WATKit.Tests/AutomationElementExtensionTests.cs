using System;
using FluentAssertions;
using NUnit.Framework;

namespace WATKit.Tests
{
	[TestFixture]
	public class AutomationElementExtensionTests: TestBase
	{
		[Test]
		public void FindFirstDescendantByAutomationIdFindsButtonInTestApp()
		{
			Aut.MainWindow.AutomationElement.FindFirstDescendantByAutomationId(Utility.ButtonWithAutomationId)
				.Should()
				.NotBeNull();
		}

		[Test]
		public void FindFirstDescendantByTextFindsButtonInTestApp()
		{
			Aut.MainWindow.AutomationElement.FindFirstDescendantByText(Utility.ButtonWithNameContent)
				.Should()
				.NotBeNull();
		}
	}
}
