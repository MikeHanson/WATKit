using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Microsoft.Build.Framework;

namespace WATKit.Build.Tests
{
	[TestClass]
	public class WATKitBuildTaskTests
	{
		[TestMethod]
		public void ExecuteReturnsTrue()
		{
			var task = new WATKitBuildTask
			{
				TestAssembly = @"C:\Users\Mike\Documents\Visual Studio 2010\Projects\WATKit\WATKit.Tests\bin\Debug\WATKit.Tests.dll",
				SourceAssemblies = @"C:\Users\Mike\Documents\Visual Studio 2010\Projects\WATKit\WATKit.TestApp.WPF\bin\Debug\WATKit.TestApp.WPF.dll"
			};

			
			task.Execute().Should().BeTrue();

		}
	}
}
