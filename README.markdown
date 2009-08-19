FluentDatabase allow you to create databases like this:

<code>
DatabaseFactory.Create( databaseType )
	.WithName( "Business" )
	.UsingSchema( "Test" )
	.AddTable( table => table
		.WithName( "Companies" )
		.AddColumn( column => column.WithName( "Id" ).OfType( SqlDbType.Int ).IsAutoIncrementing()
			.AddConstraint( constraint => constraint.OfType( ConstraintType.NotNull ) )
			.AddConstraint( constraint => constraint.OfType( ConstraintType.PrimaryKey ).WithName( "PK_Company_Id" ) )
		)
		.AddColumn( column => column.WithName( "Name" ).OfType( SqlDbType.NVarChar, 100 )
			.AddConstraint( constraint => constraint.OfType( ConstraintType.NotNull ) )
		)
	)
	.AddTable( table => table
		.WithName( "Employees" )
		.AddColumn( column => column.WithName( "Id" ).OfType( SqlDbType.Int ).IsAutoIncrementing()
			.AddConstraint( constraint => constraint.OfType( ConstraintType.NotNull ) )
			.AddConstraint( constraint => constraint.OfType( ConstraintType.PrimaryKey ).WithName( "PK_Employees_Id" ) )
		)
		.AddColumn( column => column.WithName( "CompanyId" ).OfType( SqlDbType.Int )
			.AddConstraint( constraint => constraint.OfType( ConstraintType.NotNull ) )
			.AddConstraint( constraint => constraint.OfType( ConstraintType.ForeignKey ).HasReferenceTo( "Companies", "Id" ) )
		)
		.AddColumn( column => column.WithName( "Name" ).OfType( SqlDbType.NVarChar, 50 )
			.AddConstraint( constraint => constraint.OfType( ConstraintType.NotNull ) )
		)
		.AddColumn( column => column.WithName( "Bio" ).OfType( SqlDbType.NVarChar, ColumnSize.Max )
	)
).Write( writer );
</code>

Which will create the script:

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
