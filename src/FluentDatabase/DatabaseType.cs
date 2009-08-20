#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
namespace FluentDatabase
{
	public enum DatabaseType
	{
// ReSharper disable InconsistentNaming
		/// <summary>
		/// SQLite is a software library that implements a self-contained, serverless, zero-configuration, 
		/// transactional SQL database engine.
		/// http://sqlite.org
		/// </summary>
		SQLite = 1,

		/// <summary>
		/// Microsoft SQL Server.
		/// http://www.microsoft.com/sql
		/// </summary>
		SQLServer = 2,

		/// <summary>
		/// Oracle Database runs on all industry-standard platforms and moves from a single instance 
		/// to Grid Computing without changing a single line of code.
		/// http://www.oracle.com
		/// </summary>
		Oracle = 3,

		/// <summary>
		/// Microsoft Access.
		/// http://office.microsoft.com/access
		/// </summary>
		Access = 4,

		/// <summary>
		/// The world's most advanced open source database.
		/// http://www.postgresql.org
		/// </summary>
		PostgreSQL = 5,

		/// <summary>
		/// The world's most popular open source database.
		/// http://www.mysql.com
		/// </summary>
		MySQL = 6,

		/// <summary>
		/// The RDBMS that's going where you're going.
		/// http://firebirdsql.org
		/// </summary>
		Firebird = 7
// ReSharper restore InconsistentNaming
	}
}
