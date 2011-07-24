using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WATKit.Tests
{
	[TestClass]
	public class AutomationElementExtensionTests: TestBase
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
		public void FindFirstDescendantByAutomationIdFindsButtonInTestApp()
		{
			Aut.MainWindow.AutomationElement.FindFirstDescendantByAutomationId(Utility.ButtonWithAutomationId)
				.Should()
				.NotBeNull();
		}

		[TestMethod]
		public void FindFirstDescendantByTextFindsButtonInTestApp()
		{
			Aut.MainWindow.AutomationElement.FindFirstDescendantByText(Utility.ButtonWithNameContent)
				.Should()
				.NotBeNull();
		}
	}
}
