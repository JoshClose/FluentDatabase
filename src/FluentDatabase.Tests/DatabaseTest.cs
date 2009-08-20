#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System;
using System.Data;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentDatabase.Tests
{
	[TestClass]
	public class DatabaseTest
	{
		[TestMethod]
		public void Test()
		{
			foreach( DatabaseType databaseType in Enum.GetValues( typeof( DatabaseType ) ) )
			{
				var fileName = string.Format( "{0}\\{1}.sql", AppDomain.CurrentDomain.BaseDirectory, databaseType );
				using( var stream = File.OpenWrite( fileName ) )
				{
					using( var writer = new StreamWriter( stream ) )
					{
						DatabaseFactory.Create( databaseType )
							.WithName( "Business" )
							.UsingSchema( "Test" )
							.HasTable(
							table => table
							         	.WithName( "Companies" )
							         	.HasColumn(
							         	column => column.WithName( "Id" ).OfType( SqlDbType.Int ).IsAutoIncrementing()
							         	          	.HasConstraint( constraint => constraint.OfType( ConstraintType.NotNull ) )
							         	          	.HasConstraint(
							         	          	constraint => constraint.OfType( ConstraintType.PrimaryKey ).WithName( "PK_Companies_Id" ) )
							         	)
							         	.HasColumn(
							         	column => column.WithName( "Name" ).OfType( SqlDbType.NVarChar, 100 )
							         	          	.HasConstraint( constraint => constraint.OfType( ConstraintType.NotNull ) )
							         	)
							)
							.HasTable(
							table => table
							         	.WithName( "Employees" )
							         	.HasColumn(
							         	column => column.WithName( "Id" ).OfType( SqlDbType.Int ).IsAutoIncrementing()
							         	          	.HasConstraint( constraint => constraint.OfType( ConstraintType.NotNull ) )
							         	          	.HasConstraint(
							         	          	constraint => constraint.OfType( ConstraintType.PrimaryKey ).WithName( "PK_Employees_Id" ) )
							         	)
							         	.HasColumn(
							         	column => column.WithName( "CompanyId" ).OfType( SqlDbType.Int )
							         	          	.HasConstraint( constraint => constraint.OfType( ConstraintType.NotNull ) )
							         	          	.HasConstraint(
							         	          	constraint =>
							         	          	constraint.WithName( "FK_Employees_CompanyId" ).OfType( ConstraintType.ForeignKey ).HasReferenceTo( "Companies", "Id" ) )
							         	)
							         	.HasColumn(
							         	column => column.WithName( "Name" ).OfType( SqlDbType.NVarChar, 50 )
							         	          	.HasConstraint( constraint => constraint.OfType( ConstraintType.NotNull ) )
							         	)
							         	.HasColumn(
							         	column => column.WithName( "Bio" ).OfType( SqlDbType.NVarChar, ColumnSize.Max )
							         	)
							).Write( writer );
					}
				}
			}
		}
	}
}