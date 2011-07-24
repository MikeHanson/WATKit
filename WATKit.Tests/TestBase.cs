using System;
using System.Collections.Generic;
using System.Linq;
using WATKit.Controls;

namespace WATKit.Tests
{
	public abstract class TestBase
	{
		protected ApplicationUnderTest<Window> Aut;

		protected void Initialise()
		{
			this.Aut = Fluently.Launch(Utility.GetApplicationPath()).WaitUntilMainWindowIsLoaded().WithDefaultMainWindow();
		}

		protected void Cleanup()
		{
			if(this.Aut != null)
			{
				this.Aut.ShutDown(true);
			}
		}
	}
}
