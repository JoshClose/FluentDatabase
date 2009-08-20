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
