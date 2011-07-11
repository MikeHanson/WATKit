using System;
using System.Runtime.Serialization;
using System.Windows.Automation.Toolkit.Controls;

namespace System.Windows.Automation.Toolkit.Exceptions
{
	/// <summary>
	/// Exception thrown by any fluent automation method <see cref="FindSettings" /> have not been intialised by calling Find on the <see cref="AutomationControl"/>
	/// </summary>
	public class FindNotInitialisedException: Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FindNotInitialisedException"/> class.
		/// </summary>
		public FindNotInitialisedException()
			: base("Find() must be called at least once on an AutomationControl instance to intialise the find settings")
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FindNotInitialisedException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public FindNotInitialisedException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FindNotInitialisedException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerException">The inner exception.</param>
		public FindNotInitialisedException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FindNotInitialisedException"/> class.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
		///   
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
		protected FindNotInitialisedException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}