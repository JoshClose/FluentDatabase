#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
namespace FluentDatabase.Access
{
	/// <summary>
	/// Represents errors that occur when creating a Access database.
	/// </summary>
	public class FluentDatabaseAccessException : FluentDatabaseException
	{
		/// <summary>
		/// Creates a new instance of FluentDatabaseAccessException.
		/// </summary>
		/// <param name="message"></param>
		public FluentDatabaseAccessException( string message ) : base( message ) { }
	}
}