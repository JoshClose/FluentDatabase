#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System;
using System.Data;
using System.IO;

namespace FluentDatabase.SqlServer
{
	public class Column : ColumnBase
	{
		protected override IConstraint CreateConstraint()
		{
			return new Constraint();
		}

		protected override void WriteColumnBegin( StreamWriter writer )
		{
			writer.Write( string.Format( "\t[{0}]", Name ) );
			writer.Write( string.Format( " {0}", GetSqlDbType() ) );
			if( AutoIncrementing )
			{
				writer.Write( " IDENTITY" );
			}
		}

		protected override void WriteColumnEnd( StreamWriter writer )
		{
			writer.WriteLine( "," );
		}

		private string GetSqlDbType()
		{
			switch( Type )
			{
				case SqlDbType.BigInt:
					return "BIGINT";
				case SqlDbType.Binary:
					return string.Format( "BINARY ( {0} )", Size );
				case SqlDbType.Bit:
					return "BIT";
				case SqlDbType.Char:
					return string.Format( "CHAR ( {0} )", Size );
				case SqlDbType.Date:
					return "DATE";
				case SqlDbType.DateTime:
					return "DATETIME";
				case SqlDbType.DateTime2:
					return "DATETIME2";
				case SqlDbType.DateTimeOffset:
					return "DATETIMEOFFSET";
				case SqlDbType.Decimal:
					return "DECIMAL";
				case SqlDbType.Float:
					return "FLOAT";
				case SqlDbType.Image:
					return "IMAGE";
				case SqlDbType.Int:
					return "INT";
				case SqlDbType.Money:
					return "MONEY";
				case SqlDbType.NChar:
					return string.Format( "NCHAR ( {0} )", Size );
				case SqlDbType.NText:
					return "NTEXT";
				case SqlDbType.NVarChar:
					return string.Format( "NVARCHAR ( {0} )", Size == ColumnSize.Max ? "MAX" : Size.ToString() );
				case SqlDbType.Real:
					return "REAL";
				case SqlDbType.SmallDateTime:
					return "SMALLDATETIME";
				case SqlDbType.SmallInt:
					return "SMALLINT";
				case SqlDbType.SmallMoney:
					return "SMALLMONEY";
				case SqlDbType.Text:
					return "TEXT";
				case SqlDbType.Time:
					return "TIME";
				case SqlDbType.TinyInt:
					return "TINYINT";
				case SqlDbType.UniqueIdentifier:
					return "UNIQUEIDENTIFIER";
				case SqlDbType.VarBinary:
					return string.Format( "VARBINARY ( {0} )", Size == ColumnSize.Max ? "MAX" : Size.ToString() );
				case SqlDbType.VarChar:
					return string.Format( "VARCHAR ( {0} )", Size == ColumnSize.Max ? "MAX" : Size.ToString() );
				case SqlDbType.Variant:
					return "SQL_VARIANT";
				case SqlDbType.Xml:
					return "XML";
				default:
					throw new NotSupportedException( string.Format( "SqlDbType '{0}' is not supported.", Type ) );
			}
		}
	}
}
