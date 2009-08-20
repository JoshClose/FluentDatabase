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
	/// PostgreSQL constraint.
	/// </summary>
	public class Constraint : ConstraintBase
	{
		public override void Write( StreamWriter writer )
		{
			if( Type != ConstraintType.NotNull && !string.IsNullOrEmpty( Name ) )
			{
				writer.Write( string.Format( " CONSTRAINT {0}", Name ) );
			}
			writer.Write( string.Format( " {0}", GetConstraintType() ) );
		}

		private string GetConstraintType()
		{
			switch( Type )
			{
				case ConstraintType.Check:
					return string.Format( "CHECK {0}", Expression );
				case ConstraintType.ForeignKey:
					var schema = string.IsNullOrEmpty( Schema ) ? string.Empty : string.Format( "{0}.", Schema );
					return string.Format( "FOREIGN KEY REFERENCES {0}{1} ( {2} )", schema, Table, Column );
				case ConstraintType.NotNull:
					return "NOT NULL";
				case ConstraintType.PrimaryKey:
					return "PRIMARY KEY";
				case ConstraintType.Unique:
					return "UNIQUE";
				default:
					throw new FluentDatabasePostgreSqlException( Resource.ConstraintNotSupportedErrorMessage );
			}
		}
	}
}