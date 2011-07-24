using System;
using WATKit.Controls;
using WATKit.Exceptions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WATKit.Tests
{
	[TestClass]
	public class FluentAutomationFindExtensionTests: TestBase
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
		public void FindControlIntialisesNewFindSettingsOnOwningAutomationControl()
		{
			var findSettings = this.Aut.MainWindow.FindControl();
			findSettings.Should().NotBeNull();
			findSettings.FindType.Should().Be(FindType.NotSet);
			findSettings.FindScope.Should().Be(FindScope.NotSet);
			this.Aut.MainWindow.FindSettings.Should().NotBeNull();
			this.Aut.MainWindow.FindSettings.Should().BeSameAs(findSettings);
		}

		[TestMethod]
		public void WithAutomationIdSetsFindSettingsSearchTypeToAutomationIdAndSetsIdentifier()
		{
			var findSettings = this.Aut.MainWindow.FindControl().WithId(Utility.ButtonWithAutomationId);
			findSettings.Should().NotBeNull();
			findSettings.FindType.Should().Be(FindType.AutomationId);
			findSettings.Identifier.Should().Be(Utility.ButtonWithAutomationId);
		}

		[TestMethod]
		public void WithNameSetsFindSettingsSearchTypeToNameAndSetsIdentifier()
		{
			var findSettings = this.Aut.MainWindow.FindControl().WithText(Utility.ButtonWithNameContent);
			findSettings.Should().NotBeNull();
			findSettings.FindType.Should().Be(FindType.Text);
			findSettings.Identifier.Should().Be(Utility.ButtonWithNameContent);
		}

		[TestMethod]
		public void IncludeSelfSetsScopeToSelf()
		{
			var findSettings = this.Aut.MainWindow.FindControl().IncludeSelf();
			findSettings.Should().NotBeNull();
			findSettings.FindScope.Should().Be(FindScope.Self);
		}

		[TestMethod]
		public void IncludeChildrenSetsScopeToChildren()
		{
			var findSettings = this.Aut.MainWindow.FindControl().IncludeChildren();
			findSettings.Should().NotBeNull();
			findSettings.FindScope.Should().Be(FindScope.Children);
		}

		[TestMethod]
		public void IncludeDescendantsSetsScopeToDescendants()
		{
			var findSettings = this.Aut.MainWindow.FindControl().IncludeDescendants();
			findSettings.Should().NotBeNull();
			findSettings.FindScope.Should().Be(FindScope.Descendants);
		}

		[TestMethod]
		public void IncludeSelfWhenFindScopeIsAlreadySelfAndChildrenDoesNotChangeFindScope()
		{
			var findSettings = this.Aut.MainWindow.FindControl().IncludeSelf().IncludeChildren();
			findSettings.Should().NotBeNull();
			var currentScope = findSettings.FindScope;
			findSettings.IncludeSelf();
			findSettings.FindScope.Should().Be(currentScope);
		}

		[TestMethod]
		public void IncludeSelfWhenFindScopeIsAlreadySelfAndDescendantsDoesNotChangeFindScope()
		{
			var findSettings = this.Aut.MainWindow.FindControl().IncludeSelf().IncludeDescendants();
			findSettings.Should().NotBeNull();
			var currentScope = findSettings.FindScope;
			findSettings.IncludeSelf();
			findSettings.FindScope.Should().Be(currentScope);
		}

		[TestMethod]
		public void IncludeChildrenWhenFindScopeIsAlreadySelfAndChildrenDoesNotChangeFindScope()
		{
			var findSettings = this.Aut.MainWindow.FindControl().IncludeSelf().IncludeChildren();
			findSettings.Should().NotBeNull();
			var currentScope = findSettings.FindScope;
			findSettings.IncludeChildren();
			findSettings.FindScope.Should().Be(currentScope);
		}

		[TestMethod]
		public void IncludeChildrenWhenFindScopeIsAlreadyDescendantsDoesNotChangeFindScope()
		{
			var findSettings = this.Aut.MainWindow.FindControl().IncludeDescendants();
			findSettings.Should().NotBeNull();
			var currentScope = findSettings.FindScope;
			findSettings.IncludeChildren();
			findSettings.FindScope.Should().Be(currentScope);
		}

		[TestMethod]
		public void IncludeChildrenWhenFindScopeIsAlreadySelfAndDescendantsDoesNotChangeFindScope()
		{
			var findSettings = this.Aut.MainWindow.FindControl().IncludeSelf().IncludeDescendants();
			findSettings.Should().NotBeNull();
			var currentScope = findSettings.FindScope;
			findSettings.IncludeChildren();
			findSettings.FindScope.Should().Be(currentScope);
		}

		[TestMethod]
		public void IncludeDescendantsWhenFindScopeIsAlreadySelfAndDescendantsDoesNotChangeFindScope()
		{
			var findSettings = this.Aut.MainWindow.FindControl().IncludeSelf().IncludeDescendants();
			findSettings.Should().NotBeNull();
			var currentScope = findSettings.FindScope;
			findSettings.IncludeDescendants();
			findSettings.FindScope.Should().Be(currentScope);
		}

		[TestMethod]
		public void NowSetsWaitTimeToZero()
		{
			var findSettings = this.Aut.MainWindow.FindControl().Now();
			findSettings.Should().NotBeNull();
			findSettings.WaitTime.Should().Be(TimeSpan.Zero);
		}

		[TestMethod]
		public void WaitForSetsWaitTime()
		{	
			var findSettings = this.Aut.MainWindow.FindControl().WaitFor(TimeSpan.FromSeconds(5));
			findSettings.Should().NotBeNull();
			findSettings.WaitTime.TotalSeconds.Should().BeInRange(5, 5);
		}

		[TestMethod]
		public void WaitForIntSetsWaitTime()
		{
			var findSettings = this.Aut.MainWindow.FindControl().WaitFor(5);
			findSettings.Should().NotBeNull();
			findSettings.WaitTime.TotalSeconds.Should().BeInRange(5, 5);
		}

		[TestMethod]
		public void RetryForSetsRetryTime()
		{
			var findSettings = this.Aut.MainWindow.FindControl().RetryFor(TimeSpan.FromSeconds(5));
			findSettings.Should().NotBeNull();
			findSettings.RetryTime.TotalSeconds.Should().BeInRange(5, 5);
		}

		[TestMethod]
		public void RetryForIntSetsRetryTime()
		{
			var findSettings = this.Aut.MainWindow.FindControl().RetryFor(5);
			findSettings.Should().NotBeNull();
			findSettings.RetryTime.TotalSeconds.Should().BeInRange(5, 5);
		}

		[TestMethod]
		[ExpectedException(typeof(FindTypeNotSetException))]
		public void AsThrowsExceptionIfFindTypeNotSet()
		{
			this.Aut.MainWindow.FindControl().As<AutomationControl>();
		}

		[TestMethod]
		[ExpectedException(typeof(FindTypeNotSetException))]
		public void AsDefaultThrowsExceptionIfFindTypeNotSet()
		{
			this.Aut.MainWindow.FindControl().AsDefault();
		}

		[TestMethod]
		[ExpectedException(typeof(FindScopeNotSetException))]
		public void AsThrowsExceptionIfFindScopeNotSet()
		{
			this.Aut.MainWindow.FindControl().WithText(Utility.ButtonWithName).As<AutomationControl>();
		}

		[TestMethod]
		[ExpectedException(typeof(FindScopeNotSetException))]
		public void AsDefaultThrowsExceptionIfFindScopeNotSet()
		{
			this.Aut.MainWindow.FindControl().WithText(Utility.ButtonWithName).AsDefault();
		}

		[TestMethod]
		public void AsReturnsButtonWithTextAsButton()
		{
			var result = this.Aut.MainWindow.FindControl().WithText(Utility.ButtonWithNameContent).IncludeDescendants().Now().As<Button>();
			result.Should().NotBeNull();
			result.Should().BeOfType<Button>();
			result.Name.Should().Be(Utility.ButtonWithNameContent);
		}

		[TestMethod]
		public void AsDefaultReturnsButtonWithNameAsAutomationControl()
		{
			var result = this.Aut.MainWindow.FindControl().WithText(Utility.ButtonWithNameContent).IncludeDescendants().Now().AsDefault();
			result.Should().NotBeNull();
			result.Should().BeOfType<AutomationControl>();
			result.Name.Should().Be(Utility.ButtonWithNameContent);
		}

		[TestMethod]
		public void AsReturnsButtonWithAutomationIdAsButton()
		{
			var result = this.Aut.MainWindow.FindControl().WithId(Utility.ButtonWithAutomationId).IncludeDescendants().Now().As<Button>();
			result.Should().NotBeNull();
			result.Should().BeOfType<Button>();
			result.Name.Should().Be(Utility.ButtonWithAutomationIdContent);
		}

		[TestMethod]
		public void AsDefaultReturnsButtonWithAutomationIdAsAutomationControl()
		{
			var result = this.Aut.MainWindow.FindControl().WithId(Utility.ButtonWithAutomationId).IncludeDescendants().Now().AsDefault();
			result.Should().NotBeNull();
			result.Should().BeOfType<AutomationControl>();
			result.Name.Should().Be(Utility.ButtonWithAutomationIdContent);
		}
		
		[TestMethod]
		public void WaitForTimeSpanTakesAtLeastTheSpecifiedPeriodToFindElement()
		{
			var startTime = DateTime.Now;
			this.Aut.MainWindow.FindControl().WithId(Utility.ButtonWithAutomationId).IncludeDescendants().WaitFor(TimeSpan.FromSeconds(2)).AsDefault();
			var endTime = DateTime.Now;
			var executionTime = endTime.Subtract(startTime);
			executionTime.TotalSeconds.Should().BeGreaterOrEqualTo(2D);
		}

		[TestMethod]
		public void WaitForIntTakesAtLeastTheSpecifiedPeriodToFindElement()
		{
			var startTime = DateTime.Now;
			this.Aut.MainWindow.FindControl().WithId(Utility.ButtonWithAutomationId).IncludeDescendants().WaitFor(2).AsDefault();
			var endTime = DateTime.Now;
			var executionTime = endTime.Subtract(startTime);
			executionTime.TotalSeconds.Should().BeGreaterOrEqualTo(2D);
		}

		[TestMethod]
		public void RetryForTimeSpanTakesAtLeastTheSpecifiedPeriodToFindNonExistentElement()
		{
			var startTime = DateTime.Now;
			this.Aut.MainWindow.FindControl().WithId("BadId").IncludeDescendants().RetryFor(TimeSpan.FromSeconds(2)).AsDefault();
			var endTime = DateTime.Now;
			var executionTime = endTime.Subtract(startTime);
			executionTime.TotalSeconds.Should().BeGreaterOrEqualTo(2D);
		}

		[TestMethod]
		public void RetryForIntTakesAtLeastTheSpecifiedPeriodToFindNonExistentElement()
		{
			var startTime = DateTime.Now;
			this.Aut.MainWindow.FindControl().WithId("BadId").IncludeDescendants().RetryFor(2).AsDefault();
			var endTime = DateTime.Now;
			var executionTime = endTime.Subtract(startTime);
			executionTime.TotalSeconds.Should().BeGreaterOrEqualTo(2D);
		}
	}
}
