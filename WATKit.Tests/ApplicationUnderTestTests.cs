using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WATKit.Tests
{
	[TestClass]
	public class ApplicationUnderTestTests
	{
		private const string InvalidApplicationPath = @"C:\InvalidePath.exe";
		private ApplicationUnderTest applicationUnderTest;

		[TestInitialize]
		public void Initialise()
		{
			this.applicationUnderTest = ApplicationUnderTest.Launch(Constants.ApplicationPath, true);
		}

		[TestCleanup]
		public void Cleanup()
		{
			if(this.applicationUnderTest.IsRunning)
			{
				this.applicationUnderTest.ShutDown();
			}
		}

		[TestMethod]
		public void LaunchApplicationUnderTestWithValidPathLaunchesAppAndReturnsApplicationUnderTest()
		{			
			this.applicationUnderTest
				.Should()
				.NotBeNull();
			this.applicationUnderTest.Name
				.Should()
				.Be(Constants.ApplicationTitle);
			this.applicationUnderTest.IsRunning
				.Should()
				.BeTrue();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void LaunchApplicationUnderTestWithInvalidPathThrowsException()
		{
			this.applicationUnderTest.ShutDown();
			ApplicationUnderTest.Launch(InvalidApplicationPath);
		}

		[TestMethod]
		public void ShutDownApplicationUnderTestEndsApplicationProcessAndReturnsTrue()
		{
			this.applicationUnderTest.ShutDown()
				.Should()
				.BeTrue();
			this.applicationUnderTest.IsRunning
				.Should()
				.BeFalse();
		}
	}
}
