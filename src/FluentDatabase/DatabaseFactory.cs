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
					throw new NotImplementedException();
				case DatabaseType.MySQL:
					throw new NotImplementedException();
				case DatabaseType.Oracle:
					throw new NotImplementedException();
				case DatabaseType.PostgreSQL:
					throw new NotImplementedException();
				case DatabaseType.SQLite:
					throw new NotImplementedException();
				case DatabaseType.SQLServer:
					return new SqlServer.Database();
				default:
					throw new NotSupportedException( string.Format( "Database server '{0}' is not supported.", databaseServer ) );
			}
		}
	}
}
