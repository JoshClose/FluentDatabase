using System;
using System.Collections.Generic;

namespace FluentDatabase
{
	public abstract class TableBase : ITable
	{
		protected string Name { get; private set; }
		protected List<IColumn> Columns { get; private set; }

		protected TableBase()
		{
			Columns = new List<IColumn>();
		}

		public ITable WithName( string name )
		{
			Name = name;
			return this;
		}

		public ITable AddColumn( Action<IColumn> column )
		{
			var newColumn = CreateColumn();
			column.Invoke( newColumn );
			Columns.Add( newColumn );
			return this;
		}

		protected abstract IColumn CreateColumn();
	}
}
