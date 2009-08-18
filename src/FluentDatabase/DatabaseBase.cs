using System;
using System.Collections.Generic;

namespace FluentDatabase
{
	public abstract class DatabaseBase : IDatabase
	{
		protected string Name { get; private set; }
		protected string Schema { get; private set; }
		protected List<ITable> Tables { get; private set; }

		protected DatabaseBase()
		{
			Tables = new List<ITable>();
		}

		public IDatabase WithName( string name )
		{
			Name = name;
			return this;
		}

		public IDatabase UseSchema( string schema )
		{
			Schema = schema;
			return this;
		}

		public IDatabase AddTable( Action<ITable> table )
		{
			var newTable = CreateTable();
			table.Invoke( newTable );
			Tables.Add( newTable );
			return this;
		}

		protected abstract ITable CreateTable();
	}
}
