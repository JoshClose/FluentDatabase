using System;
using System.Data;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentDatabase.Tests.SqlServer
{
	[TestClass]
	public class DatabaseTest
	{
		[TestMethod]
		public void Test()
		{
			var fileName = string.Format( "{0}\\{1}.sql", AppDomain.CurrentDomain.BaseDirectory, Guid.NewGuid() );
			using( var stream = File.OpenWrite( fileName ) )
			{
				using( var writer = new StreamWriter( stream ) )
				{
					DatabaseFactory.Create( DatabaseType.SQLServer )
						.WithName( "Business" )
						//.UsingSchema( "Test" )
						.AddTable(
						table => table
						         	.WithName( "Companies" )
						         	.AddColumn(
						         	column => column.WithName( "Id" ).OfType( SqlDbType.Int ).IsAutoIncrementing()
						         	          	.AddConstraint( constraint => constraint.OfType( ConstraintType.NotNull ) )
						         	          	.AddConstraint(
						         	          	constraint => constraint.OfType( ConstraintType.PrimaryKey ).WithName( "PK_Company_Id" ) )
						         	)
						         	.AddColumn(
						         	column => column.WithName( "Name" ).OfType( SqlDbType.NVarChar ).WithSize( 100 )
						         	          	.AddConstraint( constraint => constraint.OfType( ConstraintType.NotNull ) )
						         	)
						)
						.AddTable(
						table => table
						         	.WithName( "Employees" )
						         	.AddColumn(
						         	column => column.WithName( "Id" ).OfType( SqlDbType.Int ).IsAutoIncrementing()
						         	          	.AddConstraint( constraint => constraint.OfType( ConstraintType.NotNull ) )
						         	          	.AddConstraint(
						         	          	constraint => constraint.OfType( ConstraintType.PrimaryKey ).WithName( "PK_Employees_Id" ) )
						         	)
						         	.AddColumn(
						         	column => column.WithName( "CompanyId" ).OfType( SqlDbType.Int )
						         	          	.AddConstraint( constraint => constraint.OfType( ConstraintType.NotNull ) )
						         	          	.AddConstraint(
						         	          	constraint =>
						         	          	constraint.OfType( ConstraintType.ForeignKey ).HasReferenceTo( "Companies", "Id" ) )
						         	)
						         	.AddColumn(
						         	column => column.WithName( "Name" ).OfType( SqlDbType.NVarChar ).WithSize( 50 )
						         	          	.AddConstraint( constraint => constraint.OfType( ConstraintType.NotNull ) )
						         	)
						         	.AddColumn(
						         	column => column.WithName( "Bio" ).OfType( SqlDbType.NVarChar ).WithSize( ColumnSize.Max )
						         	)
						).Write( writer );
				}
			}
		}
	}
}
