using System;
using FluentAssertions;
using NUnit.Framework;
using WATKit.Tests.Controls;

namespace WATKit.Tests
{
	[TestFixture]
	public class MainWindowTests
	{
		private ApplicationUnderTest<MainWindow> aut;

		[SetUp]
		public void SetUp()
		{
			this.aut = Fluently.Launch(Utility.GetApplicationPath()).WaitUntilMainWindowIsLoaded().WithMainWindowAs<MainWindow>();
		}

		[TearDown]
		public void TearDown()
		{
			if(this.aut != null)
			{
				this.aut.ShutDown(true);
			}
		}

		[Test]
		public void ButtonWithNameReturnsCorrectButton()
		{
			var button = this.aut.MainWindow.ButtonWithName;
			button.Should().NotBeNull();
			button.AutomationElement.Current.AutomationId.Should().Be(Utility.ButtonWithName);
			button.Name.Should().Be(Utility.ButtonWithNameContent);
		}

		[Test]
		public void ButtonWithAutomationIdReturnsCorrectButton()
		{
			var button = this.aut.MainWindow.ButtonWithAutomationId;
			button.Should().NotBeNull();
			button.AutomationElement.Current.AutomationId.Should().Be(Utility.ButtonWithAutomationId);
			button.Name.Should().Be(Utility.ButtonWithAutomationIdContent);
		}

		[Test]
		public void InvisibleButtonReturnsCorrectButton()
		{
			var button = this.aut.MainWindow.InvisibleButton;
			button.Should().NotBeNull();
			button.AutomationElement.Current.AutomationId.Should().Be(Utility.InvisibleButtonId);
			button.IsVisible.Should().BeFalse();
		}

		[Test]
		public void ShowInvisibleButtonReturnsCorrectButton()
		{
			var button = this.aut.MainWindow.ShowInvisibleButton;
			button.Should().NotBeNull();
			button.AutomationElement.Current.AutomationId.Should().Be(Utility.ShowInvisibleButtonId);
		}

		[Test]
		public void DisabledButtonReturnsCorrectButton()
		{
			var button = this.aut.MainWindow.DisabledButton;
			button.Should().NotBeNull();
			button.AutomationElement.Current.AutomationId.Should().Be(Utility.DisabledButtonId);
			button.IsEnabled.Should().BeFalse();
		}

		[Test]
		public void EnableDisabledButtonReturnsCorrectButton()
		{
			var button = this.aut.MainWindow.EnableDisabledButton;
			button.Should().NotBeNull();
			button.AutomationElement.Current.AutomationId.Should().Be(Utility.EnableDisabledButtonId);
		}

		[Test]
		public void IChangeMyNameButtonReturnsCorrectButton()
		{
			var button = this.aut.MainWindow.ChangeMyNameButton;
			button.Should().NotBeNull();
			button.AutomationElement.Current.AutomationId.Should().Be(Utility.IChangeMyNameButtonId);
		}

		[Test]
		public void AddDynamicButtonReturnsCorrectButton()
		{
			var button = this.aut.MainWindow.AddDynamicButton;
			button.Should().NotBeNull();
			button.AutomationElement.Current.AutomationId.Should().Be(Utility.AddDynamicButtonId);
		}

		[Test]
		public void ClickOfEnableDisabledButtonChangesStateOfDisabledButton()
		{
			var disabledButton = this.aut.MainWindow.DisabledButton;
			this.aut.MainWindow.EnableDisabledButton.Click();
			disabledButton.Wait().UntilEnabled().TimeoutAfter(TimeSpan.FromSeconds(5), true);
			disabledButton.IsEnabled.Should().BeTrue();
		}

		[Test]
		public void ClickOfShowInvisibleButtonChangesStateOfInvisibleButton()
		{
			var invisibleButton = this.aut.MainWindow.InvisibleButton;
			this.aut.MainWindow.ShowInvisibleButton.Click();
			invisibleButton.Wait().UntilVisible().TimeoutAfter(TimeSpan.FromSeconds(5), true);
			invisibleButton.IsVisible.Should().BeTrue();
			invisibleButton.IsProxy.Should().BeFalse();
		}

		[Test]
		public void DynamicButtonIsFoundAfterClickOnAddDynamicButton()
		{
			var dynamicButton = this.aut.MainWindow.DynamicButton;
			this.aut.MainWindow.AddDynamicButton.Click();
			dynamicButton.Wait().UntilExists().TimeoutAfter(TimeSpan.FromSeconds(5), true);
			dynamicButton.IsProxy.Should().BeFalse();
			dynamicButton.AutomationElement.Current.AutomationId.Should().Be(Utility.DynamicButtonId);
		}
	}
}
