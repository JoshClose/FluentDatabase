#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
namespace FluentDatabase.Sqlite
{
	/// <summary>
	/// Represents errors that occur when creating a SQLite database.
	/// </summary>
	public class FluentDatabaseSqliteException : FluentDatabaseException
	{
		/// <summary>
		/// Creates a new instance of FluentDatabaseSqliteException.
		/// </summary>
		/// <param name="message"></param>
		public FluentDatabaseSqliteException( string message ) : base( message ){}
	}
}
