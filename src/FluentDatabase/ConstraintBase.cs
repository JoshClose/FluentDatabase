namespace FluentDatabase
{
	public abstract class ConstraintBase : IConstraint
	{
		protected string Name { get; private set; }
		protected ConstraintType Type { get; private set; }
		protected string TableName { get; private set; }
		protected string ColumnName { get; private set; }
		protected string Expression { get; private set; }

		public IConstraint WithName( string name )
		{
			Name = name;
			return this;
		}

		public IConstraint OfType( ConstraintType type )
		{
			Type = type;
			return this;
		}

		public IConstraint HasReferenceTo( string tableName, string columnName )
		{
			TableName = tableName;
			ColumnName = columnName;
			return this;
		}

		public IConstraint WithExpression( string expression )
		{
			Expression = expression;
			return this;
		}
	}
}
