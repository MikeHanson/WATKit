using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WATKit.Controls;

namespace WATKit.Tests
{
	[TestClass]
	public class FluentlyTests
	{
		private const string InvalidApplicationPath = @"C:\InvalidePath.exe";
		private ApplicationUnderTest<Window> aut;

		[TestInitialize]
		public void Initialise()
		{
			this.aut = Fluently.Launch(Utility.GetApplicationPath()).WaitUntilMainWindowIsLoaded().WithDefaultMainWindow();
		}

		[TestCleanup]
		public void Cleanup()
		{
			if(this.aut.IsRunning)
			{
				this.aut.ShutDown();
			}
		}

		[TestMethod]
		public void LaunchApplicationUnderTestWithValidPathLaunchesAppAndReturnsApplicationUnderTest()
		{			
			this.aut
				.Should()
				.NotBeNull();
			this.aut.Name
				.Should()
				.Be(Utility.ApplicationTitle);
			this.aut.IsRunning
				.Should()
				.BeTrue();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void LaunchApplicationUnderTestWithInvalidPathThrowsException()
		{
			this.aut.ShutDown();
			Fluently.Launch(InvalidApplicationPath).WaitUntilMainWindowIsLoaded().WithDefaultMainWindow();
		}

		[TestMethod]
		public void ShutDownApplicationUnderTestEndsApplicationProcessAndReturnsTrue()
		{
			this.aut.ShutDown()
				.Should()
				.BeTrue();
			this.aut.IsRunning
				.Should()
				.BeFalse();
		}
	}
}
