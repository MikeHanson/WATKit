using System;
using System.Threading;
using System.Windows.Automation;
using WATKit.Controls;
using WATKit.Exceptions;

namespace WATKit
{
	/// <summary>
	/// Provides extension methods for find operations within the fluent automation api
	/// </summary>
	public static class FluentAutomationFindExtensions
	{
		/// <summary>
		/// Sets up a new find operation
		/// </summary>
		/// <param name="owner">The automation control owning the find settings</param>
		/// <returns>
		/// The new find settings to support fluent usage
		/// </returns>
		public static FindSettings FindControl(this AutomationControl owner)
		{
			owner.FindSettings = new FindSettings
									{
										SearchRoot = owner,
										FindType = FindType.NotSet,
										FindScope = FindScope.NotSet,
									};
			return owner.FindSettings;
		}

		/// <summary>
		/// Sets the operation to find a control with the specified automation id
		/// </summary>
		/// <param name="findSettings">The findSettings being operated</param>
		/// <param name="automationId">The automation id.</param>
		/// <returns>
		/// The original find settings to support fluent usage
		/// </returns>
		public static FindSettings WithId(this FindSettings findSettings, string automationId)
		{
			findSettings.FindType = FindType.AutomationId;
			findSettings.Identifier = automationId;
			return findSettings;
		}

		/// <summary>
		/// Sets the operation to find a control with the specified text content
		/// </summary>
		/// <param name="findSettings">The findSettings being operated</param>
		/// <param name="text">The name.</param>
		/// <returns>
		/// The original find settings to support fluent usage
		/// </returns>
		public static FindSettings WithText(this FindSettings findSettings, string text)
		{
			findSettings.FindType = FindType.Text;
			findSettings.Identifier = text;
			return findSettings;
		}

		/// <summary>
		/// Sets the scope of the find operation to include the root element
		/// </summary>
		/// <param name="findSettings">The find settings.</param>
		/// <returns>
		/// The original find settings to support fluent usage
		/// </returns>
		public static FindSettings IncludeSelf(this FindSettings findSettings)
		{
			switch(findSettings.FindScope)
			{
				case FindScope.SelfAndChildren:
				case FindScope.SelfAndDescendants:
					break;
				case FindScope.Children:
					findSettings.FindScope = FindScope.SelfAndChildren;
					break;
				case FindScope.Descendants:
					findSettings.FindScope = FindScope.SelfAndDescendants;
					break;
				default:
					findSettings.FindScope = FindScope.Self;
					break;
			}

			return findSettings;
		}

		/// <summary>
		/// Sets the scope of the find operation to include immediate children of the root element
		/// </summary>
		/// <param name="findSettings">The find settings.</param>
		/// <returns>
		/// The original find settings to support fluent usage
		/// </returns>
		public static FindSettings IncludeChildren(this FindSettings findSettings)
		{
			switch(findSettings.FindScope)
			{
				case FindScope.Self:
					findSettings.FindScope = FindScope.SelfAndChildren;
					break;
				case FindScope.SelfAndChildren:
				case FindScope.Descendants:
				case FindScope.SelfAndDescendants:
					// nothing to do Descendants search includes children
					break;
				default:
					findSettings.FindScope = FindScope.Children;
					break;
			}

			return findSettings;
		}

		/// <summary>
		/// Sets the scope of the find operation to include descendants and children the root element
		/// </summary>
		/// <param name="findSettings">The find settings.</param>
		/// <returns>
		/// The original find settings to support fluent usage
		/// </returns>
		public static FindSettings IncludeDescendants(this FindSettings findSettings)
		{
			switch(findSettings.FindScope)
			{
				case FindScope.Self:
					findSettings.FindScope = FindScope.SelfAndDescendants;
					break;
				case FindScope.SelfAndDescendants:
					break;
				default:
					findSettings.FindScope = FindScope.Descendants;
					break;
			}

			return findSettings;
		}

		/// <summary>
		/// Sets the wait and retry settings to zero so that the find operation is immediate
		/// </summary>
		/// <param name="findSettings">The find settings.</param>
		/// <returns>
		/// The original find settings to support fluent usage
		/// </returns>
		public static FindSettings Now(this FindSettings findSettings)
		{
			findSettings.WaitTime = TimeSpan.Zero;
			return findSettings;
		}

		/// <summary>
		/// Sets the time to wait before executing the find operation.
		/// </summary>
		/// <param name="timeToWait">The time to wait.</param>
		/// <returns>
		/// The original find settings to support fluent usage
		/// </returns>
		public static FindSettings WaitFor(this FindSettings findSettings, TimeSpan timeToWait)
		{
			findSettings.WaitTime = timeToWait;
			return findSettings;
		}

		/// <summary>
		/// Sets the time to wait before executing the find operation.
		/// </summary>
		/// <param name="findSettings">The find settings.</param>
		/// <param name="secondsToWait">The time to wait in seconds.</param>
		/// <returns>
		/// The original find settings to support fluent usage
		/// </returns>
		public static FindSettings WaitFor(this FindSettings findSettings, int secondsToWait)
		{
			findSettings.WaitTime = TimeSpan.FromSeconds(secondsToWait);
			return findSettings;
		}

		/// <summary>
		/// Sets the time to retry the find operation before giving up.
		/// </summary>
		/// <param name="timeToRetry">The time to retry.</param>
		/// <returns>
		/// The original find settings to support fluent usage
		/// </returns>
		/// <remarks>Returns immediately on successful find</remarks>
		public static FindSettings RetryFor(this FindSettings findSettings, TimeSpan timeToRetry)
		{
			findSettings.RetryTime = timeToRetry;
			return findSettings;
		}

