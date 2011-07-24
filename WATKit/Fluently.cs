using System;
using System.Collections.Generic;
using System.Linq;

namespace WATKit
{

    public class Fluently
	{
		/// <summary>
		/// Initialises a launch of an application
		/// </summary>
		/// <param name="applicationPath">The application path.</param>
		/// <returns>
		/// LaunchSettings which supports fluent method chaining to setup and launch the application
		/// </returns>
		public static LaunchSettings Launch(string applicationPath)
		{
			return new LaunchSettings { ApplicationPath = applicationPath };
		}

	}
}
