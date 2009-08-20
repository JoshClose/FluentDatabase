#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System;
using System.Data;
using System.IO;

namespace FluentDatabase.Sqlite
{
	/// <summary>
	/// SQLite column.
	/// </summary>
	public class Column : ColumnBase
	{
		protected override void WriteColumn( StreamWriter writer )
		{
			if( Name.ToLower().StartsWith( "sqlite_" ) )
			{
				throw new FluentDatabaseSqliteException( "Table names cannot begin with sqlite_. This is reserved by the SQLite engine." );
			}
			if( string.IsNullOrEmpty( Name ) )
			{
				throw new FluentDatabaseSqliteException( Resource.ColumnNameEmptyErrorMessage );
			}

			writer.Write( string.Format( "\t{0} {1}", Name, GetSqlDbType() ) );
		}

		protected override IConstraint CreateConstraint()
		{
			return new Constraint();
		}

		private string GetSqlDbType()
		{
			switch( Type )
			{
				case SqlDbType.BigInt:
					return "INTEGER";
				case SqlDbType.Binary:
					return "BLOB";
				case SqlDbType.Bit:
					return "INTEGER";
				case SqlDbType.Char:
					return "TEXT";
				case SqlDbType.Date:
					return "TEXT";
				case SqlDbType.DateTime:
					return "TEXT";
				case SqlDbType.DateTime2:
					return "TEXT";
				case SqlDbType.DateTimeOffset:
					return "TEXT";
				case SqlDbType.Decimal:
					return "REAL";
				case SqlDbType.Float:
					return "REAL";
				case SqlDbType.Image:
					return "BLOB";
				case SqlDbType.Int:
					return "INTEGER";
				case SqlDbType.Money:
					return "REAL";
				case SqlDbType.NChar:
					return "TEXT";
				case SqlDbType.NText:
					return "TEXT";
				case SqlDbType.NVarChar:
					return "TEXT";
				case SqlDbType.Real:
					return "REAL";
				case SqlDbType.SmallDateTime:
					return "TEXT";
				case SqlDbType.SmallInt:
					return "INTEGER";
				case SqlDbType.SmallMoney:
					return "REAL";
				case SqlDbType.Text:
					return "TEXT";
				case SqlDbType.Time:
					return "TEXT";
				case SqlDbType.TinyInt:
					return "INTEGER";
				case SqlDbType.UniqueIdentifier:
					return "TEXT";
				case SqlDbType.VarBinary:
					return "BLOB";
				case SqlDbType.VarChar:
					return "TEXT";
				case SqlDbType.Xml:
					return "TEXT";
				default:
					throw new NotSupportedException( string.Format( "SqlDbType '{0}' is not supported.", Type ) );
			}
		}
	}
}
