using System.IO;

namespace FluentDatabase
{
	public abstract class ConstraintBase : IConstraint
	{
		public string Name { get; set; }
		public ConstraintType Type { get; set; }
		public string Schema { get; set; }
		public string Table { get; set; }
		public string Column { get; set; }
		public string Expression { get; set; }

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
			Table = tableName;
			Column = columnName;
			return this;
		}

		public IConstraint WithExpression( string expression )
		{
			Expression = expression;
			return this;
		}

		public abstract void Write( StreamWriter writer );
	}
}
