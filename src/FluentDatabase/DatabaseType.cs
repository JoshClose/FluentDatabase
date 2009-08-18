using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
		Oracle = 3,
		Access = 4,
		PostgreSQL = 5,
		MySQL = 6
// ReSharper restore InconsistentNaming
	}
}
