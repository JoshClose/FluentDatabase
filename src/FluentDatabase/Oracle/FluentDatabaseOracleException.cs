#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
namespace FluentDatabase.Oracle
{
	/// <summary>
	/// Represents errors that occur when creating an Oracle database.
	/// </summary>
	public class FluentDatabaseOracleException : FluentDatabaseException
	{
		/// <summary>
		/// Creates a new instance of FluentDatabaseOracleException.
		/// </summary>
		/// <param name="message"></param>
		public FluentDatabaseOracleException( string message ) : base( message ){}
	}
}