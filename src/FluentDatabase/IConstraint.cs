#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System.IO;

namespace FluentDatabase
{
	/// <summary>
	/// Template for a constraint.
	/// </summary>
	public interface IConstraint
	{
		/// <summary>
		/// Sets the name of the constraint.
		/// </summary>
		/// <param name="name">The name of the constraint.</param>
		IConstraint WithName( string name );

		/// <summary>
		/// Sets the name of the schema.
		/// </summary>
		/// <param name="schema">The schema.</param>
		IConstraint UsingSchema( string schema );

		/// <summary>
		/// Set the type of the constraint.
		/// </summary>
		/// <param name="type"></param>
		IConstraint OfType( ConstraintType type );

		/// <summary>
		/// Set the foreign key reference information of the constraint.
		/// Used with <see cref="ConstraintType.ForeignKey"/>.
		/// </summary>
		/// <param name="tableName">The name of the table the foreign key constraint is referencing.</param>
		/// <param name="columnName">The name of the column in the table the foreign key constraint is referencing.</param>
		IConstraint HasReferenceTo( string tableName, string columnName );

		/// <summary>
		/// Sets the check expression of the constraint.
		/// Used with <see cref="ConstraintType.Check"/>.
		/// </summary>
		/// <param name="expression">The check constraint expression.</param>
		IConstraint WithExpression( string expression );

		/// <summary>
		/// Writes the constraint to writer.
		/// </summary>
		/// <param name="writer">The writer.</param>
		void Write( StreamWriter writer );
	}
}
