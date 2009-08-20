#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System;
using System.IO;

namespace FluentDatabase.PostgreSql
{
	/// <summary>
	/// PostgreSQL table.
	/// </summary>
	public class Table : TableBase
	{
		protected override void WriteTableBegin( StreamWriter writer )
		{
			if( string.IsNullOrEmpty( Name ) )
			{
				throw new FluentDatabasePostgreSqlException( Resource.TableNameEmptyErrorMessage );
			}

			writer.Write( "CREATE TABLE " );
			if( !string.IsNullOrEmpty( Schema ) )
			{
				writer.Write( string.Format( "{0}.", Schema ) );
			}
			writer.WriteLine( Name );
			writer.WriteLine( "(" );
		}

		protected override void WriteTableEnd( StreamWriter writer )
		{
			writer.WriteLine( ");" );
		}

		protected override IColumn CreateColumn()
		{
			return new Column();
		}
	}
}