#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
namespace FluentDatabase.Firebird
{
	/// <summary>
	/// Represents errors that occur when creating a Firebird database.
	/// </summary>
	public class FluentDatabaseFirebirdException : FluentDatabaseException
	{
		/// <summary>
		/// Creates a new instance of FluentDatabaseFirebirdException.
		/// </summary>
		/// <param name="message"></param>
		public FluentDatabaseFirebirdException( string message ) : base( message ) { }
	}
}