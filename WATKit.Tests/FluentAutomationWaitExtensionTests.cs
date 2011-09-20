using System;
using NUnit.Framework;
using WATKit.Controls;
using WATKit.Exceptions;
using FluentAssertions;

namespace WATKit.Tests
{
	[TestFixture]
	public class FluentAutomationWaitExtensionTests: TestBase
	{
		[Test]
		public void WaitIntialisesNewWaitSettingsOnOwningAutomationControl()
		{
			var waitSettings = this.Aut.MainWindow.Wait();
			waitSettings.Should().NotBeNull();
			waitSettings.WaitType.Should().Be(WaitType.NotSet);
			waitSettings.WaitRoot.Should().BeSameAs(this.Aut.MainWindow);
			waitSettings.WaitTime.TotalSeconds.Should().BeInRange(0, 0);
			this.Aut.MainWindow.WaitSettings.Should().NotBeNull();
			this.Aut.MainWindow.WaitSettings.Should().BeSameAs(waitSettings);
		}

		[Test]
		public void UntilExistsSetsWaitTypeOnWaitSettings()
		{
			var waitSettings = this.Aut.MainWindow.Wait().UntilExists();
			waitSettings.Should().NotBeNull();
			waitSettings.WaitType.Should().Be(WaitType.Exists);
		}

		[Test]
		public void UntilNotExistsSetsWaitTypeOnWaitSettings()
		{
			var waitSettings = this.Aut.MainWindow.Wait().UntilNotExists();
			waitSettings.Should().NotBeNull();
			waitSettings.WaitType.Should().Be(WaitType.NotExists);
		}

		[Test]
		public void UntilVisibleSetsWaitTypeOnWaitSettings()
		{
			var waitSettings = this.Aut.MainWindow.Wait().UntilVisible();
			waitSettings.Should().NotBeNull();
			waitSettings.WaitType.Should().Be(WaitType.Visible);
		}

		[Test]
		public void UntilHiddenSetsWaitTypeOnWaitSettings()
		{
			var waitSettings = this.Aut.MainWindow.Wait().UntilHidden();
			waitSettings.Should().NotBeNull();
			waitSettings.WaitType.Should().Be(WaitType.Hidden);
		}

		[Test]
		public void UntilEnabledSetsWaitTypeOnWaitSettings()
		{
			var waitSettings = this.Aut.MainWindow.Wait().UntilEnabled();
			waitSettings.Should().NotBeNull();
			waitSettings.WaitType.Should().Be(WaitType.Enabled);
		}

		[Test]
		public void UntilDisabledSetsWaitTypeOnWaitSettings()
		{
			var waitSettings = this.Aut.MainWindow.Wait().UntilDisabled();
			waitSettings.Should().NotBeNull();
			waitSettings.WaitType.Should().Be(WaitType.Disabled);
		}

		[Test]
		[ExpectedException(typeof(WaitTypeNotSetException))]
		public void IndefinitelyThrowsExceptionIfWaitTypeNotSet()
		{
			this.Aut.MainWindow.Wait().Indefinitely();
		}

		[Test]
		[Ignore]
		public void IndefinitelySetsWaitTimeToZeroOnWaitSettings()
		{
			var control = this.Aut.MainWindow.Wait().UntilDisabled().Indefinitely();
			control.Should().NotBeNull();
			control.WaitSettings.WaitTime.TotalSeconds.Should().BeInRange(0, 0);
		}

		[Test]
		[ExpectedException(typeof(WaitTypeNotSetException))]
		public void TimeoutAfterThrowsExceptionIfWaitTypeNotSet()
		{
			this.Aut.MainWindow.Wait().TimeoutAfter(TimeSpan.FromSeconds(5));
		}

		[Test]
		public void TimeoutAfterSetsWaitTimeOnWaitSettings()
		{
			var control = this.Aut.MainWindow.Wait().UntilDisabled().TimeoutAfter(TimeSpan.FromSeconds(5));
			control.Should().NotBeNull();
			control.WaitSettings.WaitTime.TotalSeconds.Should().BeInRange(5, 5);
		}

		[Test]
		[ExpectedException(typeof(TimeoutException))]
		public void TimeOutAfterTimesoutWaitingForEnabledButtonToBeDisabled()
		{
			var button = this.Aut.MainWindow.FindControl().IncludeDescendants().WithId(Utility.ButtonWithAutomationId).Now().As<Button>();
			button.Should().NotBeNull();

			var control = button.Wait().UntilDisabled().TimeoutAfter(TimeSpan.FromSeconds(5), true);
		}

		[Test]
		public void TimeOutAfterWaitsForDisabledButtonToBecomeEnabled()
		{
			var disabledButton = this.Aut.MainWindow.FindControl().IncludeDescendants().WithId(Utility.DisabledButtonId).Now().As<Button>();
			disabledButton.Should().NotBeNull();
			disabledButton.IsEnabled.Should().BeFalse();

			var controlButton = this.Aut.MainWindow.FindControl().IncludeDescendants().WithId(Utility.EnableDisabledButtonId).Now().As<Button>();
			controlButton.Should().NotBeNull();
			controlButton.Click();

			var control = disabledButton.Wait().UntilEnabled().TimeoutAfter(TimeSpan.FromSeconds(5), true);
			control.Should().NotBeNull();
			control.IsEnabled.Should().BeTrue();
		}

		[Test]
		public void TimeOutAfterWaitsForInvisibleButtonToBecomeVisible()
		{
			var invisibleButton = this.Aut.MainWindow.FindControl().IncludeDescendants().WithId(Utility.InvisibleButtonId).Now().As<Button>();
			invisibleButton.Should().NotBeNull();
			invisibleButton.IsVisible.Should().BeFalse();

			var controlButton = this.Aut.MainWindow.FindControl().IncludeDescendants().WithId(Utility.ShowInvisibleButtonId).Now().As<Button>();
			controlButton.Should().NotBeNull();
			controlButton.Click();

			var control = invisibleButton.Wait().UntilVisible().TimeoutAfter(TimeSpan.FromSeconds(5), true);
			control.Should().NotBeNull();
			control.IsVisible.Should().BeTrue();
		}

		[Test]
		public void TimeOutAfterWaitsForDynamicallyAddedButtonToExist()
		{
			var dynamicButton = this.Aut.MainWindow.FindControl().IncludeDescendants().WithId(Utility.DynamicButtonId).Now().As<Button>();
			dynamicButton.Should().NotBeNull();
			dynamicButton.IsProxy.Should().BeTrue();
			dynamicButton.IsVisible.Should().BeFalse();

			var controlButton = this.Aut.MainWindow.FindControl().IncludeDescendants().WithId(Utility.AddDynamicButtonId).Now().As<Button>();
			controlButton.Should().NotBeNull();
			controlButton.Click();

			var control = dynamicButton.Wait().UntilExists().TimeoutAfter(TimeSpan.FromSeconds(5), true);
			control.Should().NotBeNull();
			control.IsVisible.Should().BeTrue();
		}
	}
}
