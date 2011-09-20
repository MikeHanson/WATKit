using System;
using FluentAssertions;
using NUnit.Framework;
using WATKit.Controls;

namespace WATKit.Tests
{
	[TestFixture]
	public class AutomationControlTests
	{
		private static ApplicationUnderTest<Window> Aut;

		[TestFixtureSetUp]
		public static void SetUp()
		{
			Aut = Fluently.Launch(Utility.GetApplicationPath()).WaitUntilMainWindowIsLoaded().WithDefaultMainWindow();
		}

		[TestFixtureTearDown]
		public static void TearDownClass()
		{
			if(Aut != null)
			{
				Aut.ShutDown(true);
			}
		}

		[Test]
		public void IsEnabledPropertyIsTrueForButtonWithAutomationId()
		{
			var result = Aut.MainWindow.FindControl().WithId(Utility.ButtonWithAutomationId).IncludeDescendants().Now().AsDefault();
			result.Should().NotBeNull();
			result.IsEnabled.Should().BeTrue();
		}

		[Test]
		public void IsEnabledPropertyIsFalseForDisabledButton()
		{
			var result = Aut.MainWindow.FindControl().WithId(Utility.DisabledButtonId).IncludeDescendants().Now().AsDefault();
			result.Should().NotBeNull();
			result.IsEnabled.Should().BeFalse();
		}

		[Test]
		public void AsDefaultReturnsRealControlForButtonWithName()
		{
			var result = Aut.MainWindow.FindControl().WithId(Utility.ButtonWithName).IncludeDescendants().Now().AsDefault();
			result.Should().NotBeNull();
			result.IsVisible.Should().BeTrue();
			result.FindSettings.IsOwnerProxy.Should().BeFalse();
		}

		[Test]
		public void AsDefaultReturnsProxyForNonExistentButton()
		{
			var result = Aut.MainWindow.FindControl().WithId(Utility.MissingButtonId).IncludeDescendants().Now().AsDefault();
			result.Should().NotBeNull();
			result.IsVisible.Should().BeFalse();
			result.FindSettings.IsOwnerProxy.Should().BeTrue();
			result.IsProxy.Should().BeTrue();
		}

		[Test]
		public void AsReturnsRealControlForButtonWithName()
		{
			var result = Aut.MainWindow.FindControl().WithId(Utility.ButtonWithName).IncludeDescendants().Now().As<Button>();
			result.Should().NotBeNull();
			result.Should().BeOfType<Button>();
			result.IsVisible.Should().BeTrue();
			result.FindSettings.IsOwnerProxy.Should().BeFalse();
		}

		[Test]
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
