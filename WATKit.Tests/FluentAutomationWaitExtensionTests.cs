using System;
using WATKit.Controls;
using WATKit.Exceptions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WATKit.Tests
{
	[TestClass]
	public class FluentAutomationWaitExtensionTests
	{
		private static ApplicationUnderTest Aut;

		[ClassInitialize]
		public static void Initialise(TestContext context)
		{
			Aut = ApplicationUnderTest.Launch(Constants.ApplicationPathWinForms, true);
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
		public void WaitIntialisesNewWaitSettingsOnOwningAutomationControl()
		{
			var waitSettings = Aut.MainWindow.Wait();
			waitSettings.Should().NotBeNull();
			waitSettings.WaitType.Should().Be(WaitType.NotSet);
			waitSettings.WaitRoot.Should().BeSameAs(Aut.MainWindow);
			waitSettings.WaitTime.TotalSeconds.Should().BeInRange(0, 0);
			Aut.MainWindow.WaitSettings.Should().NotBeNull();
			Aut.MainWindow.WaitSettings.Should().BeSameAs(waitSettings);
		}

		[TestMethod]
		public void UntilExistsSetsWaitTypeOnWaitSettings()
		{
			var waitSettings = Aut.MainWindow.Wait().UntilExists();
			waitSettings.Should().NotBeNull();
			waitSettings.WaitType.Should().Be(WaitType.Exists);
		}

		[TestMethod]
		public void UntilNotExistsSetsWaitTypeOnWaitSettings()
		{
			var waitSettings = Aut.MainWindow.Wait().UntilNotExists();
			waitSettings.Should().NotBeNull();
			waitSettings.WaitType.Should().Be(WaitType.NotExists);
		}

		[TestMethod]
		public void UntilVisibleSetsWaitTypeOnWaitSettings()
		{
			var waitSettings = Aut.MainWindow.Wait().UntilVisible();
			waitSettings.Should().NotBeNull();
			waitSettings.WaitType.Should().Be(WaitType.Visible);
		}

		[TestMethod]
		public void UntilHiddenSetsWaitTypeOnWaitSettings()
		{
			var waitSettings = Aut.MainWindow.Wait().UntilHidden();
			waitSettings.Should().NotBeNull();
			waitSettings.WaitType.Should().Be(WaitType.Hidden);
		}

		[TestMethod]
		public void UntilEnabledSetsWaitTypeOnWaitSettings()
		{
			var waitSettings = Aut.MainWindow.Wait().UntilEnabled();
			waitSettings.Should().NotBeNull();
			waitSettings.WaitType.Should().Be(WaitType.Enabled);
		}

		[TestMethod]
		public void UntilDisabledSetsWaitTypeOnWaitSettings()
		{
			var waitSettings = Aut.MainWindow.Wait().UntilDisabled();
			waitSettings.Should().NotBeNull();
			waitSettings.WaitType.Should().Be(WaitType.Disabled);
		}

		[TestMethod]
		[ExpectedException(typeof(WaitTypeNotSetException))]
		public void IndefinitelyThrowsExceptionIfWaitTypeNotSet()
		{
			var control = Aut.MainWindow.Wait().Indefinitely();
		}

		[TestMethod]
		[Ignore]
		public void IndefinitelySetsWaitTimeToZeroOnWaitSettings()
		{
			var control = Aut.MainWindow.Wait().UntilDisabled().Indefinitely();
			control.Should().NotBeNull();
			control.WaitSettings.WaitTime.TotalSeconds.Should().BeInRange(0, 0);
		}

		[TestMethod]
		[ExpectedException(typeof(WaitTypeNotSetException))]
		public void TimeoutAfterThrowsExceptionIfWaitTypeNotSet()
		{
			var control = Aut.MainWindow.Wait().TimeoutAfter(TimeSpan.FromSeconds(5));
		}

		[TestMethod]
		public void TimeoutAfterSetsWaitTimeOnWaitSettings()
		{
			var control = Aut.MainWindow.Wait().UntilDisabled().TimeoutAfter(TimeSpan.FromSeconds(5));
			control.Should().NotBeNull();
			control.WaitSettings.WaitTime.TotalSeconds.Should().BeInRange(5, 5);
		}

		[TestMethod]
		[ExpectedException(typeof(TimeoutException))]
		public void TimeOutAfterTimesoutWaitingForEnabledButtonToBeDisabled()
		{
			var button = Aut.MainWindow.FindControl().IncludeDescendants().WithId(Constants.ButtonWithAutomationId).Now().As<Button>();
			button.Should().NotBeNull();

			var control = button.Wait().UntilDisabled().TimeoutAfter(TimeSpan.FromSeconds(5), true);
		}

		[TestMethod]
		public void TimeOutAfterWaitsForDisabledButtonToBecomeEnabled()
		{
			var disabledButton = Aut.MainWindow.FindControl().IncludeDescendants().WithId(Constants.DisabledButtonId).Now().As<Button>();
			disabledButton.Should().NotBeNull();
			disabledButton.IsEnabled.Should().BeFalse();

			var controlButton = Aut.MainWindow.FindControl().IncludeDescendants().WithId(Constants.EnableDisabledButtonId).Now().As<Button>();
			controlButton.Should().NotBeNull();
			controlButton.Click();

			var control = disabledButton.Wait().UntilEnabled().TimeoutAfter(TimeSpan.FromSeconds(5), true);
			control.Should().NotBeNull();
			control.IsEnabled.Should().BeTrue();
		}

		[TestMethod]
		public void TimeOutAfterWaitsForInvisibleButtonToBecomeVisible()
		{
			var invisibleButton = Aut.MainWindow.FindControl().IncludeDescendants().WithId(Constants.InvisibleButtonId).Now().As<Button>();
			invisibleButton.Should().NotBeNull();
			invisibleButton.IsVisible.Should().BeFalse();

			var controlButton = Aut.MainWindow.FindControl().IncludeDescendants().WithId(Constants.ShowInvisibleButtonId).Now().As<Button>();
			controlButton.Should().NotBeNull();
			controlButton.Click();

			var control = invisibleButton.Wait().UntilVisible().TimeoutAfter(TimeSpan.FromSeconds(5), true);
			control.Should().NotBeNull();
			control.IsVisible.Should().BeTrue();
		}

		[TestMethod]
		public void TimeOutAfterWaitsForDynamicallyAddedButtonToExist()
		{
			var invisibleButton = Aut.MainWindow.FindControl().IncludeDescendants().WithId(Constants.InvisibleButtonId).Now().As<Button>();
			invisibleButton.Should().NotBeNull();
			invisibleButton.IsVisible.Should().BeFalse();

			var controlButton = Aut.MainWindow.FindControl().IncludeDescendants().WithId(Constants.ShowInvisibleButtonId).Now().As<Button>();
			controlButton.Should().NotBeNull();
			controlButton.Click();

			var control = invisibleButton.Wait().UntilVisible().TimeoutAfter(TimeSpan.FromSeconds(5), true);
			control.Should().NotBeNull();
			control.IsVisible.Should().BeTrue();
		}
	}
}
