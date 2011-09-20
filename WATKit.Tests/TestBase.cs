using System;
using NUnit.Framework;
using WATKit.Controls;
using WATKit.Tests.Controls;

namespace WATKit.Tests
{
	[TestFixture]
	public abstract class TestBase
	{
		protected ApplicationUnderTest<MainWindow> Aut;

		/// <summary>
		/// SetUps this instance.
		/// </summary>
		[SetUp]
		protected void BaseSetUp()
		{
			this.Aut = Fluently.Launch(Utility.GetApplicationPath()).WaitUntilMainWindowIsLoaded().WithMainWindowAs<MainWindow>();
		}

		/// <summary>
		/// TearDowns this instance.
		/// </summary>
		[TearDown]
		protected void BaseTearDown()
		{
			if(this.Aut != null)
			{
				this.Aut.ShutDown(true);
			}
		}
	}
}
