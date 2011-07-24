using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WATKit.Controls;

namespace WATKit.Tests
{
	[TestClass]
	public class AutomationControlTests
	{
		private static ApplicationUnderTest<Window> Aut;

		[ClassInitialize]
		public static void Initialise(TestContext context)
		{
			Aut = Fluently.Launch(Utility.GetApplicationPath()).WaitUntilMainWindowIsLoaded().WithDefaultMainWindow();
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
		public void IsEnabledPropertyIsTrueForButtonWithAutomationId()
		{
			var result = Aut.MainWindow.FindControl().WithId(Utility.ButtonWithAutomationId).IncludeDescendants().Now().AsDefault();
			result.Should().NotBeNull();
			result.IsEnabled.Should().BeTrue();
		}

		[TestMethod]
		public void IsEnabledPropertyIsFalseForDisabledButton()
		{
			var result = Aut.MainWindow.FindControl().WithId(Utility.DisabledButtonId).IncludeDescendants().Now().AsDefault();
			result.Should().NotBeNull();
			result.IsEnabled.Should().BeFalse();
		}

		[TestMethod]
		public void AsDefaultReturnsRealControlForButtonWithName()
		{
			var result = Aut.MainWindow.FindControl().WithId(Utility.ButtonWithName).IncludeDescendants().Now().AsDefault();
			result.Should().NotBeNull();
			result.IsVisible.Should().BeTrue();
			result.FindSettings.IsOwnerProxy.Should().BeFalse();
		}

		[TestMethod]
		public void AsDefaultReturnsProxyForNonExistentButton()
		{
			var result = Aut.MainWindow.FindControl().WithId(Utility.MissingButtonId).IncludeDescendants().Now().AsDefault();
			result.Should().NotBeNull();
			result.IsVisible.Should().BeFalse();
			result.FindSettings.IsOwnerProxy.Should().BeTrue();
			result.IsProxy.Should().BeTrue();
		}

		[TestMethod]
		public void AsReturnsRealControlForButtonWithName()
		{
			var result = Aut.MainWindow.FindControl().WithId(Utility.ButtonWithName).IncludeDescendants().Now().As<Button>();
			result.Should().NotBeNull();
			result.Should().BeOfType<Button>();
			result.IsVisible.Should().BeTrue();
			result.FindSettings.IsOwnerProxy.Should().BeFalse();
		}

		[TestMethod]
		public void AsReturnsProxyForNonExistentButton()
		{
			var result = Aut.MainWindow.FindControl().WithId(Utility.MissingButtonId).IncludeDescendants().Now().As<Button>();
			result.Should().NotBeNull();
			result.Should().BeOfType<Button>();
			result.IsVisible.Should().BeFalse();
			result.FindSettings.IsOwnerProxy.Should().BeTrue();
			result.IsProxy.Should().BeTrue();
		}
	}
}
