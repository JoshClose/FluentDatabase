#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
namespace FluentDatabase.SqlServer
{
	/// <summary>
	/// Represents errors that occur when creating a SQL Server database.
	/// </summary>
	public class FluentDatabaseSqlServerException : FluentDatabaseException
	{
		/// <summary>
		/// Creates a new instance of FluentDatabaseSqlServerException.
		/// </summary>
		/// <param name="message">The error message.</param>
		public FluentDatabaseSqlServerException( string message ) : base( message ){}
	}
}
