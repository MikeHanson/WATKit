using System;
using System.Runtime.Serialization;

namespace WATKit.Exceptions
{
	public class WaitTypeNotSetException: Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="WaitTypeNotSetException"/> class.
		/// </summary>
		public WaitTypeNotSetException()
			: base("One of the Until* operations must be included in your wait expression to set the type of the operation")
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WaitTypeNotSetException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public WaitTypeNotSetException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WaitTypeNotSetException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerException">The inner exception.</param>
		public WaitTypeNotSetException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WaitTypeNotSetException"/> class.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
		///   
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
		protected WaitTypeNotSetException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}