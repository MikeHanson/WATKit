using System;
using System.Linq.Expressions;

namespace WATKit
{
	/// <summary>
	/// Provides extension methods for the Class type
	/// </summary>
	public static class ClassExtensions
	{
		/// <summary>
		/// Gets the name of the member.
		/// </summary>
		/// <typeparam name="TInstance">The type of the instance.</typeparam>
		/// <typeparam name="TMember">The type of the member.</typeparam>
		/// <param name="instance">The object being extended by the operation</param>
		/// <param name="expression">The expression that identifies the target for the operation</param>
		/// <returns>The name of the member identified by <paramref name="expression"/></returns>
		public static string GetMemberName<TInstance, TMember>(this TInstance instance, Expression<Func<TInstance, TMember>> expression)
			where TInstance : class
		{
			var memberExpression = expression.Body as MemberExpression;
			if(memberExpression == null)
			{
				var unaryExpression = expression.Body as UnaryExpression;
				if(unaryExpression != null)
				{
					memberExpression = (MemberExpression)unaryExpression.Operand;
				}
			}

			return memberExpression.Member.Name;
		} 
	}
}
