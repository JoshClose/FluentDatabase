#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
namespace FluentDatabase.PostgreSql
{
	/// <summary>
	/// Represents errors that occur when creating a PostgreSQL database.
	/// </summary>
	public class FluentDatabasePostgreSqlException : FluentDatabaseException
	{
		/// <summary>
		/// Creates a new instance of FluentDatabasePostgreSqlException.
		/// </summary>
		/// <param name="message"></param>
		public FluentDatabasePostgreSqlException( string message ) : base( message ){}
	}
}
