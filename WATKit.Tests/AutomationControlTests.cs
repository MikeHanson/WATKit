using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WATKit.Controls;

namespace WATKit.Tests
{
	[TestClass]
	public class AutomationControlTests
	{
		private static ApplicationUnderTest Aut;

		[ClassInitialize]
		public static void Initialise(TestContext context)
		{
			Aut = ApplicationUnderTest.Launch(Constants.ApplicationPath, true);
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
			var result = Aut.MainWindow.FindControl().WithId(Constants.ButtonWithAutomationId).IncludeDescendants().Now().AsDefault();
			result.Should().NotBeNull();
			result.IsEnabled.Should().BeTrue();
		}

		[TestMethod]
		public void IsEnabledPropertyIsFalseForDisabledButton()
		{
			var result = Aut.MainWindow.FindControl().WithId(Constants.DisabledButtonId).IncludeDescendants().Now().AsDefault();
			result.Should().NotBeNull();
			result.IsEnabled.Should().BeFalse();
		}

		[TestMethod]
		public void AsDefaultReturnsRealControlForButtonWithName()
		{
			var result = Aut.MainWindow.FindControl().WithId(Constants.ButtonWithName).IncludeDescendants().Now().AsDefault();
			result.Should().NotBeNull();
			result.IsVisible.Should().BeTrue();
			result.FindSettings.IsOwnerProxy.Should().BeFalse();
		}

		[TestMethod]
		public void AsDefaultReturnsProxyForInvisibleButton()
		{
			var result = Aut.MainWindow.FindControl().WithId(Constants.InvisibleButtonId).IncludeDescendants().Now().AsDefault();
			result.Should().NotBeNull();
			result.IsVisible.Should().BeFalse();
			result.FindSettings.IsOwnerProxy.Should().BeTrue();
		}

		[TestMethod]
		public void AsReturnsRealControlForButtonWithName()
		{
			var result = Aut.MainWindow.FindControl().WithId(Constants.ButtonWithName).IncludeDescendants().Now().As<Button>();
			result.Should().NotBeNull();
			result.Should().BeOfType<Button>();
			result.IsVisible.Should().BeTrue();
			result.FindSettings.IsOwnerProxy.Should().BeFalse();
		}

		[TestMethod]
		public void AsReturnsProxyForInvisibleButton()
		{
			var result = Aut.MainWindow.FindControl().WithId(Constants.InvisibleButtonId).IncludeDescendants().Now().As<Button>();
			result.Should().NotBeNull();
			result.Should().BeOfType<Button>();
			result.IsVisible.Should().BeFalse();
			result.FindSettings.IsOwnerProxy.Should().BeTrue();
		}
	}
}