		/// <summary>
		/// Sets the time to retry before executing the find operation.
		/// </summary>
		/// <param name="findSettings">The find settings.</param>
		/// <param name="secondsToRetry">The time to retry in seconds.</param>
		/// <returns>
		/// The original find settings to support fluent usage
		/// </returns>
		/// <remarks>Returns immediately on successful find</remarks>
		public static FindSettings RetryFor(this FindSettings findSettings, int secondsToRetry)
		{
			findSettings.RetryTime = TimeSpan.FromSeconds(secondsToRetry);
			return findSettings;
		}

		/// <summary>
		/// Executes the find operation returning the result as an AutomationControl
		/// </summary>
		/// <param name="findSettings">The find settings.</param>
		/// <returns>The target as an AutomationControl if found, otherwise null</returns>
		public static AutomationControl AsDefault(this FindSettings findSettings)
		{
			return As<AutomationControl>(findSettings);
		}

		/// <summary>
		/// Executes the find operation returning the specified type of control.
		/// </summary>
		/// <typeparam name="TControl">The type of the control.</typeparam>
		/// <param name="findSettings">The find settings.</param>
		/// <returns>The target wrapped in a control of the specified type if found, otherise null</returns>
		public static TControl As<TControl>(this FindSettings findSettings)
			where TControl: AutomationControl, new()
		{
			if(findSettings.FindType == FindType.NotSet)
			{
				throw new FindTypeNotSetException();
			}

			return findSettings.FindType == FindType.Text
					? ExecuteFindByText<TControl>(findSettings)
					: ExecuteFindByAutomationId<TControl>(findSettings);
		}

		/// <summary>
		/// Executes a find by text content.
		/// </summary>
		/// <typeparam name="TControl">The type of the control.</typeparam>
		/// <param name="findSettings">The find settings.</param>
		/// <returns>The target wrapped in a control of the specified type if found, otherise null</returns>
		private static TControl ExecuteFindByText<TControl>(FindSettings findSettings)
			where TControl: AutomationControl, new()
		{
			var condition = new PropertyCondition(AutomationElement.NameProperty, findSettings.Identifier);
			return ExecuteFind<TControl>(findSettings, condition);
		}

		private static TControl ExecuteFind<TControl>(FindSettings findSettings, Condition condition)
			where TControl: AutomationControl, new()
		{
			ExecuteWaitFor(findSettings);

			var scope = GetTreeScope(findSettings);
			var endTime = DateTime.Now.Add(findSettings.RetryTime);
			var element = findSettings.SearchRoot.AutomationElement.FindFirst(scope, condition);
			while(element == null && DateTime.Now <= endTime)
			{
				element = findSettings.SearchRoot.AutomationElement.FindFirst(scope, condition);
			}
						
			findSettings.IsOwnerProxy = element == null;

			var result = new TControl
				       	{
				       		AutomationElement = element,
							FindSettings = findSettings,
							IsProxy = findSettings.IsOwnerProxy
				       	};

			result.ValidateControlType();
			return result;
		}

		/// <summary>
		/// Executes any wait defined for the find operation.
		/// </summary>
		/// <param name="findSettings">The find settings.</param>
		private static void ExecuteWaitFor(FindSettings findSettings)
		{
			if(findSettings.WaitTime.TotalSeconds == 0)
			{
				return;
			}

			SpinWait.SpinUntil(() => false, findSettings.WaitTime);
		}

		/// <summary>
		/// Executes the find by automation id.
		/// </summary>
		/// <typeparam name="TControl">The type of the control.</typeparam>
		/// <param name="findSettings">The find settings.</param>
		/// <returns>The target wrapped in a control of the specified type if found, otherise null</returns>
		private static TControl ExecuteFindByAutomationId<TControl>(FindSettings findSettings)
			where TControl: AutomationControl, new()
		{
			var condition = new PropertyCondition(AutomationElement.AutomationIdProperty, findSettings.Identifier);
			return ExecuteFind<TControl>(findSettings, condition);
		}

		/// <summary>
		/// Gets the tree scope.
		/// </summary>
		/// <param name="findSettings">The find settings.</param>
		/// <returns>The treescope setting to be used based on the find scope of the find settings</returns>
		private static TreeScope GetTreeScope(FindSettings findSettings)
		{
			switch(findSettings.FindScope)
			{
				case FindScope.Self:
					return TreeScope.Element;
				case FindScope.Children:
					return TreeScope.Children;
				case FindScope.Descendants:
					return TreeScope.Descendants;
				case FindScope.SelfAndChildren:
					return TreeScope.Element | TreeScope.Children;
					case FindScope.SelfAndDescendants:
					return TreeScope.Element | TreeScope.Descendants;
				default:
					throw new FindScopeNotSetException();
			}
		}
		
		/// <summary>
		/// Validates the type of the control.
		/// </summary>
		/// <param name="source">The source.</param>
		private static void ValidateControlType(this AutomationControl control)
		{
			var typeName = control.GetType().Name;

			if(control.AutomationElement == null || typeName == typeof(AutomationControl).Name)
			{
				return;
			}

			if(control.ControlType.LocalizedControlType != control.AutomationElement.Current.ControlType.LocalizedControlType)
			{
				throw new IncompatibleElementException(control.AutomationElement.Current.ControlType.LocalizedControlType, control.ControlType.LocalizedControlType);
			}
		}
	}
}
 