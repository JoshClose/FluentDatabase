#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
namespace FluentDatabase.MySql
{
	/// <summary>
	/// Represents errors that occur when creating a MySQL database.
	/// </summary>
	public class FluentDatabaseMySqlException : FluentDatabaseException
	{
		/// <summary>
		/// Creates a new instance of FluentDatabaseMySqlException.
		/// </summary>
		/// <param name="message"></param>
		public FluentDatabaseMySqlException( string message ) : base( message ){}
	}
}