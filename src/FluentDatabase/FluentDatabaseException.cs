using System;

namespace FluentDatabase
{
	/// <summary>
	/// Represents errors that occur when using FluentDatabase.
	/// </summary>
	public class FluentDatabaseException : Exception
	{
		/// <summary>
		/// Creates a new instance of FluentDatabaseException.
		/// </summary>
		/// <param name="message">The error message.</param>
		public FluentDatabaseException( string message ) : base( message ){}
	}
}
