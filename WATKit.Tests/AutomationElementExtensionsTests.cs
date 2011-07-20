using System;
using System.Collections.Generic;
using System.Linq;
using WATKit.Controls;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WATKit.Tests
{
	[TestClass]
	public class AutomationElementExtensionsTests
	{		
		private static ApplicationUnderTest Aut;
		
		[ClassInitialize]
		public static void InitialiseClass(TestContext context)
		{
			Aut = ApplicationUnderTest.Launch(Utility.GetApplicationPath(), true);
		}

		[ClassCleanup]
		public static void CleanupClass()
		{
			if(Aut != null)
			{
				Aut.ShutDown();
			}
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
