#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System;
using System.Data;
using System.IO;

namespace FluentDatabase.PostgreSql
{
	/// <summary>
	/// PostgreSQL column.
	/// </summary>
	public class Column : ColumnBase
	{
		protected override void WriteColumn( StreamWriter writer )
		{
			if( string.IsNullOrEmpty( Name ) )
			{
				throw new FluentDatabasePostgreSqlException( Resource.ColumnNameEmptyErrorMessage );
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
					return AutoIncrementing ? "bigserial" : "bigint";
				case SqlDbType.Binary:
					return "bytea";
				case SqlDbType.Bit:
					return "boolean";
				case SqlDbType.Char:
					return string.Format( "char ( {0} )", Size );
				case SqlDbType.Date:
					return "date";
				case SqlDbType.DateTime:
					return "timestamp";
				case SqlDbType.DateTime2:
					return "timestamp";
				case SqlDbType.DateTimeOffset:
					return "timestamp with time zone";
				case SqlDbType.Decimal:
					return "decimal";
				case SqlDbType.Float:
					return "real";
				case SqlDbType.Image:
					return "bytea";
				case SqlDbType.Int:
					return AutoIncrementing ? "serial" : "integer";
				case SqlDbType.Money:
					return "money";
				case SqlDbType.NChar:
					return string.Format( "char ( {0} )", Size );
				case SqlDbType.NText:
					return "text";
				case SqlDbType.NVarChar:
					return Size == ColumnSize.Max ? "text" : string.Format( "varchar ( {0} )", Size );
				case SqlDbType.Real:
					return "double precision";
				case SqlDbType.SmallDateTime:
					return "timestamp";
				case SqlDbType.SmallInt:
					return "smallint";
				case SqlDbType.SmallMoney:
					return "money";
				case SqlDbType.Text:
					return "text";
				case SqlDbType.Time:
					return "time";
				case SqlDbType.TinyInt:
					return "smallint";
				case SqlDbType.UniqueIdentifier:
					return "UUID";
				case SqlDbType.VarBinary:
					return "bytea";
				case SqlDbType.VarChar:
					return Size == ColumnSize.Max ? "text" : string.Format( "varchar ( {0} )", Size );
				case SqlDbType.Xml:
					return "xml";
				default:
					throw new NotSupportedException( string.Format( "SqlDbType '{0}' is not supported.", Type ) );
			}
		}
	}
}