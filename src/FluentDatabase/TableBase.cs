#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System;
using System.Collections.Generic;
using System.IO;

namespace FluentDatabase
{
	/// <summary>
	/// Base class for creating a table. Use this instead
	/// of implementing <see cref="ITable"/> directly.
	/// </summary>
	public abstract class TableBase : ITable
	{
		private bool isSchemaFinal;

		protected string Schema { get; set; }
		protected string Name { get; set; }
		protected List<IColumn> Columns { get; set; }

		protected abstract void WriteTableBegin( StreamWriter writer );
		protected abstract void WriteTableEnd( StreamWriter writer );

		protected TableBase()
		{
			Columns = new List<IColumn>();
		}

		public ITable WithName( string name )
		{
			Name = name;
			return this;
		}

		public ITable UsingSchema( string schema )
		{
			if( !isSchemaFinal )
			{
				Schema = schema;
			}
			return this;
		}

		public ITable UsingSchema( string schema, bool isFinal )
		{
			isSchemaFinal = isFinal;
			Schema = schema;
			return this;
		}

		public ITable HasColumn( Action<IColumn> column )
		{
			var newColumn = CreateColumn();
			column.Invoke( newColumn );
			Columns.Add( newColumn );
			return this;
		}

		protected abstract IColumn CreateColumn();

		public void Write( StreamWriter writer )
		{
			WriteTableBegin( writer );
			for( var i = 0; i < Columns.Count; i++ )
			{
				var column = Columns[i];
				column.UsingSchema( Schema );
				column.Write( writer );
				if( i + 1 < Columns.Count )
				{
					writer.WriteLine( "," );
				}
				else
				{
					writer.WriteLine();
				}
			}
			WriteTableEnd( writer );
		}
	}
}
