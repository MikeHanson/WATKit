using System;
using System.Threading;
using WATKit.Controls;
using WATKit.Exceptions;

namespace WATKit
{
	/// <summary>
	/// Provides extension methods for wait operations within the fluent automation api
	/// </summary>
	/// <remarks>
	/// These methods provide support for waiting on an automation control
	/// to become available and/or visible when it represents a proxy or for a real control
	/// to become unavailable, hidden, enabled or disabled
	/// </remarks>
	public static class FluentAutomationWaitExtensions
	{
		/// <summary>
		/// Sets up a new wait operation
		/// </summary>
		/// <param name="owner">The automation control owning the wait settings</param>
		/// <returns>
		/// The new wait settings to support fluent usage
		/// </returns>
		public static WaitSettings Wait(this AutomationControl owner)
		{
			owner.WaitSettings = new WaitSettings
			                     	{
			                     		WaitRoot = owner,
										WaitTime = TimeSpan.Zero
			                     	};
			return owner.WaitSettings;
		}

		/// <summary>
		/// Sets the operation to wait for the existence of the control.
		/// </summary>
		/// <param name="waitSettings">The wait settings.</param>
		/// <returns>The original wait settings to support fluent usage</returns>
		public static WaitSettings UntilExists(this WaitSettings waitSettings)
		{
			waitSettings.WaitType = WaitType.Exists;
			return waitSettings;
		}

		/// <summary>
		/// Sets the operation to wait for the control to no longer exist.
		/// </summary>
		/// <param name="waitSettings">The wait settings.</param>
		/// <returns>The original wait settings to support fluent usage</returns>
		public static WaitSettings UntilNotExists(this WaitSettings waitSettings)
		{
			waitSettings.WaitType = WaitType.NotExists;
			return waitSettings;
		}

		/// <summary>
		/// Sets the operation to wait for the control to be visible.
		/// </summary>
		/// <param name="waitSettings">The wait settings.</param>
		/// <returns>The original wait settings to support fluent usage</returns>
		public static WaitSettings UntilVisible(this WaitSettings waitSettings)
		{
			waitSettings.WaitType = WaitType.Visible;
			return waitSettings;
		}

		/// <summary>
		/// Sets the operation to wait for the control to become hidden.
		/// </summary>
		/// <param name="waitSettings">The wait settings.</param>
		/// <returns>The original wait settings to support fluent usage</returns>
		public static WaitSettings UntilHidden(this WaitSettings waitSettings)
		{
			waitSettings.WaitType = WaitType.Hidden;
			return waitSettings;
		}

		/// <summary>
		/// Sets the operation to wait for the control to be enabled.
		/// </summary>
		/// <param name="waitSettings">The wait settings.</param>
		/// <returns>The original wait settings to support fluent usage</returns>
		public static WaitSettings UntilEnabled(this WaitSettings waitSettings)
		{
			waitSettings.WaitType = WaitType.Enabled;
			return waitSettings;
		}

		/// <summary>
		/// Sets the operation to wait for the control to become disabled.
		/// </summary>
		/// <param name="waitSettings">The wait settings.</param>
		/// <returns>The original wait settings to support fluent usage</returns>
		public static WaitSettings UntilDisabled(this WaitSettings waitSettings)
		{
			waitSettings.WaitType = WaitType.Disabled;
			return waitSettings;
		}

		/// <summary>
		/// Executes and indefinite wait operation.
		/// </summary>
		/// <param name="waitSettings">The wait settings.</param>
		/// <returns>The control owning the wait settings</returns>
		public static AutomationControl Indefinitely(this WaitSettings waitSettings)
		{
			return ExecuteWait(waitSettings, TimeSpan.Zero);
		}

