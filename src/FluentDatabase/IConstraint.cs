namespace FluentDatabase
{
	/// <summary>
	/// Template for a constraint.
	/// </summary>
	public interface IConstraint
	{
		/// <summary>
		/// Set the name of the constraint.
		/// </summary>
		/// <param name="name">The name of the constraint.</param>
		/// <returns></returns>
		IConstraint WithName( string name );

		/// <summary>
		/// Set the type of the constraint.
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		IConstraint OfType( ConstraintType type );

		/// <summary>
		/// Set the foreign key reference information of the constraint.
		/// Used with <see cref="ConstraintType.ForeignKey"/>.
		/// </summary>
		/// <param name="tableName">The name of the table the foreign key constraint is referencing.</param>
		/// <param name="columnName">The name of the column in the table the foreign key constraint is referencing.</param>
		/// <returns>The constraint.</returns>
		IConstraint HasReferenceTo( string tableName, string columnName );

		/// <summary>
		/// Set the check expression of the constraint.
		/// Used with <see cref="ConstraintType.Check"/>.
		/// </summary>
		/// <param name="expression">The check constraint expression.</param>
		/// <returns>The constraint.</returns>
		IConstraint WithExpression( string expression );
	}
}
