FluentDatabase is a library to create fluently create a number of different database types.

Currently supported databases are:

- Access
- Firebird
- MySQL
- Oracle
- PostgreSQL
- SQLite
- SQLServer

Example:

<pre>
<code>
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
</code>
</pre>

Creates the script:

<pre>
<code>
USE [Business]

CREATE TABLE [Test].[Companies]
(
	[Id] INT IDENTITY NOT NULL CONSTRAINT [PK_Companies_Id] PRIMARY KEY,
	[Name] NVARCHAR ( 100 ) NOT NULL,
)

CREATE TABLE [Test].[Employees]
(
	[Id] INT IDENTITY NOT NULL CONSTRAINT [PK_Employees_Id] PRIMARY KEY,
	[CompanyId] INT NOT NULL CONSTRAINT [FK_Employees_CompanyId] FOREIGN KEY REFERENCES [Test].[Companies] ( [Id] ),
	[Name] NVARCHAR ( 50 ) NOT NULL,
	[Bio] NVARCHAR ( MAX ),
)
</code>
</pre>
