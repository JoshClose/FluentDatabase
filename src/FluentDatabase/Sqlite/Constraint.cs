#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System.IO;

namespace FluentDatabase.Sqlite
{
	/// <summary>
	/// SQLite constraint.
	/// </summary>
	public class Constraint : ConstraintBase
	{
		public override void Write( StreamWriter writer )
		{
			writer.Write( GetConstraintType() );
		}

		private string GetConstraintType()
		{
			switch( Type )
			{
				case ConstraintType.Check:
					return string.Format( " CHECK {0}", Expression );
				case ConstraintType.ForeignKey:
					return string.Empty;
				case ConstraintType.NotNull:
					return " NOT NULL";
				case ConstraintType.PrimaryKey:
					return " PRIMARY KEY";
				case ConstraintType.Unique:
					return " UNIQUE";
				default:
					throw new FluentDatabaseSqliteException( string.Format( Resource.ConstraintNotSupportedErrorMessage, Type ) );
			}
		}
	}
}
