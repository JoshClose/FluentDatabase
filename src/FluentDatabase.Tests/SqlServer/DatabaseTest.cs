using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentDatabase.Tests.SqlServer
{
	[TestClass]
	public class DatabaseTest
	{
		[TestMethod]
		public void Test()
		{
			DatabaseFactory.Create( DatabaseType.SQLServer )
				.WithName( "Database1" )
				.UseSchema( "Schema1" )

				.AddTable(
				table => table
				         	.WithName( "Table1" )
				         	.AddColumn(
				         	column => column
				         	          	.WithName( "column1" )
				         	          	.OfType( SqlDbType.Int )
				         	          	.AddConstraint( constraint => constraint.OfType( ConstraintType.NotNull ) )
				         	          	.AddConstraint(
				         	          	constraint => constraint.WithName( "PK_Table1_Column1" ).OfType( ConstraintType.PrimaryKey ) )
				         	          	.IsAutoIncrementing()
				         	)
				         	.AddColumn(
				         	column => column
				         	          	.WithName( "column2" )
				         	          	.OfType( SqlDbType.NVarChar )
				         	          	.AddConstraint( constraint => constraint.OfType( ConstraintType.NotNull ) )
				         	)
				);
		}
	}
}
