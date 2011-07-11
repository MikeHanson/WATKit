using System;
using System.Runtime.Serialization;

namespace WATKit.Exceptions
{
	/// <summary>
	/// Exception thrown by some fluent automation methods when <see cref="FindScope"/> has not been set <see cref="FindSettings" />
	/// </summary>
	public class FindScopeNotSetException: Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FindScopeNotSetException"/> class.
		/// </summary>
		public FindScopeNotSetException()
			: base("One or more of IncludeSelf, IncludeChildren or IncludeDescendants() must be included in your find expression to set the scope of the operation")
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FindScopeNotSetException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public FindScopeNotSetException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FindScopeNotSetException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerException">The inner exception.</param>
		public FindScopeNotSetException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FindScopeNotSetException"/> class.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
		///   
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
		protected FindScopeNotSetException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}