		/// <summary>
		/// Executes a wait operation that will timeout if not successful
		/// </summary>
		/// <param name="waitSettings">The wait settings.</param>
		/// <param name="timeout">The timeout.</param>
		/// <param name="throwExceptionOnTimeout">if set to <c>true</c> a TimeoutException will be thrown on timeout without success.</param>
		/// <returns>
		/// The control owning the wait settings
		/// </returns>
		/// <exception cref="TimeoutException">Thrown if the timeout period is reached before the expected state is true</exception>
		public static AutomationControl TimeoutAfter(this WaitSettings waitSettings, TimeSpan timeout, bool throwExceptionOnTimeout = false)
		{
			return ExecuteWait(waitSettings, timeout, throwExceptionOnTimeout);
		}

		/// <summary>
		/// Executes a wait operation
		/// </summary>
		/// <param name="waitSettings">The wait settings.</param>
		/// <param name="throwExceptionOnTimeout">if set to <c>true</c> a TimeoutException will be thrown on timeout without success.</param>
		/// <returns>
		/// The control owning the wait settings
		/// </returns>
		/// <exception cref="TimeoutException">Thrown if the timeout period is reached before the expected state is true</exception>
		private static AutomationControl ExecuteWait(WaitSettings waitSettings, TimeSpan timeout, bool throwExceptionOnTimeout = false)
		{
			if(waitSettings.WaitType == WaitType.NotSet)
			{
				throw new WaitTypeNotSetException();
			}

			waitSettings.WaitTime = timeout;

			switch(waitSettings.WaitType)
			{
				case WaitType.Enabled:
				case WaitType.Disabled:
					return ExecuteIsEnabledWait(waitSettings, throwExceptionOnTimeout);
				case WaitType.Visible:
				case WaitType.Hidden:
					return ExecuteIsVisibleWait(waitSettings, throwExceptionOnTimeout);
				case WaitType.Exists:
				case WaitType.NotExists:
					return ExecuteExistsWait(waitSettings, throwExceptionOnTimeout);
				default:
					return waitSettings.WaitRoot;
			}
		}

		/// <summary>
		/// Executes a wait on the existence of the target automation control.
		/// </summary>
		/// <param name="waitSettings">The wait settings.</param>
		/// <param name="throwExceptionOnTimeout">if set to <c>true</c> throw an execption if the timeout expires.</param>
		/// <returns>
		/// The control owning the wait settings
		/// </returns>
		/// <exception cref="TimeoutException">Thrown if the timeout period is reached before the expected state is true</exception>
		private static AutomationControl ExecuteExistsWait(WaitSettings waitSettings, bool throwExceptionOnTimeout)
		{
			var stateToWaitFor = waitSettings.WaitType == WaitType.NotExists;
			var control = waitSettings.WaitRoot;

			SpinWait.SpinUntil(() =>
			{
				control = control.FindSettings.AsDefault();
				return control.IsProxy == stateToWaitFor;
			}, waitSettings.ActualTimeOut);

			if(throwExceptionOnTimeout && control.IsProxy != stateToWaitFor)
			{
				throw new TimeoutException("Wait operation timed out before the required existence was achieved");
			}

			waitSettings.WaitRoot = control;
			return waitSettings.WaitRoot;
		}

        /// <summary>
		/// Executes a wait on the IsVisible state of the target automation control.
		/// </summary>
		/// <param name="waitSettings">The wait settings.</param>
		/// <param name="throwExceptionOnTimeout">if set to <c>true</c> throw an execption if the timeout expires.</param>
		/// <returns>
		/// The control owning the wait settings
		/// </returns>
		/// <exception cref="TimeoutException">Thrown if the timeout period is reached before the expected state is true</exception>
		private static AutomationControl ExecuteIsVisibleWait(WaitSettings waitSettings, bool throwExceptionOnTimeout)
		{
			var expectedState = waitSettings.WaitType == WaitType.Visible;

			if(waitSettings.WaitRoot.IsVisible == expectedState)
			{
				return waitSettings.WaitRoot;
			}

			if(waitSettings.WaitRoot.AutomationElement != null && waitSettings.WaitRoot.AutomationElement.Current.FrameworkId == "WPF")
			{
				return ExecuteWpfVisiblityWait(waitSettings, throwExceptionOnTimeout, expectedState);
			}

			return ExecuteWinFormsVisibilityWait(waitSettings, throwExceptionOnTimeout, expectedState);
		}

