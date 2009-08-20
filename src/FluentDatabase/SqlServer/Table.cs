#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System.IO;

namespace FluentDatabase.SqlServer
{
	/// <summary>
	/// SQL Server table.
	/// </summary>
	public class Table : TableBase
	{
		protected override IColumn CreateColumn()
		{
			return new Column();
		}

		protected override void WriteTableBegin( StreamWriter writer )
		{
			if( string.IsNullOrEmpty( Name ) )
			{
				throw new FluentDatabaseSqlServerException( "The database name cannot be null or empty." );
			}

			writer.WriteLine( string.Format( "CREATE TABLE [{0}].[{1}]", Schema, Name ) );
			writer.WriteLine( "(" );
		}

		protected override void WriteTableEnd( StreamWriter writer )
		{
			writer.WriteLine( ")" );
		}
	}
}
