#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System;

namespace FluentDatabase
{
	public static class DatabaseFactory
	{
		public static IDatabase Create( DatabaseType databaseServer )
		{
			switch( databaseServer )
			{
				case DatabaseType.Access:
					return new Access.Database();
				case DatabaseType.MySQL:
					return new MySql.Database();
				case DatabaseType.Oracle:
					return new Oracle.Database();
				case DatabaseType.PostgreSQL:
					return new PostgreSql.Database();
				case DatabaseType.SQLite:
					return new Sqlite.Database();
				case DatabaseType.SQLServer:
					return new SqlServer.Database();
				default:
					throw new NotSupportedException( string.Format( "Database server '{0}' is not supported.", databaseServer ) );
			}
		}
	}
}
