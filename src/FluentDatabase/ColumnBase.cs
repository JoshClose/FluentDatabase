using System;
using System.Collections.Generic;
using System.Data;

namespace FluentDatabase
{
	public abstract class ColumnBase : IColumn
	{
		protected string Name { get; private set; }
		protected SqlDbType Type { get; private set; }
		protected bool AutoIncrementing { get; private set; }
		protected List<IConstraint> Constraints { get; private set; }

		protected ColumnBase()
		{
			Constraints = new List<IConstraint>();
		}

		public IColumn WithName( string name )
		{
			Name = name;
			return this;
		}

		public IColumn OfType( SqlDbType type )
		{
			Type = type;
			return this;
		}

		public IColumn IsAutoIncrementing()
		{
			AutoIncrementing = true;
			return this;
		}

        public IColumn AddConstraint( Action<IConstraint> constraint )
        {
        	var newConstraint = CreateConstraint();
        	constraint.Invoke( newConstraint );
        	Constraints.Add( newConstraint );
			return this;
        }

		protected abstract IConstraint CreateConstraint();
	}
}
