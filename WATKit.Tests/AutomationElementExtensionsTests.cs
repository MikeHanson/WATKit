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
			Aut = ApplicationUnderTest.Launch(Constants.ApplicationPath, true);
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
			Aut.MainWindow.AutomationElement.FindFirstDescendantByAutomationId(Constants.ButtonWithAutomationId)
				.Should()
				.NotBeNull();
		}

		[TestMethod]
		public void FindFirstDescendantByTextFindsButtonInTestApp()
		{
			Aut.MainWindow.AutomationElement.FindFirstDescendantByText(Constants.ButtonWithNameContent)
				.Should()
				.NotBeNull();
		}
	}
}