		/// <summary>
		/// Executes a wait on the IsVisible state of a WinForms automation control.
		/// </summary>
		/// <param name="waitSettings">The wait settings.</param>
		/// <param name="throwExceptionOnTimeout">if set to <c>true</c> [throw exception on timeout].</param>
		/// <param name="stateToWaitFor">The visibility state to wait for</param>
		/// <returns>
		/// The control owning the wait settings
		/// </returns>
		/// <exception cref="TimeoutException">Thrown if the timeout period is reached before the expected state is true</exception>
		private static AutomationControl ExecuteWinFormsVisibilityWait(WaitSettings waitSettings, bool throwExceptionOnTimeout, bool stateToWaitFor)
		{
			var control = waitSettings.WaitRoot;

			SpinWait.SpinUntil(() =>
			{
				control = control.FindSettings.AsDefault();
				return control.IsVisible == stateToWaitFor;
			}, waitSettings.ActualTimeOut);

			if(throwExceptionOnTimeout && control.IsVisible != stateToWaitFor)
			{
				throw new TimeoutException("Wait operation timed out before the required visibility was achieved");
			}

			waitSettings.WaitRoot = control;
			return waitSettings.WaitRoot;
		}

		/// <summary>
		/// Executes a wait on the IsVisible state of a WPF automation control.
		/// </summary>
		/// <param name="waitSettings">The wait settings.</param>
		/// <param name="throwExceptionOnTimeout">if set to <c>true</c> [throw exception on timeout].</param>
		/// <param name="stateToWaitFor">The visibility state to wait for</param>
		/// <returns>
		/// The control owning the wait settings
		/// </returns>
		/// <exception cref="TimeoutException">Thrown if the timeout period is reached before the expected state is true</exception>
        private static AutomationControl ExecuteWpfVisiblityWait(WaitSettings waitSettings, bool throwExceptionOnTimeout, bool stateToWaitFor)
		{
			var control = waitSettings.WaitRoot;
			var element = control.AutomationElement;

			SpinWait.SpinUntil(() =>
			{
				return control.IsVisible == stateToWaitFor;
			}, waitSettings.ActualTimeOut);
			
			if(throwExceptionOnTimeout && control.IsVisible != stateToWaitFor)
			{
				throw new TimeoutException("Wait operation timed out before the required visibility was achieved");
			}

			return waitSettings.WaitRoot;
		}

		/// <summary>
		/// Executes a wait on the IsEnabled state of the target automation control.
		/// </summary>
		/// <param name="waitSettings">The wait settings.</param>
		/// <param name="throwExceptionOnTimeout">if set to <c>true</c> throw an exception if the timeout expires.</param>
		/// <returns>
		/// The control owning the wait settings
		/// </returns>
		/// <exception cref="TimeoutException">Thrown if the timeout period is reached before the expected state is true</exception>
		private static AutomationControl ExecuteIsEnabledWait(WaitSettings waitSettings, bool throwExceptionOnTimeout = false)
		{
			var expectedState = waitSettings.WaitType == WaitType.Enabled;
			
			if(waitSettings.WaitRoot.IsEnabled == expectedState)
			{
				return waitSettings.WaitRoot;
			}

			SpinWait.SpinUntil(() => waitSettings.WaitRoot.IsEnabled == expectedState, waitSettings.ActualTimeOut);
			if(throwExceptionOnTimeout && waitSettings.WaitRoot.IsEnabled != expectedState)
			{
				throw new TimeoutException("Wait operation timed out before the required enabled state was achieved");
			}

			return waitSettings.WaitRoot;
		}
	}
}
