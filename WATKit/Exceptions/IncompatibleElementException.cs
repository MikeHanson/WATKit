using System;
using System.Runtime.Serialization;
using System.Windows.Automation;

namespace WATKit.Exceptions
{
	/// <summary>
	/// Thrown when an attempt to wrap an incompatible AutomationElement with an AutomationControl derived class is made
	/// </summary>
	public class IncompatibleElementException: Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="IncompatibleElementException"/> class.
		/// </summary>
		/// <param name="sourceType">Type of the source.</param>
		/// <param name="targetType">Type of the target.</param>
		public IncompatibleElementException(string sourceType, string targetType)
			: base(String.Format("The element was found but it's Control Type {0} is not compatible with {0}", sourceType, targetType))
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IncompatibleElementException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public IncompatibleElementException(string message)
			: base(message)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IncompatibleElementException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerException">The inner exception.</param>
		public IncompatibleElementException(string message, Exception innerException)
			: base(message, innerException)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IncompatibleElementException"/> class.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
		///   
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
		protected IncompatibleElementException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{

		}

	}
}
