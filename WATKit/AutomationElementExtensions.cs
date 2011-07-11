using System;
using System.Windows.Automation;
using WATKit.Controls;

namespace WATKit
{
	/// <summary>
	/// Provides extension methods for the AutomationElement type
	/// </summary>
	public static class AutomationElementExtensions
	{
		/// <summary>
		/// Encapsulates the element in an AutomationControl.
		/// </summary>
		/// <typeparam name="TControl">The type of the control.</typeparam>
		/// <param name="element">The element.</param>
		/// <returns>A new instance of TControl wrapping the element instance</returns>
		public static TControl As<TControl>(this AutomationElement element)
			where TControl: AutomationControl, new()
		{
			return new TControl
			{
				AutomationElement = element
			};
		}

		/// <summary>
		/// Finds the first.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="scope">The scope.</param>
		/// <param name="condition">The condition.</param>
		/// <param name="secondsToRetry">Optional time to retry if the element is not available initially.</param>
		/// <returns>First element within the specified scope and matching the specified condition, if foun otherwise null</returns>
		public static AutomationElement FindFirst(this AutomationElement element, TreeScope scope, Condition condition, int secondsToRetry)
		{
			var result = element.FindFirst(scope, condition);
			var endTime = DateTime.Now.Add(TimeSpan.FromSeconds(secondsToRetry));
			while(result == null && DateTime.Now < endTime)
			{
				result = element.FindFirst(TreeScope.Descendants, condition);
			}
			return result;
		}

		/// <summary>
		/// Finds the first child.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="condition">The condition.</param>
		/// <param name="secondsToRetry">Optional time to wait for the element to be available.</param>
		/// <returns>First child element matching the condition</returns>
		public static AutomationElement FindFirstChild(this AutomationElement element, Condition condition, int secondsToRetry = 0)
		{
			return element.FindFirst(TreeScope.Element | TreeScope.Children, condition, secondsToRetry);
		}

		/// <summary>
		/// Finds the first name of the child by.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="name">The name.</param>
		/// <param name="secondsToRetry">Optional time to wait for the element to be available.</param>
		/// <returns>First child element matching the name</returns>
		public static AutomationElement FindFirstChildByName(this AutomationElement element, string name, int secondsToRetry = 0)
		{
			return element.FindFirstChild(new PropertyCondition(AutomationElement.NameProperty, name), secondsToRetry);
		}

		/// <summary>
		/// Finds the first name of the child by.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="automationId">The automation id.</param>
		/// <param name="secondsToRetry">Optional time to wait for the element to be available.</param>
		/// <returns>
		/// First child element matching the name
		/// </returns>
		public static AutomationElement FindFirstChildByAutomationId(this AutomationElement element, string automationId, int secondsToRetry = 0)
		{
			return element.FindFirstChild(new PropertyCondition(AutomationElement.AutomationIdProperty, automationId, PropertyConditionFlags.IgnoreCase), secondsToRetry);
		}

		/// <summary>
		/// Finds the first descendant.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="condition">The condition.</param>
		/// <returns>First descendant matching the condition</returns>
		public static AutomationElement FindFirstDescendant(this AutomationElement element, Condition condition, int secondsToRetry = 0)
		{
			return element.FindFirst(TreeScope.Element | TreeScope.Descendants, condition, secondsToRetry);
		}

		/// <summary>
		/// Finds the first descendant by name property.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="text">The text content to be matched.</param>
		/// <param name="secondsToRetry">Optional time to wait for the element to be available.</param>
		/// <returns>First descendant with matching the name</returns>
		public static AutomationElement FindFirstDescendantByText(this AutomationElement element, string text, int secondsToRetry = 0)
		{
			return element.FindFirstDescendant(new PropertyCondition(AutomationElement.NameProperty, text), secondsToRetry);
		}

		public static AutomationElement FindFirstDescendantByAutomationId(this AutomationElement element, string automationId, int secondsToRetry = 0)
		{
			return element.FindFirstDescendant(new PropertyCondition(AutomationElement.AutomationIdProperty, automationId), secondsToRetry);
		}

		/// <summary>
		/// Finds the first ancestor.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="condition">The condition.</param>
		/// <param name="secondsToRetry">Optional time to wait for the element to be available.</param>
		/// <returns>First anscestor matching the condition</returns>
		public static AutomationElement FindFirstAncestor(this AutomationElement element, Condition condition, int secondsToRetry = 0)
		{
			return element.FindFirst(TreeScope.Ancestors, condition, secondsToRetry);
		}

		/// <summary>
		/// Finds the first element in subtree.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="condition">The condition.</param>
		/// <param name="secondsToRetry">Optional time to wait for the element to be available.</param>
		/// <returns>First element in the subtree including this element that matches the condition</returns>
		public static AutomationElement FindFirstInSubtree(this AutomationElement element, Condition condition, int secondsToRetry = 0)
		{
			return element.FindFirst(TreeScope.Subtree, condition, secondsToRetry);
		}

		/// <summary>
		/// Finds the first window or child window (via the Desktop) by it's title
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="title">The name.</param>
		/// <param name="secondsToRetry">Optional time to wait for the element to be available.</param>
		/// <returns>The first child of the desktop matching the specified name and returning true for IsWindowPatterAvailableProperty</returns>
		public static AutomationElement FindWindowByTitle(this AutomationElement element, string title, int secondsToRetry = 0)
		{
			var result = AutomationElement.RootElement.FindFirstChildByName(title, secondsToRetry);
			if(result != null && (bool)result.GetCurrentPropertyValue(AutomationElement.IsWindowPatternAvailableProperty))
			{
				return result;
			}

			return null;
		}

		/// <summary>
		/// Finds the first window or child window (via the Desktop) by it's automation id
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="automationId">The automation id.</param>
		/// <param name="secondsToRetry">Optional time to wait for the element to be available.</param>
		/// <returns>The first child of the desktop matching the specified automation id and returning true for IsWindowPatterAvailableProperty</returns>
		public static AutomationElement FindWindowByAutomationId(this AutomationElement element, string automationId, int secondsToRetry = 0)
		{
			var result = AutomationElement.RootElement.FindFirstChildByAutomationId(automationId, secondsToRetry);
			
			if(result != null && (bool)result.GetCurrentPropertyValue(AutomationElement.IsWindowPatternAvailableProperty))
			{
				return result;
			}

			return null;
		}
	}
}
