using System;
using System.Windows.Automation;

namespace WATKit.Controls
{
	public class AutomationControl
	{
		/// <summary>
		/// Gets the underlying automation element.
		/// </summary>
		public AutomationElement AutomationElement{get; internal set;}

		/// <summary>
		/// Gets the current criteria for find operations.
		/// </summary>
		public FindSettings FindSettings { get;  internal set; }

		/// <summary>
		/// Gets the name of the control if set
		/// </summary>
		public string Name { get { return this.AutomationElement.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString(); } }

		/// <summary>
		/// Initializes a new instance of the <see cref="AutomationControl"/> class.
		/// </summary>
		public AutomationControl()
		{
		}

		///// <summary>
		///// Finds a child control by name.
		///// </summary>
		///// <typeparam name="TControl">The type of the control.</typeparam>
		///// <param name="name">The name.</param>
		///// <param name="secondsToRetry">The seconds to retry.</param>
		///// <returns>The first child control with the specified name or null if not found in the specified period</returns>
		//public TControl FindChildByName<TControl>(string name, int secondsToRetry = 0)
		//    where TControl: AutomationControl, new()
		//{
		//    return this.AutomationElement.FindFirstChildByName(name, secondsToRetry).As<TControl>();
		//}

		///// <summary>
		///// Finds a child control by automationId.
		///// </summary>
		///// <typeparam name="TControl">The type of the control.</typeparam>
		///// <param name="automationId">The automationId.</param>
		///// <param name="secondsToRetry">The seconds to retry.</param>
		///// <returns>The first child control with the specified automationId or null if not found in the specified period</returns>
		//public TControl FindChildByAutomationId<TControl>(string automationId, int secondsToRetry = 0)
		//    where TControl: AutomationControl, new()
		//{
		//    return this.AutomationElement.FindFirstChildByAutomationId(automationId, secondsToRetry).As<TControl>();
		//}

		///// <summary>
		///// Finds a descendant control by name.
		///// </summary>
		///// <typeparam name="TControl">The type of the control.</typeparam>
		///// <param name="name">The name.</param>
		///// <param name="secondsToRetry">The seconds to retry.</param>
		///// <returns>The first descendant control with the specified name or null if not found in the specified period</returns>
		//public TControl FindDescendantByName<TControl>(string name, int secondsToRetry = 0)
		//    where TControl: AutomationControl, new()
		//{
		//    return this.AutomationElement.FindFirstDescendantByText(name, secondsToRetry).As<TControl>();
		//}

		///// <summary>
		///// Finds a descendant control by automationId.
		///// </summary>
		///// <typeparam name="TControl">The type of the control.</typeparam>
		///// <param name="automationId">The automationId.</param>
		///// <param name="secondsToRetry">The seconds to retry.</param>
		///// <returns>The first descendant control with the specified automationId or null if not found in the specified period</returns>
		//public TControl FindDescendantByAutomationId<TControl>(string automationId, int secondsToRetry = 0)
		//    where TControl: AutomationControl, new()
		//{
		//    return this.AutomationElement.FindFirstDescendantByAutomationId(automationId, secondsToRetry).As<TControl>();
		//}
	}
}
