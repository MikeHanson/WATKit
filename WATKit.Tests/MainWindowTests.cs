using System;
using System.Collections.Generic;
using System.Linq;
using WATKit.Tests.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WATKit.Tests
{
	[TestClass]
	public class MainWindowTests
	{
		private ApplicationUnderTest<MainWindow> aut;

		[TestInitialize]
		public void Initialise()
		{
			this.aut = Fluently.Launch(Utility.GetApplicationPath()).WaitUntilMainWindowIsLoaded().WithMainWindowAs<MainWindow>();
		}

		[TestCleanup]
		protected void Cleanup()
		{
			if(this.aut != null)
			{
				this.aut.ShutDown(true);
			}
		}
	}
}
